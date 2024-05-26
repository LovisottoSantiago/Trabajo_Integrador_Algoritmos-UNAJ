using System;
namespace Integrador
	
{
	public class obrero
	{
		protected string nombre;
		protected string apellido;
		protected string dni;
		protected int legajo;
		protected double sueldo;
		protected string cargo;
		
		public obrero(string nombre, string apellido, string dni, int legajo, double sueldo, string cargo)
		{
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
			this.legajo = legajo;
			this.sueldo = sueldo;
			this.cargo = cargo;
		}
		
		public string _nombre {
			get {return nombre;}
			set {nombre = value;}
		}
		
		public string _apellido {
			get {return apellido;}
			set {apellido = value;}
		}
		
		public string _dni {
			get {return dni;}
			set {dni = value;}
		}
		
		public int _legajo {
			get {return legajo;}
			set {legajo = value;}
		}
		
		public double _sueldo {
			get {return sueldo;}
			set {sueldo = value;}
		}
		
		public string _cargo {
			get {return cargo;}
			set {cargo = value;}
		}
		
		
		
	}
	
}
