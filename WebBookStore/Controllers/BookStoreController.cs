using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebBookStore.Models;

namespace WebBookStore.Controllers
{
    public class BookStoreController : ApiController
    {
        private ModelOperation modelOperation;

        public BookStoreController()
        {
            modelOperation = new ModelOperation();
        }

        public BookStoreController(ModelOperation modelOperation)
        {
            this.modelOperation = modelOperation;
        }

        public IHttpActionResult Get()
        {
            List<BookStoreModel> book = modelOperation.GetDetails();

            if (book.Count > 0)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Getbookcon(int id)
        {
            BookStoreModel model = null;

            model = modelOperation.GetBookById(id);

            if (model != null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Post([FromBody]BookStoreModel bookModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            int res = modelOperation.AddBooks(bookModel);

            if (res != 0)
            {
                return Ok("Success inserted book");
            }
            else
            {
                return BadRequest("Not Inserted");
            }
        }

        public IHttpActionResult PutIntoFavList(int id, [FromBody]BookStoreModel bookModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            int res = modelOperation.PutIntoFavList(id, bookModel);

            if (res != 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [Route("api/BookStore/GetFavList")]
        public IHttpActionResult GetFavList()
        {
            List<BookStoreModel> book = modelOperation.GetFavList();

            if (book.Count > 0)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            int res = modelOperation.Delete(id);

            if (res != 0)
            {
                return Ok("Deleted Success");
            }
            else
            {
                return BadRequest("Not Deleted");
            }
        }
    }
}