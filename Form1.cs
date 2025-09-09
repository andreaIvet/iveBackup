using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Schema;

namespace IveBackUp
{
    public class bkTreeNode : TreeNode{

        public override string ToString()
        {
            XmlElement e = (XmlElement)Tag;  
            return e.GetAttribute("path") +" escludi {"+ e.GetAttribute("escludi")+"}";
        }

        public string PATH{
            get{
                XmlElement e = (XmlElement)Tag; 
                return e.GetAttribute("path");
            }
        }

        public string estensioni{
            get{
                XmlElement e = (XmlElement)Tag; 
                return e.GetAttribute("escludi");
            }
            set{
                XmlElement e = (XmlElement)Tag;
                e.SetAttribute("escludi",value);
            }
        }
        public bkTreeNode(string path,string esc,XmlDocument doc,ListBox lb) : base(path.Substring(path.LastIndexOf('/')+ 1))
        {
            Checked = false;
            foreach(XmlElement le in doc.DocumentElement.ChildNodes){
                if(le.GetAttribute("path").ToLower() == path.ToLower())
                {
                    Checked = true;
                    Tag = le;
                    lb.Items.Add(this);
                }
            }

            if(!Checked){
                XmlElement e = doc.CreateElement("bkTreeNode");
                //e.SetAttributeNode(doc.CreateAttribute("path")).Value = path.ToLower();
                e.SetAttributeNode(doc.CreateAttribute("path")).Value = path;
                e.SetAttributeNode(doc.CreateAttribute("escludi")).Value = esc;
                Tag = e;
                //string[] sdir = Directory.GetDirectories(path.ToLower());
                string[] sdir = Directory.GetDirectories(path);
                foreach (string d in sdir)
                {
                    DirectoryInfo di = new DirectoryInfo(d);
                    if ((di.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == (FileAttributes)0)
                    {
                        Nodes.Add(new bkTreeNode(d,esc,doc,lb));
                    }
                }
            }
        }
    }


    public partial class Form1 : Form
    {
        XmlDocument doc =new XmlDocument();

        public Form1()
        {
            InitializeComponent();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            if(File.Exists("ListaDir.xml")){
                doc.Load("ListaDir.xml");
                txtoutdir.Text = doc.DocumentElement.GetAttribute("bkdir");
                trBackUp.Nodes.Add(new bkTreeNode(doc.DocumentElement.GetAttribute("root"),doc.DocumentElement.GetAttribute("def_no_ext"),doc,lbldir));                
            }
            else {
                doc.AppendChild(doc.CreateElement("iveBk"));
                doc.DocumentElement.SetAttribute("root",Environment.CurrentDirectory);
                doc.DocumentElement.SetAttribute("bkdir","c:\\bk");
                doc.DocumentElement.SetAttribute("def_no_ext","zip|rar|pdf");
                txtoutdir.Text = ".\\";
                trBackUp.Nodes.Add(new bkTreeNode(Environment.CurrentDirectory,"zip|rar|pdf",doc,lbldir)); 
            }
                                
        }

        private void trBackUp_AfterCheck(object sender, TreeViewEventArgs e)
        {
            bkTreeNode t =(bkTreeNode)e.Node;
            XmlElement ee = (XmlElement)t.Tag;
            if(!t.Checked){
                string[] sdir = Directory.GetDirectories(t.PATH);
                foreach (string d in sdir)
                {
                    DirectoryInfo di = new DirectoryInfo(d);
                    if ((di.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == (FileAttributes)0)
                    {
                        t.Nodes.Add(new bkTreeNode(d,doc.DocumentElement.GetAttribute("def_no_ext"),doc,lbldir));
                    }
                }
                doc.DocumentElement.RemoveChild(ee);
                lbldir.Items.Remove(t);
            }
            else{
                t.Nodes.Clear();
                doc.DocumentElement.AppendChild(ee);
                lbldir.Items.Add(t);
            }          
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            doc.DocumentElement.SetAttribute("root",((bkTreeNode)trBackUp.Nodes[0]).PATH);
            doc.DocumentElement.SetAttribute("bkdir",txtoutdir.Text);
            doc.Save("ListaDir.xml");
        }

        private void CreateFileListZip(string dir,string zipdir,ZipArchive zz,string[] Filtri)
        {
            if (dir.Length > 247) return;
            string[] files = Directory.GetFiles(dir);
            string[] sdir = Directory.GetDirectories(dir); 

            pbar.Minimum = 0;
            pbar.Value = 0;
            pbar.Maximum = files.Length;

            foreach (string f in files)
            {
                bool escludi = false;
                foreach (String ff in Filtri)
                {
                    if (f.EndsWith(ff, StringComparison.OrdinalIgnoreCase))
                    {
                        escludi = true;
                        break;
                    }
                }
                if(!escludi){
                    FileInfo fi =new FileInfo(f);
                    string zzf = zipdir+fi.Name;
                    Console.WriteLine(f+"->"+zzf);
                    FileStream fsi = new FileStream(f, FileMode.Open);
                    ZipArchiveEntry ze =  zz.CreateEntry(zzf);
                    Stream cs = ze.Open();
                    fsi.CopyTo(cs);
                    cs.Close();
                    fsi.Close();
                }
                pbar.Value++;
                Application.DoEvents();
            }

            foreach (string d in sdir)
            {
                DirectoryInfo di = new DirectoryInfo(d);
                CreateFileListZip(d,zipdir+di.Name+"\\", zz, Filtri);
            }           
        }

        private void CreaZip(){
            string outdir = txtoutdir.Text;
            
            foreach (bkTreeNode gg in lbldir.Items)
            {
                String[] Filtri = gg.estensioni.Split('|');                    
                String g = gg.PATH;
                String[] fname = g.Split('/');                       
                string sss = DateTime.Today.Day + "_" + DateTime.Today.Month + "_" + DateTime.Today.Year;
                string fn = outdir + "/" + fname[fname.Length - 1].Replace(' ', '_') + sss + ".zip";
                FileStream fsz = new FileStream(fn, FileMode.Create);
                ZipArchive zz=new ZipArchive(fsz,ZipArchiveMode.Create);
                CreateFileListZip(g, "", zz, Filtri);
                zz.Dispose();
                fsz.Close();
            }
        }

        private void btZip_Click(object sender, EventArgs e)
        {
            CreaZip();
        }

        private void btRadice_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() == DialogResult.OK)
            {
                trBackUp.Nodes.Clear();
                lbldir.Items.Clear();
                doc.DocumentElement.SetAttribute("root",fl.SelectedPath);
                trBackUp.Nodes.Add(new bkTreeNode(fl.SelectedPath,doc.DocumentElement.GetAttribute("def_no_ext"),doc,lbldir));
            }
        }

        private void lbldir_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                bkTreeNode tr = (bkTreeNode)lbldir.Items[e.Index];
                e.Graphics.DrawString(tr.ToString(), Font, Brushes.Black, e.Bounds);
                int x1 = e.Bounds.Right - lbldir.ItemHeight - 2;
                int y1 = e.Bounds.Top;
                e.Graphics.FillRectangle(Brushes.Red, x1, y1, lbldir.ItemHeight, lbldir.ItemHeight);
                Pen pp = new Pen(Brushes.White, 2);
                e.Graphics.DrawLine(pp, x1, y1, x1 + lbldir.ItemHeight, y1 + lbldir.ItemHeight);
                e.Graphics.DrawLine(pp, x1, y1 + lbldir.ItemHeight, x1 + lbldir.ItemHeight, y1);
                pp = new Pen(Brushes.Black, 1);
                e.Graphics.DrawRectangle(pp, x1, y1, lbldir.ItemHeight, lbldir.ItemHeight);
            }

        }

        private void lbldir_MouseClick(object sender, MouseEventArgs e)
        {
            if(lbldir.SelectedItem!=null)
                    if (e.X > lbldir.ClientSize.Width - (lbldir.ItemHeight+2))
            {
                bkTreeNode tr = (bkTreeNode)lbldir.SelectedItem;
                tr.Checked =false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();            
            of.Filter = "xml|*.xml";
            if (of.ShowDialog() == DialogResult.OK)
            {
                doc.Load(of.FileName);
                trBackUp.Nodes.Clear();
                lbldir.Items.Clear();
                trBackUp.Nodes.Add(new bkTreeNode(doc.DocumentElement.GetAttribute("root"),doc.DocumentElement.GetAttribute("def_no_ext"),doc,lbldir));                           
            }
        }

        private void btSalva_Click(object sender, EventArgs e)
        {
            SaveFileDialog of = new SaveFileDialog();
            of.Filter = "xml|*.xml";
            if (of.ShowDialog() == DialogResult.OK)
            {
                doc.DocumentElement.SetAttribute("root",((bkTreeNode)trBackUp.Nodes[0]).PATH);
                doc.DocumentElement.SetAttribute("bkdir",txtoutdir.Text);
                doc.Save(of.FileName);
            }
        }

        private void CercaDir(string dir,int giorni,string est)
        {
            if (dir.Length > 247) return;
            string[] files = Directory.GetFiles(dir);            

            bool find = false;

            foreach (string f in files)
            {
                FileInfo fi = new FileInfo(f);
                if (f.ToUpper().EndsWith(est))
                {
                    if ((DateTime.Today - fi.LastWriteTime).Days < giorni)
                    {
                        XmlElement e = doc.CreateElement("bkTreeNode");
                        //e.SetAttributeNode(doc.CreateAttribute("path")).Value = dir.ToLower();
                        e.SetAttributeNode(doc.CreateAttribute("path")).Value = dir;
                        e.SetAttributeNode(doc.CreateAttribute("escludi")).Value = doc.DocumentElement.GetAttribute("def_no_ext");
                        doc.DocumentElement.AppendChild(e);
                        find = true;
                        break;
                    }
                }
            }
            
            if (!find)
            {
                string[] sdir = Directory.GetDirectories(dir);
                foreach (string d in sdir)
                {                    
                    CercaDir(d, giorni,est);
                }
            }
        }

        private void btricerca_Click(object sender, EventArgs e)
        {
            trBackUp.Nodes.Clear();
            lbldir.Items.Clear();
            while(doc.DocumentElement.ChildNodes.Count>0)doc.DocumentElement.RemoveChild(doc.DocumentElement.FirstChild);
            CercaDir(doc.DocumentElement.GetAttribute("root"), (int)numGiorni.Value,txtEst.Text.ToUpper());
            trBackUp.Nodes.Add(new bkTreeNode(doc.DocumentElement.GetAttribute("root"),doc.DocumentElement.GetAttribute("def_no_ext"),doc,lbldir));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtoutdir.Text = fl.SelectedPath;
            }
        }
    }
}
