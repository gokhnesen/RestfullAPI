﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RestfullAPI.BookOperations.Commands.CreateBook;
using RestfullAPI.BookOperations.Commands.DeleteBook;
using RestfullAPI.BookOperations.Commands.GetBook;
using RestfullAPI.BookOperations.Commands.UpdateBook;
using RestfullAPI.DbOperations;
using static RestfullAPI.BookOperations.Commands.CreateBook.CreateBookCommand;

namespace RestfullAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookById([FromRoute] int bookId)
        {
            BookDetailViewModel result;
    
          
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = bookId;
                result = query.Handle();

            
      
            return Ok(result);
        }

        [HttpPut("update/{bookId}")]
        public IActionResult UpdateBooks([FromBody] UpdateBookModel request, int bookId)
        {

          
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = bookId;
                command.Model = request;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            
      

            return Ok(request);

       


        }
        [HttpPost("add")]
        public IActionResult AddBooks([FromBody] CreateBookModel request)
        {
            CreateBookCommand command = new CreateBookCommand(_context);

           
                command.Model = request;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
       



                 return Ok(request);
        }

        [HttpDelete("{bookId}")]
        public async Task<IActionResult> DeleteBooks(int bookId)
        {

           
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = bookId;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
           

                
            
                 return Ok();


      
        }



    }
}
