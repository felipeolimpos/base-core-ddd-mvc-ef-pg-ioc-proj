using CoreBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreBase.Infra.Data.Context
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
        }

        public CoreContext() : base()
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
