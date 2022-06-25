using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NetCore_API.Model.Entidades.Bike
{
    public class BicicletaMarca
    {
        [Key]
        public int IdBicicletaMarca { get; set; }
        public string Nombre { get; set; }
        protected internal List<BicicletaModelo> BicicletaModelo { get; set; }
    }
}