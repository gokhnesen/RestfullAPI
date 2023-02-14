using AutoMapper;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.Entities;
using RestfullAPI.Operations.AuthorOperations.CreateAuthor;
using RestfullAPI.Operations.AuthorOperations.GetAuthor;
using RestfullAPI.Operations.GenreOperations.CreateGenre;
using RestfullAPI.Operations.GenreOperations.GetGenre;
using static RestfullAPI.BookOperations.Commands.CreateBook.CreateBookCommand;
using static RestfullAPI.Operations.AuthorOperations.GetAuthor.GetAuthorDetailQuery;
using static RestfullAPI.Operations.GenreOperations.GetGenre.GetGenresDetailQuery;

namespace RestfullAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Books>();
            CreateMap<CreateGenreModel,Genre>();
            CreateMap<CreateAuthorModel,Author>();
            CreateMap<Books, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest=>dest.Author,opt=>opt.MapFrom(src=>src.Author.Name+" "+src.Author.Surname));
            CreateMap<Books, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name+" "+src.Author.Surname));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenresDetailViewModel>();
            CreateMap<Author, AuthorDetailViewModel>();
            CreateMap<Author, AuthorViewModel>();
        }
    }
}
