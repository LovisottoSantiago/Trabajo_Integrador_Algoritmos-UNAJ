using System;
using System.Collections;
namespace Integrador
	
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			//PRIMER GRUPO DE OBREROS
			obrero Agustin = new obrero("Agustin", "Bacclean", "44.000.400", 0001, 350000, "Capataz");
			obrero Lucas = new obrero("Lucas", "Pradela", "34.300.100", 0002, 350000, "Peon");
			obrero Jorgito = new obrero("Jorge", "Johnson", "41.902.900", 888, 350000, "Electricista");
			obrero Santiago = new obrero("Santiago", "Lovinson", "45.004.460", 0004, 350000, "Plomero");
			obrero Raul = new obrero("Raul", "Bacclean", "38.060.130", 0005, 350000, "Techista");
			
			// Crear el grupo de obreros 1235
			grupoObreros Grupo1235 = new grupoObreros(1235);
			
			Grupo1235.agregarObrero(Agustin);
			Grupo1235.agregarObrero(Lucas);
			Grupo1235.agregarObrero(Jorgito);
			Grupo1235.agregarObrero(Santiago);
			Grupo1235.agregarObrero(Raul);
			

			//SEGUNDO GRUPO DE OBREROS
			obrero Pedro = new obrero("Pedro", "González", "44.000.4400", 0006, 320000, "Carpintero");
			obrero Javier = new obrero("Javier", "Martínez", "34.300.200", 0007, 320000, "Albañil");
			obrero Luis = new obrero("Luis", "Fernández", "41.902.950", 0008, 320000, "Pintor");
			obrero Carlos = new obrero("Carlos", "López", "45.004.470", 0009, 320000, "Electricista");
			obrero Manuel = new obrero("Manuel", "Rodríguez", "38.060.150", 0099, 320000, "Plomero");
			
			// Crear el grupo de obreros 1240
			grupoObreros Grupo1240 = new grupoObreros(1240);
			
			Grupo1240.agregarObrero(Pedro);
			Grupo1240.agregarObrero(Javier);
			Grupo1240.agregarObrero(Luis);
			Grupo1240.agregarObrero(Carlos);
			Grupo1240.agregarObrero(Manuel);
														

			//TERCER GRUPO DE OBREROS (SIN JEFE)
			obrero Messi = new obrero("Leo", "Messi", "34.000.4400", 0010, 320000, "Carpintero");
			obrero Mascherano = new obrero("Javier", "Masche", "33.343.200", 0011, 320000, "Albañil");
			obrero CR7 = new obrero("Cristiano", "Ronaldo", "30.777.777", 0077, 320000, "Pintor");
			obrero Higuain = new obrero("Higuain", "Pipita", "25.004.470", 0012, 320000, "Electricista");
			obrero Tevez = new obrero("Carlos", "Tevez", "28.060.150", 0013, 320000, "Plomero");
			
			
			// Crear el grupo de obreros 2006
			grupoObreros Grupo2006 = new grupoObreros(2006);
			
			Grupo2006.agregarObrero(Messi);
			Grupo2006.agregarObrero(Mascherano);
			Grupo2006.agregarObrero(CR7);
			Grupo2006.agregarObrero(Higuain);
			Grupo2006.agregarObrero(Tevez);
			
			
			//Creación de 2 jefes
			jefeObra jefeRamon = new jefeObra("Ramón", "Baccleaning", "37912005", 77300, 350000, "Jefe de Obra", 180000);
			jefeRamon.asignarGrupo(Grupo1235);
			
			jefeObra jefeJulio = new jefeObra("Julio", "Fernandez", "33511031", 65305, 320000, "Jefe de Obra", 150000);
			jefeJulio.asignarGrupo(Grupo1240);
						
			//No se crea un tercer jefe para probar el enunciado
			
			
			// Creación de 3 obras
			obra puenteFcioVarela = new obra("Jeremy Jackson", "20.152.912", 555, "Remodelacion", 20, 10500250);
			puenteFcioVarela.asignarJefe(jefeRamon);
			
			
			obra rotonda = new obra("Fabricio Diaz", "35.184.557", 999, "Remodelacion", 70,2900000);
			rotonda.asignarJefe(jefeJulio);

			
			obra canchaFulbo = new obra("Chiqui Tapia", "15.859.151", 206, "Construcción de cancha", 10, 23500250);
			
			
			// !!! Codigo nuevo por correccion, 22/06/2024
			//crear obra finalizada
			obra pipiCucu = new obra("John Johnson", "12.356.925", 666, "Jardin Japones", 100, 500000);
			
			
			// ASIGNAR OBRA PUENTE AL GRUPO 1235
			Grupo1235.asignarObra(puenteFcioVarela);
			
			
			// ASIGNAR OBRA ROTONDA AL GRUPO 1235
			Grupo1240.asignarObra(rotonda);
			
			
			// ASIGNAR OBRA ROTONDA AL GRUPO 2006
			Grupo2006.asignarObra(canchaFulbo);
			
			
			// !!! eliminado el 22/06/24
			// Obras en ejecucion 
			/*
			ArrayList listaObrasEjecucion = new ArrayList();			
			ArrayList listaObrasFinalizadas = new ArrayList();			
			*/
			
			// Creacion de la Empresa
			empresa miEmpresa = new empresa();
			
			miEmpresa.asignarGrupo(Grupo1235, 1235);
			miEmpresa.asignarGrupo(Grupo1240, 1240);  // ASIGNACIÓN DE GRUPOS A LA EMPRESA
			miEmpresa.asignarGrupo(Grupo2006, 2006);
			
			
			miEmpresa.agregarObraEmpresa(puenteFcioVarela);
			miEmpresa.agregarObraEmpresa(rotonda);  // ASIGNACIÓN DE OBRAS A LA EMPRESA TENIENDO EN CUENTA
			miEmpresa.agregarObraEmpresa(canchaFulbo); // SU ESTADO DE AVANCE %.
			miEmpresa.agregarObraEmpresa(pipiCucu);
			
			bool menuPrincipal = true;
			
			while (menuPrincipal){
				
				Console.WriteLine("                                                    ");
				Console.WriteLine("       ██╗   ██╗███╗   ██╗ █████╗      ██╗          ");
				Console.WriteLine("       ██║   ██║████╗  ██║██╔══██╗     ██║          ");
				Console.WriteLine("       ██║   ██║██╔██╗ ██║███████║     ██║          ");
				Console.WriteLine("       ██║   ██║██║╚██╗██║██╔══██║██   ██║          ");
				Console.WriteLine("       ╚██████╔╝██║ ╚████║██║  ██║╚█████╔╝          ");
				Console.WriteLine("        ╚═════╝ ╚═╝  ╚═══╝╚═╝  ╚═╝ ╚════╝           ");
				Console.WriteLine("                                                    ");
				Console.WriteLine("        Lovisotto Santiago & Pradela Axel           ");
				Console.WriteLine("                                                    ");
				

				Console.WriteLine("Menu de opciones");
				Console.WriteLine("1. Contratar un obrero nuevo.");
				Console.WriteLine("2. Eliminar un obrero.");
				Console.WriteLine("3. Contratar a un jefe de obra.");
				Console.WriteLine("4. Submenú de impresión");
				Console.WriteLine("5. Modificar el estado de avance de una obra");
				Console.WriteLine("6. Dar de baja a un jefe");
				Console.WriteLine("7. Crear Obra (idea de los estudiantes)");
				Console.WriteLine("8. Salir");
				
				
				// Manejador de excepciones | PRINCIPAL, por si el usuario no elije un número (int)
				try{
					Console.Write("Elija una opción: ");
					int menuOpcion = Convert.ToInt32(Console.ReadLine());
					
					// Si se respeta la condicion
					
					switch (menuOpcion) {
						
						// OPCION 1: CONTRATAR OBRERO
						case 1:
							Console.WriteLine("--------------- CONTRATAR A UN OBRERO ---------------\n");
							try {
								obrero A = IngresarObrero(miEmpresa);
								int codigo = MostrarListaObras(miEmpresa);
								miEmpresa.asignarObreroEmpresa(A, codigo);
								Console.WriteLine("¡Obrero contratado correctamente!");
							}
							catch (misExcepciones.excepcionCodigoNoExiste u){
								Console.WriteLine(u.Message);
							}

							break;
							
						// OPCION 2: ELIMINAR UN OBRERO
						case 2:
							Console.WriteLine("--------------- ELIMINAR A UN OBRERO ---------------\n");
							try {
								int codigoObra = MostrarListaObras(miEmpresa);		
								miEmpresa.verTodosLosObreros(codigoObra);
								
								Console.Write("Ingrese el legajo: ");
								int legajo = Convert.ToInt32(Console.ReadLine());
								
								miEmpresa.despedirObrero(codigoObra, legajo); //recibe 2 parametros
								Console.WriteLine("Obrero despedido correctamente");
																																								
							}
							catch (misExcepciones.excepcionCodigoNoExiste a){ //si no existe la obra o el legajo
								Console.WriteLine(a.Message);
							}							
							break;

						// OPCION 3: CONTRATAR UN JEFE DE OBRA
						case 3:
							Console.WriteLine("--------------- CONTRATAR A UN JEFE DE OBRA ---------------\n");
							try {
								jefeObra C = funcionContratarJefe(miEmpresa);
								int codigo = MostrarListaObras(miEmpresa);
								miEmpresa.contratarJefe(C, codigo);
								Console.WriteLine("¡Jefe Contratado!");
							}
							catch (misExcepciones.excepcionCodigoNoExiste u){
								Console.WriteLine(u.Message);
							}
							catch (misExcepciones.excepcionJefeAsignado u){
								Console.WriteLine(u.Message);
							}
							break;

						// OPCION 4: SUBMENU
						case 4:
							
							bool submenuCondicion = true;
							while(submenuCondicion){
								Console.WriteLine("                                                                             ");
								Console.WriteLine("       ███████╗██╗   ██╗██████╗ ███╗   ███╗███████╗███╗   ██╗██╗   ██╗       ");
								Console.WriteLine("       ██╔════╝██║   ██║██╔══██╗████╗ ████║██╔════╝████╗  ██║██║   ██║       ");
								Console.WriteLine("       ███████╗██║   ██║██████╔╝██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║       ");
								Console.WriteLine("       ╚════██║██║   ██║██╔══██╗██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║       ");
								Console.WriteLine("       ███████║╚██████╔╝██████╔╝██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝       ");
								Console.WriteLine("       ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝        ");
								Console.WriteLine("                                                                             ");
								Console.WriteLine("Submenu de opciones:");

								Console.WriteLine("a. Ver listado de obreros");
								Console.WriteLine("b. Ver listado de obras en ejecución");
								Console.WriteLine("c. Ver listado de obras finalizadas");
								Console.WriteLine("d. Ver listado de jefes");
								Console.WriteLine("e. Ver porcentaje de obras de remodelación sin finalizar");
								Console.WriteLine("x. Salir");
								
								
								// MANEJO DE EXCEPCIONES
								try{
									Console.Write("Elije una opción: ");
									string opcionSubmenu = Console.ReadLine();
									
									switch (opcionSubmenu) {
										case "a":
											Console.WriteLine("------------------------------ Ver listado de obreros ------------------------------\n");
											int nObra = MostrarListaObras(miEmpresa);
											miEmpresa.verTodosLosObreros(nObra);
											break;
											
										case "b":
											Console.WriteLine("------------------------------ Ver listado de obras en ejecución ------------------------------\n");
											miEmpresa.listadoObrasEnEjecucion();
											break;
											
										case "c":
											Console.WriteLine("------------------------------ Ver listado de obras finalizadas ------------------------------\n");
											miEmpresa.listadoObrasFinalizadas();											
											break;
											
										case "d":
											Console.WriteLine("------------------------------ Ver listado de jefes ------------------------------\n");
											miEmpresa.verTodosLosJefes();
											break;
											
										case "e":
											Console.WriteLine("-------------- Ver porcentaje de obras de remodelación sin finalizar --------------\n");
										    int a = miEmpresa.porcentajeRemodelacion();
										    Console.WriteLine("El porcentaje de obras en remodelacion sin finalizar es de " + a + "%.");
											break;
											
										case "x":
											Console.WriteLine("Saliendo...");
											submenuCondicion = false;											
											break;	
											
										default:
											Console.WriteLine("No elegiste ninguna opción");
											break;
									}
									
								}
								catch (FormatException){
									Console.WriteLine("Porfavor, ingresa una letra");
								}
							}

							break;


						// OPCION 5: MODIFICAR ESTADO DE OBRA
						case 5:
							Console.WriteLine("--------------- MODIFICAR ESTADO DE AVANCE DE UNA OBRA ---------------\n");
							try {
								int codigo = MostrarListaObras(miEmpresa);
								miEmpresa.ObraModificarEstado(codigo);
							} 
							catch (misExcepciones.excepcionModificarObra o) {
								Console.WriteLine(o.Message);
							}
							break;


						// OPCION 6: DAR DE BAJA A UN JEFE
						case 6:
							Console.WriteLine("--------------- DAR DE BAJA A UN JEFE ---------------\n");
							try {
								int codigo = MostrarListaObras(miEmpresa);
								miEmpresa.despedirJefe(codigo);
								Console.WriteLine("¡Jefe despedido!");
							}
							catch (misExcepciones.excepcionCodigoNoExiste u){
								Console.WriteLine(u.Message);
							}
							break;
							
						
						// OPCION 7: CREAR OBRA
						case 7:
							Console.WriteLine("------------------------------ Crear Obra ------------------------------\n");
							
							try {
								obra a = crearObra(miEmpresa); // Como crearObra devuelve una obra, la asigno en una variable							
								
								Console.Write("Ingresa un codigo para el grupo asignado: ");
								int codigoG = Convert.ToInt32(Console.ReadLine());
								grupoObreros grupoNuevo = new grupoObreros(codigoG);
								
								miEmpresa.asignarGrupo(grupoNuevo, codigoG); // Evaluo si el codigo del grupo no se repite
								
								miEmpresa.agregarObraEmpresa(a); // Si no se repite, agrego la obra
								grupoNuevo.asignarObra(a); // Le asigno la obra al grupo
								Console.WriteLine("¡Obra creada!");
							}
							catch (misExcepciones.excepcionCodigoRepetido e) {
								Console.WriteLine(e.Message);
							}
							catch (misExcepciones.excepcionAsignarGrupo x) {
								Console.WriteLine(x.Message);
							}
							catch (misExcepciones.excepcionEstadoInvalido c){
								Console.WriteLine(c.Message);
							}
														
							break;
							
						case 8:
							Console.WriteLine("Saliendo...");
							menuPrincipal = false;
							break;	
							
						default:
							Console.WriteLine("La opción que elegiste no es correcta\n");
							break;
					}
	
				}
				
				// Para manejar la excepcion del menu, si el usuario no ingresa un numero e ingresa una letra
				catch (FormatException){
					Console.WriteLine("Porfavor, ingresa un número");
				}
				catch (OverflowException){
					Console.WriteLine("Valor fuera del rango");
				}
			}	
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		
		
			// METODOS PARA CORREGIR EL EXCESO DE PERSONALIZACION DE CLASE EMPRESA (correccion de la profesora)
			// !
			// !
			// !
			// ------------------------------- CARGA DATOS DE OBRERO Y DEVUELVE UN OBRERO------------------------------- //
			public static obrero IngresarObrero(empresa emp){
				Console.Write("Ingrese el nombre: ");
		        string nombre = Console.ReadLine();
		        Console.Write("Ingrese el apellido: ");
		        string apellido = Console.ReadLine();
		        Console.Write("Ingrese el DNI: ");
		        string dni = Console.ReadLine();
		        Console.Write("Ingrese el legajo: ");
		        int legajo = Convert.ToInt32(Console.ReadLine());
		        
		        emp.verificarLegajo(legajo);
		        
		        Console.Write("Ingrese el sueldo: ");
		        double sueldo = Convert.ToDouble(Console.ReadLine());
		        Console.Write("Ingrese el cargo [Capataz, Albañil, Peón, Plomero, Electricista]: ");
		        string cargo = Console.ReadLine();
		        
		        obrero obreroContratado = new obrero(nombre, apellido, dni, legajo, sueldo, cargo);
		        
				return obreroContratado;
			}
			
			
			// ------------------------------- CARGA DATOS DE JEFE Y DEVUELVE UN JEFE ------------------------------- //
			public static jefeObra funcionContratarJefe(empresa emp){
				Console.Write("Ingrese el nombre: ");
		        string nombre = Console.ReadLine();
		        Console.Write("Ingrese el apellido: ");
		        string apellido = Console.ReadLine();
		        Console.Write("Ingrese el DNI: ");
		        string dni = Console.ReadLine();	
		        Console.Write("Ingrese el legajo: ");
		        int legajo = Convert.ToInt32(Console.ReadLine());	
				emp.verificarLegajo(legajo);		        
		        
		        
		        Console.Write("Ingrese el sueldo: ");
		        double sueldo = Convert.ToDouble(Console.ReadLine());	
		        string cargo = "Jefe";			
		        Console.Write("Ingrese la bonificación: ");
		        double bonificacion = Convert.ToDouble(Console.ReadLine());
		        
		        jefeObra jefeMetodo = new jefeObra(nombre, apellido, dni, legajo, sueldo, cargo, bonificacion);
		        return jefeMetodo;
		        
			}
			
			
			// ------------------------------- MUESTRA LAS OBRAS Y DEVUELVE UN INT ------------------------------- //
			public static int MostrarListaObras(empresa emp){
				Console.WriteLine("------Lista de obras------"); 
		        foreach (obra x in emp._obrasEnEjecucion) {
					Console.WriteLine(x._codigoInterno + ", " + x._tipoObra + ".");
				}
				
				Console.Write("\nIngresar codigo: "); 
				int preguntaCodigoInterno = Convert.ToInt32(Console.ReadLine());
				return preguntaCodigoInterno;				
			}
		

			// ------------------------------- CREAR OBRA (idea propia) ------------------------------- //
			public static obra crearObra(empresa emp){
				Console.Write("Ingresar nombre del propietario: ");
				string nombrePropietario = Console.ReadLine();
				Console.Write("Ingresar DNI del propietario: ");
				string dniPropietario = Console.ReadLine();
				Console.Write("Ingresar codigo interno: ");
				int codigoInterno = Convert.ToInt32(Console.ReadLine());
				
				foreach (obra y in emp._obrasEnEjecucion) {
					if (y._codigoInterno == codigoInterno){
						throw new misExcepciones.excepcionCodigoRepetido("Ese codigo ya existe");
					}
				} 
				
				Console.Write("Ingresar tipo de obra: ");
				string tipoObra = Console.ReadLine();
				Console.Write("Ingresar estado de avance [0 - 100]: ");
				double estadoDeAvance = Convert.ToDouble(Console.ReadLine());
				if (estadoDeAvance > 100) {
					throw new misExcepciones.excepcionEstadoInvalido("Opcion incorrecta");
				}
				else if (estadoDeAvance < 0) {
					throw new misExcepciones.excepcionEstadoInvalido("Opcion incorrecta");
				}
				Console.Write("Ingresar costo: ");
				double costo = Convert.ToDouble(Console.ReadLine());
				
				obra nuevaObra = new obra(nombrePropietario, dniPropietario, codigoInterno, tipoObra, estadoDeAvance, costo);					
				return nuevaObra;
			}
			
			
			// ------------------------------- FIN ------------------------------- //
			
	}
}