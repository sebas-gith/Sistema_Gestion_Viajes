namespace SGV.Entities
{
    public class Destino
    {
        public int IdDestino { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public decimal PrecioBase { get; set; }
    }
}
