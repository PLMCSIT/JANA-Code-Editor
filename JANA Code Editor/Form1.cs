using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JANA_Code_Editor
{
    public partial class frmMain : Form
    {
        public static frmMain Self;
        public frmMain()
        {
            InitializeComponent();
            Self = this;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Lexical LexicalAnalyzer = new Lexical();

            dGridResults.Rows.Clear();
            txtOutput.Text = LexicalAnalyzer.Start(document.Lines);
        }

        private void dGridResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dGridResults_SelectionChanged(object sender, EventArgs e)
        {
            dGridResults.ClearSelection();
        }
    }
}
