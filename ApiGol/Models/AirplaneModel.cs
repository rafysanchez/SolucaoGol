using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGol.Models
{
    public class AirplaneModel
    {
        [Key]
        public int AirplaneId { get; set; }
        public string Modelo { get; set; }
        public int QuantidadePassageiros { get; set; }
        public string DtCriacao { get; set; }
    }
}
