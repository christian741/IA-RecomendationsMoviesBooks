namespace MovBooks.Core.Entities
{
    public class GenreMovies : BaseEntity
    {
        public GenreMovies()
        {
        }
        public int IdGenre { get; set; }
        public int IdMovie { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
