using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Model.Entidades.Bike
{
    public class BicicletaMarca
    {
        [Key]
        public int IdBicicletaMarca { get; set; }
        public string Nombre { get; set; }
        public List<BicicletaModelo> BicicletaModelo { get; set; }
    }
}