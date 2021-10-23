package vuelosaerolineas;

public class VUELOSAEROLINEAS {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        ListaAerolinea la = new ListaAerolinea();
        juegodeprueba(la);
        listadoAV(la);
        listadoAVR(la, "LAN", "VUELO 2 DE LAN");
        
    }

    public static void juegodeprueba(ListaAerolinea la) {
        la.agregarInicio("AA");
        la.agregarInicio("LAN");
        la.agregarInicio("AlasU");
        la.agregarInicio("IBERIA");
        la.mostrar();
        la.obtenerElemento("LAN").getLv().agregarInicio("VUELO 1 DE LAN", 3);
        la.obtenerElemento("LAN").getLv().agregarInicio("VUELO 2 DE LAN", 4);
        la.obtenerElemento("AlasU").getLv().agregarInicio("VUELO 1 DE AlasU", 200);
        la.obtenerElemento("IBERIA").getLv().agregarInicio("VUELO 234 DE IBERIA", 150);

        la.obtenerElemento("LAN").getLv().obtenerElemento("VUELO 2 DE LAN").getLr().agregarInicio("Reserva 1");
        la.obtenerElemento("LAN").getLv().obtenerElemento("VUELO 2 DE LAN").getLr().agregarInicio("Reserva 2");
        la.obtenerElemento("LAN").getLv().obtenerElemento("VUELO 2 DE LAN").getLr().agregarInicio("Reserva 3");
        la.obtenerElemento("LAN").getLv().obtenerElemento("VUELO 2 DE LAN").getLr().agregarInicio("Reserva 4");
        la.obtenerElemento("LAN").getLv().obtenerElemento("VUELO 2 DE LAN").getLr().agregarInicio("Reserva 5");
    }

    public static void listadoAV(ListaAerolinea la) {
        NodoAerolinea aux = la.getPrimero();
        while (aux != null) {
            System.out.println("vuelos de la aerolinea " + aux.getDato());
            
            aux.getLv().mostrar();
            aux = aux.siguiente;
        }
    }
    
public static void listadoAVR(ListaAerolinea la, String aerolinea, String vuelo) {
    la.obtenerElemento(aerolinea).lv.obtenerElemento(vuelo).getLr().mostrar();
}    

}
