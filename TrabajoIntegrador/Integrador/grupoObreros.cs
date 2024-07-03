using System;
using System.Collections;
namespace Integrador
	
{
	public class grupoObreros
	{
		private int codigoGrupo;
		private ArrayList listaObreros;
		private int obraAsignadaGrupo;
		
		public grupoObreros(int codigoGrupo)
		{
			this.codigoGrupo = codigoGrupo;
			listaObreros = new ArrayList();
			this.obraAsignadaGrupo = 0;
		}
		
		public int _codigoGrupo{
			get {return codigoGrupo;}
			set {codigoGrupo = value;}
		}
		
		public ArrayList _listaObreros{
			get {return listaObreros;}
		}
		
		public int _obraAsignadaGrupo{
			get {return obraAsignadaGrupo;}
			set {obraAsignadaGrupo = value;}
		}
		
		
		
		// ------------------------------- AGREGAR UN OBRERO ------------------------------- // void agregarElemento(Elemento e);
		
		public void agregarObrero(obrero x){ //Agrega a un Obrero creado previamente.
			listaObreros.Add(x);
		}
		
		
		// ------------------------------- ELIMINAR UN OBRERO ------------------------------- // void eliminarElemento(Elemento e)
		
		public void eliminarObrero(int legajo){	
		
			foreach (obrero x in listaObreros){ //Recorro todos los obreros de la lista
				if (x._legajo == legajo){
			    	listaObreros.Remove(x); //Si el legajo del obrero coincide, se elimina al obrero de la lista
			        return; // Salir del método después de eliminar al obrero
			    }
			  }
    		throw new misExcepciones.excepcionCodigoNoExiste("No existe un obrero con ese legajo");
		}
		
		
		// ------------------------------- VISUALIZAR UN OBRERO ------------------------------- // Elemento verElemento(id)
		
		public void visualizarObrero(int legajo){
			foreach (obrero z in listaObreros) { //Recorro todos los obreros de la lista
				if (z._legajo == legajo){
					Console.WriteLine("Nombre: " + z._nombre);
					Console.WriteLine("Apellido: " + z._apellido);
					Console.WriteLine("DNI: " + z._dni);
					Console.WriteLine("Legajo: " + z._legajo);
					Console.WriteLine("Sueldo: " + z._sueldo);
					Console.WriteLine("Cargo: " + z._cargo);
					return;
				}
			}
			throw new misExcepciones.excepcionCodigoNoExiste("No existe un obrero con ese legajo");
		}
		
		
		// ------------------------------- VER LA CANTIDAD DE OBREROS ------------------------------- // int cantidadElementos()
		public void cantidadObreros(){
			Console.WriteLine("La cantidad de obreros es: " + listaObreros.Count);
		}		
		
		
		// ------------------------------- MOSTRAR A TODOS LOS OBREROS ------------------------------- // void listadoElementos()		 
		public void verObreros(){
			foreach (obrero x in listaObreros) {
				Console.WriteLine(x._apellido + " " + x._nombre + ", legajo: " + x._legajo + ".");
			}	
		}
		
		
		// ------------------------------- VERIFICAR EL LEGAJO ------------------------------- //
		public bool verificarLegajo(int legajo){
			foreach (obrero y in listaObreros) {
				if (y._legajo == legajo){
		            return false;
		        }
		    }
		    return true;
		}
		
		
		// ------------------------------- ASIGNAR OBRA AL GRUPO ------------------------------- //
		public void asignarObra(obra obraParaAsignar){
			 _obraAsignadaGrupo = obraParaAsignar._codigoInterno;
		}
		
		
		// --- FIN --- //
	}
}
