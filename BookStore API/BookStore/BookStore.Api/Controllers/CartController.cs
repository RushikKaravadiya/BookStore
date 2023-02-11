using BookStore.Models.ViewModels;
using BookStore.Models.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Api.Controllers
{
    [Route("api")]
    [ApiController]
    
    public class CartController : Controller
    {
        private readonly CartRepository _cartRepository = new();

        //[HttpGet]
        //[Route("list")]
        //public IActionResult GetCartItems(int Userid = 0)
        //{
        //    CartRepository repo = new CartRepository();
        //    List<Cart> cart = repo.GetCartItems(Userid);
        //    return View(cart);
        //    //var keyword = "";
        //    //List<Cart> carts = _cartRepository.GetCartItems(keyword);
        //    IEnumerable<CartModel> cartModels = cart.Select(c => new CartModel(c));
        //    return Ok(cartModels);
        //}

        [HttpGet]
        [Route("list")]
        public IActionResult GetCartItems(int UserId, int pageIndex = 1, int pageSize = 10)
        {
            ListResponse<Cart> carts = _cartRepository.GetCartItems(UserId, pageIndex, pageSize);
            ListResponse<GetCartModel> cartModels = new ListResponse<GetCartModel>()
            {
                Records = carts.Records.Select(c => new GetCartModel(c.Id, c.Userid, new BookModel(c.Book), c.Quantity)).ToList(),
                TotalRecords = carts.TotalRecords
            };
            return Ok(cartModels);
        }


        //[HttpPost]
        //[Route("add")]
        //public IActionResult AddCart(CartModel model)
        //{
        //    if (model == null)
        //        return BadRequest();

        //    Cart cart = new Cart()
        //    {
        //        Id = model.Id,
        //        Quantity = 1,
        //        Bookid = model.BookId,
        //        Userid = model.UserId
        //    };
        //    cart = _cartRepository.AddCart(cart);

        //    return Ok(new CartModel(cart));
        //}

        [HttpPost]
        [Route("add")]
        public ActionResult<CartModel> AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = 1,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.AddCart(cart);
            if (cart == null)
            {
                return StatusCode(500);
            }
            return new CartModel(cart);
        }


        [HttpPut]
        [Route("update")]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest();

            Cart cart = new Cart()
            {
                Id = model.Id,
                Quantity = model.Quantity,
                Bookid = model.Bookid,
                Userid = model.Userid
            };
            cart = _cartRepository.UpdateCart(cart);

            return Ok(new CartModel(cart));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest();

            bool response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }
    }
}
