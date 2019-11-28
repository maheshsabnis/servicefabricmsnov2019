using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductServ.Models;
namespace ProductServ.Services
{
    public interface IService<T,U> where T: class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(U id);
        Task<T> CreateAsync(T data);
    }

    public class DataService : IService<Product, Guid>
    {
        NoSQLDbContext ctx;
        public DataService(NoSQLDbContext ctx)
        {
            this.ctx = ctx;
            // make sure that the Database is created
            ctx.Database.EnsureCreated();
        }
        public async Task<Product> CreateAsync(Product data)
        {
            var res  = await ctx.Products.AddAsync(data);
            await ctx.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await ctx.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(Guid id)
        {
            var res = await ctx.Products.FindAsync(id);
            return res;
        }
    }
}
