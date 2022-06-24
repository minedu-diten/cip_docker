using System.Collections.Generic;
using System.Threading.Tasks;
using apiWeb.Data;
using apiWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiWeb.Controllers
{
    [ApiController]
    [Route("v1/cip/docker/invitados")]
    public class InvitadoController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<List<Invitado>>> Get([FromServices] DataContext context)
        {
            var invitados = await context.Invitados
                .Include(p => p.Participante)
                .ToListAsync();
            return invitados;
        }

        [HttpPost]
        [Route("adicionar")]
        public async Task<ActionResult<Invitado>> Post([FromServices] DataContext context, [FromBody] Invitado model)
        {
            var hasParticipante = await context.Participantes
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ParticipanteId == model.ParticipanteId);
            if (hasParticipante == null)
                return BadRequest("Participante no encontrado");

            // El participante ya tiene un invitado
            var hasInvitado = await context.Invitados
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ParticipanteId == model.ParticipanteId);
            if (hasInvitado != null)
                return BadRequest("El participante ya tiene un invitado");

            if (ModelState.IsValid)
            {
                context.Invitados.Add(model);
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
        public async Task<ActionResult<Invitado>> Get([FromServices] DataContext context, int id)
        {
            var invitado = await context.Invitados
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.InvitadoId == id);
            if (invitado == null)
                return BadRequest("Invitado no encontrado");
            context.Invitados.Remove(invitado);

            await context.SaveChangesAsync();
            return invitado;
        }
    }
}