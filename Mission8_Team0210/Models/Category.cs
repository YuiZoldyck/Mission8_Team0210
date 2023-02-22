using System;
using System.ComponentModel.DataAnnotations;

namespace Mission8_Team0210.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

    }
}
