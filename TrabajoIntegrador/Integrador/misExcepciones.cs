using System;
namespace Integrador
{
	public static class misExcepciones
	{
		public class excepcionCodigoRepetido : Exception
		{
			public excepcionCodigoRepetido(string Message) : base(Message) {}						
			
			
		}
	}
}
