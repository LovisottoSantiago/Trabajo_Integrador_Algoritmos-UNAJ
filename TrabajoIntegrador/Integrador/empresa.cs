using System;
using System.Collections;
namespace Integrador
	
{
	public class empresa
	{
		private ArrayList obrasEnEjecucion;
		private ArrayList obrasFinalizadas;
		private ArrayList empresaGrupoAsignado;
		
		public empresa(ArrayList obrasEnEjecucion, ArrayList obrasFinalizadas)
		{	
			this.obrasEnEjecucion = obrasEnEjecucion;
			this.obrasFinalizadas = obrasFinalizadas;
			empresaGrupoAsignado = new ArrayList();
		}
		
		public ArrayList _obrasEnEjecucion{
			get {return obrasEnEjecucion;}
			set {obrasEnEjecucion = value;}
		}
		
		public ArrayList _obrasFinalizadas{
			get {return obrasFinalizadas;}
			set {obrasFinalizadas = value;}
		}
		
		public ArrayList _empresaGrupoAsignado{
			get {return empresaGrupoAsignado;}
			set {empresaGrupoAsignado = value;}
		}
		
		
		public void asignarGrupo(grupoObreros grupoAsignado){
			empresaGrupoAsignado.Add(grupoAsignado);
		}
		
		
		public void contratarObrero(){
			Console.Write("Ingrese el nombre: ");
	        string nombre = Console.ReadLine();
	
	        Console.Write("Ingrese el apellido: ");
	        string apellido = Console.ReadLine();
	
	        Console.Write("Ingrese el DNI: ");
	        string dni = Console.ReadLine();
	
	        Console.Write("Ingrese el legajo: ");
	        int legajo = Convert.ToInt32(Console.ReadLine());
	
	        Console.Write("Ingrese el sueldo: ");
	        double sueldo = Convert.ToDouble(Console.ReadLine());
	
	        Console.Write("Ingrese el cargo [Capataz, Albañil, Peón, Plomero, Electricista]: ");
	        string cargo = Console.ReadLine();
	        
	        obrero obreroContratado = new obrero(nombre, apellido, dni, legajo, sueldo, cargo);
		}
		
		
		public void despedirObrero(){
			// Me muestra las obras en ejecucion
			foreach (obra x in obrasEnEjecucion) {
				Console.WriteLine("Codigo interno de la obra es de: " + x._codigoInterno);
			}
	
			try {
				Console.Write("Elegir obra [codigo de obra]: ");
				int preguntaCodigo = Convert.ToInt32(Console.ReadLine());						
				
				// Entrar en la obra especifica
				foreach (obra y in _obrasEnEjecucion) {
					if (preguntaCodigo == y._codigoInterno){
						Console.WriteLine("entraste");
						
						// Me muestra todos los obreros
						Console.WriteLine("Has seleccionado la obra con código: " + y._codigoInterno);
                    	foreach (grupoObreros gr in _empresaGrupoAsignado) {
							Console.WriteLine("El codigo del grupo es de: " + gr._codigoObra);
                    	}
						
						Console.Write("Ingresar codigo del grupo: ");
						int preguntaCodigoGrupo = Convert.ToInt32(Console.ReadLine());
						
						
						// Entrar en el grupo especifico y mostrar Obreros
						foreach (grupoObreros gr in _empresaGrupoAsignado) {
							if (preguntaCodigoGrupo == gr._codigoObra){
								Console.WriteLine("Seleccionaste al grupo: " + gr._codigoObra);
								gr.verObreros();
							}
						}
						
						foreach (grupoObreros gr in _empresaGrupoAsignado) {
							Console.Write("Ingresar legajo del obrero: ");
							int preguntaLegajoObrero = Convert.ToInt32(Console.ReadLine());
											
							gr.eliminarObrero(preguntaLegajoObrero);
								
							
						}
						
						
					}
				}
			}
			catch (FormatException){
				Console.WriteLine("Porfavor, ingresa un número.");
			} 
		}
		
		
		
		
		
		
	}
}
