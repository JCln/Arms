using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arms.Forms
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }

        private async void SplashForm_Load(object sender, System.EventArgs e)
        {
            await Task.Delay(2000);
            var masterForm = new MasterForm();
            this.Hide();      
            masterForm.ShowDialog(this);
            this.Close();
            masterForm.Dispose();
        }
    }
}
