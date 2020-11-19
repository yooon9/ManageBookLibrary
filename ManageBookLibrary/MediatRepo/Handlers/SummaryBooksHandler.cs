using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ManageBookLibrary.Data.Context;
using ManageBookLibrary.Data.DbEntities;
using ManageBookLibrary.Dtos;
using ManageBookLibrary.MediatRepo.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ManageBookLibrary.MediatRepo.Handlers
{
    public class SummaryBooksHandler : IRequestHandler<SummaryBooksQuery, LibrarySummaryDto>
    {
        private readonly DataContext _context;

        public SummaryBooksHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<LibrarySummaryDto> Handle(SummaryBooksQuery request, CancellationToken cancellationToken)
        {
            return new LibrarySummaryDto
            {
                NumberOfBooks = await _context.Books.CountAsync(),
                NumberOfDifferentAuthors = await _context.Books.GroupBy(a => a.Author).CountAsync()
            };
        }
    }
}
