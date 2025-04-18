namespace SGV.Entities
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdDestino { get; set; }
        public int IdTransporte { get; set; }
        public DateTime FechaReserva { get; set; }
        public int CantidadPersonas { get; set; }
        public decimal Total { get; set; }
    }
}
