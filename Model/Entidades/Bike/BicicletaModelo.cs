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
    }
}