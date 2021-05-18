using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.DesktopApp.ViewModel
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class ClassTeacher
    {
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
    }
}
