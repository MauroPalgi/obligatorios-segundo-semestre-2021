
package vuelosaerolineas;

public class NodoReserva {
    Object dato;
    
    NodoReserva siguiente;

    public NodoReserva(Object dato) {
        this.dato = dato;
        this.siguiente = null;
    }

    public Object getDato() {
        return dato;
    }

    public void setDato(Object dato) {
        this.dato = dato;
    }

    public NodoReserva getSiguiente() {
        return siguiente;
    }

    public void setSiguiente(NodoReserva siguiente) {
        this.siguiente = siguiente;
    }

 
    
}
