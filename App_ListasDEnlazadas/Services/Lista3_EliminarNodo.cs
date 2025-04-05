using App_ListasDEnlazadas.Models;

namespace App_ListasDEnlazadas.Services
{
    public class Lista3_EliminarNodo
    {
        public int Nodos { get; set; }
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public Lista3_EliminarNodo()
        {
            PrimerNodo = null;
            UltimoNodo = null;

        }

        bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        public void LimpiarLista()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            Nodos = 0;
        }

        public string AgregarAlFinal(Nodo dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            if (EstaVacia())
            {
                PrimerNodo = UltimoNodo = nuevoNodo;
            }
            else
            {
                UltimoNodo.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = UltimoNodo;
                UltimoNodo = nuevoNodo;
            }
            Nodos++;

            return "Nodo insertado";
        }

        public void AgregarLista()
        {
            for (int i = 1; i <= 10; i++)
            {
                Nodo nuevoNodo = new Nodo(i);
                AgregarAlFinal(nuevoNodo);
            }
        }
        public string EliminarNodoX(Nodo datoExiste)
        {
            if (EstaVacia())
            {
                return "La lista esta vacia.";
            }
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Informacion.ToString().Trim().Equals(datoExiste.Informacion.ToString().Trim()))
                {
                    // Si es primer nodo.
                    if (nodoActual == PrimerNodo)
                    {
                        PrimerNodo = nodoActual.Siguiente;
                        if (PrimerNodo != null)
                        {
                            PrimerNodo.Anterior = null;
                        }
                    } // Si es el ultimo nodo.
                    else if (nodoActual == UltimoNodo)
                    {
                        UltimoNodo = nodoActual.Anterior;
                        UltimoNodo.Siguiente = null;
                    }                    
                    else
                    {
                        nodoActual.Anterior.Siguiente = nodoActual.Siguiente;
                        nodoActual.Siguiente.Anterior = nodoActual.Anterior;
                    }

                    Nodos--;

                    return $"El nodo, {datoExiste} se Elimino.";
                }

                nodoActual = nodoActual.Siguiente;

            }

            return $"El dato existente no se encontro. {datoExiste.Informacion}";
        }

        public string EliminarAntesDeX(Nodo datoExiste)
        {
            if (EstaVacia())
            {
                return "La lista esta vacia.";
            }
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Informacion.ToString().Trim().Equals(datoExiste.Informacion.ToString().Trim()))
                {
                    
                    if (nodoActual == PrimerNodo)
                    {
                        return "No se puede eliminar antes del primer nodo.";
                    }

                    Nodo nodoAnterior = nodoActual.Anterior;

                    if (nodoAnterior.Anterior == PrimerNodo)
                    {
                        PrimerNodo = nodoActual;
                        PrimerNodo.Anterior = null;
                    }
                    else
                    {
                        nodoAnterior.Anterior.Siguiente = nodoActual;
                        nodoActual.Anterior = nodoAnterior.Anterior;
                    }
                    Nodos--;

                    return $"El nodo anterior de {datoExiste}, a sido eliminado.";
                }

                nodoActual = nodoActual.Siguiente;

            }

            return $"El dato existente no se encontro. {datoExiste.Informacion} ";
        }

        public string EliminarDespuesDeX(Nodo datoExiste)
        {
            if (EstaVacia())
            {
                return "La lista esta vacia.";
            }
            Nodo nodoActual = PrimerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Informacion.ToString().Trim().Equals(datoExiste.Informacion.ToString().Trim()))
                {

                    if (nodoActual == PrimerNodo)
                    {
                        return "No se puede eliminar despues del primer nodo.";
                    }

                    Nodo nodoSiguiente = nodoActual.Siguiente;

                    if (nodoSiguiente.Siguiente == UltimoNodo)
                    {
                        UltimoNodo = nodoActual;
                        UltimoNodo.Siguiente = null;
                    }
                    else
                    {
                        nodoActual.Siguiente = nodoSiguiente.Siguiente;
                        nodoSiguiente.Siguiente.Anterior = nodoActual;
                    }
                    Nodos--;

                    return $"El nodo despues de {datoExiste}, a sido eliminado.";
                }

                nodoActual = nodoActual.Siguiente;

            }

            return $"El dato existente no se encontro. {datoExiste.Informacion} ";
        }
    }
}
