using System;
using System.Collections.Generic;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TClassMember
    {
        public string FUserId { get; set; }
        public string FClassId { get; set; }

        public virtual TClass FClass { get; set; }
        public virtual TUser FUser { get; set; }
    }
}
