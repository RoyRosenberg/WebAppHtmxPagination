using WebAppHtmxPagination.Models;

namespace WebAppHtmxPagination.Services
{
    public class PersonService
    {
        public List<Person> PersonList { get; set; }
        public PersonService()
        {
            PersonList = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                PersonList.Add(new Person()
                {
                    Id = i,
                    FirstName = $"name {i}",
                    LastName = $"last name {i}"
                });
            }

        }
    }
}
