using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandManagerSampleApp
{
    public partial class frmMain : Form
    {
        Commands.CommandManager cmdManager = new Commands.CommandManager();

        public frmMain()
        {
            InitializeComponent();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // method 1 to create the command
            cmdManager.CreateCommand("copy", new ToolStripItem[] { miCopy, tsbCopy }, cmdCopy_CommandClick);
            cmdManager.CreateCommand("bold", tsbBold, cmdBold_CommandClick);

            // method 2 to create the command
            Commands.Command cmdSave = cmdManager.CreateCommand("save", new ToolStripItem[] { miSave, tsbSave });
            cmdSave.CommandClick += cmdSave_CommandClick;

            // register new UICommand on existing command
            cmdManager.RegisterUICommand("copy", ctxmiCopy);

            // disable "copy" command 
            cmdManager.SetCommandEnable(false, "copy");

            InitRichText();
        }

        private void InitRichText()
        {
            Font fontTitle = new Font("arial", 14, FontStyle.Bold);
            Font fontDefault = new Font("arial", 10, FontStyle.Regular);
            Font fontBold = new Font("arial", 10, FontStyle.Bold);

            rtbText.SelectionRightIndent = 20;
            rtbText.SelectionIndent = 20;

            rtbText.SelectionAlignment = HorizontalAlignment.Left;

            rtbText.SelectionFont = fontTitle;
            rtbText.AppendText("What is Lorem Ipsum?\n\n");

            rtbText.SelectionAlignment = HorizontalAlignment.Left;
            rtbText.SelectionFont = fontBold;
            rtbText.AppendText("Lorem Ipsum");

            rtbText.SelectionFont = fontDefault;
            rtbText.AppendText(" is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.\n");


        }

        private void cmdCopy_CommandClick(object sender, EventArgs args)
        {
            MessageBox.Show($"copy command clicked ({((ToolStripItem)sender).Name})");
        }

        private void cmdBold_CommandClick(object sender, EventArgs args)
        {
            MessageBox.Show($"bold command clicked ({((ToolStripItem)sender).Name})");
        }
        private void cmdSave_CommandClick(object sender, EventArgs e)
        {
            MessageBox.Show($"save command clicked ({((ToolStripItem)sender).Name})");
        }

        private void rtbText_SelectionChanged(object sender, EventArgs e)
        {
            cmdManager.SetCommandEnable(rtbText.SelectedText != "", new string[] { "copy", "bold" });
        }
    }
}
