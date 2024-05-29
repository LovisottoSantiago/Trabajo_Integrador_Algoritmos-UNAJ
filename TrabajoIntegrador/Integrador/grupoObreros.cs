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
			set {listaObreros = value;}
		}
		
		public int _obraAsignadaGrupo{
			get {return obraAsignadaGrupo;}
			set {obraAsignadaGrupo = value;}
		}
		
		
		
		// ------------------------------- AGREGAR UN OBRERO ------------------------------- //
		
		public void agregarObrero(obrero x){ //Agrega a un Obrero creado previamente.
			listaObreros.Add(x);
		}
		
		
		
		// ------------------------------- ELIMINAR UN OBRERO ------------------------------- //
		
		public void eliminarObrero(int legajo){	
		
			foreach (obrero x in listaObreros){ //Recorro todos los obreros de la lista
				if (legajo == 0){ //Si el legajo es 0, que vuelva para atrás
					return;
				}
				else if (x._legajo == legajo){
			    	listaObreros.Remove(x); //Si el legajo del obrero coincide, se elimina al obrero de la lista
			        Console.WriteLine("Obrero " + x._nombre + " eliminado correctamente.");
			        return; // Salir del método después de eliminar al obrero
			    }
			  }
    		Console.WriteLine("No se encontró ningún obrero con el legajo " + legajo + ".");
		}
		
		
		
		// ------------------------------- VISUALIZAR UN OBRERO ------------------------------- //
		
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
			Console.WriteLine("No se encontró ningun obrero con el legajo " + legajo + ".");
		}
		
		
		
		// ------------------------------- VER LA CANTIDAD DE OBREROS ------------------------------- //
		
		public void cantidadObreros(){
			Console.WriteLine("La cantidad de obreros es: " + listaObreros.Count);
		}		
		
		
		
		// ------------------------------- MOSTRAR A TODOS LOS OBREROS ------------------------------- //
		
		public void verObreros(){
			foreach (obrero x in listaObreros) {
				Console.WriteLine(x._apellido + " " + x._nombre + ", legajo: " + x._legajo + ".");
			}	
		}
		
		
		
		// ------------------------------- VERIFICAR EL LEGAJO ------------------------------- //
		
		public bool verificarLegajo(int legajo){
			foreach (obrero y in listaObreros) {
				if (y._legajo == legajo){
					Console.WriteLine("El legajo está ocupado");
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
