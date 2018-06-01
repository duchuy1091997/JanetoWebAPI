using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Class:Entity<int>
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime LearningTime { get; set; }
        
        //1 lớp có 1 GV chủ nhiệm.
        [InverseProperty("Homeroom")]
        public virtual Teacher Homeroom { get; set; }

        //1 lớp dạy bởi nhiều GV
        public ICollection<Teacher> Teacher { get; set; }
        //1 lớp có nhiều SV
        public ICollection<Student> Student { get; set; }
    }
}
