using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parcial2_Darwin_Lantigua.Entidades
{
    public class Llamadas
    {
        [Key]
        public int LlamadaId { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("LlamadaId")]
        public virtual List<LlamadasDetalle> Detalle { get; set; }

        public Llamadas()
        {
            LlamadaId = 0;
            Descripcion = string.Empty;

            Detalle = new List<LlamadasDetalle>();
        }

    }
}
