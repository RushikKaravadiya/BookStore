using Microsoft.AspNetCore.Mvc;
using BookStore.Models.ViewModels;
using BookStore.Models.Models;
using BookStore.Repository;
using System.Linq;
using System.Net;

namespace BookStore.Api.Controllers
{
    [ApiController]
    [Route("api/publisher")]
    public class PublisherController : ControllerBase
    {
        PublisherRepository _publisherRepository = new PublisherRepository();

        [HttpGet]
        [Route("list")]

        public IActionResult GetPublishers(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var publisher = _publisherRepository.GetPublishers(pageIndex, pageSize, keyword);

            ListResponse<PublisherModel> listResponse = new ListResponse<PublisherModel>()
            {
                Records = publisher.Records.Select(c => new PublisherModel(c)),
                TotalRecords = publisher.TotalRecords,
            };
            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(NotFoundResult), (int)HttpStatusCode.NotFound)]
        public IActionResult GetPublisher(int id)
        {
            var publisher = _publisherRepository.GetPublisher(id);
            if (publisher == null)
                return NotFound();

            return Ok(new PublisherModel(publisher));
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddPublisher(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Contact = model.Contact,

            };
            var response = _publisherRepository.AddPublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(PublisherModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdatePublisher(PublisherModel model)
        {
            if (model == null)
                return BadRequest("Model is null");

            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
                Address =model.Address,
                Contact = model.Contact,
            };
            var response = _publisherRepository.UpdatePublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeletePublisher(int id)
        {
            if (id == 0)
                return BadRequest("id is null");

            var response = _publisherRepository.DeletePublisher(id);
            return Ok(response);
        }

    }
}

