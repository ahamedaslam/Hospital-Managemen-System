using System.Drawing.Text;

namespace hmsVideo
{
    public partial class Login : Form
    {
        Thread th;
        public Login()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string pass = txtPassword.Text;

            if (username == "hms" && pass == "pass")
            {
                //MessageBox.Show("Login Successfull..");
                this.Hide();

                //used to open the dashboard form
                Dashboard ds = new Dashboard();
                ds.Show();

                //th = new Thread(newform);
                //th.SetApartmentState(ApartmentState.STA);
                //th.Start();
                //this.Close();



            }
            else
            {
                MessageBox.Show("Wrong UserName or PassWord..");
            }
        }
        //private void newform()
        //{
        //    Application.Run(new Dashboard());
        //}


    }
}