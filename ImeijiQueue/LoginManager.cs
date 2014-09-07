using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ImeijiQueue
{
    public partial class LoginManager : Form
    {

        FuckingOAuthLogin currentLogin;

        public LoginManager()
        {
            InitializeComponent();
        }

        private void btnRequestToken_Click(object sender, EventArgs e)
        {
            currentLogin = FuckingOAuthLogin.getToken("scKZ3jbMMZ08sDLFf4Ceg9njAGMX3XYDnDN6ma0eFMGJ64e1xf", "CMovNXhiReAHKA1JTU7DhME1FXwf0mx0MkzUdBqwYJnyFx5Z1R");
            tbxToken.Text = currentLogin.Token;
            tbxTokenSecret.Text = currentLogin.TokenSecret;
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (currentLogin == null) 
            {
                MessageBox.Show("Please get a request token first");
                return;
            }
            webthing.Navigate("http://www.tumblr.com/oauth/authorize?oauth_token=" + currentLogin.Token);
        }

        private void btnAccessToken_Click(object sender, EventArgs e)
        {
            if (currentLogin == null)
            {
                MessageBox.Show("Please get a request token first");
                return;
            }
            //Get the URL of the site the browser is on, hopefully includes the verifier
            String url = webthing.Url.AbsoluteUri;

            //Get the position of the verifier
            int startIndex = url.IndexOf("oauth_verifier=");
            if(startIndex == -1)
            {
                MessageBox.Show("Please authorize the app first");
                return;
            }
            startIndex += 15;
            int length = url.IndexOf("#_") - startIndex;

            //Get the verifier
            String verifier = url.Substring(startIndex, length);

            MessageBox.Show(currentLogin.verifyToken(verifier)? "SUCCESS":"FAILURE");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            currentLogin.BlogName = tbxBlagName.Text;
            Stream river = File.OpenWrite("logindata");
            currentLogin.write(river);
            river.Close();
            Program.loginMain = currentLogin;
            this.Close();
        }
    }
}
