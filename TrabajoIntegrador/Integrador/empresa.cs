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
		public void despedirObrero(int legajoInterno, int legajoObrero){

			foreach (grupoObreros y in empresaGruposAsignado) {				
				if (legajoInterno == y._obraAsignadaGrupo){																
						y.eliminarObrero(legajoObrero); // Invoca la funcion creada en grupoObreros
						return;						
					}
				}
			throw new misExcepciones.excepcionCodigoNoExiste("El codigo ingresado es incorrecto");
		}

		
		// ------------------------------- VER A TODOS LOS OBREROS ------------------------------- //		
		public void verTodosLosObreros(int nObra){
			foreach (grupoObreros x in empresaGruposAsignado) {
				if (nObra == x._obraAsignadaGrupo){
					x.verObreros(); // Invoca la funcion creada en grupoObreros
					return;				
				}
			}
			throw new misExcepciones.excepcionCodigoNoExiste("Esa obra no existe");
		}
				
		
		// ------------------------------- VER A TODOS LOS JEFES ------------------------------- //
		public void verTodosLosJefes(){
			foreach (obra y in obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){ // Invoca la funcion creada en obra
					y.verJefeAsignado(); // Invoca la funcion creada en obra
				}
			}			
		}
		
		
		
		// ------------------------------- CONTRATAR UN JEFE (corregido) ------------------------------- //
		public void contratarJefe(jefeObra jefe, int preguntaCodigoInterno){  
				
			foreach (obra g in obrasEnEjecucion) {
				if (preguntaCodigoInterno == g._codigoInterno) {
					if (g.ExisteUnJefe() == false){ // Si no existe un jefe en esa obra
						g.asignarJefe(jefe); // asigno un jefe
						foreach (grupoObreros grupo in empresaGruposAsignado) {
							jefe.asignarGrupo(grupo); // le asigno un grupo a ese jefe
						}							
						return;							
					}	
					else{
						throw new misExcepciones.excepcionCodigoNoExiste("Esa obra ya tiene un jefe asignado");
					}
				}							
	       	}
			throw new misExcepciones.excepcionCodigoNoExiste("Esa obra no existe");
		}
		
		
		// ------------------------------- DESPEDIR JEFE (corregido) ------------------------------- //
		public void despedirJefe(int preguntaCodigoInterno){
			
			foreach (obra y in obrasEnEjecucion) {
				if (preguntaCodigoInterno == y._codigoInterno){ // Se fija que exista un jefe
					if (y.ExisteUnJefe() == true){
						y.eliminarJefe(y._legajoJefe); // Invoca la funcion creada en obra
						return;
					}
					else{
						throw new misExcepciones.excepcionCodigoNoExiste("No existe un jefe en esa obra");
					}
				}				
			}
			throw new misExcepciones.excepcionCodigoNoExiste("La obra no existe");
		} 
				

		// ------------------------------- CANTIDAD DE OBRAS EN EJECUCIÓN ------------------------------- //
		public int cantidadObrasEnEjecucion(){
			int cantidad = 0;
			foreach (obra x in obrasEnEjecucion) {
				cantidad ++;
			}
			return cantidad;
		}
		
				
		// ------------------------------- CANTIDAD DE OBRAS FINALIZADAS ------------------------------- //
		public int cantidadObrasFinalizadas(){
			int cantidad = 0;
			foreach (obra x in obrasFinalizadas) {
				cantidad ++;
			}
			return cantidad;
		}
				
		
		// ------------------------------- CANTIDAD DE OBRAS EN 'REMODELACION' SIN FINALIZAR ------------------------------- //
		public int porcentajeRemodelacion(){
			int cantidadRemodelacion = 0;
			foreach (obra y in obrasEnEjecucion) {
				if ((y._tipoObra).ToUpper() == "REMODELACION"){
					cantidadRemodelacion ++;
				}
			}                                
			int cantidadObras = cantidadObrasEnEjecucion();	
			int cuenta = (cantidadRemodelacion * 100) / cantidadObras;	
			return cuenta;
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
