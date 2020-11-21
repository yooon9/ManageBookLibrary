using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManageBookLibrary.Data.Context;
using ManageBookLibrary.Data.DbEntities;
using ManageBookLibrary.Dtos;
using ManageBookLibrary.MediatRepo.Queries;
using MediatR;
using ManageBookLibrary.MediatRepo.Commends;

namespace ManageBookLibrary.Controllers
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
        public async Task<ActionResult> GetBooks(string title, string author, string description)
        {
            var query = new GetAllBooksQuery(title, author, description);
            var books = await _mediator.Send(query);
            return Ok(new { books });
        } 

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var query = new GetBookByIdQuery(id);
            var book = await _mediator.Send(query);
            return book != null ? (IActionResult)Ok(new { book }) : NotFound();
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, EditBookCommand command)
        {
            command.Id = id;
            var book = await _mediator.Send(command);
            return book != null ? (IActionResult)Ok(new { book }) : NotFound();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult> PostBook(CreatBookCommand command)
        {
            var book = await _mediator.Send(command);
            return Ok(new { book });
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var query = new DeleteBookQuery(id);
            if (await _mediator.Send(query))
                return Ok();
            return NotFound();
        }


        // DELETE: api/Books/summary
        [HttpGet("Summary")]
        public async Task<ActionResult> Summary()
        {
            var query = new SummaryBooksQuery();
            return Ok(new { summary = await _mediator.Send(query) });
        }
    }
}
