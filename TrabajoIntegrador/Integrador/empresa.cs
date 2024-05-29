using System;
using System.Collections;
namespace Integrador
	
{
	public class empresa
	{
		private ArrayList obrasEnEjecucion;
		private ArrayList obrasFinalizadas;
		private ArrayList empresaGruposAsignado; // TODOS LOS GRUPOS
		
		public empresa(ArrayList obrasEnEjecucion, ArrayList obrasFinalizadas)
		{	
			this.obrasEnEjecucion = obrasEnEjecucion;
			this.obrasFinalizadas = obrasFinalizadas;
			empresaGruposAsignado = new ArrayList();
		}
		
		public ArrayList _obrasEnEjecucion{
			get {return obrasEnEjecucion;}
			set {obrasEnEjecucion = value;}
		}
		
		public ArrayList _obrasFinalizadas{
			get {return obrasFinalizadas;}
			set {obrasFinalizadas = value;}
		}
		
		public ArrayList _empresaGruposAsignado{
			get {return empresaGruposAsignado;}
			set {empresaGruposAsignado = value;}
		}
		
		
		public void asignarGrupo(grupoObreros y){
			empresaGruposAsignado.Add(y);
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
	        
	        
	        foreach (grupoObreros y in _empresaGruposAsignado) {
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

				foreach (grupoObreros y in _empresaGruposAsignado) {
				
					if (preguntaCodigoInterno == y._obraAsignadaGrupo){
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

				foreach (grupoObreros y in _empresaGruposAsignado) {
				
				if (preguntaCodigoInterno == y._obraAsignadaGrupo){
					
						y.verObreros();
						Console.WriteLine("\n--------Escriba 0 para volver atrás--------\n");	
						Console.Write("Ingresar legajo del obrero a eliminar: ");
						int inputObreroEliminar = Convert.ToInt32(Console.ReadLine());
						
						
						y.eliminarObrero(inputObreroEliminar);
						return;						
					}
				}
		}

		
		
		
		// VER TODOS LOS OBREROS
		public void verTodosLosObreros(){
			foreach (grupoObreros x in _empresaGruposAsignado) {
				x.verObreros(); //polimorfismo
			}
		}
		
		
		// VER TODOS LOS JEFES
		public void verTodosLosJefes(){
			Console.WriteLine("\nJefes en obras en ejecucion:");
			foreach (obra y in _obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){ // Para que no me muestre los jefes vacios
					y.verJefeAsignado();
				}
				
			}
			
			Console.WriteLine("\nLos Jefes en obras finalizadas eran:");
			foreach (obra y in _obrasFinalizadas) {
				if (y.ExisteUnJefe() == true){ // Para que no me muestre los jefes vacios
					y.verJefeAsignado();
					return;
				}				
			}
			Console.WriteLine("No hay jefes en obras finalizadas");
		}
		
		
		
		// CONTRATAR UN JEFE
		public void contratarJefe(){
			
			Console.Write("Ingrese el nombre: ");
	        string nombre = Console.ReadLine();
	        Console.Write("Ingrese el apellido: ");
	        string apellido = Console.ReadLine();
	        Console.Write("Ingrese el DNI: ");
	        string dni = Console.ReadLine();	
	        Console.Write("Ingrese el legajo: ");
	        int legajo = Convert.ToInt32(Console.ReadLine());	        
	        
	        foreach (grupoObreros y in _empresaGruposAsignado) {
					if (y.verificarLegajo(legajo) == false) {
						return;
					}
	        	}
	        
	        Console.Write("Ingrese el sueldo: ");
	        double sueldo = Convert.ToDouble(Console.ReadLine());	
	        string cargo = "Jefe";			
	        Console.Write("Ingrese la bonificación: ");
	        double bonificacion = Convert.ToDouble(Console.ReadLine());
	        
	        // Una vez que termino de Crear al Jefe
	       bool condicion = true;
	       
	       while (condicion){
	       	
		       Console.WriteLine("------Lista de obras------"); 
		       foreach (obra x in _obrasEnEjecucion) {
					Console.WriteLine(x._codigoInterno + ", " + x._tipoObra + ".");
				}
				
				Console.Write("\nIngresar codigo: "); 
				int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());      
				
				foreach (obra g in _obrasEnEjecucion) {
					if (preguntaCodigoInterno == g._codigoInterno) {
						
						if (g.ExisteUnJefe() == true){ //llamo a la funcion ExisteUnJefe, que devuelve un bool
			        		Console.WriteLine("El grupo ya tiene un jefe asignado");
			        		return;
			        	}
						else {
							Console.WriteLine("El grupo está libre");
							jefeObra jefeMetodo = new jefeObra(nombre, apellido, dni, legajo, sueldo, cargo, bonificacion);
							g.asignarJefe(jefeMetodo); //se asigna el jefe a la obra seleccionada
							Console.WriteLine("Se asignó el jefe " + g._nombreJefe + ", con éxito a la obra " + g._tipoObra + ".");							
							

							foreach (grupoObreros grupo in _empresaGruposAsignado) {
								grupo.asignarObra(g);
							}

							return;							
						}						
					}
				}
				Console.WriteLine("No existe esa obra...");
	       }
		}
		

		
		// METODO PARA DESPEDIR JEFE
		
		public void despedirJefe(){
			Console.WriteLine("------Lista de obras------"); 
		    //Me muestra las obras en ejecucion
			foreach (obra x in _obrasEnEjecucion) {
				Console.WriteLine("Codigo interno de la obra es de: " + x._codigoInterno + ", " + x._tipoObra + ".");
			}		    		    
			
			Console.Write("Ingresar codigo: "); 
			int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());

			foreach (obra y in _obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){
					if (preguntaCodigoInterno == y._codigoInterno){
						y.verJefeAsignado();
						y.eliminarJefe();
						return;
					}
				}
				else {
					Console.WriteLine("No existe un jefe"); 
				}
				
			}
			
		} 
		
		// Agregar Obra a la Empresa
		public void agregarObraEmpresa(obra obraParaAgregar){
			
			if (obraParaAgregar._estadoDeAvance < 100){
				_obrasEnEjecucion.Add(obraParaAgregar);
			}
			else {
				_obrasFinalizadas.Add(obraParaAgregar);
			}
		}
		

		// CANTIDAD DE OBRAS EN EJECUCION
		public void cantidadObrasEnEjecucion(){
			int cantidad = 0;
			foreach (obra x in _obrasEnEjecucion) {
				cantidad ++;
			}
			Console.WriteLine(cantidad);
		}
		
		// CANTIDAD DE OBRAS FINALIZADAS
		public void cantidadObrasFinalizadas(){
			int cantidad = 0;
			foreach (obra x in _obrasFinalizadas) {
				cantidad ++;
			}
			Console.WriteLine(cantidad);
		}
		
		
		// PORCENTAJE DE OBRAS 'REMODELACION' SIN FINALIZAR
		public void porcentajeRemodelacion(){
			//	LAS OBRAS EN REMODELACION
			int cantidadRemodelacion = 0;
			foreach (obra y in _obrasEnEjecucion) {
				if ((y._tipoObra).ToUpper() == "REMODELACION"){
					cantidadRemodelacion ++;
				}
			}                                         // cantidadObras  ==> 100% 			                                         //  cantidadRemodelacion ==> x
			// TODAS LAS OBRAS
			int cantidadObras = 0;
			foreach (obra x in _obrasEnEjecucion) {
				cantidadObras ++;
			}			
			int cuenta = (cantidadRemodelacion * 100) / cantidadObras;			
			Console.WriteLine("El porcentaje de obras Remodelacion sin finalizar es de " + cuenta + "%.");
		}
		
		
		// Modificar estado de una obra
		public void ObraModificarEstado(){
			Console.WriteLine("------Lista de obras------"); 
		    //Me muestra las obras en ejecucion
			foreach (obra x in _obrasEnEjecucion) {
				Console.WriteLine("Codigo interno de la obra es de: " + x._codigoInterno + ", " + x._tipoObra + ".");
			}		    		    
			
			Console.Write("Ingresar codigo: "); 
			int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());
			
			foreach (obra y in _obrasEnEjecucion) {
				if (preguntaCodigoInterno == y._codigoInterno){
					y.modificarEstado();
					
					if (y._estadoDeAvance == 100){
						_obrasFinalizadas.Add(y);
						_obrasEnEjecucion.Remove(y);
						return;
					}
				}
			}
		}
		

		// Ver listado de obras en ejecución
		public void listadoObrasEnEjecucion(){
			foreach (obra x in _obrasEnEjecucion) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}
			
		}
		
		
		// Ver listado de obras finalizadas
		public void listadoObrasFinalizadas(){
			foreach (obra x in _obrasFinalizadas) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}
			
		}
		
		
		// CREAR OBRA
		public obra crearObra(){
			Console.Write("Ingresar nombre del propietario: ");
			string nombrePropietario = Console.ReadLine();
			Console.Write("Ingresar DNI del propietario: ");
			string dniPropietario = Console.ReadLine();
			Console.Write("Ingresar codigo interno: ");
			int codigoInterno = Convert.ToInt32(Console.ReadLine());
			
			foreach (obra y in _obrasEnEjecucion) {
				if (y._codigoInterno == codigoInterno){
					throw new misExcepciones.excepcionCodigoRepetido("Ese codigo ya existe");
				}
			} 
			
			Console.Write("Ingresar tipo de obra: ");
			string tipoObra = Console.ReadLine();
			Console.Write("Ingresar estado de avance: ");
			double estadoDeAvance = Convert.ToDouble(Console.ReadLine());
			Console.Write("Ingresar costo: ");
			double costo = Convert.ToDouble(Console.ReadLine());
			
			obra nuevaObra = new obra(nombrePropietario, dniPropietario, codigoInterno, tipoObra, estadoDeAvance, costo);					
			return nuevaObra;
		}
		
		
		
	}
}
