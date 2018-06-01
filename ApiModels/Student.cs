using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiModels
{
    public class Student : Entity<int>
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime StudentBirth { get; set; }
        public string StudentAddress { get; set; }
        public virtual Class Class { get; set; }
    }
}
