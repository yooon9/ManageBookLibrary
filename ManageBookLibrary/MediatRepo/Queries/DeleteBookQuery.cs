using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Queries
{
    public class DeleteBookQuery : IRequest<bool>
    {
        public int BookId { get; }

        public DeleteBookQuery(int bookIdid)
        {
            BookId = bookIdid;
        }
    }
}
