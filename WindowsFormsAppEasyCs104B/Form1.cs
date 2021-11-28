using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs104B
{
    public partial class Form1 : Form
    {
        private TextBox tb;
        private ToolStrip ts;
        private ToolStripButton[] tsb = new ToolStripButton[3];
        private Button bt1, bt2;
        private FlowLayoutPanel flp;
        private string url = "C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs104B\\WindowsFormsAppEasyCs104B\\img\\";
        
        // [STAThread]
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Text Editor 2";
            ts = new ToolStrip(); // Create ToolBar

            for (int i = 0; i < tsb.Length; i++)
            {
                tsb[i] = new ToolStripButton();
            }

            tsb[0].Image = Image.FromFile(url + "cut.bmp");
            tsb[1].Image = Image.FromFile(url + "copy.bmp");
            tsb[2].Image = Image.FromFile(url + "paste.bmp");

            tsb[0].ToolTipText = "Cut";
            tsb[1].ToolTipText = "Copy";
            tsb[2].ToolTipText = "Paste";

            tb = new TextBox();
            tb.Multiline = true;
            tb.Width = this.Width;
            tb.Height = this.Height - 100;
            tb.Dock = DockStyle.Top;

            bt1 = new Button();
            bt2 = new Button();
            bt1.Text = "Read";
            bt2.Text = "Save";

            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Bottom;

            for (int i = 0; i < tsb.Length; i++)
            {
                ts.Items.Add(tsb[i]);
            }

            bt1.Parent = flp;
            bt2.Parent = flp;
            flp.Parent = this;
            tb.Parent = this;
            ts.Parent = this;

            bt1.Click += new EventHandler(BtClick);
            bt2.Click += new EventHandler(BtClick);
            for (int i = 0; i < tsb.Length; i++)
            {
                tsb[i].Click += new EventHandler(TsbClick);
            }
        }

        public void TsbClick(Object sender, EventArgs e)
        {
            if (sender == tsb[0])
            {
                tb.Cut();
            }
            else if (sender == tsb[1])
            {
                tb.Copy();
            }
            else if (sender == tsb[2])
            {
                tb.Paste();
            }
        }

        public void BtClick(Object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text File | *.txt";
            if (sender == bt1)
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8);
                    tb.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            else if (sender == bt2)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text File | *.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    sw.WriteLine(tb.Text);
                    sw.Close();
                }
            }
            
        }
    }
}