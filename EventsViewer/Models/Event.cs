using System.ComponentModel.DataAnnotations;

namespace EventsViewer.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string? EventTitle { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
