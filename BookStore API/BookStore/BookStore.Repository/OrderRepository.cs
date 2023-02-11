using BookStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class OrderRepository : BaseRepository
    {
        public List<Orderdtl> GetOrderdtlItems(string keyword)
        {
            keyword = keyword?.ToLower()?.Trim();
            var query = _context.Orderdtls.Include(c => c.Book).Where(c => keyword == null || c.Book.Name.ToLower().Contains(keyword)).AsQueryable();
            return query.ToList();
        }

        public Orderdtl GetOrders(int id)
        {
            return _context.Orderdtls.FirstOrDefault(c => c.Id == id);
        }

        public Orderdtl AddOrder(Orderdtl category)
        {
            var entry = _context.Orderdtls.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }


    }
}
