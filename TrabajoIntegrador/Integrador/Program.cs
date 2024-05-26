using System;
using System.Collections;
namespace Integrador
	
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Bienvenido al programa");
			
			
			obrero Agustin = new obrero("Agustin", "Bacclean", "4444", 123, 1200, "Albañil");
			obrero Agustin2 = new obrero("Agustin", "Pradela", "1234", 000, 1200, "Albañil");
			obrero Jorgito = new obrero("Jorge", "Johnson", "1123", 888, 1411, "Albañil");
			obrero Santiago = new obrero("Santiago", "Bacclean", "6321", 999, 1200, "Albañil");
			
			grupoObreros LosPibes = new grupoObreros(1235);
			
			LosPibes.agregarObrero(Agustin);
			LosPibes.agregarObrero(Agustin2);
			LosPibes.agregarObrero(Jorgito);
			LosPibes.agregarObrero(Santiago);
			
			
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