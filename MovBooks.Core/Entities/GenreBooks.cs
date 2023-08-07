namespace MovBooks.Core.Entities
{
    public class GenreBooks : BaseEntity
    {
        public GenreBooks()
        {
        }

        public int IdGenre { get; set; }
        public int IdBook { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Book Book { get; set; }
    }
}
