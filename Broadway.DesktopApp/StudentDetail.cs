using Broadway.DesktopApp.EF;
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
    public partial class StudentDetail : Form
    {
        public Student student = new Student();
        private Broadway_430Entities db = new Broadway_430Entities();
        public StudentDetail(Student students)
        {
            InitializeComponent();
            this.student = students;
            ReloadData();
        }

        void ReloadData()
        {
            textBox1.Text = student.name;

            var father = student.StudentParents.FirstOrDefault(p => p.ParentType == 0);
            var mother= student.StudentParents.FirstOrDefault(p => p.ParentType == 1);

            textBox2.Text = father.ParentName;
            textBox3.Text = mother.ParentName;

            textBox4.Text = father.ParentAddresses.FirstOrDefault().Address;
            textBox5.Text = mother.ParentAddresses.FirstOrDefault().Address;
        }

        private void StudentDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
