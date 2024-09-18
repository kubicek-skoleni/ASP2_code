using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Model
{
    public class Email
    {
        public int Id { get; set; }

        [NotMapped]
        public bool IsProcessed { get => Processed != null; }

        public DateTime Submitted { get; set; }

        public DateTime? Processed {  get; set; }

        [MaxLength(1000)]
        public string SendTo { get; set; }
    }
}
