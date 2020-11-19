using ManageBookLibrary.Data.Context;
using ManageBookLibrary.Data.DbEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBookLibrary.Data
{
    public class SeedDefaultData
    {
        private readonly DataContext _context;

        public SeedDefaultData(DataContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (!_context.Books.Any())
            {
                var bookData = System.IO.File.ReadAllText("Data/bookSeedData.json");
                var books = JsonConvert.DeserializeObject<List<Book>>(bookData);
                _context.AddRange(books);
                _context.SaveChanges();
            }
        }
    }
}
