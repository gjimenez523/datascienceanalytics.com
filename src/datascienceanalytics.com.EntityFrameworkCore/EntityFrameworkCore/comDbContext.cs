using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace datascienceanalytics.com.EntityFrameworkCore
{
    public class comDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public comDbContext(DbContextOptions<comDbContext> options) 
            : base(options)
        {

        }
    }
}
