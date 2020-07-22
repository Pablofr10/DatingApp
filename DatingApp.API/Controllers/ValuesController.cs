using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetValue()
        {
            var values = await _context.Values.ToListAsync();
           
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            var valor = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            
            if (valor == null)
            {
                return NotFound("Valor não encontrado");
            }

            return Ok(valor);
        }
    }
}