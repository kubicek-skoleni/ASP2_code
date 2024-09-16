using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class PrivacyPolicy
    {
        public int Id { get; set; }

        public DateOnly ValidFrom { get; set; }

        [MaxLength(1000)]
        public string Text { get; set; }   
    }
}
