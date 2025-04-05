namespace App_ListasDEnlazadas.Models
{
    public class Nodo
    {
        public object Informacion { get; set; }
       // public Nodo? Referencia { get; set; }
        public Nodo? Siguiente { get; set; }
        public Nodo? Anterior { get; set; }
        public Nodo()
        {
            Informacion = string.Empty;
           // Referencia = null;
            Siguiente = null;
            Anterior = null;
        }

        public Nodo(object informacion)
        {
            Informacion = informacion;
           // Referencia = null;
            Siguiente = null;
            Anterior = null;
        }

        public override string ToString()
        {
            return $"{Informacion}";
        }
    }
}
