using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Category
    {
        [Key] //automated increment
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Pleas enter a number greater of 0")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
