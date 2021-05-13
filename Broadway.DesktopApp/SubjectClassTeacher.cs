using Broadway.DesktopApp.Models;
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
    public partial class SubjectClassTeacher : Form
    {

        private CodeFirst.CodeFirstContext db = new CodeFirst.CodeFirstContext();

        //private model.Broadway_430Entities db = new model.Broadway_430Entities();

        public SubjectClassTeacher()
        {
            InitializeComponent();
            ReloadAllGrid();

            ReloadClassesTeacherCombo();
            ReloadSubjectClassCombo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textTeacherName.Text)) //""
            {
                var Teacher = new Teacher() { Name = textTeacherName.Text };
                db.Teacher.Add(Teacher);
                db.SaveChanges();
                
                ReloadTeachersGrid();
                textTeacherName.Text = "";

                //todo: update the combo box
                ReloadClassesTeacherCombo();
            }
        }



        void ReloadClassesTeacherCombo()
        {
            var teachers = db.Teacher.ToList();
            var source = new List<string> { ""};
            source.AddRange(teachers.Select(p => $"{p.Id} - {p.Name}").ToList());
            comboBox1.DataSource = source;
            comboBox1.Refresh();
        }

        void ReloadSubjectClassCombo()
        {
            var classes = db.Class.ToList();
            var source = new List<string> ();
            source.AddRange(classes.Select(p => $"{p.Id} - {p.ClassName}").ToList());
            comboBox3.DataSource = source;
            comboBox3.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtClassName.Text))
            {
                Classes classObj = new Classes() { ClassName = txtClassName.Text };
                if (comboBox1.SelectedIndex>0)
                {
                    var item = (string)comboBox1.SelectedItem;
                    var array = item.Split('-');
                    var teacherId = Convert.ToInt32(array[0]);
                    classObj.TeacherId = teacherId;

                }

                db.Class.Add(classObj);
                db.SaveChanges();

                txtClassName.Text = "";
                comboBox1.SelectedIndex = 0;
                ReloadClassesGrid();

                ReloadSubjectClassCombo();


            }
        }

        private void SubjectClassTeacher_Load(object sender, EventArgs e)
        {
          

        }

        void ReloadTeachersGrid()
        {
            dataGridView1.DataSource = db.Teacher.ToList();
            dataGridView1.Refresh();
        }
        void ReloadClassesGrid()
        {
            dataGridView2.DataSource = db.Class.ToList();
            dataGridView2.Refresh();
        }
        void ReloadSubjectGrid()
        {
            dataGridView3.DataSource = db.Subjects.ToList();
            dataGridView3.Refresh();
        }

        void ReloadAllGrid()
        {
            ReloadTeachersGrid(); //gridview1
            ReloadClassesGrid();
            ReloadSubjectGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSubjectName.Text) && !string.IsNullOrWhiteSpace(txtSubjectCode.Text) && comboBox3.SelectedIndex >= 0)
            {
                Subjects subjects = new Subjects() { SubjectName = txtSubjectName.Text, SubjectCode = txtSubjectCode.Text };
                var item = (string)comboBox3.SelectedItem;
                var array = item.Split('-');
                var classId = Convert.ToInt32(array[0]);
                subjects.ClassId = classId;

                db.Subjects.Add(subjects);
                db.SaveChanges();


                txtSubjectName.Text = "";
                txtSubjectCode.Text = "";
                comboBox3.SelectedIndex = 0;

                ReloadSubjectGrid();
            }
        }
    }
}
