using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class showDetail : Form
    {
       
        public showDetail()
        {
            InitializeComponent();
        }
        public void ShowDetail(string detail) {
            textBox1.Clear();
            textBox1.Text = detail;
        }

       
    }
}
