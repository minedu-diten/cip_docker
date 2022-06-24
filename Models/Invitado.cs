using System.ComponentModel.DataAnnotations;

namespace apiWeb.Models
{
    public class Invitado
    {
        [Key]
        public int InvitadoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(60, ErrorMessage = "Este campo debe contener entre 3 y 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo debe contener entre 3 y 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool ConsumeBebidaAlcoholica { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Participante inválido")]
        public int ParticipanteId { get; set; }

        public Participante Participante { get; set; }
    }
}