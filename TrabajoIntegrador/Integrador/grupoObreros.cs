using System;
using System.Collections;
namespace Integrador
	
{
	public class grupoObreros
	{
		private int codigoObra;
		private ArrayList listaObreros;
			
		public grupoObreros(int codigoObra)
		{
			this.codigoObra = codigoObra;
			listaObreros = new ArrayList();
		}
		
		public int _codigoObra{
			get {return codigoObra;}
			set {codigoObra = value;}
		}
		
		public ArrayList _listaObreros{
			get {return listaObreros;}
			set {listaObreros = value;}
		}
		
		
		//METODOS
		public void agregarObrero(obrero x){ //Agrega a un Obrero creado previamente.
			listaObreros.Add(x);
		}
		
		
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
			
		public void cantidadObreros(){
			Console.WriteLine("La cantidad de obreros es: " + listaObreros.Count);
		}		
		
		public void verObreros(){
			foreach (obrero x in listaObreros) {
				Console.WriteLine(x._nombre + ", " + x._legajo + ".");
			}	
		}
		
		
	}
}
