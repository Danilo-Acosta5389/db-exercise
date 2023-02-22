using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_exercise
{
    internal class CourseModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int points { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}
