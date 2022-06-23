using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Model.BD;
using NetCore_API.Model.Entidades.Bike;

namespace NetCore_API.Controllers
{
    [Route("api/bike/marca")]
    [ApiController]
    public class BicicletaMarcaController : Controller
    {
        private readonly BicicletaContext _context;

        public BicicletaMarcaController(BicicletaContext context) { _context = context; }

        /// <summary>
        /// Metodo que retorna listado de marcas registradas en sistema
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ListMarcas = await _context.BicicletaMarca.ToListAsync();
            return  Ok(ListMarcas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var ListMarcas = await _context.BicicletaMarca.FindAsync(id);
            return  Ok(ListMarcas);
        }


    }
}