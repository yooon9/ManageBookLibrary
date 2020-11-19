using ManageBookLibrary.Data.Context;
using ManageBookLibrary.Data.DbEntities;
using ManageBookLibrary.MediatRepo.Commends;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Handlers
{
    public class EditBookHandler : IRequestHandler<EditBookCommand, Book>
    {
        private readonly DataContext _context;

        public EditBookHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(EditBookCommand request, CancellationToken cancellationToken)
        {
            Book book = await _context.Books.FindAsync(request.Id);
            if (book == null) return null;

            book.Author = request.Author;
            book.Title = request.Title;
            book.Description = request.Description;
            book.YearPublished = request.YearPublished;
            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
            return book;
        }
    }
}
