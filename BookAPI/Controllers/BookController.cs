using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookLibrary;
using BookAPI.Managers;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookManager bookManager = new BookManager();
        public static Dictionary<string, Book> BooksCatalog = new Dictionary<string, Book>();
        // GET: api/<BookController>
        [HttpGet]
        public ActionResult<string> Get()
        {
            string jsonString = JsonSerializer.Serialize(bookManager.GetAll());
            return Ok(jsonString);
        }

        // GET api/<BookController>/5
        [HttpGet("{isbn13}")]
        public ActionResult<string> Get(string isbn13)
        {
            string jsonString;
            if (BooksCatalog.ContainsKey(isbn13))
            {
                jsonString = JsonSerializer.Serialize(bookManager.GetBook(isbn13));
                return Ok(jsonString);
            }
            else return BadRequest();
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult Post([FromBody] Book value)
        {
            if (!BooksCatalog.ContainsKey(value.ISBN13)) 
            {
                bookManager.Create(value); 
                return NoContent(); 
            }
            else return BadRequest();
        }

        // PUT api/<BookController>/5
        [HttpPut("{isbn13}")]
        public ActionResult Put(string isbn13, [FromBody] Book value)
        {
            if (BooksCatalog.ContainsKey(value.ISBN13))
            {
                bookManager.Update(isbn13, value);
                return NoContent();
            }
            else return BadRequest();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{isbn13}")]
        public ActionResult Delete(string isbn13)
        {
            if (BooksCatalog.ContainsKey(isbn13))
            {
                bookManager.Delete(isbn13);
                return NoContent();
            }
            else return BadRequest();
        }
    }
}
