using Core.Entities;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
       // public string? Passaword { get; set; }
        public byte[]? PassawordHash { get; set; }
        public byte[]? PassawordSalt { get; set; }
        public bool Status { get; set; }
    }
}
