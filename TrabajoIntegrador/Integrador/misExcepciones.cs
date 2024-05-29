using System;
namespace Integrador
{
	public static class misExcepciones
	{
		public class excepcionCodigoRepetido : Exception
		{
			public excepcionCodigoRepetido(string Message) : base(Message) {}						
		}
		
		
		public class excepcionModificarObra : Exception
		{
			public excepcionModificarObra(string Message) : base(Message) {}						

		}
	}
}
