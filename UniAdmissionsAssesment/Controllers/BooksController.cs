using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniAdmissionsAssesment.Entities.ViewModels;
using UniAdmissionsAssesment.Queries;

namespace UniAdmissionsAssesment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult> GetBooks()
        {
            var response = await _mediator.Send(new GetAllBooks());

            if (!response.Success)
                return StatusCode(response.StatusCode, response.Message);

            return Ok(response.Result);
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBook(long id)
        {
            var response = await _mediator.Send(new GetBookById 
            {
                Id = id
            });

            if (!response.Success)
                return StatusCode(response.StatusCode, response.Message);

            return Ok(response.Result);
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, UpdateBookModel book)
        {
            var response = await _mediator.Send(new UpdateBook 
            {
                Book = book,
                Id = id
            });

            if (!response.Success)
                return StatusCode(response.StatusCode, response.Message);

            return Ok(response.Result);
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostBook(CreateBookModel bookModel)
        {
            var response = await _mediator.Send(new CreateBook
            {
                Book = bookModel
            });

            if (!response.Success)
                return StatusCode(response.StatusCode, response.Message);

            return CreatedAtAction("GetBook", new { id = response.Result.Id }, response.Result);         
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var result = await _mediator.Send(new DeleteBook { BookId = id });

            if (!result.Success)
                return StatusCode(result.StatusCode, result.Message);

            return NoContent();
        }
    }
}
