using School.Managment.Services;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            refreshStudentData();
            refreshTeacherData();
        }

        void refreshStudentData()
        {
            var studentData = StudentService.GetAllStudents();
            grdStudent.DataSource = studentData;
            grdStudent.Refresh();

        }

        private void grdStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void refreshTeacherData()
        {
            var teachertData = TeacherService.GetAllTeachers();
            grdteacher.DataSource = teachertData;
            grdteacher.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshStudentData();
            refreshTeacherData();
        }
    }
}
