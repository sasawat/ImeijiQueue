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
    public partial class FormTSLManage : Form
    {
        String selection;

        public FormTSLManage()
        {
            InitializeComponent();
        }

        private void FormTSLManage_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
            lbxTagIf.Items.Clear();
            lbxTagIf.Items.AddRange(Program.tslMain.listValidTagIf());
            selection = "";
        }

        private void lbxTagIf_SelectedIndexChanged(object sender, EventArgs e)
        {
            //The user has changed her selection for tagIf!
            String newSuggestions = "";

            //Store the suggestion list for the previously selected tag
            parseTagsThenBox();

            //Update the current selection
            selection = lbxTagIf.Text;

            //Get the suggestions for the selected tag
            String[] tagsThen = Program.tslMain.suggest(selection);

            //Put them into a newline separated string for display
            foreach (String tagThen in tagsThen)
            {
                newSuggestions += tagThen + "\r\n";
            }

            //Display the list of suggestions
            tbxTagsThen.Text = newSuggestions;
            
        }

        private void parseTagsThenBox()
        {
            //Check whether the current selection is nothing
            if (selection != "")
            {

                //Put each tag in the TagsThen TextBox into a list. They are separated by newline
                List<String> tagsThen = tbxTagsThen.Text.Split(new char[] {'\n','\r'}).ToList();

                //Remove blank lines if any
                while (tagsThen.Remove("")) ;
                while (tagsThen.Remove(null)) ;
                while (tagsThen.Remove(" ")) ;

                //Remove repeats
                tagsThen = tagsThen.Distinct().ToList();

                //Edit the suggestion in the library
                Program.tslMain.editSuggestion(selection, tagsThen.ToArray());
            }
        }

        private void btnAddTagIf_Click(object sender, EventArgs e)
        {
            //Clear the current selection of tag in the listbox
            lbxTagIf.ClearSelected();
            selection = "";

            //Add the tag to the list of selectable
            lbxTagIf.Items.Add(tbxNewTag.Text);

            //Add the tag to the library
            Program.tslMain.editSuggestion(tbxNewTag.Text, new String[] { "" });

            //Clear the new tag textbox
            tbxNewTag.Text = "";

            //Clear the suggestion tags textbox
            tbxTagsThen.Text = "";
        }

        private void tbxTagsThen_TextChanged(object sender, EventArgs e)
        {
            if(tbxTagsThen.Text.Length != 0 && tbxTagsThen.Text[tbxTagsThen.Text.Length-1] == '\n')
            {
                parseTagsThenBox();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //The user wants to import! This will be continued in the handler after they selected a file
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //We have the file to open!
            Stream strum = openFileDialog1.OpenFile();

            //Load the library to replace the program's current library
            Program.tslMain = TagSuggestionLibrary.load(strum);

            //Close the stream and clean up
            strum.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //User wants to export a backup library, continued in handler for save file dialogue

            //But first we will make sure the library is actually up to date with what is displayed
            parseTagsThenBox();

            //Show the save file dialog
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //We have the file to save to!
            Stream strum = saveFileDialog1.OpenFile();

            //Save the library into the file
            Program.tslMain.write(strum);

            //Close the stream and clean up
            strum.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Make sure the library is up to date with latest changes
            parseTagsThenBox();

            //Open the program's library storage file
            Stream strum = File.OpenWrite("main.tsl");

            //Save the library to the main file
            Program.tslMain.write(strum);

            //Close the stream and clean up
            strum.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            //Open the library file
            Stream strum = File.OpenRead("main.tsl");

            //Reload the library from it
            Program.tslMain = TagSuggestionLibrary.load(strum);

            //close the stream and clean up
            strum.Close();

            //Reload the manager
            FormTSLManage_Load(null, null);

            //Clear the textbox of suggestions
            tbxTagsThen.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Open the program's library storage file
            Stream strum = File.OpenWrite("main.tsl");

            //Save the library to the main file
            Program.tslMain.write(strum);

            //Close the stream and clean up
            strum.Close();

            this.Close();
        }

        private void btnRmTagIf_Click(object sender, EventArgs e)
        {
            //Remove the selected tag from the library
            Program.tslMain.removeSuggestion(selection);

            //Reload the manager
            FormTSLManage_Load(null, null);

            //Clear the textbox of suggestions
            tbxTagsThen.Text = "";
        }




    }
}
