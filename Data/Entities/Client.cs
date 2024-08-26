using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Client
    {
        [Key]
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string CUIT { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string PhoneNumber { get; set; }
    }
}
