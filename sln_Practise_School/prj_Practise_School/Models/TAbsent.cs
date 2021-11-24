using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TAbsent
    {
        public int FIdIdentity { get; set; }
        public string FUserId { get; set; }
        public string FStatus { get; set; }
        public string FSemesterSubjectId { get; set; }
        public string FLesonTimeId { get; set; }
        public string FDay { get; set; }

        public virtual TUser FUser { get; set; }
    }
}
