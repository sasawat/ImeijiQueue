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
    public partial class Form1 : Form
    {
        TumblrPost tumblingdown;

        int TumblrTagsLen; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TagSuggestionLibrary Initialization
            if (File.Exists("main.tsl"))
            {
                Stream filereadstream = File.OpenRead("main.tsl");
                try
                {
                    Program.tslMain = TagSuggestionLibrary.load(filereadstream);
                }
                catch (Exception sEx)
                {
                    MessageBox.Show(sEx.Message);
                    Program.tslMain = TagSuggestionLibrary.generate();
                    Stream filewritestream = File.OpenWrite("main.tsl");
                    Program.tslMain.write(filewritestream);
                    filewritestream.Close();
                }
                filereadstream.Close();
            }
            else
            {
                Program.tslMain = TagSuggestionLibrary.generate();
                Stream filewritestream = File.OpenWrite("main.tsl");
                Program.tslMain.write(filewritestream);
                filewritestream.Close();
            }

            //Login information
            if (File.Exists("logindata"))
            {
                Stream river = File.OpenRead("logindata");
                try
                {
                    Program.loginMain = FuckingOAuthLogin.load(river);
                }
                catch (Exception sEx)
                {
                    MessageBox.Show(sEx.Message);
                    (new LoginManager()).Show();
                }
                river.Close();
            }
            else
            {
                (new LoginManager()).Show();
            }

            //Pixiv Login Data
            if (File.Exists("PixivPHPSESSID"))
            {
                Stream river = File.OpenRead("PixivPHPSESSID");
                StreamReader riverRider = new StreamReader(river);
                PixivRetrieval.PixivCookie = riverRider.ReadToEnd();
                tbxPHPSESSID.Text = PixivRetrieval.PixivCookie;
                river.Close();
            }

            //Image box so it scales the image down for the correct size
            picbxTheImage.SizeMode = PictureBoxSizeMode.Zoom;

            //Set the tracker for the length of tumblr tags textbox to zero
            TumblrTagsLen = 0;
        }

        private void btnPixivRetGo_Click(object sender, EventArgs e)
        {
            //Create a base Tumblr Post based on the Pixiv Image ID
            try
            {
                tumblingdown = new TumblrPost(tbxImageID.Text);
            }
            catch (Exception sEx)
            {
                MessageBox.Show(sEx.Message);
                return;
            }

            //Display the image
            MemoryStream memorylane = new MemoryStream(tumblingdown.ImageData);
            picbxTheImage.Image = System.Drawing.Image.FromStream(memorylane);

            //Put the image title into the textbox for caption
            tbxTumblrCaption.Text = tumblingdown.Caption;
            tbxTumblrCaption.Select(tbxTumblrCaption.Text.Length, 0);

            //Clear the Tumblr Tags
            tbxTumblrTags.Text = "";
            TumblrTagsLen = 0;
        }

        private void btnTumblrPostGo_Click(object sender, EventArgs e)
        {
            //Put the consumer key/secret information into the OAuth thing
            DashBuddy.API.OAuth.ConsumerKey = Program.loginMain.ConsumerKey;
            DashBuddy.API.OAuth.ConsumerSecret = Program.loginMain.ConsumerSecret;

            //No empty tags I guess
            if (tbxTumblrTags.Text == "")
            {
                tbxTumblrTags.Text = "None\n";
            }

            //Put the tags into the TumblrPost
            string[] tags = tbxTumblrTags.Text.Split(new char[] { '\r', '\n' });
            foreach (string tag in tags)
            {
                if (tag != "")
                {
                    tumblingdown.addTag(tag);
                }
            }

            //Put the caption into the TumblrPost
            tumblingdown.Caption = tbxTumblrCaption.Text;

            //Queue the TumblrPost
            String result = tumblingdown.post(Program.loginMain.BlogName, Program.loginMain.Token, Program.loginMain.TokenSecret);

            //Message box with the response from server
            MessageBox.Show(result);
        }

        private void tbxTumblrTags_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Last char is " + tbxTumblrTags.Text[tbxTumblrTags.Text.Length - 1] + ".");

            //Check whether the user just created a new line, i.e. finished typing her most recent tag
            if (tbxTumblrTags.Text != "" && //Stop array out of bounds of the next condition when the user deletes everything
                tbxTumblrTags.Text[tbxTumblrTags.Text.Length - 1] == '\n' && //User just hit enter
                tbxTumblrTags.Text.Length > TumblrTagsLen) //Otherwise backspace won't work because this will create a new line as soon as you backspace to the beginning of a line
            {

                //She finished the tag, let's look for suggestions!

                //Get all the tags entered so far
                List<String> tagsentered = tbxTumblrTags.Text.Split(new char[] { '\n', '\r' }).ToList();

                //Remove blanks that were created because my shitty way of separating the tags
                while (tagsentered.Remove("")) ;

                //Look up the final tag entered
                String[] suggestions = Program.tslMain.suggest(tagsentered[tagsentered.Count - 1]);

                //Iterate through and append the suggested tags into the tags textbox
                String append = "";
                foreach (String suggestion in suggestions)
                {
                    append += suggestion + "\r\n";
                }

                //Kill the final newline character
                append = append.Substring(0, append.Length - 1);

                //Add the suggestions to the textbox
                tbxTumblrTags.Text += append;

                //Deselect the text in the textbox
                tbxTumblrTags.SelectionLength = 0;

                //Move the cursor to the end
                tbxTumblrTags.SelectionStart = tbxTumblrTags.Text.Length;
            }

            //Update the length of the textbox to the actual length
            TumblrTagsLen = tbxTumblrTags.Text.Length;
        }

        private void btnOpenTSLManager_Click(object sender, EventArgs e)
        {
            (new FormTSLManage()).ShowDialog();
        }

        private void btnAccountManager_Click(object sender, EventArgs e)
        {
            (new LoginManager()).ShowDialog();
        }

        private void tbxPHPSESSID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Stream river = File.OpenWrite("PixivPHPSESSID");
                StreamWriter riverRider = new StreamWriter(river);
                PixivRetrieval.PixivCookie = tbxPHPSESSID.Text;
                riverRider.Write(PixivRetrieval.PixivCookie);
                riverRider.Flush();
                river.Close();
            }
            catch (Exception sEx)
            {

            }
        }

        private void picbxTheImage_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tumblr Authentication:\r\n" +
                "1. Open Manage Accounts if it isn't open already\r\n" +
                "2. Hit Request Token\r\n" +
                "3. After the Token and Secret textboxes are filled, hit Go Authorize\r\n" +
                "4. Sign in to Tumblr and allow my stupid app\r\n" +
                "5. When you get to the not found page, hit Verify Access\r\n" +
                "6. Put your blog name into the Blog textbox\r\n" +
                "7. Save and Close\r\n" +
                "    \r\n" +
                "Pixiv Authentication\r\n" +
                "1. Log in to Pixiv on your browser of choice\r\n" +
                "2. Get the Pixiv PHPSESSID cookie. In Firefox this can be found via Options > Privacy > remove individual cookies, and searching for Pixiv\r\n" +
                "3. Copy paste into the Pixiv PHPSESSID field\r\n" +
                "4. Make fun of my lazy workaround for Pixiv login\r\n" +
                "    \r\n" +
                "Posting\r\n" +
                "1. Put the Pixiv ID into the box\r\n" +
                "2. Hit Get!\r\n" +
                "3. Put your caption and tags and shit into the textboxes for them\r\n" +
                "4. Hit Queue!\r\n" +
                "5. Wait for a message saying something like 201 Created\r\n" +
                "6. If you don't get that, please message xyzismywaifu.tumblr.com or psasawat@umich.edu with details)\r\n");

        }

        private void tbxTumblrTags_KeyDown(object sender, KeyEventArgs e)
        {
            //Handling select all on the tags textbox
            if (e.Control & e.KeyCode == Keys.A)
            {
                tbxTumblrTags.SelectAll();
            }
        }




    }
}
;