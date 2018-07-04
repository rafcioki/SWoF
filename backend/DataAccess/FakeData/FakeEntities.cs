using System.Collections.Generic;
using BusinessLogic.DomainObjects;

namespace DataAccess.FakeData
{
    public class FakeEntities
    {
        public static IList<Engineer> Engineers =>
            new List<Engineer>
            {
                new Engineer {Id = 1, FirstName = "Bradley", LastName = "Buckley"},
                new Engineer {Id = 2, FirstName = "Melissa", LastName = "Hancock"},
                new Engineer {Id = 3, FirstName = "Chelsea", LastName = "Davidson"},
                new Engineer {Id = 4, FirstName = "Hayden", LastName = "Akhtar"},
                new Engineer {Id = 5, FirstName = "Lucy", LastName = "Wade"},
                new Engineer {Id = 6, FirstName = "James", LastName = "Harding"},
                new Engineer {Id = 7, FirstName = "Elizabeth", LastName = "Pratt"},
                new Engineer {Id = 8, FirstName = "Samuel", LastName = "Jenkins"},
                new Engineer {Id = 9, FirstName = "Brian", LastName = "Shugart"},
                new Engineer {Id = 10, FirstName = "Owen", LastName = "Stephenson"}
            };
    }
}
