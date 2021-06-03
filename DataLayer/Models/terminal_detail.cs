using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class terminal_detail
    {
        [Key]
        public Guid id { get; set; }
        public Guid group_id { get; set; }
        [Display(Name ="شماره پذیرندگی")]
        public string acceptor { get; set; }
        [Display(Name = "شماره ترمینال")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string terminal_number { get; set; }
        [Display(Name = "مکان پذیرنده")]
        public string place_name { get; set; }
        [Display(Name = "تلفن پذیرنده")]
        public string place_phone { get; set; }
        [Display(Name = "تلفن پذیرنده")]
        public string serial_number { get; set; }
        [Display(Name = "دسترسی")]
        public string is_access { get; set; }
        [Display(Name = "احراز هویت")]
        public string is_authenticate { get; set; }
        [Display(Name = "تاریخ ایجاد")]
        public string createDate { get; set; }
   


        public virtual terminal_groups terminal_groups { get; set; }

        public terminal_detail()
        {

        }

    }
}
