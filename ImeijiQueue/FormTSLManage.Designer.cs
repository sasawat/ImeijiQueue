namespace ImeijiQueue
{
    partial class FormTSLManage
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
            this.lbxTagIf = new System.Windows.Forms.ListBox();
            this.tbxTagsThen = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddTagIf = new System.Windows.Forms.Button();
            this.tbxNewTag = new System.Windows.Forms.TextBox();
            this.btnRmTagIf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxTagIf
            // 
            this.lbxTagIf.FormattingEnabled = true;
            this.lbxTagIf.Location = new System.Drawing.Point(13, 13);
            this.lbxTagIf.Name = "lbxTagIf";
            this.lbxTagIf.Size = new System.Drawing.Size(221, 225);
            this.lbxTagIf.TabIndex = 0;
            this.lbxTagIf.SelectedIndexChanged += new System.EventHandler(this.lbxTagIf_SelectedIndexChanged);
            // 
            // tbxTagsThen
            // 
            this.tbxTagsThen.AcceptsReturn = true;
            this.tbxTagsThen.Location = new System.Drawing.Point(241, 13);
            this.tbxTagsThen.Multiline = true;
            this.tbxTagsThen.Name = "tbxTagsThen";
            this.tbxTagsThen.Size = new System.Drawing.Size(239, 316);
            this.tbxTagsThen.TabIndex = 1;
            this.tbxTagsThen.TextChanged += new System.EventHandler(this.tbxTagsThen_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(487, 13);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(211, 23);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import TSL Dictionary";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(487, 43);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(211, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export TSL Dictionary";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(487, 73);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(211, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Commit To File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(487, 103);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(211, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Undo Changes";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(487, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(211, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddTagIf
            // 
            this.btnAddTagIf.Location = new System.Drawing.Point(12, 299);
            this.btnAddTagIf.Name = "btnAddTagIf";
            this.btnAddTagIf.Size = new System.Drawing.Size(222, 23);
            this.btnAddTagIf.TabIndex = 7;
            this.btnAddTagIf.Text = "Add Tag";
            this.btnAddTagIf.UseVisualStyleBackColor = true;
            this.btnAddTagIf.Click += new System.EventHandler(this.btnAddTagIf_Click);
            // 
            // tbxNewTag
            // 
            this.tbxNewTag.Location = new System.Drawing.Point(12, 273);
            this.tbxNewTag.Name = "tbxNewTag";
            this.tbxNewTag.Size = new System.Drawing.Size(222, 20);
            this.tbxNewTag.TabIndex = 8;
            // 
            // btnRmTagIf
            // 
            this.btnRmTagIf.Location = new System.Drawing.Point(13, 244);
            this.btnRmTagIf.Name = "btnRmTagIf";
            this.btnRmTagIf.Size = new System.Drawing.Size(221, 23);
            this.btnRmTagIf.TabIndex = 9;
            this.btnRmTagIf.Text = "Remove Selected Tag";
            this.btnRmTagIf.UseVisualStyleBackColor = true;
            this.btnRmTagIf.Click += new System.EventHandler(this.btnRmTagIf_Click);
            // 
            // FormTSLManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 339);
            this.Controls.Add(this.btnRmTagIf);
            this.Controls.Add(this.tbxNewTag);
            this.Controls.Add(this.btnAddTagIf);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.tbxTagsThen);
            this.Controls.Add(this.lbxTagIf);
            this.Name = "FormTSLManage";
            this.Text = "TagSuggestionLibrary Manager";
            this.Load += new System.EventHandler(this.FormTSLManage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxTagIf;
        private System.Windows.Forms.TextBox tbxTagsThen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddTagIf;
        private System.Windows.Forms.TextBox tbxNewTag;
        private System.Windows.Forms.Button btnRmTagIf;
    }
}