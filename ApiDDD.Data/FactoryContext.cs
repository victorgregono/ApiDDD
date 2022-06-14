using Microsoft.EntityFrameworkCore;
using ApiDDD.Domain.Models;
//using System.Data.Entity;

namespace ApiDDD.Data
{
    public class FactoryContext : DbContext
    {
        public FactoryContext(DbContextOptions<FactoryContext> options) : base(options)
        { }

        public virtual DbSet<Promocoes> Promocoes { get; set; }
    }
}