using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TSemesterSubjectTime
    {
        public int FIdIdentity { get; set; }
        public string FSemesterSubjectId { get; set; }
        public string FLesonTimeId { get; set; }
        public string FDay { get; set; }

        public virtual TLesonTime FLesonTime { get; set; }
        public virtual TSemesterSubject FSemesterSubject { get; set; }
    }
}
