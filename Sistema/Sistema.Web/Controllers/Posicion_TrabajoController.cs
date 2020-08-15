using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Generales;
using Sistema.Web.Models.Generales.Posicion_Trabajo;

namespace Sistema.Web.Controllers
{
    [Route("api/Posicion-Trabajo")]
    [ApiController]
    public class Posicion_TrabajoController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public Posicion_TrabajoController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Posicion-Trabajo/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<Posicion_TrabajoViewModel>> Listar()
        {
            var posicion_trabajo = await _context.Posicion_Trabajos.ToListAsync();

            return posicion_trabajo.Select(c => new Posicion_TrabajoViewModel
            {
                PosicionTrabajoId = c.PosicionTrabajoId,
                Nombre = c.Nombre
            });

        }

        // GET: api/Posicion-Trabajo/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var posicion_trabajo = await _context.Posicion_Trabajos.FindAsync(id);

            if (posicion_trabajo == null)
            {
                return NotFound();
            }

            return Ok(new Posicion_TrabajoViewModel {
                PosicionTrabajoId = posicion_trabajo.PosicionTrabajoId,
                Nombre = posicion_trabajo.Nombre
            });
        }

        // PUT: api/Posicion-Trabajo/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] Posicion_Trabajo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.PosicionTrabajoId <= 0)
            {
                return BadRequest();
            }

            var posicion_trabajo = await _context.Posicion_Trabajos.FirstOrDefaultAsync(c => c.PosicionTrabajoId == model.PosicionTrabajoId);

            if (posicion_trabajo == null)
            {
                return NotFound();
            }

            posicion_trabajo.Nombre = model.Nombre;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Posicion-Trabajo/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] Posicion_Trabajo model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Posicion_Trabajo posicion_trabajo = new Posicion_Trabajo
            {
                Nombre = model.Nombre
            };

            _context.Posicion_Trabajos.Add(posicion_trabajo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}