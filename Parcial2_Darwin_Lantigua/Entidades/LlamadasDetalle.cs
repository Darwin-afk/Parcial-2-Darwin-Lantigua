using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Parcial2_Darwin_Lantigua.Entidades
{
    public class LlamadasDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int LlamadaId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public LlamadasDetalle()
        {
            DetalleId = 0;
            LlamadaId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }

        public LlamadasDetalle(string problema, string solucion)
        {
            DetalleId = 0;
            LlamadaId = 0;
            Problema = problema;
            Solucion = solucion;
        }
    }
}
