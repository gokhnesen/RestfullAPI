using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.BookOperations.Commands.CreateBook;
using RestfullAPI.BookOperations.Commands.DeleteBook;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.BookOperations.Commands.UpdateBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Operations.AuthorOperations.CreateAuthor;
using RestfullAPI.Operations.AuthorOperations.DeleteAuthor;
using RestfullAPI.Operations.AuthorOperations.GetAuthor;
using RestfullAPI.Operations.AuthorOperations.UpdateAuthor;
using static RestfullAPI.BookOperations.Commands.CreateBook.CreateBookCommand;
using static RestfullAPI.Operations.AuthorOperations.GetAuthor.GetAuthorDetailQuery;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthorById([FromRoute] int authorId)
        {
            AuthorDetailViewModel result;


            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = authorId;
            GetAuthorDetailValidator validator = new GetAuthorDetailValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

        [HttpPut("update/{authorId}")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorModel request, int authorId)
        {


            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = authorId;
            command.Model = request;
            UpdateAuthorValidator validator = new UpdateAuthorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();



            return Ok(request);




        }

        [HttpPost("add")]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel request)
        {


            CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
            command.Model = request;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok(request);
        }

        [HttpDelete("{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {


            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.AuthorId = authorId;
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();



        }
    }
}
