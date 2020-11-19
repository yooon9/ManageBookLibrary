using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManageBookLibrary.Data.Context;
using ManageBookLibrary.Data.DbEntities;
using ManageBookLibrary.MediatRepo.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManageBookLibrary.MediatRepo.Handlers
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly DataContext _context;

        public GetBookByIdHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books.FindAsync(request.BookId);
        }
    }
}
