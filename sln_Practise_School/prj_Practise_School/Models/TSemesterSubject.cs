using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TSemesterSubject
    {
        public TSemesterSubject()
        {
            TScores = new HashSet<TScore>();
            TSemesterSubjectTimes = new HashSet<TSemesterSubjectTime>();
            TStudentSubjects = new HashSet<TStudentSubject>();
        }

        public string FSemesterSubjectId { get; set; }
        public string FSubjectId { get; set; }
        public string FUserId { get; set; }
        public int FSchoolYear { get; set; }
        public string FSemester { get; set; }
        public string FClassRoom { get; set; }
        public int FNumberOfStudent { get; set; }

        public virtual TSubject FSubject { get; set; }
        public virtual TUser FUser { get; set; }
        public virtual ICollection<TScore> TScores { get; set; }
        public virtual ICollection<TSemesterSubjectTime> TSemesterSubjectTimes { get; set; }
        public virtual ICollection<TStudentSubject> TStudentSubjects { get; set; }
    }
}
