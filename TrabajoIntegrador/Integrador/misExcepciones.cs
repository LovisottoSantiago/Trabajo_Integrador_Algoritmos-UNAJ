using System;
namespace Integrador
{
	public static class misExcepciones
	{
		// SI QUIERO CREAR UNA OBRA Y ASIGNO UN CODIGO QUE YA EXISTE
		public class excepcionCodigoRepetido : Exception
		{
			public excepcionCodigoRepetido(string Message) : base(Message) {}						
		}
		
		// SI LA OBRA QUE QUIERO MODIFICAR NO EXISTE		
		public class excepcionModificarObra : Exception
		{
			public excepcionModificarObra(string Message) : base(Message) {}						
		}
		
		// SI EL CODIGO DEL GRUPO SE REPITE
		public class excepcionAsignarGrupo : Exception
		{
			public excepcionAsignarGrupo(string Message) : base(Message) {}
		}
		
		// SI ELIJO UNA OBRA CON UN VALOR QUE NO EXISTE
		public class excepcionCodigoNoExiste : Exception
		{
			public excepcionCodigoNoExiste(string Message) : base(Message) {}
		}
		
		// SI CREO UNA OBRA CON UN VALOR DE ESTADO INVALIDO
		public class excepcionEstadoInvalido : Exception
		{
			public excepcionEstadoInvalido(string Message) : base(Message) {}
		}
		
		
		// SI EL GRUPO YA TIENE UN JEFE ASIGNADO
		public class excepcionJefeAsignado : Exception
		{
			public excepcionJefeAsignado(string Message) : base(Message) {}
		}
		
	}
}
