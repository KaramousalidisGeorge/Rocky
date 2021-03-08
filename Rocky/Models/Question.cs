using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Models
{
    public class Question
    {
            [Key]
            public string questionId { get; set; }
            public string text { get; set; }
        
    }
}
