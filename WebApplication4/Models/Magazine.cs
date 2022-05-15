namespace WebApplication4.Models
{
    public class Magazine
    {
        public Magazine() {
        AuthorBook = new List<Author>();
        }
        public int Id { get; set; } = 0;
        public string Title { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual ICollection<Author> AuthorBook { get; set; }


    }
}
