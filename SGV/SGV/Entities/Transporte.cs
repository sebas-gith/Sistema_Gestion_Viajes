namespace SGV.Entities
{
    public class Transporte
    {
        public int TransporteId { get; set; }
        public string Tipo { get; set; }
        public string Compania { get; set; }
        public string Numero { get; set; }
        public int Capacidad { get; set; }

        public decimal Precio_unitario { get; set; }

    }
}
