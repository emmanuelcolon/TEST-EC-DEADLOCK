using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Generales;
using Sistema.Web.Models.Generales.Persona;

namespace Sistema.Web.Controllers
{
    [Route("api/Persona")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public PersonaController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Persona/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<PersonaViewModel>> Listar()
        {
            var persona = await _context.Personas.Include(x => x.Posicion_Trabajos).ToListAsync();

            return persona.Select(c => new PersonaViewModel
            {
                PersonaId = c.PersonaId,
                NombreCompleto = c.NombreCompleto,
                PosicionTrabajoId = c.PosicionTrabajoId,
                NombrePosicionTrabajo = c.Posicion_Trabajos.Nombre
            });

        }

        // GET: api/Persona/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {

            var persona = await _context.Personas.Include(x => x.Posicion_Trabajos).Where(x => x.PosicionTrabajoId == id).FirstOrDefaultAsync();

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(new PersonaViewModel {
                PersonaId = persona.PersonaId,
                NombreCompleto = persona.NombreCompleto,
                PosicionTrabajoId = persona.PosicionTrabajoId,
                NombrePosicionTrabajo = persona.Posicion_Trabajos.Nombre
            });
        }

        // PUT: api/Persona/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] Persona model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.PersonaId <= 0)
            {
                return BadRequest();
            }

            var persona = await _context.Personas.FirstOrDefaultAsync(c => c.PersonaId == model.PersonaId);

            if (persona == null)
            {
                return NotFound();
            }

            persona.NombreCompleto = model.NombreCompleto;
            persona.PosicionTrabajoId = model.PosicionTrabajoId;

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

        // POST: api/Persona/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] Persona model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Persona persona = new Persona
            {
                NombreCompleto = model.NombreCompleto,
                PosicionTrabajoId = model.PosicionTrabajoId
            };

            _context.Personas.Add(persona);
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