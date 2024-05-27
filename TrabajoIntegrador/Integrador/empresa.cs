﻿using System;
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
		
		// CONTRATAR OBRERO
		
		public void contratarObrero(){
			Console.Write("Ingrese el nombre: ");
	        string nombre = Console.ReadLine();

	        Console.Write("Ingrese el apellido: ");
	        string apellido = Console.ReadLine();
	
	        Console.Write("Ingrese el DNI: ");
	        string dni = Console.ReadLine();
	
	        Console.Write("Ingrese el legajo: ");
	        int legajo = Convert.ToInt32(Console.ReadLine());
	        
	        
	        foreach (grupoObreros y in _empresaGrupoAsignado) {
					if (y.verificarLegajo(legajo) == false) {
						return;
					}
	        	}
	        
	
	        Console.Write("Ingrese el sueldo: ");
	        double sueldo = Convert.ToDouble(Console.ReadLine());
	
	        Console.Write("Ingrese el cargo [Capataz, Albañil, Peón, Plomero, Electricista]: ");
	        string cargo = Console.ReadLine();
	        
	        obrero obreroContratado = new obrero(nombre, apellido, dni, legajo, sueldo, cargo);
	        
			//Me muestra las obras en ejecucion
			foreach (obra x in _obrasEnEjecucion) {
				Console.WriteLine("Codigo interno de la obra es de: " + x._codigoInterno + ", " + x._tipoObra + ".");
			}
			
			Console.Write("Ingresar codigo: "); 
			int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());

				foreach (grupoObreros y in _empresaGrupoAsignado) {
				
					if (preguntaCodigoInterno == y._codigoGrupo){
					y.agregarObrero(obreroContratado);
					Console.WriteLine("Se contrató a " + obreroContratado._apellido + " " + obreroContratado._nombre + ", legajo: " + obreroContratado._legajo + " con éxito.");
					Console.WriteLine("Formará parte del grupo: " + y._codigoGrupo + ".");
					return;						
					}
				}
		}
		
		
		
		// DESPEDIR OBRERO
		
		public void despedirObrero(){
			//Me muestra las obras en ejecucion
			foreach (obra x in _obrasEnEjecucion) {
				Console.WriteLine("Codigo interno de la obra es de: " + x._codigoInterno + ", " + x._tipoObra + ".");
			}
			
			Console.Write("Ingresar codigo: "); 
			int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());

				foreach (grupoObreros y in _empresaGrupoAsignado) {
				
					if (preguntaCodigoInterno == y._codigoGrupo){
						y.verObreros();
						
						Console.Write("Ingresar legajo del obrero a eliminar: ");
						int inputObreroEliminar = Convert.ToInt32(Console.ReadLine());
						y.eliminarObrero(inputObreroEliminar);
						return;						
					}
				}
		}



		public void verTodosLosObreros(){
			foreach (grupoObreros x in empresaGrupoAsignado) {
				x.verObreros();
			}
		}
		
	
	}
}