using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TLesonTime
    {
        public TLesonTime()
        {
            TSemesterSubjectTimes = new HashSet<TSemesterSubjectTime>();
        }

        public string FLesonTimeId { get; set; }
        public TimeSpan FStarTime { get; set; }
        public TimeSpan FEndTime { get; set; }

        public virtual ICollection<TSemesterSubjectTime> TSemesterSubjectTimes { get; set; }
    }
}
