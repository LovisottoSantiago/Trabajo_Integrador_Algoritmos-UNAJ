using System;
namespace Integrador
{
	public static class misExcepciones
	{
		public class excepcionObrasDisponibles : Exception
		{
			public excepcionObrasDisponibles(string Message) : base(Message) {}						
			
			
		}
	}
}
