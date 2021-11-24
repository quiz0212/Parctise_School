using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace prj_Practise_School.Models
{
    public partial class TJobTitleIdToJobTitleName
    {
        public TJobTitleIdToJobTitleName()
        {
            TUsers = new HashSet<TUser>();
        }


        [RegularExpression(@"^[0-9]*$"), Required, StringLength(3)]
        public string FJobTitleId { get; set; }
        public string FJobTitleName { get; set; }

        public virtual ICollection<TUser> TUsers { get; set; }
    }
}
