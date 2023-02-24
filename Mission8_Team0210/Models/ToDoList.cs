using System;
using System.ComponentModel.DataAnnotations;

namespace Mission8_Team0210.Models
{
    public class ToDoList
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string Task { get; set; }
        public string Date { get; set; }

        [Required]
        public int Quadrant { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
