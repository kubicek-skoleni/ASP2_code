using BlazorApp.Model;
using System.Text.Json;

namespace BlazorApp.Data
{
    public class PeopleDataset
    {
       private List<Person> _people;
       public List<Person> GetPeople()
        {
            if(_people == null) 
            {
                _people = JsonSerializer.Deserialize<List<Person>>(@"C:\Users\Student EN\source\repos\ASP2\dataset_people\data2024.json");
            }

            return _people;
        }
    }
}
