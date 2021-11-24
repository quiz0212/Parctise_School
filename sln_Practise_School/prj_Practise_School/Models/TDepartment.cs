using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TDepartment
    {
        public TDepartment()
        {
            TClasses = new HashSet<TClass>();
            TTeacherDepts = new HashSet<TTeacherDept>();
        }

        public string FDeptId { get; set; }
        public string FDeptName { get; set; }

        public virtual ICollection<TClass> TClasses { get; set; }
        public virtual ICollection<TTeacherDept> TTeacherDepts { get; set; }
    }
}
