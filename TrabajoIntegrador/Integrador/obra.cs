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
		
		
		// ------------------------------- ASIGNAR JEFE ------------------------------- //
		
		public void asignarJefe(jefeObra jefe){
			nombreJefe = jefe._nombre;
			legajoJefe = jefe._legajo;
		}
		
		
		// ------------------------------- ELIMINAR JEFE (desvincularlo de la obra) ------------------------------- //
		
		public void eliminarJefe(int legajoJefe){
			nombreJefe = null;
			legajoJefe = 0;			
		}
			
		
		// ------------------------------- VER JEFE ------------------------------- //				
		
		public void verJefeAsignado(){
			Console.WriteLine("Jefe: " + nombreJefe + ".");
			Console.WriteLine("Legajo: " + legajoJefe);
		}
		
		
		
		// ------------------------------- CONSULTAR SI EXISTE UN JEFE ------------------------------- //
		public bool ExisteUnJefe(){
			if (nombreJefe != null){
				return true;
			}
			else {
				return false;
			}
		}
		
		
		// ------------------------------- MODIFICAR ESTADO DE UNA OBRA ------------------------------- //
		
		public void modificarEstado(double valor){
			if ((valor <= 100) && (valor >= 0)){
				estadoDeAvance = valor;
			}
			else {
				throw new misExcepciones.excepcionModificarObra("Valor fuera del rango");
			}
		}
		
		
		// ------------------------------- CONSULTAR SI SE REPITE EL CODIGO INTERNO ------------------------------- //
		
		public bool ExisteCodigo(int codigo){
			if (_codigoInterno == codigo){
				return true;
			}
			else {
				return false;
			}
		}
		
		
		
		// --- FIN --- //
	}
}
