using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Managment.Models
{
    [Table("ExamInfo")]
    public class Exams
    {
        [Key]
        public Guid Id { get; set; }
        public string ExamName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Year { get; set; }

    }
}
