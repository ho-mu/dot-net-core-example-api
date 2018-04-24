using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using System.Linq;

namespace MovieApi.Controllers
{
    [Route("api/movie")]
    public class MovieController : Controller
    {
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;

            if (_context.Movies.Count() == 0)
            {
                _context.Movies.Add(new MovieClass { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<MovieClass> GetAll()
        {
            return _context.Movies.ToList();
        }


        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetById(long id)
        {
            var item = _context.Movies.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }


}



