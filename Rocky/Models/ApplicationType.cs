using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class ApplicationType
    {
        [Key] //automated increment
        public int CategoryId { get; set; }
       [Required]
        public string Name { get; set; }
        
    }
}
