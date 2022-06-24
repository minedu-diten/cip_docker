using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiWeb.Data;
using apiWeb.Models;
using System.Threading.Tasks;

namespace apiWeb.Controllers
{
    [ApiController]
    [Route("v1/cip/docker/totales")]
    public class TotalController : ControllerBase
    {
        [HttpPost]
        [Route("resumen")]
        public async Task<ActionResult<Total>> Post([FromServices] DataContext context, [FromBody] Total model)
        {
            int valorPorPersona = 20;
            int valorPorPersonaQueNoBebe = 10;

            if (ModelState.IsValid)
            {
                var participantes = await context.Participantes.ToListAsync();
                var invitados = await context.Invitados.ToListAsync();

                foreach (var participante in participantes)
                {
                    if (participante.ConsumeBebidaAlcoholica)
                        model.TotalRecogido += valorPorPersona;
                    else
                        model.TotalRecogido += valorPorPersonaQueNoBebe;
                }

                foreach (var invitado in invitados)
                {
                    if (invitado.ConsumeBebidaAlcoholica)
                        model.TotalRecogido += valorPorPersona;
                    else
                        model.TotalRecogido += valorPorPersonaQueNoBebe;
                }

                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}