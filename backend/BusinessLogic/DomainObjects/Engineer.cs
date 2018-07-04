using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLogic.DomainObjects
{
    public class Engineer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotMapped] public string FullName => $"{FirstName} {LastName}";
    }
}
