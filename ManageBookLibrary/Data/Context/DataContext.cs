using ManageBookLibrary.Data.DbEntities;
using Microsoft.EntityFrameworkCore;


namespace ManageBookLibrary.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
