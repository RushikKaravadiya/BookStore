using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;
using BookStore.Models.ViewModels;

namespace BookStore.Models.Models
{
    public class OrderModel
    {
        public OrderModel() { }

        public OrderModel(Orderdtl order)
        {
            this.Bookid = order.Bookid;
            this.Ordermstid = order.Ordermstid;
            this.Id = order.Id;
            this.Quantity= order.Quantity;
            this.Price= order.Price;
            this.Totalprice= order.Totalprice;

        }
        public int Id { get; set; }
        public int? Bookid { get; set; }
        public int? Quantity { get; set; }
        public decimal? Totalprice { get; set; }
        public int? Ordermstid { get; set; }
        public decimal? Price { get; set; }


    }
}
