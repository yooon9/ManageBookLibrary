using ManageBookLibrary.Data.DbEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Queries
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int BookId { get; }

        public GetBookByIdQuery(int bookIdid)
        {
            BookId = bookIdid;
        }
    }
}
