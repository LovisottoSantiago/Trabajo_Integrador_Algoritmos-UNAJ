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
			
			
			// ASIGNAR OBRA PUENTE AL GRUPO 1235
			Grupo1235.asignarObra(puenteFcioVarela);
			
			
			// ASIGNAR OBRA ROTONDA AL GRUPO 1235
			Grupo1240.asignarObra(rotonda);
			
			
			// ASIGNAR OBRA ROTONDA AL GRUPO 2006
			Grupo2006.asignarObra(canchaFulbo);
			
			
			
			// Obras en ejecucion
			ArrayList listaObrasEjecucion = new ArrayList();
			//listaObrasEjecucion.Add(puenteFcioVarela);
		//	listaObrasEjecucion.Add(rotonda);
		//	listaObrasEjecucion.Add(canchaFulbo);
			
			ArrayList listaObrasFinalizadas = new ArrayList();
			
			
			
			// Creacion de la Empresa
			empresa miEmpresa = new empresa(listaObrasEjecucion, listaObrasFinalizadas);
			
			miEmpresa.asignarGrupo(Grupo1235);
			miEmpresa.asignarGrupo(Grupo1240);  // ASIGNACIÓN DE GRUPOS A LA EMPRESA
			miEmpresa.asignarGrupo(Grupo2006);
			
			
			miEmpresa.agregarObraEmpresa(puenteFcioVarela);
			miEmpresa.agregarObraEmpresa(rotonda);  // ASIGNACIÓN DE OBRAS A LA EMPRESA TENIENDO EN CUENTA
			miEmpresa.agregarObraEmpresa(canchaFulbo); // SU ESTADO DE AVANCE %.
			
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
				Console.WriteLine("7. Crear Obra");
				Console.WriteLine("8. Salir");
				
				
				// Manejador de excepciones | PRINCIPAL, por si el usuario no elije un número (int)
				try{
					Console.Write("Elija una opción: ");
					int menuOpcion = Convert.ToInt32(Console.ReadLine());
					
					// Si se respeta la condicion
					
					switch (menuOpcion) {
						
						// OPCION 1: CONTRATAR OBRERO
						case 1:
							Console.Clear();
							Console.WriteLine("Contratar un obrero nuevo (se agrega a la empresa y a un grupo).\n");
							miEmpresa.contratarObrero();

							break;
							
						// OPCION 2: ELIMINAR UN OBRERO
						case 2:
							Console.Clear();
							Console.WriteLine("Eliminar un obrero (se elimina de la empresa y de su grupo).\n");
							miEmpresa.despedirObrero();

							break;

						// OPCION 3: CONTRATAR UN JEFE DE OBRA
						case 3:
							
							Console.WriteLine("\nContratar a un jefe de obra");
							miEmpresa.contratarJefe();
							
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
											Console.Clear();
											Console.WriteLine("------------------------------ Ver listado de obreros ------------------------------\n");
											miEmpresa.verTodosLosObreros();
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
											// miEmpresa.cantidadObrasEnEjecucion(); //Me muestra la cantidad de obras en ejecucion
										    // miEmpresa.cantidadObrasFinalizadas(); //Me muestra la cantidad de obras en ejecucion
										    miEmpresa.porcentajeRemodelacion();
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
							Console.Clear();
							Console.WriteLine("Modificar el estado de avance de una obra.");
							miEmpresa.ObraModificarEstado();
							break;


						// OPCION 6: DAR DE BAJA A UN JEFE
						case 6:
							Console.Clear();
							Console.WriteLine("Dar de baja a un jefe.");
							miEmpresa.despedirJefe();
							break;
							
						
						// OPCION 7: CREAR OBRA
						case 7:
							Console.Clear();
							Console.WriteLine("------------------------------ Crear Obra ------------------------------\n");
							
							try {
								obra a = miEmpresa.crearObra(); // Como crearObra devuelve una obra, la asigno en una variable							
								miEmpresa.agregarObraEmpresa(a); 	
							}
							catch (misExcepciones.excepcionCodigoRepetido e) {
								Console.WriteLine(e.Message);
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

			}
				
				


			
			
			
			/*
			//PREVIO 
			obra PatioBacclean = new obra("Baccleaning Charles", "123123", 09, "Limpiezaning", 900000);
							
			jefeObra ELJEFOTE = new jefeObra("SUPREME BACCLEANING", "Bacclean", "6321", 999, 1200, "Jefe", 7000);			

			ELJEFOTE.asignarGrupo(LosPibes);
						
			PatioBacclean.asignarJefe(ELJEFOTE);
			
			//PatioBacclean.verJefeAsignado();
			
			
			// Cambiar porcentaje de obra
			PatioBacclean.modificarEstado();
			
			ArrayList lista1 = new ArrayList();
			lista1.Add(PatioBacclean);
			ArrayList lista2 = new ArrayList();
			
			
			// Asignar grupo de la obra
			empresa BaccleanInc = new empresa(lista1, lista2);
			BaccleanInc.asignarGrupo(LosPibes);
			
			BaccleanInc.despedirObrero();
			
			
			LosPibes.verObreros();
			
			
			
			
			
			
			
			
			
			
			
			/* ELIMINAR OBRERO
			
			
			try {
				Console.Write("¿Cual desea eliminar? [legajo]: ");
				int pregunta = Convert.ToInt32(Console.ReadLine());						
				LosPibes.eliminarObrero(pregunta);
			}
			catch (FormatException){
				Console.WriteLine("Porfavor, ingresa un número.");
			} */	

			
			
			
			
			/* VISUALIZAR OBRERO
			try {
				Console.Write("¿Cual desea visualizar? [legajo]: ");
				int pregunta = Convert.ToInt32(Console.ReadLine());						
				LosPibes.visualizarObrero(pregunta);
			}
			catch (FormatException){
				Console.WriteLine("Porfavor, ingresa un número.");
			} */
			
			
			
			
			/* VER CANTIDAD DE OBREROS
			LosPibes.cantidadObreros(); */
			
			
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}