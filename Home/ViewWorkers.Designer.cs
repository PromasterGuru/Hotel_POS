namespace Home
{
    partial class ViewWorkers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvworkers = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblrole = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblid = new System.Windows.Forms.Label();
            this.lbltelno = new System.Windows.Forms.Label();
            this.lbluname = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtidno = new System.Windows.Forms.TextBox();
            this.txtuname = new System.Windows.Forms.TextBox();
            this.txttelno = new System.Windows.Forms.TextBox();
            this.cborole = new System.Windows.Forms.ComboBox();
            this.lblmessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvworkers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvworkers
            // 
            this.dgvworkers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvworkers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvworkers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvworkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvworkers.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvworkers.Location = new System.Drawing.Point(1, 21);
            this.dgvworkers.Name = "dgvworkers";
            this.dgvworkers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvworkers.Size = new System.Drawing.Size(628, 176);
            this.dgvworkers.TabIndex = 0;
            this.dgvworkers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvworkers_CellClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(458, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 40);
            this.button2.TabIndex = 2;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblrole
            // 
            this.lblrole.AutoSize = true;
            this.lblrole.Location = new System.Drawing.Point(1, 221);
            this.lblrole.Name = "lblrole";
            this.lblrole.Size = new System.Drawing.Size(29, 13);
            this.lblrole.TabIndex = 3;
            this.lblrole.Text = "Role";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(1, 262);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(32, 13);
            this.lblemail.TabIndex = 4;
            this.lblemail.Text = "Email";
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(-2, 294);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(32, 13);
            this.lblid.TabIndex = 5;
            this.lblid.Text = "IDNo";
            // 
            // lbltelno
            // 
            this.lbltelno.AutoSize = true;
            this.lbltelno.Location = new System.Drawing.Point(1, 330);
            this.lbltelno.Name = "lbltelno";
            this.lbltelno.Size = new System.Drawing.Size(36, 13);
            this.lbltelno.TabIndex = 6;
            this.lbltelno.Text = "TelNo";
            // 
            // lbluname
            // 
            this.lbluname.AutoSize = true;
            this.lbluname.Location = new System.Drawing.Point(1, 374);
            this.lbluname.Name = "lbluname";
            this.lbluname.Size = new System.Drawing.Size(55, 13);
            this.lbluname.TabIndex = 7;
            this.lbluname.Text = "Username";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(76, 248);
            this.txtemail.Multiline = true;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(301, 25);
            this.txtemail.TabIndex = 9;
            // 
            // txtidno
            // 
            this.txtidno.Location = new System.Drawing.Point(76, 284);
            this.txtidno.Multiline = true;
            this.txtidno.Name = "txtidno";
            this.txtidno.Size = new System.Drawing.Size(301, 25);
            this.txtidno.TabIndex = 10;
            // 
            // txtuname
            // 
            this.txtuname.Location = new System.Drawing.Point(76, 362);
            this.txtuname.Multiline = true;
            this.txtuname.Name = "txtuname";
            this.txtuname.Size = new System.Drawing.Size(301, 25);
            this.txtuname.TabIndex = 11;
            // 
            // txttelno
            // 
            this.txttelno.Location = new System.Drawing.Point(76, 325);
            this.txttelno.Multiline = true;
            this.txttelno.Name = "txttelno";
            this.txttelno.Size = new System.Drawing.Size(301, 25);
            this.txttelno.TabIndex = 12;
            // 
            // cborole
            // 
            this.cborole.FormattingEnabled = true;
            this.cborole.Location = new System.Drawing.Point(76, 213);
            this.cborole.Name = "cborole";
            this.cborole.Size = new System.Drawing.Size(132, 21);
            this.cborole.TabIndex = 13;
            // 
            // lblmessage
            // 
            this.lblmessage.AutoSize = true;
            this.lblmessage.Location = new System.Drawing.Point(341, 204);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(0, 13);
            this.lblmessage.TabIndex = 14;
            // 
            // ViewWorkers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 416);
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.cborole);
            this.Controls.Add(this.txttelno);
            this.Controls.Add(this.txtuname);
            this.Controls.Add(this.txtidno);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.lbluname);
            this.Controls.Add(this.lbltelno);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.lblrole);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvworkers);
            this.Name = "ViewWorkers";
            this.Text = "ViewWorkers";
            this.Load += new System.EventHandler(this.ViewWorkers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvworkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvworkers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblrole;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Label lbltelno;
        private System.Windows.Forms.Label lbluname;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtidno;
        private System.Windows.Forms.TextBox txtuname;
        private System.Windows.Forms.TextBox txttelno;
        private System.Windows.Forms.ComboBox cborole;
        private System.Windows.Forms.Label lblmessage;
    }
}