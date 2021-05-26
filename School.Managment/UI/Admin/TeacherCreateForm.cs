using School.Managment.Services;
using School.Managment.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School.Managment.UI.Admin
{
    public partial class TeacherCreateForm : Form
    {
        public TeacherCreateForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (valid())
            {
                TeacherUserViewModel model = new TeacherUserViewModel()
                {
                    FirstName = txtFName.Text,
                    MiddleName = txtMName.Text,
                    LastName = txtLName.Text,
                    Address = txtAddress.Text,
                    Username = txtUsername.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    ConfirmPassword = txtConfirmPassword.Text
                };

                switch (cmbGender.SelectedIndex)
                {
                    case 0:
                        model.Gender = Common.Gender.Male;
                        break;
                    case 1:
                        model.Gender = Common.Gender.Female;
                        break;
                    default:
                        model.Gender = Common.Gender.Others;
                        break;
                }
                var result = TeacherCreateService.CreateTeacherUser(model);
                MessageBox.Show(result.Message);
                if (result.Status)
                {
                    Clear();
                }
            }
        }
        bool valid()
        {
            var result = true;
            lblvalidaion.Text = "";

            ValidationFunc(txtFName, "First Name is required", ref result);
            ValidationFunc(txtLName, "Last Name is required", ref result);
            if (cmbGender.SelectedIndex == -1)
            {
                lblvalidaion.Text += "\nGender is Required";
                result = false;
            }
            ValidationFunc(txtAddress, "Address is required", ref result);
            ValidationFunc(txtUsername, "Username is required", ref result);
            ValidationFunc(txtEmail, "Email is required", ref result);
            ValidationFunc(txtPassword, "Password is required", ref result);
            ValidationFunc(txtConfirmPassword, "Confirm Password is required", ref result);


            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblvalidaion.Text += "\nPassword and Confirm Password does not match";
            }

            return result;
        }

        void ValidationFunc(TextBox txt, string label, ref bool result)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                lblvalidaion.Text += "\n" + label;
                result = false;
            }
        }

        void Clear()
        {
            txtFName.Text = "";
            txtMName.Text = "";
            txtLName.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";


            cmbGender.SelectedIndex = -1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
