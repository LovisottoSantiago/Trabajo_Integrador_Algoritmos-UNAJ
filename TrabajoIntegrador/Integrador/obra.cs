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
		private double costo;		
		
		public obra(string nombrePropietario, string dniPropietario, int codigoInterno, string tipoObra, double costo)
		{
			this.nombrePropietario = nombrePropietario;
			this.dniPropietario = dniPropietario;
			this.codigoInterno = codigoInterno;
			this.tipoObra = tipoObra;
			estadoDeAvance = 0;
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
		
		public double _costo{
			get {return costo;}
			set {costo = value;}
		}
		
		
		public void asignarJefe(jefeObra jefe){
			nombreJefe = jefe._nombre;
		}
		
		
		/* OJOOO
		public void asignarGrupo(grupoObreros grupo){
			grupo._codigoGrupo = _codigoInterno;
		} */
		
		
		
		public void verJefeAsignado(){
			Console.WriteLine(nombreJefe);
		}
		
		public void modificarEstado(){
			Console.WriteLine("El porcentaje de avance de la obra es de: " + estadoDeAvance + "%.");
			Console.Write("Ingresar valor: ");
			double modificacion = Convert.ToDouble(Console.ReadLine());
			if (modificacion <= 100){
				estadoDeAvance = modificacion;
				Console.WriteLine("Porcentaje actualizado: " + estadoDeAvance + "%.");
			}
			else {
				Console.WriteLine("Valor fuera del rango.");
			}
			
		}
		
	}
}
