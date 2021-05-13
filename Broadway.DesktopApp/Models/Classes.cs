using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broadway.DesktopApp.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        public string ClassName { get; set; }

        public int? TeacherId { get; set; }

        [ForeignKey("TeacherId")]
        public virtual Teacher ClassTeacher { get; set; }

        public ICollection<Subjects> Subjects { get; set; }


    }
}
