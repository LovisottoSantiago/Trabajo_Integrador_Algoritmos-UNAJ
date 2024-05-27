using System;
using System.Collections;
namespace Integrador
	
{
	public class grupoObreros
	{
		private int codigoGrupo;
		private ArrayList listaObreros;
			
		public grupoObreros(int codigoGrupo)
		{
			this.codigoGrupo = codigoGrupo;
			listaObreros = new ArrayList();
		}
		
		public int _codigoGrupo{
			get {return codigoGrupo;}
			set {codigoGrupo = value;}
		}
		
		public ArrayList _listaObreros{
			get {return listaObreros;}
			set {listaObreros = value;}
		}
		
		
		//METODOS
		
		// METODO PARA AGREGAR UN OBRERO
		public void agregarObrero(obrero x){ //Agrega a un Obrero creado previamente.
			listaObreros.Add(x);
		}
		
		
		// METODO PARA ELIMINAR UN OBRERO
		public void eliminarObrero(int legajo){		
			foreach (obrero x in listaObreros){ //Recorro todos los obreros de la lista
			    if (x._legajo == legajo){
			    	listaObreros.Remove(x); //Si el legajo del obrero coincide, se elimina al obrero de la lista
			        Console.WriteLine("Obrero " + x._nombre + " eliminado correctamente.");
			        return; // Salir del método después de eliminar al obrero
			    }
			  }
    
    		Console.WriteLine("No se encontró ningún obrero con el legajo " + legajo + ".");
		}
		
		
		// METODO PARA VISUALIZAR UN OBRERO
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
		
		// METODO PARA VER LA CANTIDAD DE OBREROS	
		public void cantidadObreros(){
			Console.WriteLine("La cantidad de obreros es: " + listaObreros.Count);
		}		
		
		
		// METODO PARA VER TODA LA LISTA DE OBREROS
		public void verObreros(){
			foreach (obrero x in listaObreros) {
				Console.WriteLine(x._apellido + " " + x._nombre + ", legajo: " + x._legajo + ".");
			}	
		}
		
		
		// METODO PARA VERIFICAR SI EL LEGAJO ESTÁ DISPONIBLE
		public bool verificarLegajo(int legajo){
			foreach (obrero y in listaObreros) {
				if (y._legajo == legajo){
					Console.WriteLine("El legajo está ocupado");
		            return false;
		        }
		    }
		    return true;
		}
				
	}
}
