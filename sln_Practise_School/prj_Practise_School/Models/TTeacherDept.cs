using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TTeacherDept
    {
        public string FUserId { get; set; }
        public string FDeptId { get; set; }

        public virtual TDepartment FDept { get; set; }
        public virtual TUser FUser { get; set; }
    }
}
