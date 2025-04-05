using App_ListasDEnlazadas.Models;

namespace App_ListasDEnlazadas.Services
{
    public class AgregarPorPosicion
    {
        public int Nodos { get; set; }
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public AgregarPorPosicion()
        {
            PrimerNodo = null;
            UltimoNodo = null;

        }

        bool EstaVacia()
        {
            return PrimerNodo == null;
        }

        public string AgregarAlInicio(Nodo dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            if (EstaVacia())
            {
                PrimerNodo = UltimoNodo = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = PrimerNodo;
                PrimerNodo.Anterior = nuevoNodo;
                PrimerNodo = nuevoNodo;
            }
            Nodos++;

            return "Nodo insertado";
        }

        public string AgregarAntesDePosicion(Nodo dato, int posicion)
        {
            if (EstaVacia())
            {
                return "La lista esta vacia.";
            }

            if (posicion <= 0)
            {
                return "La posición debe ser mayo a 0.";
            }

            Nodo nodoActual = PrimerNodo;
            int contador = 0;

            // Antes del primer nodo.
            if (posicion == 1)
            {
                dato.Siguiente = PrimerNodo;
                if (PrimerNodo != null)
                {
                    PrimerNodo.Anterior = dato;
                }
                PrimerNodo = dato;
                Nodos++;
                return $"Nodo ingresado antes de la posicion {posicion}.";
            }

            while (nodoActual != null && contador < posicion)
            {
                if (contador == posicion - 1)
                {
                    dato.Siguiente = nodoActual; 
                    dato.Anterior = nodoActual.Anterior; 
                    if (nodoActual.Anterior != null)
                    {
                        nodoActual.Anterior.Siguiente = dato; 
                    }
                    nodoActual.Anterior = dato; 
                    Nodos++; 
                    return $"Nodo insertado antes de la posición {posicion}";
                }
                nodoActual = nodoActual.Siguiente; 
                contador++;
            }

            return "La posicion es mayor al tamaño de la lista.";
        }

        public string AgregarDespuesDePosicion(Nodo nuevoDato, int posicion)
        {
            if (EstaVacia())
            {
                return "La lista está vacía.";
            }

            if (posicion <= 0)
            {
                return "La posición debe ser mayor que 0.";
            }

            Nodo nodoActual = PrimerNodo;
            int contador = 1;
                        
            while (nodoActual != null && contador <= posicion)
            {
                if (contador == posicion)
                {
                    nuevoDato.Siguiente = nodoActual.Siguiente;
                    nuevoDato.Anterior = nodoActual;
                    if (nodoActual.Siguiente != null)
                    {
                        nodoActual.Siguiente.Anterior = nuevoDato;
                    }
                    nodoActual.Siguiente = nuevoDato;
                    Nodos++;
                    return $"Nodo insertado después de la posición {posicion}";
                }
                nodoActual = nodoActual.Siguiente;
                contador++;
            }

            return "La posición es mayor que el tamaño de la lista.";
        }

        public void LimpiarLista()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            Nodos = 0;
        }
    }
}
