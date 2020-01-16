using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class AirplaneModel
    {

        [Key] 
        public int AirplaneId { get; set; }
        public string Modelo { get; set; }
        public int QuantidadePassageiros { get; set; }
        public DateTime DtCriacao { get; set; }

    }
}
