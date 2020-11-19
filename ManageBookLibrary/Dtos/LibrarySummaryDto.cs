using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBookLibrary.Dtos
{
    public class LibrarySummaryDto
    {
        public int NumberOfBooks { get; set; }
        public int NumberOfDifferentAuthors { get; set; }
    }
}
