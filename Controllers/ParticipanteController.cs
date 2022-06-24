using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiWeb.Data;
using apiWeb.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiWeb.Controllers
{
    [ApiController]
    [Route("v1/cip/docker/participantes")]
    public class ParticipanteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<List<Participante>>> Get([FromServices] DataContext context)
        {
            var participantes = await context.Participantes.ToListAsync();
            return participantes;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Participante>> Post([FromServices] DataContext context, [FromBody] Participante model)
        {
            if (ModelState.IsValid)
            {
                context.Participantes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("remover/{id:int}")]
        public async Task<ActionResult<Participante>> Get([FromServices] DataContext context, int id)
        {
            // Remove participante
            var participante = await context.Participantes
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ParticipanteId == id);
            if (participante == null)
                return BadRequest("Participante no encontrado");
            context.Participantes.Remove(participante);

            // Remove invitado del participante
            var invitado = await context.Invitados
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ParticipanteId == id);
            if (invitado != null)
                context.Invitados.Remove(invitado);

            await context.SaveChangesAsync();
            return participante;
        }
    }
}