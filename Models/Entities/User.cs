namespace markamed_api.Models.Entities
{
    public class User : EntityBase
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Navigation properties
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}