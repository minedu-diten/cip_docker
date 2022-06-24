using System;
using System.ComponentModel.DataAnnotations;

namespace apiWeb.Models
{
    public class Total
    {
        public double TotalRecogido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Valor inválido")]
        public double TotalGastoComida { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Range(0, int.MaxValue, ErrorMessage = "Valor inválido")]
        public double TotalGastoBebida { get; set; }

        public double TotalGasto
        {
            get
            {
                return Math.Round(TotalGastoComida + TotalGastoBebida, 2);
            }
        }

        public double Saldo
        {
            get
            {
                return Math.Round(TotalRecogido - (TotalGastoComida + TotalGastoBebida), 2);
            }
        }
    }
}