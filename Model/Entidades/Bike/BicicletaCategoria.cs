using System.ComponentModel.DataAnnotations;

namespace NetCore_API.Model.Entidades.Bike
{
    public class BicicletaCategoria
    {
        [Key]
        public int IdBicicletaCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}