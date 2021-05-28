using School.Managment.Services;
using School.Managment.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.Managment
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            { 
                MessageBox.Show("Username is blank");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is blank");
                return;
            }
            
            var model = new LoginRequestViewModel() {  UserName=txtUsername.Text, Password=txtPassword.Text};
            var loginresult = LoginService.Login(model);
            if (loginresult.Status)
            {
                //redirect to another form
                switch (loginresult.UserType)
                {
                    case Common.UserType.Student:
                        UI.Student.StudentMDi studentDashboard = new UI.Student.StudentMDi(loginresult.Userid);
                        studentDashboard.Show();
                        break;
                    case Common.UserType.Teacher:
                        UI.Teacher.TeacherMdi teacherDashboard = new UI.Teacher.TeacherMdi(loginresult.Userid);
                        teacherDashboard.Show();
                        break;
                    case Common.UserType.Admin:
                        UI.Admin.AdminMdi adminDashboard = new UI.Admin.AdminMdi();
                        adminDashboard.Show();
                        break;
                    default:
                        break;
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show(loginresult.Message);
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
                //var checkbox = (CheckBox)sender;
               // checkbox.Text = "Show Password";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                //var checkbox = (CheckBox)sender;
                //checkbox.Text = "Hide Password";
            }

        }
    }
}
