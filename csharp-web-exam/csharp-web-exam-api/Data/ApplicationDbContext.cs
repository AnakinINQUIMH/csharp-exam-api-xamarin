using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_web_exam_api
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BirdsModel> Birds { get; set; }
        public DbSet<TypeBirdModel> TypeBirds { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
