using AutoMapper;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.Entities;
using static RestfullAPI.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace RestfullAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Books>();
            //CreateMap<Books,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
        }
    }
}
