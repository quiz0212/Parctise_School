using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TSubject
    {
        public TSubject()
        {
            TSemesterSubjects = new HashSet<TSemesterSubject>();
        }

        public string FSubjectId { get; set; }
        public string FSubjectName { get; set; }
        public int FCredits { get; set; }

        public virtual ICollection<TSemesterSubject> TSemesterSubjects { get; set; }
    }
}
