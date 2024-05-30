using CRUD_APP.Context;
using CRUD_APP.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_APP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController(DataContext dataContext) : ControllerBase
    {
        private readonly DataContext _dataContext = dataContext;

        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> GetAllSuperHeros()
        {
            var heros = await _dataContext.Superheroes.ToListAsync();
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetSuperHeroById(int id)
        {
            var hero = await _dataContext.Superheroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(hero);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Superhero>> CreateSuperHero(Superhero superhero)
        {
            _dataContext.Superheroes.Add(superhero);
            await _dataContext.SaveChangesAsync();
            return Ok(superhero);
        }

        [HttpPut]
        public async Task<ActionResult<Superhero>> UpdateSuperHero(Superhero superhero)
        {
            var hero = await _dataContext.Superheroes.FindAsync(superhero.Id);

            if (hero == null)
            {
                return NotFound();
            }
            else
            {
                hero.Name = superhero.Name;
                hero.Place = superhero.Place;

                await _dataContext.SaveChangesAsync();
                return Ok(superhero);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var hero = await _dataContext.Superheroes.FindAsync(id);

            if (hero == null)
            {
                return NotFound();
            }
           
             _dataContext.Superheroes.Remove(hero);
            await _dataContext.SaveChangesAsync();
            return Ok();
            
        }
    }
}
