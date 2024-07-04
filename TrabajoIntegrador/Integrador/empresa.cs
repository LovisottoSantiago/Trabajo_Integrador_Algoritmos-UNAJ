using System;
using System.Collections;
namespace Integrador
	
{
	public class empresa
	{
		private ArrayList obrasEnEjecucion;
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
		}
		
		public ArrayList _obrasFinalizadas{ //defino una instancia para visualizar su dato, pero no sobreescribirlo
			get {return obrasFinalizadas;}
		}
		
		public ArrayList _empresaGruposAsignado{ //defino una instancia para visualizar su dato, pero no sobreescribirlo
			get {return empresaGruposAsignado;}
		}
		
		

		// ------------------------------- AGREGAR OBRA A LA EMPRESA ------------------------------- //
        public void agregarObraEmpresa(obra x) //void agregarElemento(Elemento e);
        {
        	if (x._estadoDeAvance < 100 && x._estadoDeAvance >= 0){
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
								
				
		// ------------------------------- AGREGAR GRUPO A LA EMPRESA ------------------------------- //
		public void asignarGrupo(grupoObreros y, int codigo){ //void agregarElemento(Elemento e);
			
			foreach (grupoObreros x in empresaGruposAsignado) {
				if (x._codigoGrupo == codigo){
					throw new misExcepciones.excepcionCodigoRepetido("Ya existe un grupo con ese código");
				}
			}
			// Si no repite el código, que se asigne			
			empresaGruposAsignado.Add(y); //void agregarElemento(Elemento e);
		}
		
		
		// ------------------------------- ASIGNAR A UN OBRERO A LA EMPRESA ------------------------------- //
		public void asignarObreroEmpresa(obrero o, int preguntaCodigoInterno){			

				foreach (grupoObreros y in empresaGruposAsignado) {
					if (preguntaCodigoInterno == y._obraAsignadaGrupo){
					y.agregarObrero(o); // Invoca la funcion creada en grupoObreros					
					}					
				}
		}
		
		
		// ------------------------------- DESPEDIR UN OBRERO ------------------------------- //
		public void despedirObrero(int legajoInterno, int legajoObrero){ //void eliminarElemento(Elemento e)
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
			foreach (grupoObreros x in empresaGruposAsignado) { //void listadoElementos()
				if (nObra == x._obraAsignadaGrupo){
					x.verObreros(); // Invoca la funcion creada en grupoObreros			
				}
			}
		}
		
		
		// Lo pide el enunciado por listado (no se usa en nuestro caso) Elemento verElemento(id)
		public void verElementoGrupoAsignado(int nObra){
			foreach (grupoObreros x in empresaGruposAsignado) { 
				if (nObra == x._obraAsignadaGrupo){
					Console.WriteLine(x._codigoGrupo); 
				}
			}
		}
				
		
		
		// Lo pide el enunciado por listado (no se usa en nuestro caso) int cantidadElementos()
		public int verCantidadGrupoAsignado(){
			int cantidad = 0;
			foreach (grupoObreros x in empresaGruposAsignado) { 
				cantidad++;
			}
			return cantidad;
		}
		
		
		// ------------------------------- VER A TODOS LOS JEFES ------------------------------- //
		public void verTodosLosJefes(){
			foreach (obra y in obrasEnEjecucion) {
				if (y.ExisteUnJefe() == true){ // Invoca la funcion creada en obra
					y.verJefeAsignado(); // Invoca la funcion creada en obra
				}
			}			
		}
		
		
		
		// ------------------------------- CONTRATAR UN JEFE ------------------------------- //
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
		}
		
		
		// ------------------------------- DESPEDIR JEFE (corregido) ------------------------------- //
		public void despedirJefe(int preguntaCodigoInterno){			
			foreach (obra y in obrasEnEjecucion) {
				if (preguntaCodigoInterno == y._codigoInterno){ // Se fija que exista un jefe
					if (y.ExisteUnJefe() == true){
						y.eliminarJefe(); // Invoca la funcion creada en obra
						return;
					}
					else{
						throw new misExcepciones.excepcionCodigoNoExiste("No existe un jefe en esa obra");
					}
				}				
			}
		} 
				

		// ------------------------------- CANTIDAD DE OBRAS EN EJECUCIÓN ------------------------------- //
		public int cantidadObrasEnEjecucion(){ //int cantidadElementos()
			int cantidad = 0;
			foreach (obra x in obrasEnEjecucion) {
				cantidad ++;
			}
			return cantidad;
		}
		
		// Lo pide el enunciado por listado (no se usa en nuestro caso) void eliminarElemento(Elemento e)
		public void eliminarElementoObrasEnEjecucion(obra x){ 
			obrasEnEjecucion.Remove(x);
		}
		
		// Lo pide el enunciado por listado (no se usa en nuestro caso) Elemento verElemento(id)
		public void verElementoObrasEnEjecucion(int codigo){
			foreach (obra x in obrasEnEjecucion) {
				if (codigo == x._codigoInterno){
					Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
				}
			}
		}
		
		// Lo pide el enunciado por listado (no se usa en nuestro caso) void eliminarElemento(Elemento e)
		public void eliminarElementoObrasFinalizadas(obra x){ 
			obrasFinalizadas.Remove(x);
		}
		
		
		// Lo pide el enunciado por listado (no se usa en nuestro caso) Elemento verElemento(id)
		public void verElementoObrasFinalizadas(int codigo){
			foreach (obra x in obrasFinalizadas) {
				if (codigo == x._codigoInterno){
					Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
				}
			}
		}
		
		
				
		// ------------------------------- CANTIDAD DE OBRAS FINALIZADAS ------------------------------- //
		public int cantidadObrasFinalizadas(){ // int cantidadElementos()
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
		public void ObraModificarEstado(int preguntaCodigoInterno, double valor){
			
			foreach (obra y in obrasEnEjecucion) {
				
				if (preguntaCodigoInterno == y._codigoInterno){
					y.modificarEstado(valor); // Invoca la funcion creada en obra
					
					if (y._estadoDeAvance == 100){
						obrasFinalizadas.Add(y); // Si el estado pasa a ser 100%, se agrega a obrasFinalizadas
						obrasEnEjecucion.Remove(y); // y se elimina de obrasEnEjecucion
						return;
					}
				}
			}
		}
				
		

		// ------------------------------- VER LISTADO DE OBRAS EN EJECUCION ------------------------------- //
		
		public void listadoObrasEnEjecucion(){ // void listadoElementos()
			foreach (obra x in obrasEnEjecucion) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}	
		}
		
		
		// ------------------------------- VER LISTADO DE OBRAS FINALIZADAS ------------------------------- //
		
		public void listadoObrasFinalizadas(){ // void listadoElementos()
			foreach (obra x in obrasFinalizadas) {
				Console.WriteLine(x._tipoObra + ", codigo " + x._codigoInterno + ", avance " + x._estadoDeAvance + "%, propietario: " + x._nombrePropietario + ", jefe de obra asignado: " + x._nombreJefe + ".\n");
			}	
		}
		
		// --- FIN --- //		
	}
}
