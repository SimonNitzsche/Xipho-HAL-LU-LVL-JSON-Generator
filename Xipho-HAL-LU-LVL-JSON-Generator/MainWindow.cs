using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
        }

        private void CreditsButton_Click(object sender, EventArgs e) {
            string[] contributorList = GithubAPI.getContributors();
            string sContributorList = "Contributors:\n-----------------";
            foreach (string s in contributorList) {
                sContributorList += "\n"+s;
            }
            MessageBox.Show(this, sContributorList, "Contributors", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void ToolStrip_OpenLUZ_Click(object sender, EventArgs e) {
            LUZOpenFileDialog.ShowDialog();
            WorldLoader.LUZFile.Open(LUZOpenFileDialog.FileName);
        }
    }
}
