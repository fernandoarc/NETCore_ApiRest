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
        public async Task<IActionResult> Get(int id)
        {
            var ListMarcas = await _context.BicicletaMarca.FindAsync(id);
            return  Ok(ListMarcas);
        }

        /// <summary>
        /// Metodo encargado de registrar una nueva marca en sistema
        /// </summary>
        /// <param name="bicicletaMarca">Objeto Bicicle Marca a registrar en sistema</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Add([FromBody] BicicletaMarca bicicletaMarca)
        {
            if (ModelState.IsValid)
            {
                _context.BicicletaMarca.Add(bicicletaMarca);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Metodo encargado de actualizar una marca ya existente
        /// </summary>
        /// <param name="bicicletaMarca">Objeto marca a actualizar</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Edit([FromBody]BicicletaMarca bicicletaMarca)
        {
            var bicicletaMarcaSql = await _context.BicicletaMarca.FindAsync(bicicletaMarca.IdBicicletaMarca);
            if (bicicletaMarcaSql == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    bicicletaMarcaSql.Nombre = bicicletaMarca.Nombre;
                    _context.Update(bicicletaMarcaSql);
                    await _context.SaveChangesAsync();
                }
                catch (System.Exception ex)
                {
                    
                    return BadRequest(ex.Message);
                }
            }
            return Ok();
        }
    }
}