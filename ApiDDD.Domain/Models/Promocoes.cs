using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDDD.Domain.Models
{
    [Table("Promocao")]
    public class Promocoes : BaseEntity
    {
        [Key]
        [Column("ID_CONFIRMACAO")]        
        public int IdConfirmacao { get; set; }
        
        [Column("USUARIO")]        
        public string Usuario { get; set; }       
       
        [Column("LOJA")]
        public int Loja { get; set; }

        [Column("DATAHORA")]
        public DateTime DataHora { get; set; }

        [Column("NOMEARQUIVO")]
        public string NomeArquivo { get; set; }

        [Column("STATUS")]
        public int Status { get; set; }
      

    }
}