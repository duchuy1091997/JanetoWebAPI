using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Teacher:Entity<int>
    {
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherAddress { get; set; }
        //1 GV chủ nhiệm nhiều lớp
        public virtual ICollection<Class> Homeroom { get; set; }
        //1 GV dạy nhiều lớp
        public virtual ICollection<Class> Class { get; set; }
    }
}
