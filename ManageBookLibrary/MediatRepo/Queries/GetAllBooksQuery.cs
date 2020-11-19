using ManageBookLibrary.Data.DbEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Queries
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
        public string Title { get; }
        public string Author { get; }
        public string Description { get; }

        public GetAllBooksQuery(string title, string author, string description)
        {
            Title = title;
            Author = author;
            Description = description;
        }
    }
}
