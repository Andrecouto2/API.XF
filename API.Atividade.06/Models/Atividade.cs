using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Atividade._06.Models
{
    public class Atividade
    {
        public Atividade() { }

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataEntrega { get; set; }
        public Boolean TipoAvaliacao { get; set; }
        public String Descricao { get; set; }
        public int Nota { get; set; }
    }

}