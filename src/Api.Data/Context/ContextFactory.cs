using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var conectionString = "Server=.\\SQLEXPRESS2017;Database=sdAPI;User Id=sa;Password=senha";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer(conectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
