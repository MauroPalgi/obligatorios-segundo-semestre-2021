
package vuelosaerolineas;

public interface IListaReserva {
    public boolean esVacia();
    public void agregarInicio(Object dato);
    public void agregarFinal(Object dato); // recorriendo la lista
    public void agregarFinalV2(Object dato); // sin recorrer la lista 
    public void borrarInicio(); 
    public void borrarFin();     
    public boolean buscarelemento(Object dato); 
    public NodoReserva obtenerElemento(Object dato); 
    public void borrarElemento(Object dato);
    public void agregarOrd(Object dato);    
    public void vaciar();
    public void mostrar();    
    public int cantElementos();  // recorro la lista
    public int cantElementosV2(); // no recorro la lista
    public void mostrarREC(NodoReserva l);   // mostrar recursivo    
    
  
}
