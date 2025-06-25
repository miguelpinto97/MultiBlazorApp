using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Common.Constants
{
    public static class GeneralConstants
    {
		public const int EDAD_MINIMA_ALUMNO = 6;
		public const int EDAD_MAXIMA_ALUMNO = 18;
		public const int EDAD_MINIMA_OTROS = 18;
		public const int EDAD_MAXIMA_OTROS = 100;
		public const int NOTAS_POR_DEFECTO = 4;
        public static class Asociados
        {

			public const int ADMINISTRADORA_ID = 1;
		}

        public static class Acciones
        {
            public const string ACTUALIZAR = "Actualizar";
            public const string REGISTRAR = "Registrar";
            public const string ELIMINAR = "Eliminar";
			public const string ELIMINARMASIVO = "EliminarMasivo";
			public const string ASIGNARPERFILES = "AsignarPerfiles";
            public const string ABRIR = "Abrir Periodo";
            public const string CERRAR = "Cerrar Periodo";
			public const string CUSTOM = "Custom";
            public const string ANULAR = "Anular";
			public const string RESOLVER = "Resolver";
			public const string FINALIZAR_ASAMBLEA = "FinalizarAsamblea";
			public const string REINICIAR_ASAMBLEA = "ReiniciarAsamblea";
			public const string PUBLICAR_ASAMBLEA = "PublicarAsamblea";
		}

		public static class MimeTypes
        {
			public const string EXCEL = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
			public const string PDF = "application/pdf";
		}

        public static class ExportacionExcel
        {
            public const int LIMITE_REGISTROS = 1000000;

		}

        public static class Periodos
        {
            public const string CIERRE_EJERCICIO_ID = "13";
            public const string CIERRE_EJERCICIO_NOMBRE = "CIERRE EJERCICIO";
        }

        public static class LongitudCodigos
        {
            public const int CONTRATO = 6;
			public const int VENTA = 6;
			public const int VOUCHER = 6;
			public const int ASOCIADO = 10;
            public const int COMPROBANTE = 8;
			public const int ENTREGA = 6;
		}

        public const int AFECTO_IGV = 2;
        public const int NO_AFECTO_IGV = 3;
		public static class TiposReportes
		{
			public const int Estado_Cuenta_Completo = 1;
			public const int Estado_Cuenta_Mensual = 2;
		}

		public static class Anios
		{
			public const int ANIO_MINIMO = 2023;
			public const int ANIO_MAXIMO = 2050;
		}

        public static class MensajesValidacion
        {
			public const string FECHA_INVALIDA = "Debe ingresar una fecha válida";
			public const string NUMERO_INVALIDO = "Debe ingresar un número válido";

		}

		public const decimal PORCENTAJE_MINIMO_ASOCIADOS_GRUPO = 0.7M;


    }
}
