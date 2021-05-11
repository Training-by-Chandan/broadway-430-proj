using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Broadway.DesktopApp.EF;

namespace Broadway.DesktopApp
{
    public partial class FormOrm : Form
    {
        Broadway_430Entities db = new Broadway_430Entities();
        public FormOrm()
        {
            InitializeComponent();
            ReloadData();
        }

        private void FormOrm_Load(object sender, EventArgs e)
        {

        }

        void ReloadData()
        {
            try
            {
                var data = db.Students.ToList();
                

              
                dataGridView1.DataSource = data;
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var student = new Student() { 
                 name=textBox1.Text,
                 email=textBox2.Text,
                 Age=Convert.ToInt32(textBox3.Text)
                };

                db.Students.Add(student);
                db.SaveChanges();
                ReloadData();

                var res=db.SP_StudentParent().ToList();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            //studentDetail.student=
            

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var datagrid = (DataGridView)sender;
            var selectedItem = datagrid.SelectedRows;
            var studentId = (int)selectedItem[0].Cells[0].Value;

            var student = db.Students.Find(studentId);
            StudentDetail studentDetail = new StudentDetail(student);
            
            studentDetail.Show();
        }
    }
}
