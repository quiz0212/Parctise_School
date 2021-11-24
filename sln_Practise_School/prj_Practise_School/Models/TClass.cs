using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TClass
    {
        public TClass()
        {
            TClassMembers = new HashSet<TClassMember>();
        }

        public string FClassId { get; set; }
        public string FDeptId { get; set; }
        public int FSchoolYear { get; set; }

        public virtual TDepartment FDept { get; set; }
        public virtual ICollection<TClassMember> TClassMembers { get; set; }
    }
}
