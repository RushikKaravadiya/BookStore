using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.ViewModels;

namespace BookStore.Models.Models
{
    public class CartModel
    {
        public CartModel() { }

        public CartModel(Cart cart)
        {
            this.Id = cart.Id;
            this.Userid = cart.Userid;
            this.Bookid = cart.Bookid;
            this.Quantity=cart.Quantity;
        }

        public int Id { get; set; }
        //public int UserId { get; set; }
        public int Userid { get; set; }
        //public int BookId { get; set; }
        public int Bookid { get; set; }
        public int Quantity { get; set; }
    }
}
