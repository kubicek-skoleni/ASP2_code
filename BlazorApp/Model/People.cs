using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp.Model
{

    public class Person
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Neplatný email.")]
         
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
                
        public Address? Address { get; set; }

        [NotMapped]
        public string AdressAsString { get => $""; }

        public ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();

        public override string ToString()
        {
            return $"{FirstName} {LastName} {Email}";
        }
    }

    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }

    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlateNumber { get; set; }
        public DateTime Signed { get; set; }
        public int CarBrand { get; set; }
        public string HexColor { get; set; }
    }

}
