using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TScore
    {
        public int FIdIdentity { get; set; }
        public string FSemesterSubjectId { get; set; }
        public string FUserId { get; set; }
        public int FScore { get; set; }

        public virtual TSemesterSubject FSemesterSubject { get; set; }
        public virtual TUser FUser { get; set; }
    }
}
