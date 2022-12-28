using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Number { get; set; }
    }
}
