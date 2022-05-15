namespace WebApplication4.Models
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public int MagazineId { get; set; }
        public int AuthorId { get; set; }
        public virtual Author author { get; set; }
        public virtual Magazine magazine { get; set; }
    }
}
