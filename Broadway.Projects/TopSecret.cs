using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.Projects
{
    public class TopSecret
    {
        static void Create(string Name)
        {
            object a = Activator.CreateInstance(Type.GetType(Name));

            Console.WriteLine("The type of object is => "+ a.GetType());
        }
    }

    public class ABC //Broadway.Projects.ABC
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DEF
    {
        public int ActualId { get; set; }
        public string FullName { get; set; }
    }
}
