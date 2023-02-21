using System;
namespace Mission8_Team0210.Models
{
    public class ToDoList
    {
        public string Task { get; set; }
        public DateTime Date { get; set; }
        public string Quadrant { get; set; }
        public int CategoryId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
