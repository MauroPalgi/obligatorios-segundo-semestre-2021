
package vuelosaerolineas;

public class NodoAerolinea {
    Object dato;
    ListaVuelo lv;
    NodoAerolinea siguiente;

    public NodoAerolinea(Object dato) {
        this.dato = dato;
        this.lv= new ListaVuelo();
        this.siguiente = null;
    }

    public Object getDato() {
        return dato;
    }

    public void setDato(Object dato) {
        this.dato = dato;
    }

    public NodoAerolinea getSiguiente() {
        return siguiente;
    }

    public void setSiguiente(NodoAerolinea siguiente) {
        this.siguiente = siguiente;
    }

    public ListaVuelo getLv() {
        return lv;
    }

    public void setLv(ListaVuelo lv) {
        this.lv = lv;
    }

 
    
}
