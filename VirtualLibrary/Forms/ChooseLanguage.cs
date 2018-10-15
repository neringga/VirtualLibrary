using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualLibrary.Forms
{
    public partial class ChooseLanguage : Form
    {
        public static string _language;
        public ChooseLanguage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _language = "LT";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _language = "EN";
        
        }
        public static string GetUserLanguageSetting()
        {
            return _language;
        }
    }
}
