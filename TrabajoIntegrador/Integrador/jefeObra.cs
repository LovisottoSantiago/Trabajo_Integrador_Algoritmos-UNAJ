using System;
using System.Collections;

namespace Integrador
	
{
	public class jefeObra : obrero
	{
		private double bonificacion;
		private grupoObreros[] jefeGrupoAsignado;
		
		public jefeObra(string nombre, string apellido, string dni, int legajo, double sueldo, string cargo, double bonificacion):base(nombre, apellido, dni, legajo, sueldo, cargo)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.legajo = legajo;
			this.sueldo = sueldo;
			this.cargo = cargo;
			this.bonificacion = bonificacion;
			this.jefeGrupoAsignado = new grupoObreros[1];
		}		
		
		
		public double _bonificacion {
			get {return bonificacion;}
			set {bonificacion = value;}
		}
		
		public grupoObreros[] _jefeGrupoAsignado {
			get {return jefeGrupoAsignado;}
			set {jefeGrupoAsignado = value;}
		}
		

		// ------------------------------- ASIGNAR UN GRUPO ------------------------------- //		
		
		public void asignarGrupo(grupoObreros grupoAsignado){
			jefeGrupoAsignado[0] = (grupoAsignado);
		}
		
		

		// --- FIN --- //		
	}
}
