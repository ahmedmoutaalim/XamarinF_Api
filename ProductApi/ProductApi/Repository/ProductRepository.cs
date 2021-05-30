using ProductApi.Models;
using Microsoft.EntityFrameworkCore;
using ProductApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Repository
{
    public class ProductRepository : IproductRepository
    {
        private readonly productContext _context;

        public ProductRepository(productContext context)
        {
            _context = context;
        }

        public async Task<products> Create(products book)
        {
            _context.Product.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.Product.FindAsync(id);
            _context.Product.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<products>> Get()
        {
            return await _context.Product.ToListAsync();
        }

        public async Task<products> Get(int id)
        {
            return await _context.Product.FindAsync(id);
        }

        public async Task Update(products product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
