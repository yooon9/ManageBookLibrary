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
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly DataContext _context;

        public GetAllBooksHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books.AsQueryable();
            if (!string.IsNullOrEmpty(request.Title))
            {
                books = books.Where(a => a.Title.Contains(request.Title));
            }
            if (!string.IsNullOrEmpty(request.Author))
            {
                books = books.Where(a => a.Author.Contains(request.Author));
            }
            if (!string.IsNullOrEmpty(request.Description))
            {
                books = books.Where(a => a.Description.Contains(request.Description));
            }
            return await books.ToListAsync();
        }
    }
}
