using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MikroProject.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public string Class { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }
    }
}
