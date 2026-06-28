namespace SistemaFacturacion.Models
{
    public class Factura
    {
        public int Id { get; set; }

        public string Cliente { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal Subtotal
        {
            get { return Cantidad * Precio; }
        }

        public decimal ITBIS
        {
            get { return Subtotal * 0.18m; }
        }

        public decimal Total
        {
            get { return Subtotal + ITBIS; }
        }
    }
}
