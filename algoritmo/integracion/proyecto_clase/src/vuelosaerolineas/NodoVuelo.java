
package vuelosaerolineas;

public class NodoVuelo {
    Object dato;
    int cupo;
    ListaReserva lr;
    NodoVuelo siguiente;

    public NodoVuelo(Object dato,int cupo) {
        this.dato = dato;
        this.cupo=cupo;
        this.lr= new ListaReserva(cupo);
        this.siguiente = null;
    }

    public int getCupo() {
        return cupo;
    }

    public void setCupo(int cupo) {
        this.cupo = cupo;
    }

    public ListaReserva getLr() {
        return lr;
    }

    public void setLr(ListaReserva lr) {
        this.lr = lr;
    }

    
    public Object getDato() {
        return dato;
    }

    public void setDato(Object dato) {
        this.dato = dato;
    }

    public NodoVuelo getSiguiente() {
        return siguiente;
    }

    public void setSiguiente(NodoVuelo siguiente) {
        this.siguiente = siguiente;
    }

 
    
}
