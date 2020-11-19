using ManageBookLibrary.Data.Context;
using ManageBookLibrary.Data.DbEntities;
using ManageBookLibrary.MediatRepo.Commends;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Handlers
{
    public class CreateBookHandler : IRequestHandler<CreatBookCommand, Book>
    {
        private readonly DataContext _context;

        public CreateBookHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(CreatBookCommand request, CancellationToken cancellationToken)
        {
            Book book = new Book
            {
                Author = request.Author,
                Title = request.Title,
                Description = request.Description,
                YearPublished = request.YearPublished
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}
