namespace WebApplication4.Models
{
    public class Author
    {
        public Author()
        {
            AuthorBooks = new List<Author>();
        }
        public int Id { get; set; } = 0;
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Author> AuthorBooks { get; set; }

    }
}
