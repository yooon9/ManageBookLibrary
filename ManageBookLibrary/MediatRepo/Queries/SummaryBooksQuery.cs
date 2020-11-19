using ManageBookLibrary.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Queries
{
    public class SummaryBooksQuery : IRequest<LibrarySummaryDto>
    {
    }
}
