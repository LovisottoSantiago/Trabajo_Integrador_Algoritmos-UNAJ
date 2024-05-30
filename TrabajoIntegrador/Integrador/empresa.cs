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
		
		
		// ------------------------------- ASIGNAR UN GRUPO A LA OBRA ------------------------------- //
		
		public void asignarGrupo(grupoObreros y, int codigo){
			
			foreach (grupoObreros x in _empresaGruposAsignado) {
				if (x._codigoGrupo == codigo){
					throw new misExcepciones.excepcionCodigoRepetido("Ya existe un grupo con ese código");
				}
			}
			// Si no repite el código, que se asigne			
			empresaGruposAsignado.Add(y);
		}
		
		
		
		// ------------------------------- CONTRATAR UN OBRERO Y ASIGNARLO A UNA OBRA ------------------------------- //
		
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
					if (y.verificarLegajo(legajo) == false) { // Invoca la funcion creada en grupoObreros
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
					y.agregarObrero(obreroContratado); // Invoca la funcion creada en grupoObreros
					Console.WriteLine("Se contrató a " + obreroContratado._apellido + " " + obreroContratado._nombre + ", legajo: " + obreroContratado._legajo + " con éxito.");
					Console.WriteLine("Formará parte del grupo: " + y._codigoGrupo + ".");
					return;						
					}					
				}
			throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
		}
		
		
		
		// ------------------------------- DESPEDIR UN OBRERO ------------------------------- //
		
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
											
						y.eliminarObrero(inputObreroEliminar); // Invoca la funcion creada en grupoObreros
						return;						
					}
				}
			throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
		}


		
		// ------------------------------- VER A TODOS LOS OBREROS ------------------------------- //
		
		public void verTodosLosObreros(){
			foreach (grupoObreros x in _empresaGruposAsignado) {
				Console.WriteLine("\nObra: " + x._obraAsignadaGrupo + ".");
				x.verObreros(); // Invoca la funcion creada en grupoObreros
			}
		}
		
		
		
		// ------------------------------- VER A TODOS LOS JEFES ------------------------------- //
		
		public void verTodosLosJefes(){
			Console.WriteLine("\nJefes en obras en ejecucion:");
			foreach (obra y in _obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){ // Invoca la funcion creada en obra
					y.verJefeAsignado(); // Invoca la funcion creada en obra
				}
			}			
		}
		
		
		
	// ------------------------------- CONTRATAR UN JEFE ------------------------------- //
	
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
					if (y.verificarLegajo(legajo) == false) { // Invoca la funcion creada en grupoObreros
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
						
						if (g.ExisteUnJefe() == true){ // Invoca la funcion creada en obra, que devuelve un bool
			        		Console.WriteLine("El grupo ya tiene un jefe asignado");
			        		return;
			        	}
						else {
							Console.WriteLine("El grupo está libre");
							jefeObra jefeMetodo = new jefeObra(nombre, apellido, dni, legajo, sueldo, cargo, bonificacion);
							g.asignarJefe(jefeMetodo); // Invoca la funcion creada en obra
							Console.WriteLine("Se asignó el jefe " + g._nombreJefe + ", con éxito a la obra " + g._tipoObra + ".");							
							
							
							foreach (grupoObreros grupo in _empresaGruposAsignado) {
								jefeMetodo.asignarGrupo(grupo); // Invoca la funcion creada en jefeObra
							}

							return;							
						}						
					}
				}
				throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
	       }
		}
		

		
		// ------------------------------- DESPEDIR JEFE ------------------------------- //
		
		public void despedirJefe(){
			Console.WriteLine("------Lista de obras------"); 
		    //Me muestra las obras en ejecucion
			foreach (obra x in _obrasEnEjecucion) {
				Console.WriteLine("Codigo interno de la obra es de: " + x._codigoInterno + ", " + x._tipoObra + ".");
			}		    		    
			
			Console.Write("Ingresar codigo: "); 
			int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());

			foreach (obra y in _obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){ // Invoca la funcion creada en obra
					if (preguntaCodigoInterno == y._codigoInterno){
						y.verJefeAsignado(); // Invoca la funcion creada en obra
						y.eliminarJefe(); // Invoca la funcion creada en obra
						return;
					}
				}
				else {
					Console.WriteLine("No existe un jefe"); 
				}
				
			}
			throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
		} 
		
		
		
		// ------------------------------- AGREGAR OBRA A LA EMPRESA ------------------------------- //
		
		public void agregarObraEmpresa(obra obraParaAgregar){
			
			if (obraParaAgregar._estadoDeAvance < 100){
				_obrasEnEjecucion.Add(obraParaAgregar);
			}
			else {
				_obrasFinalizadas.Add(obraParaAgregar);
			}
		}
		
		

		// ------------------------------- CANTIDAD DE OBRAS EN EJECUCIÓN ------------------------------- //
		
		public void cantidadObrasEnEjecucion(){
			int cantidad = 0;
			foreach (obra x in _obrasEnEjecucion) {
				cantidad ++;
			}
			Console.WriteLine(cantidad);
		}
		
		
		
		// ------------------------------- CANTIDAD DE OBRAS FINALIZADAS ------------------------------- //
		
		public void cantidadObrasFinalizadas(){
			int cantidad = 0;
			foreach (obra x in _obrasFinalizadas) {
				cantidad ++;
			}
			Console.WriteLine(cantidad);
		}
		
		
		
		// ------------------------------- CANTIDAD DE OBRAS EN 'REMODELACION' SIN FINALIZAR ------------------------------- //
		
		public void porcentajeRemodelacion(){
			//	LAS OBRAS EN REMODELACION
			int cantidadRemodelacion = 0;
			foreach (obra y in _obrasEnEjecucion) {
				if ((y._tipoObra).ToUpper() == "REMODELACION"){
					cantidadRemodelacion ++;
				}
			}                                
			// TODAS LAS OBRAS
			int cantidadObras = 0;
			foreach (obra x in _obrasEnEjecucion) {
				cantidadObras ++;
			}			
			int cuenta = (cantidadRemodelacion * 100) / cantidadObras;			
			Console.WriteLine("El porcentaje de obras en remodelacion sin finalizar es de " + cuenta + "%.");
		}
		
		
		
		// ------------------------------- MODIFICAR ESTADO DE OBRA ------------------------------- //
		
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
					y.modificarEstado(); // Invoca la funcion creada en obra
					
					if (y._estadoDeAvance == 100){
						_obrasFinalizadas.Add(y); // Si el estado pasa a ser 100%, se agrega a obrasFinalizadas
						_obrasEnEjecucion.Remove(y); // y se elimina de obrasEnEjecucion
						return;
					}
					else {
						return; // Si no es 100%, se cambia y sigue en obrasEnEjecucion
					}
				}
			}
			throw new misExcepciones.excepcionModificarObra("Esa obra no existe"); // Si el foreach no encuentra ninguna obra
		}
				
		

		// ------------------------------- VER LISTADO DE OBRAS EN EJECUCION ------------------------------- //
		
		public void listadoObrasEnEjecucion(){
			foreach (obra x in _obrasEnEjecucion) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}	
		}
		
		
		
		// ------------------------------- VER LISTADO DE OBRAS FINALIZADAS ------------------------------- //
		
		public void listadoObrasFinalizadas(){
			foreach (obra x in _obrasFinalizadas) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}	
		}
		
		
		
		// ------------------------------- CREAR OBRA ------------------------------- //
		
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
		
		
		
		// --- FIN --- //		
	}
}
