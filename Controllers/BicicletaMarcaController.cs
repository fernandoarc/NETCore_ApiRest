using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_API.Model.BD;
using NetCore_API.Model.Entidades.Bike;

namespace NetCore_API.Controllers
{
    /// <summary>
    /// Controlador encargado de agregar, editar, eliminar o seleccionar
    /// todas las marcas de bicicleta configurados en sistema
    /// </summary>
    [Route("api/bike/marca")]
    [ApiController]
    public class BicicletaMarcaController : Controller
    {
        private readonly BicicletaContext _context;

        /// <summary>
        /// Constructor marca controller
        /// </summary>
        /// <param name="context"></param>
        public BicicletaMarcaController(BicicletaContext context) { _context = context; }

        /// <summary>
        /// Metodo encargado de retornar listado de marcas registradas en sistema
        /// </summary>
        /// <returns>Objeto List BicicletaMarca </returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BicicletaMarca>))]
        public async Task<IActionResult> Get()
        {
            var ListMarcas = await _context.BicicletaMarca.ToListAsync();
            return  Ok(ListMarcas);
        }

        /// <summary>
        /// Metodo encargado de retornar una marca en especifico
        /// </summary>
        /// <param name="id">Identificador de la marca a retornar</param>
        /// <returns>Objeto BicicletaMarca</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BicicletaMarca))]
        public async Task<ActionResult> Get(int id)
        {
            var ListMarcas = await _context.BicicletaMarca.FindAsync(id);
            return  Ok(ListMarcas);
        }


    }
}