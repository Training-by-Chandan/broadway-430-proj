using Broadway.DesktopApp.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Broadway.DesktopApp
{
    public partial class Form1 : Form
    {
        string connectionString =
            "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Broadway_430;"
            + "Integrated Security=true";
        public Form1()
        {
            InitializeComponent();

            ReloaddData();
        }

        private void ReadFromTable(SqlConnection connection)
        {
            // Provide the query string with a parameter placeholder.
            string queryString = "select * from Students";

            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);


            try
            {
                SqlDataReader reader = command.ExecuteReader();
                List<Student> students = new List<Student>();
                while (reader.Read())
                {
                   
                    students.Add(new Student
                    {
                        id = (int)reader[0],
                        name = reader[1].ToString(),
                        email = reader[2].ToString(),
                        Age = (int)reader[3]
                    });


                    // Console.WriteLine(string.Join(",", readers));
                }
                reader.Close();
                    dataGridView1.DataSource = students;
                    dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           

        }

        private void InsertToTable(SqlConnection connection)
        {
            
           
            var name = textBox1.Text;
            
            var email = textBox2.Text;
            
            var age = textBox3.Text;

            string queryString =
               $"Insert into Student (Name, Email,Age) values ('{name}','{email}','{age}')";

            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(queryString, connection);
            try
            {
                var res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }
        void ExecuteStoredProcedure(SqlConnection connection)
        {
            // Provide the query string with a parameter placeholder.
            string spName =
                "[dbo].[TableCreateSP]";

            Console.WriteLine("Enter TableName");
            var tableName = Console.ReadLine();

            // Create the Command and Parameter objects.
            SqlCommand command = new SqlCommand(spName, connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@tablename";
            param.SqlDbType = System.Data.SqlDbType.NVarChar;
            param.Value = tableName;
            command.Parameters.Add(param);

            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloaddData();
        }
        void ReloaddData()
        {
            using (SqlConnection connection =
              new SqlConnection(connectionString))
            {
                connection.Open();
                ReadFromTable(connection);
               

                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection =
              new SqlConnection(connectionString))
            {
                connection.Open();
                InsertToTable(connection);


                connection.Close();
                ReloaddData();
            }
        }
    }

    //public class Student
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Email { get; set; }
    //    public int Age { get; set; }
    //}
}
