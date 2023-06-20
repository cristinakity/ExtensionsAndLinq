namespace ExtensionsAndLinq
{
    public class Venta
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string Category { get; set; }
        public string Department { get; set; } 
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; } 
        public string TipoDeVenta { get; set; }
    }
}
