using Broadway.DesktopApp.Services;
using Broadway.DesktopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadway.DesktopApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new UserLoginViewModel() { UserName=txtUserName.Text, Password=txtPassword.Text  };

            var result = UserService.Login(model);
            if (result.Item1)
            {
                SubjectClassTeacher subjectClassTeacher = new SubjectClassTeacher();
                subjectClassTeacher.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(result.Item2);
            }
        }
    }
}
