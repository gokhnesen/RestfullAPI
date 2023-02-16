using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestfullAPI.DbOperations;

namespace RestfullAPI.Operations.AuthorOperations.GetAuthor
{
    public class GetAuthorQuery
    {
   
            private readonly IBookStoreDbContext _context;
            private readonly IMapper _mapper;
            public GetAuthorQuery(IBookStoreDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public List<AuthorViewModel> Handle()
            {
                var author = _context.Authors.OrderBy(x => x.Id).ToList();
                List<AuthorViewModel> authorViewModel = _mapper.Map<List<AuthorViewModel>>(author);

                return authorViewModel;
            }
        }


        public class AuthorViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string DateOfBirth { get; set; }
    }
    }

