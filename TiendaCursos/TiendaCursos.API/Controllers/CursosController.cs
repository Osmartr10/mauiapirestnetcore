using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaCursos.API.Data;
using TiendaCursos.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public CursosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: api/<CursosController>
        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get()
        {
            var lista = await _dataContext.Cursos.ToListAsync();
            return lista;
        }

        // GET api/<CursosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> Get(int id)
        {
            var curso = await _dataContext.Cursos.FirstOrDefaultAsync(x=> x.Id==id);
            if(curso == null) { return NotFound(); }
            return Ok(curso);
        }

        // POST api/<CursosController>
        [HttpPost]
        public async Task<ActionResult> Post(Curso curso)
        {
            _dataContext.Cursos.Add(curso);
            await _dataContext.SaveChangesAsync();
            return Ok(curso);
        }

        // PUT api/<CursosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Curso curso)
        {
            _dataContext.Cursos.Update(curso);
            await _dataContext.SaveChangesAsync();
            return Ok(curso);
        }

        // DELETE api/<CursosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var curso = await _dataContext.Cursos.FirstOrDefaultAsync(x => x.Id == id);
            if (curso == null) { return NotFound(); }

            _dataContext.Cursos.Remove(curso);
            await _dataContext.SaveChangesAsync();
            return Ok(curso);
        }
    }
}
