namespace App_ListasDEnlazadas.Models
{
    public class Nodo
    {
        public object Informacion { get; set; }
        public Nodo? Referencia { get; set; }
        public Nodo()
        {
            Informacion = string.Empty;
            Referencia = null;
        }

        public Nodo(object informacion)
        {
            Informacion = informacion;
            Referencia = null;
        }
    }
}
