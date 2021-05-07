using Broadway.Projects.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.Projects
{
    class Program
    {
          static  string connectionString =
            "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Broadway_430;"
            + "Integrated Security=true";

        static void Main(string[] args)
        {
            var result = "y";
            do
            {
                //    //Console.WriteLine("Enter the table name:");
                //    //string tableName = Console.ReadLine();
                //    Console.WriteLine("Enter the Choice\n1: Display the record\n2: Create the reordd\n3: Update the record\n4: Delete the reccord\n5: Execute Stored Procedure");
                //    using (SqlConnection connection =
                //   new SqlConnection(connectionString))
                //    {
                //        connection.Open();
                //        var choice = Console.ReadLine();
                //        switch (choice)
                //        {
                //            case "1":
                //                ReadFromTable(connection);
                //                break;
                //            case "2":
                //                InsertToTable(connection);
                //                break;
                //            case "3":
                //                UpdateToTable();
                //                break;
                //            case "4":
                //                DeleteFromTable();
                //                break;
                //            case "5":
                //                ExecuteStoredProcedure(connection);
                //                break;
                //            default:
                //                break;
                //        }

                //        connection.Close();
                //    }
                string str = "";
                str=str.AddDefaultValue(); //"The quick brown fox jumps over the lazy dog."
                Console.WriteLine(str);
                str=str.AddAnchalData(); //"Anchal Lama"
                Console.WriteLine(str);
                str=str.AddHimanshuData(); //"Himanshu Tiwari"
                Console.WriteLine(str);

                int i = 20;
                i=i.Increaseby1();
                Console.WriteLine(i);
                i = i.IncreasebyNum(15);
                Console.WriteLine(i);
                //Create();

                Console.WriteLine("Want to try more (y/n)?");
                result = Console.ReadLine();
            } while (result == "y" || result == "Y");

            Console.ReadLine();

        }

        static void Create()
        {
            Console.WriteLine("Enter the name of class you want to create the object of ");
            var str = Console.ReadLine();
            var a = Activator.CreateInstance(Type.GetType(str));
            //ABC abc=new "Broadway.Projects.DEF";
            ABC abc = new ABC();
            Console.WriteLine("The type of object is => " + a.GetType());
        }
        private static void ReadFromTable( SqlConnection connection)
        {
            // Provide the query string with a parameter placeholder.
            string queryString =
                "select * from Student";

                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                
                
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var readers = new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString() };
                        Console.WriteLine(string.Join(",",readers));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
                Console.ReadLine();
            
        }

        private static void InsertToTable(SqlConnection connection)
        {
            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Email");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Age");
            var age = Console.ReadLine();

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

            Console.ReadLine();
        }
        static void ExecuteStoredProcedure(SqlConnection connection)
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

            Console.ReadLine();
        }
        private static void UpdateToTable()
        {

        }
        private static void DeleteFromTable()
        {

        }
    }



    
}

