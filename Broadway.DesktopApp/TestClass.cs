using Broadway.DesktopApp.Models;
using Broadway.DesktopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.DesktopApp
{
    public class TestClass
    {
        public CodeFirst.CodeFirstContext db = new CodeFirst.CodeFirstContext();

        public List<TeacherViewModel> FilterTeacher(string search)
        {
            var d = from teacher in db.Teacher
                    where teacher.Name.ToUpper().Contains(search.ToUpper()) select teacher;


            var data = from teacher in db.Teacher where teacher.Name.ToUpper().Contains(search.ToUpper()) select new TeacherViewModel { Name=teacher.Name, Email=teacher.Email };


            var innerjoinData =( from c in db.Class join t in db.Teacher on c.TeacherId equals t.Id select new ClassTeacher { ClassName = c.ClassName, TeacherName = t.Name }).ToList();
            
            
            
            //var dataLambda = db.Teacher.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).Select(p=>p.Name);
            return data.ToList();
        }
    }
}
