namespace ImeijiQueue
{
    partial class Form1
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
            this.gbxPixivRet = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxPHPSESSID = new System.Windows.Forms.TextBox();
            this.btnPixivRetGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxImageID = new System.Windows.Forms.TextBox();
            this.gbxTumblrPost = new System.Windows.Forms.GroupBox();
            this.btnTumblrPostGo = new System.Windows.Forms.Button();
            this.tbxTumblrTags = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTumblrCaption = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picbxTheImage = new System.Windows.Forms.PictureBox();
            this.btnOpenTSLManager = new System.Windows.Forms.Button();
            this.btnAccountManager = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.gbxPixivRet.SuspendLayout();
            this.gbxTumblrPost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxTheImage)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxPixivRet
            // 
            this.gbxPixivRet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxPixivRet.Controls.Add(this.label5);
            this.gbxPixivRet.Controls.Add(this.tbxPHPSESSID);
            this.gbxPixivRet.Controls.Add(this.btnPixivRetGo);
            this.gbxPixivRet.Controls.Add(this.label1);
            this.gbxPixivRet.Controls.Add(this.tbxImageID);
            this.gbxPixivRet.Location = new System.Drawing.Point(12, 12);
            this.gbxPixivRet.Name = "gbxPixivRet";
            this.gbxPixivRet.Size = new System.Drawing.Size(220, 115);
            this.gbxPixivRet.TabIndex = 0;
            this.gbxPixivRet.TabStop = false;
            this.gbxPixivRet.Text = "Pixiv Retrieval";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pixiv PHPSESSID";
            // 
            // tbxPHPSESSID
            // 
            this.tbxPHPSESSID.Location = new System.Drawing.Point(7, 89);
            this.tbxPHPSESSID.Name = "tbxPHPSESSID";
            this.tbxPHPSESSID.Size = new System.Drawing.Size(207, 20);
            this.tbxPHPSESSID.TabIndex = 3;
            this.tbxPHPSESSID.TextChanged += new System.EventHandler(this.tbxPHPSESSID_TextChanged);
            // 
            // btnPixivRetGo
            // 
            this.btnPixivRetGo.Location = new System.Drawing.Point(10, 43);
            this.btnPixivRetGo.Name = "btnPixivRetGo";
            this.btnPixivRetGo.Size = new System.Drawing.Size(204, 23);
            this.btnPixivRetGo.TabIndex = 2;
            this.btnPixivRetGo.Text = "Get!";
            this.btnPixivRetGo.UseVisualStyleBackColor = true;
            this.btnPixivRetGo.Click += new System.EventHandler(this.btnPixivRetGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pixiv Image ID";
            // 
            // tbxImageID
            // 
            this.tbxImageID.Location = new System.Drawing.Point(88, 17);
            this.tbxImageID.Name = "tbxImageID";
            this.tbxImageID.Size = new System.Drawing.Size(126, 20);
            this.tbxImageID.TabIndex = 0;
            // 
            // gbxTumblrPost
            // 
            this.gbxTumblrPost.Controls.Add(this.btnTumblrPostGo);
            this.gbxTumblrPost.Controls.Add(this.tbxTumblrTags);
            this.gbxTumblrPost.Controls.Add(this.label3);
            this.gbxTumblrPost.Controls.Add(this.tbxTumblrCaption);
            this.gbxTumblrPost.Controls.Add(this.label2);
            this.gbxTumblrPost.Location = new System.Drawing.Point(13, 133);
            this.gbxTumblrPost.Name = "gbxTumblrPost";
            this.gbxTumblrPost.Size = new System.Drawing.Size(220, 282);
            this.gbxTumblrPost.TabIndex = 1;
            this.gbxTumblrPost.TabStop = false;
            this.gbxTumblrPost.Text = "Tumblr Post";
            // 
            // btnTumblrPostGo
            // 
            this.btnTumblrPostGo.Location = new System.Drawing.Point(6, 253);
            this.btnTumblrPostGo.Name = "btnTumblrPostGo";
            this.btnTumblrPostGo.Size = new System.Drawing.Size(208, 23);
            this.btnTumblrPostGo.TabIndex = 4;
            this.btnTumblrPostGo.Text = "Queue!";
            this.btnTumblrPostGo.UseVisualStyleBackColor = true;
            this.btnTumblrPostGo.Click += new System.EventHandler(this.btnTumblrPostGo_Click);
            // 
            // tbxTumblrTags
            // 
            this.tbxTumblrTags.AcceptsReturn = true;
            this.tbxTumblrTags.AllowDrop = true;
            this.tbxTumblrTags.Location = new System.Drawing.Point(7, 73);
            this.tbxTumblrTags.Multiline = true;
            this.tbxTumblrTags.Name = "tbxTumblrTags";
            this.tbxTumblrTags.Size = new System.Drawing.Size(207, 175);
            this.tbxTumblrTags.TabIndex = 3;
            this.tbxTumblrTags.TextChanged += new System.EventHandler(this.tbxTumblrTags_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tags (one per line)";
            // 
            // tbxTumblrCaption
            // 
            this.tbxTumblrCaption.Location = new System.Drawing.Point(7, 33);
            this.tbxTumblrCaption.Name = "tbxTumblrCaption";
            this.tbxTumblrCaption.Size = new System.Drawing.Size(207, 20);
            this.tbxTumblrCaption.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Caption";
            // 
            // picbxTheImage
            // 
            this.picbxTheImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picbxTheImage.Location = new System.Drawing.Point(239, 13);
            this.picbxTheImage.Name = "picbxTheImage";
            this.picbxTheImage.Size = new System.Drawing.Size(493, 368);
            this.picbxTheImage.TabIndex = 2;
            this.picbxTheImage.TabStop = false;
            this.picbxTheImage.Click += new System.EventHandler(this.picbxTheImage_Click);
            // 
            // btnOpenTSLManager
            // 
            this.btnOpenTSLManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenTSLManager.Location = new System.Drawing.Point(239, 393);
            this.btnOpenTSLManager.Name = "btnOpenTSLManager";
            this.btnOpenTSLManager.Size = new System.Drawing.Size(192, 23);
            this.btnOpenTSLManager.TabIndex = 3;
            this.btnOpenTSLManager.Text = "Manage Tag Suggestion Library";
            this.btnOpenTSLManager.UseVisualStyleBackColor = true;
            this.btnOpenTSLManager.Click += new System.EventHandler(this.btnOpenTSLManager_Click);
            // 
            // btnAccountManager
            // 
            this.btnAccountManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccountManager.Location = new System.Drawing.Point(436, 393);
            this.btnAccountManager.Name = "btnAccountManager";
            this.btnAccountManager.Size = new System.Drawing.Size(197, 23);
            this.btnAccountManager.TabIndex = 4;
            this.btnAccountManager.Text = "Manage Accounts";
            this.btnAccountManager.UseVisualStyleBackColor = true;
            this.btnAccountManager.Click += new System.EventHandler(this.btnAccountManager_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(640, 391);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(92, 23);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 428);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnAccountManager);
            this.Controls.Add(this.btnOpenTSLManager);
            this.Controls.Add(this.picbxTheImage);
            this.Controls.Add(this.gbxTumblrPost);
            this.Controls.Add(this.gbxPixivRet);
            this.Name = "Form1";
            this.Text = "ImeijiQueue V.1.0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxPixivRet.ResumeLayout(false);
            this.gbxPixivRet.PerformLayout();
            this.gbxTumblrPost.ResumeLayout(false);
            this.gbxTumblrPost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbxTheImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPixivRet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxImageID;
        private System.Windows.Forms.Button btnPixivRetGo;
        private System.Windows.Forms.GroupBox gbxTumblrPost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxTumblrCaption;
        private System.Windows.Forms.Button btnTumblrPostGo;
        private System.Windows.Forms.TextBox tbxTumblrTags;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picbxTheImage;
        private System.Windows.Forms.Button btnOpenTSLManager;
        private System.Windows.Forms.Button btnAccountManager;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxPHPSESSID;
        private System.Windows.Forms.Button btnHelp;

    }
}

