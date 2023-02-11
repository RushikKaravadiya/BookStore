using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Repository
{
    public class CartRepository : BaseRepository
    {
        public ListResponse<Cart> GetCartItems(int UserId, int pageIndex, int pageSize)
        {
            //var query = _context.Carts.Include(c => c.Book).Where(c => c.Userid = UserId).AsQueryable
            var query = _context.Carts.Where(c => c.Userid == UserId).AsQueryable();
            return new ListResponse<Cart>()
            {
                Records = (from Cart in query.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                           join Book in _context.Books on Cart.Bookid equals Book.Id
                           select new Cart
                           {
                               Id = Cart.Id,
                               Userid = Cart.Userid,
                               Bookid = Cart.Bookid,
                               Quantity = Cart.Quantity,
                               Book = Book
                           }).ToList(),
                TotalRecords = query.Count(),
            };
        }




        public Cart GetCarts(int id)
        {
            return _context.Carts.FirstOrDefault(c => c.Id == id);
        }

        public Cart AddCart(Cart category)
        {
            var entry = _context.Carts.Add(category);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Cart UpdateCart(Cart category)
        {
            var id = category.Id;
            var uc = _context.Carts.Where(x=> x.Id==id).FirstOrDefault();  
            uc.Quantity = category.Quantity;
            var entry = _context.Carts.Update(uc);
            _context.SaveChanges();
            return entry.Entity;
        }

        public bool DeleteCart(int id)
        {
            var cart = _context.Carts.FirstOrDefault(c => c.Id == id);
            if (cart == null)
                return false;

            _context.Carts.Remove(cart);
            _context.SaveChanges();
            return true;
        }
    }
}
