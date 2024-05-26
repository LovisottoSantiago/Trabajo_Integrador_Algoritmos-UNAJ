using System;
using System.Collections;
namespace Integrador
	
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Bienvenido al programa");
			
			
			//PRIMER GRUPO DE OBREROS
			obrero Agustin = new obrero("Agustin", "Bacclean", "44.000.400", 0001, 350000, "Albañil");
			obrero Lucas = new obrero("Lucas", "Pradela", "34.300.100", 0002, 350000, "Pintor");
			obrero Jorgito = new obrero("Jorge", "Johnson", "41.902.900", 888, 350000, "Electricista");
			obrero Santiago = new obrero("Santiago", "Lovinson", "45.004.460", 0004, 350000, "Plomero");
			obrero Raul = new obrero("Raul", "Bacclean", "38.060.130", 0005, 350000, "Techista");
			
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
			obrero Manuel = new obrero("Manuel", "Rodríguez", "38.060.150", 0010, 320000, "Plomero");
			
			// Crear el grupo de obreros y agregar los nuevos obreros
			grupoObreros Grupo1240 = new grupoObreros(1240);
			
			Grupo1240.agregarObrero(Pedro);
			Grupo1240.agregarObrero(Javier);
			Grupo1240.agregarObrero(Luis);
			Grupo1240.agregarObrero(Carlos);
			Grupo1240.agregarObrero(Manuel);
											
			

			obra puenteFcioVarela = new obra("Michael Jackson", "20.152.912", 555, "Construcción de puente", 10500250);
			
			
			
			
			
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