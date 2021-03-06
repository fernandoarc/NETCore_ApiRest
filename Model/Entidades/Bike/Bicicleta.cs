using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Model.Entidades.Bike
{
    public class Bicicleta
    {
        [Key]
        public int IdBicicleta { get; set; }
        public int IdBicicletaModelo { get; set; }
        public BicicletaModelo BicicletaModelo { get; set; }
        public string Serial { get; set; }
        public bool Vigente { get; set; }
    }
}