using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDeck
{
    class Assignment
    {
        public string asn;
        public string course;
        public string due;

        public Assignment()
        {
            asn = "N/A";
            course = "N/A";
            due = "N/A";
        }
        public Assignment(string _asn, string _course, string _due)
        {
            asn = _asn;
            course = _course;
            due = _due;
        }
        public override string ToString()
        {
            return $"Assignment: {asn}\nCourse: {course}\nDue: {due}\n";
        }
    }
}
