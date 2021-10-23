
package vuelosaerolineas;

public interface IListaVuelo {
    public boolean esVacia();
    public void agregarInicio(Object dato, int cupo);
    public void agregarFinal(Object dato,int cupo); // recorriendo la lista
    public void agregarFinalV2(Object dato, int cupo); // sin recorrer la lista 
    public void borrarInicio(); 
    public void borrarFin();     
    public boolean buscarelemento(Object dato); 
    public NodoVuelo obtenerElemento(Object dato); 
    public void borrarElemento(Object dato);
    public void agregarOrd(Object dato,int cupo);    
    public void vaciar();
    public void mostrar();    
    public int cantElementos();  // recorro la lista
    public int cantElementosV2(); // no recorro la lista
    public void mostrarREC(NodoVuelo l);   // mostrar recursivo    
    
  
}
