using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.DbOperations;
using RestfullAPI.Operations.GenreOperations.CreateGenre;
using RestfullAPI.Operations.GenreOperations.DeleteGenre;
using RestfullAPI.Operations.GenreOperations.GetGenre;
using RestfullAPI.Operations.GenreOperations.UpdateGenre;
using static RestfullAPI.Operations.GenreOperations.GetGenre.GetGenresDetailQuery;

namespace RestfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;


        public GenreController(IBookStoreDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGenre()
        {
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("{genreId}")]
        public ActionResult GetGenreDetail([FromRoute]int genreId)
        {
            GenresDetailViewModel result;


            GetGenresDetailQuery query = new GetGenresDetailQuery(_context,_mapper);
            query.GenreId = genreId;
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();



            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody]CreateGenreModel request)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = request;

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int genreId, [FromBody] UpdateGenreModel request)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context);
            command.GenreId = genreId;
            command.Model = request;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult DeleteGenre(int genreId)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = genreId;

            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}
