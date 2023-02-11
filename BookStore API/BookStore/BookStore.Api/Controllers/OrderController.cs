using BookStore.Models.ViewModels;
using BookStore.Models.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.Controllers
{
    [Route("api/order")]
    [ApiController]

    public class OrderController : Controller
    {
        private readonly OrderRepository _orderRepository = new();

        [HttpGet]
        [Route("list")]
        public IActionResult GetOrderdtlItems(string keyword)
        {
            List<Orderdtl> orders = _orderRepository.GetOrderdtlItems(keyword);
            IEnumerable<OrderModel> orderModels = orders.Select(c => new OrderModel(c));
            return Ok(orderModels);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddOrder(Orderdtl model)
        {
            if (model == null)
                return BadRequest();

            Orderdtl order = new Orderdtl()
            {
                Id = model.Id,
                Book = model.Book,
                Ordermstid = model.Ordermstid,
                Quantity = model.Quantity,
                Price = model.Price,
                Totalprice = model.Totalprice
            };
            order = _orderRepository.AddOrder(order);

            return Ok(new OrderModel(order));
        }
    }
}
