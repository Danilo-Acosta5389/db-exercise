using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_exercise
{
    internal class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int points { get; set; }
        public DateOnly start_date { get; set; }
        public DateOnly end_date { get; set; }
    }
}
