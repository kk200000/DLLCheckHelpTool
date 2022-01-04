using System.Threading;
using System.Windows.Forms;

namespace EditConfigForm
{
    public partial class progressForm : Form
    {

        public string statusInfo = "正在查询中...";
        public int Max;
        //初始化程序
        public progressForm(int Maxcount)
        {
            InitializeComponent();
            Max = Maxcount;
        }
        public void AddProgress()
        {
            progressBar1.Maximum = Max;
            progressBar1.Value++;
            label1.Text = statusInfo;
            label1.Refresh();
        }




        }



       
}
