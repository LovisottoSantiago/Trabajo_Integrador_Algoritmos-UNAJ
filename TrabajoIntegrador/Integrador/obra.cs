using System;
using System.Collections;

namespace Integrador
{
	public class obra
	{
		private string nombrePropietario;
		private string dniPropietario;
		private int codigoInterno;
		private string tipoObra;
		private double estadoDeAvance;
		private string nombreJefe; // jefe asignado (nombre)
		private int legajoJefe; // legajo del jefe asignado
		private double costo;		
		
		public obra(string nombrePropietario, string dniPropietario, int codigoInterno, string tipoObra, double estadoDeAvance, double costo)
		{
			this.nombrePropietario = nombrePropietario;
			this.dniPropietario = dniPropietario;
			this.codigoInterno = codigoInterno;
			this.tipoObra = tipoObra;
			this.estadoDeAvance = estadoDeAvance;
			this.costo = costo;
		}
		
		public string _nombrePropietario{
			get {return nombrePropietario;}
			set {nombrePropietario = value;}
		}
		
		public string _dniPropietario{
			get {return dniPropietario;}
			set {dniPropietario = value;}
		}
		
		public int _codigoInterno{
			get {return codigoInterno;}
			set {codigoInterno = value;}
		}
		
		public string _tipoObra{
			get {return tipoObra;}
			set {tipoObra = value;}
		}
		
		public double _estadoDeAvance{
			get {return estadoDeAvance;}
			set {estadoDeAvance = value;}
		}
		
		public string _nombreJefe{
			get {return nombreJefe;}
			set {nombreJefe = value;}
		}
		
		public int _legajoJefe{
			get {return legajoJefe;}
			set {legajoJefe = value;}
		}
		
		public double _costo{
			get {return costo;}
			set {costo = value;}
		}
		
		
		public void asignarJefe(jefeObra jefe){
			nombreJefe = jefe._nombre;
			legajoJefe = jefe._legajo;
		}
		
		
		public void eliminarJefe(){
			nombreJefe = null;
			legajoJefe = 0;
			Console.WriteLine("El jefe fue despedido");
		}
				
				
		public void verJefeAsignado(){
			Console.WriteLine("Jefe: " + nombreJefe + ".");
			Console.WriteLine("Legajo: " + legajoJefe);
		}
		
		public bool ExisteUnJefe(){
			if (nombreJefe != null){
				return true;
			}
			else {
				return false;
			}
		}
		
		
		public void modificarEstado(){
			Console.WriteLine("El porcentaje de avance de la obra es de: " + estadoDeAvance + "%.");
			Console.Write("Ingresar valor: ");
			double modificacion = Convert.ToDouble(Console.ReadLine());
			if ((modificacion <= 100) && (modificacion >= 0)){
				estadoDeAvance = modificacion;
				Console.WriteLine("Porcentaje actualizado: " + estadoDeAvance + "%.");
			}
			else {
				Console.WriteLine("Valor fuera del rango.");
			}
			
		}
		
		
		public bool ExisteCodigo(int codigo){
			if (_codigoInterno == codigo){
				return true;
			}
			else {
				return false;
			}
		}
		
		
		
	}
}
