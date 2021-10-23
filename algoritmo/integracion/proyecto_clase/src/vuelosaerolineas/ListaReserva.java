package vuelosaerolineas;

public class ListaReserva implements IListaReserva {

    NodoReserva primero;
    NodoReserva ultimo;
    int cantidadnodos;
    int cupo;

    public ListaReserva(int cupo) {
        this.primero = null;
        this.ultimo = null;
        this.cantidadnodos = 0;
        this.cupo = cupo;
    }

    public int getCupo() {
        return cupo;
    }

    public void setCupo(int cupo) {
        this.cupo = cupo;
    }

    public NodoReserva getPrimero() {
        return primero;
    }

    public void setPrimero(NodoReserva primero) {
        this.primero = primero;
    }

    public NodoReserva getUltimo() {
        return ultimo;
    }

    public void setUltimo(NodoReserva ultimo) {
        this.ultimo = ultimo;
    }

    public Object getCantidadnodos() {
        return cantidadnodos;
    }

    public void setCantidadnodos(int cantidadnodos) {
        this.cantidadnodos = cantidadnodos;
    }

    @Override
    public boolean esVacia() {
        return this.primero == null;
    }

    @Override
    public void agregarInicio(Object dato) {
        NodoReserva nuevo = new NodoReserva(dato);
        if (this.cantidadnodos < this.cupo) {
            if (this.esVacia()) {
                this.primero = nuevo;
                this.ultimo = nuevo;
            } else {
                nuevo.siguiente = primero;  // 1
                primero = nuevo;            //2       
            }
            this.cantidadnodos = this.cantidadnodos + 1;
        }
    }

    @Override
    public void agregarFinal(Object dato) {

        if (this.cantidadnodos < this.cupo) {
            NodoReserva nuevo = new NodoReserva(dato);
            NodoReserva aux = this.getPrimero();
            if (this.esVacia()) {
                this.setPrimero(nuevo);
            } else {
                while (aux.getSiguiente() != null) {
                    aux = aux.getSiguiente();
                }
                aux.setSiguiente(nuevo);
            }
            this.cantidadnodos = this.cantidadnodos + 1;
            this.ultimo = nuevo; // agregado luego de definir el puntero al ultimo
        }
    }

    @Override
    public void agregarFinalV2(Object dato) {
        if (this.cantidadnodos < this.cupo) {
            NodoReserva nuevo = new NodoReserva(dato);
            if (this.esVacia()) {
                this.setPrimero(nuevo);
                this.setUltimo(nuevo);
            } else {
                ultimo.siguiente = nuevo;
                ultimo = nuevo;
            }
            this.cantidadnodos = this.cantidadnodos + 1;
        }
    }

    @Override
    public void borrarInicio() {
        if (!this.esVacia()) {
            this.setPrimero(this.primero.getSiguiente());
            if (this.cantidadnodos == 1) {
                this.setUltimo(null);
            }
        }
        this.cantidadnodos = this.cantidadnodos - 1;

    }

    @Override
    public void agregarOrd(Object dato) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void borrarFin() {
        if (!this.esVacia()) {
            if (this.primero == this.ultimo) {
                this.primero = null;
                this.ultimo = null;
            } else {
                NodoReserva aux = this.getPrimero();
                while (aux.siguiente != ultimo) {
                    aux = aux.siguiente;
                }
                aux.setSiguiente(null);
                this.ultimo = aux;
            }

            this.cantidadnodos = this.cantidadnodos - 1;
        }

    }

    @Override
    public void borrarElemento(Object dato) {
        NodoReserva elementoaborrar = this.obtenerElemento(dato);
        NodoReserva aux = this.getPrimero();
        if (elementoaborrar != null) {
            if (aux == elementoaborrar) {
                this.primero = this.primero.getSiguiente();
                if (this.cantidadnodos == 1) {
                    this.ultimo = null;
                }
            } else {

                while (aux.siguiente != elementoaborrar) {
                    aux = aux.getSiguiente();
                }
                aux.setSiguiente(elementoaborrar.getSiguiente());
            }
            this.cantidadnodos = this.cantidadnodos - 1;
        }

    }

    @Override
    public boolean buscarelemento(Object dato) {
        NodoReserva aux = this.getPrimero();
        boolean resultado = false;
        while (aux != null) {
            if (aux.getDato() == dato) {
                resultado = true;
                return resultado;
            }
            aux = aux.siguiente;
        }
        return resultado;
    }

    @Override
    public NodoReserva obtenerElemento(Object dato) {
        NodoReserva aux = this.getPrimero();
        NodoReserva resultado = null;
        while (aux != null) {
            if (aux.getDato() == dato) {
                resultado = aux;
                return resultado;
            }
            aux = aux.siguiente;
        }
        return resultado;

    }

    @Override
    public void vaciar() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mostrar() {
        NodoReserva aux = this.getPrimero();
        while (aux != null) {
            System.out.print(aux.getDato() + " - ");
            aux = aux.getSiguiente();
        }
        System.out.println();
    }

    @Override
    public int cantElementos() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void mostrarREC(NodoReserva l) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public int cantElementosV2() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

}
