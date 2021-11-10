using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaWebVuelos.Models
{
    
    public class Vuelo

    {
        public int Id { get; set; }

        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }

        [Required]
        public string Destino { get; set; }
        [Required]
        public string Origen { get; set; }

        [Range(100, 1000, ErrorMessage = "The field PagesNumber must be between 100 and 1000")]
        public string Matricula { get; set; }



    }
}