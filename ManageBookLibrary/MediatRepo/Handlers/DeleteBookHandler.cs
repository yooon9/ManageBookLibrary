using ManageBookLibrary.Data.Context;
using ManageBookLibrary.Data.DbEntities;
using ManageBookLibrary.MediatRepo.Commends;
using ManageBookLibrary.MediatRepo.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Handlers
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookQuery, bool>
    {
        private readonly DataContext _context;

        public DeleteBookHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.BookId);
            if (book == null)
            {
                return false;
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
