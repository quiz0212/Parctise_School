using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TUser
    {
        public TUser()
        {
            TAbsents = new HashSet<TAbsent>();
            TScores = new HashSet<TScore>();
            TSemesterSubjects = new HashSet<TSemesterSubject>();
            TStudentSubjects = new HashSet<TStudentSubject>();
        }

        public string FUserId { get; set; }
        public string FName { get; set; }
        public string FGender { get; set; }
        public DateTime FBirthday { get; set; }
        public string FEmail { get; set; }
        public string FPhone { get; set; }
        public string FAddress { get; set; }
        public string FPassword { get; set; }
        public string FJobTitleId { get; set; }
        public string FImage { get; set; }

        public virtual TJobTitleIdToJobTitleName FJobTitle { get; set; }
        public virtual TClassMember TClassMember { get; set; }
        public virtual TTeacherDept TTeacherDept { get; set; }
        public virtual ICollection<TAbsent> TAbsents { get; set; }
        public virtual ICollection<TScore> TScores { get; set; }
        public virtual ICollection<TSemesterSubject> TSemesterSubjects { get; set; }
        public virtual ICollection<TStudentSubject> TStudentSubjects { get; set; }
    }
}
