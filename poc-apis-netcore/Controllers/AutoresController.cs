using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using poc_apis_netcore.Contexts;
using poc_apis_netcore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace poc_apis_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        public AppDbContext Context { get; }
        public AutoresController(AppDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return Context.Autores.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = Context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;

        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            //ModelState no es necesario de netcore 2.1, por ejemplo si en la clase autor uso un [Required]
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            Context.Autores.Add(autor);
            Context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autor);

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor author)
        {
            Context.Entry(author).State = EntityState.Modified;
            Context.SaveChanges();
            return Ok();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = Context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            Context.Remove(autor);
            Context.SaveChanges();
            return Ok(autor);
        }


    }
}