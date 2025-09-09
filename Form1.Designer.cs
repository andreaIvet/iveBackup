using System;
using System.Windows.Forms;
using System.Drawing;

namespace IveBackUp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.trBackUp = new System.Windows.Forms.TreeView();
            this.btRadice = new System.Windows.Forms.Button();
            this.btricerca = new System.Windows.Forms.Button();
            this.btZip = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEst = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numGiorni = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.pbar = new System.Windows.Forms.ProgressBar();
            this.btSalva = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbldir = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtoutdir = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiorni)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trBackUp
            // 
            this.trBackUp.CheckBoxes = true;
            this.trBackUp.Location = new System.Drawing.Point(11, 58);
            this.trBackUp.Name = "trBackUp";
            this.trBackUp.Size = new System.Drawing.Size(218, 383);
            this.trBackUp.TabIndex = 0;
            this.trBackUp.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trBackUp_AfterCheck);
            // 
            // btRadice
            // 
            this.btRadice.Location = new System.Drawing.Point(12, 13);
            this.btRadice.Name = "btRadice";
            this.btRadice.Size = new System.Drawing.Size(217, 39);
            this.btRadice.TabIndex = 1;
            this.btRadice.Text = "Seleziona Radice";
            this.btRadice.UseVisualStyleBackColor = true;
            this.btRadice.Click += new System.EventHandler(this.btRadice_Click);
            // 
            // btricerca
            // 
            this.btricerca.Location = new System.Drawing.Point(5, 71);
            this.btricerca.Name = "btricerca";
            this.btricerca.Size = new System.Drawing.Size(132, 39);
            this.btricerca.TabIndex = 2;
            this.btricerca.Text = "Avvia Ricerca";
            this.btricerca.UseVisualStyleBackColor = true;
            this.btricerca.Click += new System.EventHandler(this.btricerca_Click);
            // 
            // btZip
            // 
            this.btZip.Location = new System.Drawing.Point(395, 17);
            this.btZip.Name = "btZip";
            this.btZip.Size = new System.Drawing.Size(105, 38);
            this.btZip.TabIndex = 3;
            this.btZip.Text = "Crea File Compressi";
            this.btZip.UseVisualStyleBackColor = true;
            this.btZip.Click += new System.EventHandler(this.btZip_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEst);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numGiorni);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btricerca);
            this.groupBox1.Location = new System.Drawing.Point(525, 402);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 116);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ricerca";
            // 
            // txtEst
            // 
            this.txtEst.Location = new System.Drawing.Point(6, 45);
            this.txtEst.Name = "txtEst";
            this.txtEst.Size = new System.Drawing.Size(120, 20);
            this.txtEst.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Estensione";
            // 
            // numGiorni
            // 
            this.numGiorni.Location = new System.Drawing.Point(6, 19);
            this.numGiorni.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numGiorni.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numGiorni.Name = "numGiorni";
            this.numGiorni.Size = new System.Drawing.Size(120, 20);
            this.numGiorni.TabIndex = 4;
            this.numGiorni.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Giorni";
            // 
            // pbar
            // 
            this.pbar.Location = new System.Drawing.Point(235, 13);
            this.pbar.Name = "pbar";
            this.pbar.Size = new System.Drawing.Size(487, 23);
            this.pbar.TabIndex = 5;
            // 
            // btSalva
            // 
            this.btSalva.Location = new System.Drawing.Point(381, 382);
            this.btSalva.Name = "btSalva";
            this.btSalva.Size = new System.Drawing.Size(138, 52);
            this.btSalva.TabIndex = 7;
            this.btSalva.Text = "Salva Albero di bkup";
            this.btSalva.UseVisualStyleBackColor = true;
            this.btSalva.Click += new System.EventHandler(this.btSalva_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(235, 382);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(140, 52);
            this.button6.TabIndex = 8;
            this.button6.Text = "Carica Albero di bkup";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(53, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Aggiornamento Albero";
            this.label3.Visible = false;
            // 
            // lbldir
            // 
            this.lbldir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbldir.FormattingEnabled = true;
            this.lbldir.ItemHeight = 15;
            this.lbldir.Location = new System.Drawing.Point(235, 42);
            this.lbldir.Name = "lbldir";
            this.lbldir.Size = new System.Drawing.Size(492, 334);
            this.lbldir.TabIndex = 10;
            this.lbldir.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbldir_DrawItem);
            this.lbldir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbldir_MouseClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 38);
            this.button1.TabIndex = 11;
            this.button1.Text = "Seleziona ZipDir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtoutdir
            // 
            this.txtoutdir.Location = new System.Drawing.Point(23, 27);
            this.txtoutdir.Name = "txtoutdir";
            this.txtoutdir.Size = new System.Drawing.Size(255, 20);
            this.txtoutdir.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtoutdir);
            this.groupBox2.Controls.Add(this.btZip);
            this.groupBox2.Location = new System.Drawing.Point(12, 447);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(507, 71);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zip File";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbldir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbar);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btSalva);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btRadice);
            this.Controls.Add(this.trBackUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "MicroBackUp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGiorni)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TreeView trBackUp;
        private System.Windows.Forms.Button btRadice;
        private System.Windows.Forms.Button btricerca;
        private System.Windows.Forms.Button btZip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numGiorni;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbar;
        private System.Windows.Forms.TextBox txtEst;
        private System.Windows.Forms.Button btSalva;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbldir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtoutdir;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

