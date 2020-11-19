using ManageBookLibrary.Data.DbEntities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageBookLibrary.MediatRepo.Commends
{
    public class CreatBookCommand : IRequest<Book>
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Author { get; set; }
        public int YearPublished { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
