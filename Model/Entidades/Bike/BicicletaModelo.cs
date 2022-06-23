using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Model.Entidades.Bike
{
    public class BicicletaModelo
    {
        [Key]
        public int IdBicicletaModelo { get; set; }
        public string Nombre { get; set; }
        public int Anio { get; set; }
        public int IdBicicletaMarca { get; set; }
        public BicicletaMarca BicicletaMarca { get; set; }
        public int IdBicicletaCategoria { get; set; }
        public BicicletaCategoria BicicletaCategoria { get; set; }
        public List<Bicicleta> Bicicleta { get; set; }
    }
}