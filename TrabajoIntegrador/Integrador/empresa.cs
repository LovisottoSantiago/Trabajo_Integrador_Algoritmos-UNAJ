using System;
using System.Collections;
namespace Integrador
	
{
	public class empresa
	{
		public ArrayList obrasEnEjecucion;
		private ArrayList obrasFinalizadas;
		private ArrayList empresaGruposAsignado; // TODOS LOS GRUPOS
		
		public empresa()
		{	
			obrasEnEjecucion = new ArrayList();
			obrasFinalizadas = new ArrayList();
			empresaGruposAsignado = new ArrayList();
		}
		
		public ArrayList _obrasEnEjecucion{ //defino una instancia para visualizar su dato, pero no sobreescribirlo
			get {return obrasEnEjecucion;}
			set {}
		}
		
		

		// ------------------------------- AGREGAR OBRA A LA EMPRESA (corregido) ------------------------------- //
        public void agregarObraEmpresa(obra x)
        {
        	if (x._estadoDeAvance < 100){
        		obrasEnEjecucion.Add(x);	
        	}
        	else if (x._estadoDeAvance < 0 || x._estadoDeAvance > 100){
        		throw new misExcepciones.excepcionEstadoInvalido("Ocurrió un error");
        	}
        	else {
        		obrasFinalizadas.Add(x);
        	}
        }
		
        
		// ------------------------------- VERIFICAR EL LEGAJO ------------------------------- //
		public void verificarLegajo(int legajo){
			 foreach (grupoObreros y in empresaGruposAsignado) {
				if (y.verificarLegajo(legajo) == false) { // Invoca la funcion creada en grupoObreros
							throw new misExcepciones.excepcionCodigoNoExiste("Legajo ocupado");
				}
		     }
		}
								
				
		// ------------------------------- AGREGAR GRUPO A LA EMPRESA (corregido) ------------------------------- //
		public void asignarGrupo(grupoObreros y, int codigo){
			
			foreach (grupoObreros x in empresaGruposAsignado) {
				if (x._codigoGrupo == codigo){
					throw new misExcepciones.excepcionCodigoRepetido("Ya existe un grupo con ese código");
				}
			}
			// Si no repite el código, que se asigne			
			empresaGruposAsignado.Add(y);
		}
		
		
		// ------------------------------- ASIGNAR A UN OBRERO A LA EMPRESA (corregido) ------------------------------- //
		public void asignarObreroEmpresa(obrero o, int preguntaCodigoInterno){			

				foreach (grupoObreros y in empresaGruposAsignado) {
				
					if (preguntaCodigoInterno == y._obraAsignadaGrupo){
					y.agregarObrero(o); // Invoca la funcion creada en grupoObreros
					return;						
					}					
				}
			throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
		}
		
		
		// ------------------------------- DESPEDIR UN OBRERO (corregido) ------------------------------- //
		public void despedirObrero(int legajoInterno){

			foreach (grupoObreros y in empresaGruposAsignado) {
				
				if (legajoInterno == y._obraAsignadaGrupo){					
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
			foreach (grupoObreros x in empresaGruposAsignado) {
				Console.WriteLine("\nObra: " + x._obraAsignadaGrupo + ".");
				x.verObreros(); // Invoca la funcion creada en grupoObreros
			}
		}
		
		
		
		// ------------------------------- VER A TODOS LOS JEFES ------------------------------- //
		
		public void verTodosLosJefes(){
			Console.WriteLine("\nJefes en obras en ejecucion:");
			foreach (obra y in obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){ // Invoca la funcion creada en obra
					y.verJefeAsignado(); // Invoca la funcion creada en obra
				}
			}			
		}
		
		
		
	// ------------------------------- CONTRATAR UN JEFE (corregido) ------------------------------- //
	
		public void contratarJefe(jefeObra jefeMetodo, int preguntaCodigoInterno){  
				
				foreach (obra g in obrasEnEjecucion) {
					if (preguntaCodigoInterno == g._codigoInterno) {
						
						if (g.ExisteUnJefe() == true){ // Invoca la funcion creada en obra, que devuelve un bool
			        		throw new misExcepciones.excepcionJefeAsignado("El grupo ya tiene un jefe asignado");
			        	}
						else {
							g.asignarJefe(jefeMetodo); // Invoca la funcion creada en obra
							
							foreach (grupoObreros grupo in empresaGruposAsignado) {
								jefeMetodo.asignarGrupo(grupo); // Invoca la funcion creada en jefeObra
							}
							Console.WriteLine("Se asignó con éxito al jefe " + jefeMetodo._nombre + " " + jefeMetodo._apellido + ".");
							return;							
						}						
					}
				
	       }
				throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
		}
		
		
		// ------------------------------- DESPEDIR JEFE (corregido) ------------------------------- //
		
		public void despedirJefe(int preguntaCodigoInterno){

			foreach (obra y in obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){ // Invoca la funcion creada en obra
					if (preguntaCodigoInterno == y._codigoInterno){
						y.eliminarJefe(y._legajoJefe); // Invoca la funcion creada en obra
						return;
					}
				}
				else {
					Console.WriteLine("No existe un jefe"); 
					return;
				}
				
			}
			throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
		} 
				

		// ------------------------------- CANTIDAD DE OBRAS EN EJECUCIÓN ------------------------------- //
		
		public void cantidadObrasEnEjecucion(){
			int cantidad = 0;
			foreach (obra x in obrasEnEjecucion) {
				cantidad ++;
			}
			Console.WriteLine(cantidad);
		}
		
				
		// ------------------------------- CANTIDAD DE OBRAS FINALIZADAS ------------------------------- //
		
		public void cantidadObrasFinalizadas(){
			int cantidad = 0;
			foreach (obra x in obrasFinalizadas) {
				cantidad ++;
			}
			Console.WriteLine(cantidad);
		}
				
		
		// ------------------------------- CANTIDAD DE OBRAS EN 'REMODELACION' SIN FINALIZAR ------------------------------- //
		
		public void porcentajeRemodelacion(){
			//	LAS OBRAS EN REMODELACION
			int cantidadRemodelacion = 0;
			foreach (obra y in obrasEnEjecucion) {
				if ((y._tipoObra).ToUpper() == "REMODELACION"){
					cantidadRemodelacion ++;
				}
			}                                
			// TODAS LAS OBRAS
			int cantidadObras = 0;
			foreach (obra x in obrasEnEjecucion) {
				cantidadObras ++;
			}			
			int cuenta = (cantidadRemodelacion * 100) / cantidadObras;			
			Console.WriteLine("El porcentaje de obras en remodelacion sin finalizar es de " + cuenta + "%.");
		}
				
		
		// ------------------------------- MODIFICAR ESTADO DE UNA OBRA DENTRO DE LA EMPRESA (corregido) ------------------------------- //
		
		public void ObraModificarEstado(int preguntaCodigoInterno){
			
			foreach (obra y in obrasEnEjecucion) {
				
				if (preguntaCodigoInterno == y._codigoInterno){
					y.modificarEstado(); // Invoca la funcion creada en obra
					
					if (y._estadoDeAvance == 100){
						obrasFinalizadas.Add(y); // Si el estado pasa a ser 100%, se agrega a obrasFinalizadas
						obrasEnEjecucion.Remove(y); // y se elimina de obrasEnEjecucion
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
			foreach (obra x in obrasEnEjecucion) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}	
		}
		
		
		// ------------------------------- VER LISTADO DE OBRAS FINALIZADAS ------------------------------- //
		
		public void listadoObrasFinalizadas(){
			foreach (obra x in obrasFinalizadas) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}	
		}
		
		// --- FIN --- //		
	}
}
