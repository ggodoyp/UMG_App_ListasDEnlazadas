using App_ListasDEnlazadas.Models;
using System.Security.Cryptography.X509Certificates;

namespace App_ListasDEnlazadas.Services
{
    public class Lista1_DatoX
    {
        public int Nodos { get; set; }
        public Nodo? PrimerNodo { get; set; }
        public Nodo? UltimoNodo { get; set; }

        public Lista1_DatoX()
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
        public string AgregarAntesDeX(Nodo dato, Nodo datoExiste)
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
                    Nodo nodoNuevo = new Nodo(dato);

                    if (nodoActual == PrimerNodo)
                    {
                        nodoNuevo.Siguiente = PrimerNodo;
                        PrimerNodo.Anterior = nodoNuevo;
                        PrimerNodo = nodoNuevo;
                    }
                    else
                    {
                        nodoNuevo.Siguiente = nodoActual;
                        nodoNuevo.Anterior = nodoActual.Anterior;
                        nodoActual.Anterior.Siguiente = nodoNuevo;
                        nodoActual.Anterior = nodoNuevo;
                    }
                    Nodos++;

                    return $"El nodo se inserto antes de {datoExiste}";
                }

               nodoActual = nodoActual.Siguiente;
                
            }
           
            return $"El dato existente no se encontro. {datoExiste.Informacion} - {nodoActual}";
        }
        public string AgregarDespuesDeX(Nodo dato, Nodo datoExiste)
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
                    Nodo nodoNuevo = new Nodo(dato);

                    if (nodoActual == UltimoNodo)
                    {
                        nodoActual.Siguiente = nodoNuevo;
                        nodoNuevo.Anterior = nodoActual;
                        UltimoNodo = nodoNuevo;
                    }
                    else
                    {
                        nodoNuevo.Siguiente = nodoActual.Siguiente;
                        nodoNuevo.Anterior = nodoActual;
                        nodoActual.Siguiente.Anterior = nodoNuevo;
                        nodoActual.Siguiente = nodoNuevo;
                    }
                    Nodos++;

                    return $"El nodo se inserto despues de {datoExiste.ToString()}";
                }

                nodoActual = nodoActual.Siguiente;
            }

            return "El dato existente no se encontro.";
        }

        public void LimpiarLista()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            Nodos = 0;
        }
    }
}
