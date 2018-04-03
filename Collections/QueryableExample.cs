using Collections.Model;
using System;
using System.Linq;

namespace Collections
{
    internal class QueryableExample : IExample
    {
        public QueryableExample()
        {
            SeedDatabase();
            
        }


        public void Example()
        {
            using (var dbContext = new PersonDbContext())
            {
                var people = dbContext.People;

                var peopleInWorkingAge = people
                    .Where(p => p.Age < 50)
                    .Where(p => p.Age > 18);

                peopleInWorkingAge.ToList();
            }
        }

        private void SeedDatabase()
        {
            using (var dbContext = new PersonDbContext())
            {
                if (!dbContext.People.Any())
                {
                    dbContext.People.Add(new Person()
                    {
                        Name = "James",
                        Age = 15
                    });
                    dbContext.People.Add(new Person()
                    {
                        Name = "Olive",
                        Age = 19
                    });
                    dbContext.People.Add(new Person()
                    {
                        Name = "John",
                        Age = 45
                    });
                    dbContext.People.Add(new Person()
                    {
                        Name = "Sarah",
                        Age = 95
                    });
                    dbContext.People.Add(new Person()
                    {
                        Name = "Ryan",
                        Age = 87
                    });
                    dbContext.People.Add(new Person()
                    {
                        Name = "Alice",
                        Age = 23
                    });
                    dbContext.People.Add(new Person()
                    {
                        Name = "Eduard",
                        Age = 54
                    });

                    dbContext.SaveChanges();
                }
            }
        }
    }
}