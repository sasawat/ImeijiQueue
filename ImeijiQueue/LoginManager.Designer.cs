namespace ImeijiQueue
{
    partial class LoginManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxToken = new System.Windows.Forms.TextBox();
            this.tbxTokenSecret = new System.Windows.Forms.TextBox();
            this.btnRequestToken = new System.Windows.Forms.Button();
            this.webthing = new System.Windows.Forms.WebBrowser();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.btnAccessToken = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tbxBlagName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Secret";
            // 
            // tbxToken
            // 
            this.tbxToken.Location = new System.Drawing.Point(58, 13);
            this.tbxToken.Name = "tbxToken";
            this.tbxToken.Size = new System.Drawing.Size(512, 20);
            this.tbxToken.TabIndex = 2;
            // 
            // tbxTokenSecret
            // 
            this.tbxTokenSecret.Location = new System.Drawing.Point(58, 40);
            this.tbxTokenSecret.Name = "tbxTokenSecret";
            this.tbxTokenSecret.Size = new System.Drawing.Size(512, 20);
            this.tbxTokenSecret.TabIndex = 3;
            // 
            // btnRequestToken
            // 
            this.btnRequestToken.Location = new System.Drawing.Point(576, 12);
            this.btnRequestToken.Name = "btnRequestToken";
            this.btnRequestToken.Size = new System.Drawing.Size(107, 23);
            this.btnRequestToken.TabIndex = 4;
            this.btnRequestToken.Text = "Request Token (1)";
            this.btnRequestToken.UseVisualStyleBackColor = true;
            this.btnRequestToken.Click += new System.EventHandler(this.btnRequestToken_Click);
            // 
            // webthing
            // 
            this.webthing.AllowWebBrowserDrop = false;
            this.webthing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webthing.IsWebBrowserContextMenuEnabled = false;
            this.webthing.Location = new System.Drawing.Point(17, 66);
            this.webthing.MinimumSize = new System.Drawing.Size(20, 20);
            this.webthing.Name = "webthing";
            this.webthing.Size = new System.Drawing.Size(921, 371);
            this.webthing.TabIndex = 5;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(689, 12);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(101, 23);
            this.btnAuthorize.TabIndex = 6;
            this.btnAuthorize.Text = "Go Authorize (2)";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // btnAccessToken
            // 
            this.btnAccessToken.Location = new System.Drawing.Point(796, 13);
            this.btnAccessToken.Name = "btnAccessToken";
            this.btnAccessToken.Size = new System.Drawing.Size(142, 23);
            this.btnAccessToken.TabIndex = 7;
            this.btnAccessToken.Text = "Verify Access Token (3)";
            this.btnAccessToken.UseVisualStyleBackColor = true;
            this.btnAccessToken.Click += new System.EventHandler(this.btnAccessToken_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(796, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Save and Close (FINAL)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tbxBlagName
            // 
            this.tbxBlagName.Location = new System.Drawing.Point(611, 40);
            this.tbxBlagName.Name = "tbxBlagName";
            this.tbxBlagName.Size = new System.Drawing.Size(179, 20);
            this.tbxBlagName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Blog";
            // 
            // LoginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 449);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxBlagName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAccessToken);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.webthing);
            this.Controls.Add(this.btnRequestToken);
            this.Controls.Add(this.tbxTokenSecret);
            this.Controls.Add(this.tbxToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginManager";
            this.Text = "LoginManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxToken;
        private System.Windows.Forms.TextBox tbxTokenSecret;
        private System.Windows.Forms.Button btnRequestToken;
        private System.Windows.Forms.WebBrowser webthing;
        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.Button btnAccessToken;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbxBlagName;
        private System.Windows.Forms.Label label3;

    }
}