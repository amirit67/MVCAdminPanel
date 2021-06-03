using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class terminal_groups
    {
        [Key]
        public Guid group_id { get; set; }
        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string group_name { get; set; }

        public virtual List<terminal_detail> terminal_detail { get; set; }

        public terminal_groups()
        {

        }
    }
}
