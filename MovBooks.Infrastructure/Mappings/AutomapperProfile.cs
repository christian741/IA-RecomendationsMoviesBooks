using AutoMapper;
using MovBooks.Core.DTOs;
using MovBooks.Core.Entities;

namespace MovBooks.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
           
            //Users
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<PasswordRecovery, PasswordRecoveryDto>().ReverseMap();
            //Movies
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<ViewsMovies, ViewsMoviesDto>().ReverseMap();
            CreateMap<RatingMovie, RatingMovieDto>().ReverseMap();
            //Books
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<ViewsBooks, ViewsBooksDto>().ReverseMap();
            CreateMap<RatingBook, RatingBookDto>().ReverseMap();


            //Configuration
            CreateMap<Gender, GenderDto>().ReverseMap();
            CreateMap<Parameter, ParameterDto>().ReverseMap();
            CreateMap<Pqr, PqrDto>().ReverseMap();
        }
    }
}
