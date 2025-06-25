namespace MultiBlazorApp.Common.Constants
{
    public static class ParametrosConstants
    {
		public static class ParametrosId
		{

			public const string ESTADOS_GENERALES = "ESTA";
			public const string AREA_CURSOS = "AREA";
			public const string ESTADO_PERIODOS = "ESPE";
			public const string MESES = "MESE";
			public const string PAGINACION = "PAGI";
			public const string GENERO = "GENE";
			public const string ESTADO_CIVIL = "ECIV";
			public const string MOTIVOS_CESE = "CESE";
			public const string LISTA_CURSOS = "CRSO";
			public const string ROLES_PERSONAS = "ROLP";
			public const string SALONES = "SALO";
			public const string TIPOS_DOCUMENTO = "TIDO";
			public const string DEPARTAMENTOS = "DEPA";
			public const string DISTRITOS = "DIST";
			public const string PROVINCIAS = "PROV";
			public const string SITUACIONES_ASISTENCIA = "ASIS";

            public const string EQUIVALENCIAS_NOTAS = "EQUI";

			public const string ESTADOS_PEDIDOS = "ESPE";
			public const string TIPOS_ITEMS = "ITEM";
            public const string CATEGORIAS_ITEMS = "CATE"; 
			public const string SUB_CATEGORIAS_ITEMS = "SCAT";

        }

        public static class Situaciones_Asistencia
		{
			public const string FALTA = "ASIS0001";
			public const string PRESENTE = "ASIS0002";
			public const string TARDANZA = "ASIS0003";
		}
		public static class Estados_Pedido
		{
			public const string POR_APROBAR = "ESPE0001";
			public const string EN_PREPARACION = "ESPE0002";
			public const string EN_CAMINO = "ESPE0003";
			public const string ENTREGADO = "ESPE0004";
		}
        public static class Tipos_Items
        {
            public const string PRODUCTOS = "ITEM0001";
            public const string EXTRAS = "ITEM0002";
            public const string CREMAS = "ITEM0003";
        }
        public static class Tipos_Acciones_Historial
		{
            public const string CREADO = "TIPH0001";
            public const string ACTUALIZADO = "TIPH0002";
            public const string OBSERVADO = "TIPH0003";
            public const string APROBADO = "TIPH0004";
			public const string CONTRATO_GENERADO = "TIPH0005";
			public const string ANULADA = "TIPH0010";
			public const string CESION_FONDEO = "TIPH0018";

			/* Contrato */
			public const string RESUELTO_RETIRADO = "TIPH0006";
			public const string CEDIDO = "TIPH0007";

			public const string COBRO_REGISTRADO = "TIPH0008";
            public const string DEUDA_VENCIDA_CANCELADA = "TIPH0009";
            public const string HABILITADO = "TIPH0011";
            public const string REMATE_APLICADO = "TIPH0012";
			public const string REMATE_REVERTIDO = "TIPH0013";
			public const string MOROSO = "TIPH0014";
			public const string MORA_APLICADA = "TIPH0015";
			public const string ADJUDICACION_ANULADA = "TIPH0016";
			public const string ADJUDICACION = "TIPH0017";

		}
		public static class TiposPersonas
		{
			public const string NATURAL = "TPER0001";
			public const string JURIDICA = "TPER0002";
		}
		public static class RolesPersonas
		{
			public const string ALUMNO = "ROLP0001";
			public const string PADRE_MADRE = "ROLP0002";
			public const string PROFESOR = "ROLP0003";
			public const string PERSONAL_ADMINISTRATIVO = "ROLP0004";
		}
		public static class Areas
		{
			public const string VENTAS = "AREA0001";
            public const string OPERACIONES = "AREA0002";
        }
		public static class CargoColaborador
		{
			public const string ATENCION_AL_CLIENTE = "CRGO0002";
            public const string VENDEDOR = "CRGO0001";
            public const string SUPERVISOR = "CRGO0003";
            public const string JEFE_VENTAS = "CRGO0004";
        }

        public static class EstadosGenerales
        {
            public const string ACTIVO = "ESTA0001";
            public const string INACTIVO = "ESTA0002";
		}
		public static class SituacionesAsistencia
		{
			public const string FALTA = "ASIS0001";
			public const string PRESENTE = "ASIS0002";
			public const string TARDANZA = "ASIS0003";
		}
		public static class EstadosMovimientosBancarios
		{
			public const string NO_ASIGNADO = "ESMB0001";
			public const string ASIGNADO = "ESMB0002";
			public const string NO_IDENTIFICADO = "ESMB0003";
		}

		public static class EstadosPeriodos
		{
			public const string ABIERTO = "ESPE0001";
			public const string CERRADO = "ESPE0002";
        }

        public static class EstadosVouchers
        {
            public const string TERMINADO = "ESVO0001";
            public const string MAYORIZADO = "ESVO0002";
            public const string ANULADO = "ESVO0003";
		}

		public static class EstadosLiquidacionBancaria
		{
			public const string PENDIENTE = "ESLQ0001";
			public const string FINALIZADO = "ESLQ0002";
		}

		public static class EstadosLogVouchers
		{
			public const string PENDIENTE = "ESLV0001";
			public const string ERROR = "ESLV0002";
			public const string ANULADO = "ESLV0003";
			public const string PROCESADO = "ESLV0004";
		}

		public static class EstadosVenta
		{
			public const string PROSPECTO = "ESTV0001";
			public const string OBSERVADO = "ESTV0002";
			public const string APROBADO = "ESTV0003";
			public const string ANULADO = "ESTV0004";
			public const string CON_CONTRATO = "ESTV0005";
			public const string CONTRATO_PENDIENTE = "ESTV0006";
		}

		public static class EstadosGarantias
		{
			public const string REGISTRADO = "ESGA0001";
			public const string EN_EJECUCION = "ESGA0002";
		}

		public static class PeriodicidadFeriados
		{
			public const string NINGUNA = "PEFE0001";
			public const string ANUAL = "PEFE0002";
		}

		public static class SituacionAsamblea
		{
			public const string PROGRAMADA = "SIAS0001";
			public const string FINALIZADA = "SIAS0002";
			public const string EN_CURSO = "SIAS0003";
			public const string PUBLICADA = "SIAS0004";
		}

		public static class SituacionGrupo
		{
			public const string EN_FORMACION = "SIGR0001";
			public const string VIGENTE = "SIGR0002";
		}

		public static class SubcuentasAutomaticas
		{
			public const string PROGRAMAS_GRUPOS = "SACC0001";
			public const string BANCO_CUENTAS = "SACC0002";
		}

		public static class TiposDocumento
        {
            public const string DNI_COD = "TIDO0001";
            public const string RUC_COD = "TIDO0002";
            public const string CARNET_EXTRANJERIA_COD = "TIDO0003";
            public const string PASAPORTE_COD = "TIDO0004";
            public const string PARTIDA_NACIMIENTO_COD = "TIDO0005";

            public const int DNI_LONG = 8;
            public const int RUC_LONG = 11;
            public const int CARNET_EXTRANJERIA_LONG = 12;
            public const int PASAPORTE_LONG = 12;
            public const int PARTIDA_NACIMIENTO_LONG = 15;
        }

		public static class TipoCambioConfiguracion
		{
			public const string UMBRAL_VARIACION = "TICA0001";
		}

		public static class TiposLiquidacionBancaria
		{
			public const string SISTEMA = "TPLQ0001";
			public const string EMPRESA = "TPLQ0002";
			public const string AMBOS = "TPLQ0003";
		}

        public static class SistemasConceptoPago
        {
            public const string SISTEMA = "SIST0001";
            public const string EMPRESA = "SIST0002";
        }

        public static class TipoValorTarifario
		{
			public const string RANGO_PORCENTAJE = "TITF0001";
			public const string RANGO_MONTOS = "TITF0002";
			public const string PORCENTAJE = "TITF0003";
			public const string MONTO = "TITF0004";
			public const string CANTIDAD_CUOTAS = "TITF0005";
		}
		public static class ConceptosDePago
		{
			public const int ID_PRIMERA_CUOTA_INSCRIPCION = 1;
			public const int ID_SEGUNDA_CUOTA_INSCRIPCION = 2;
			public const int ID_SEGURO_DESGRAVAMEN = 3;
			public const int ID_TERCERA_CUOTA_INSCRIPCION = 4;
			public const int ID_CUOTA_ADMINISTRATIVA = 5;
			public const int ID_CUOTA_CAPITAL = 6;
			public const int ID_MORA = 7;
			public const int ID_SEGURO_INMUEBLE = 8;
			public const int ID_CUOTA_CAPITAL_DEVENGADA = 9;
			public const int ID_CUOTA_CAPITAL_REMATE = 14;
            public const int ID_CUOTA_ADMINISTRATIVA_REMATE = 15;
            public const int ID_CUOTA_ADMINISTRATIVA_DEVENGADA = 10;
			public const int PENALIDAD_RESOLUCION = 11;
			public const int PENALIDAD_REMATE_SISTEMA = 12;
			public const int PENALIDAD_REMATE_ADMINISTADORA = 13;
			public const int PENALIDAD_CESION = 16;
			public const int PENALIDAD_REMATE_TOTAL = 1000;

			public const string CUOTA_INSTRIPCION_ABREVIACION = "CI \"5%";

			public static readonly List<int> ConceptosPrincipales = new List<int> { 3,5,6,7,8 };
			public static readonly List<int> OtrosConceptos = new List<int> { 1,2,4,9,10, 11,12,13,14,15 };
			public static readonly List<int> Seguros = new List<int> { 3 , 8 };
			public static readonly List<int> ConceptosDevolucion_Aportes = new List<int> { 1,2,4,5,6, 9, 10};

			public static readonly List<int> CuotasInscripcion = new List<int> { 1, 2, 4 };
			public static readonly List<int> CuotasCapitales = new List<int> { 6,9, 14};
			public static readonly List<int> CuotasAdministrativas = new List<int> { 5, 10,15 };
            public static readonly List<int> ConceptosCuotaMensual = new List<int> { 5, 6 };

            public static readonly List<int> ConceptosEstadoCuenta = new List<int> { 1, 2, 3,4 ,5,6,8};
			public static readonly List<int> ConceptosSaldoInicialAsamblea = new List<int> { 6, 9, 11, 12, 13, 16 };
			public static readonly List<int> CuotasCapitalesAsamblea = new List<int> { 6, 9};
            public static readonly List<int> ConceptosRemate = new List<int> { 14, 15 };

			public static readonly List<int> Penalidades_Fondo_Asamblea = new List<int> { 11, 12, 13, 16 };
			public static readonly List<int> Penalidades = new List<int> { 7,11,12,13,16 };

			public static readonly List<int> Penalidades_Remate = new List<int> { PENALIDAD_REMATE_SISTEMA, PENALIDAD_REMATE_ADMINISTADORA };

		}
		public static class ValoresContables
		{
			public const string IGV = "CONT0001";
		}


		public static class Perfiles
		{
			public const int ADMIN = 1;
			public const int SUPER_ADMIN = 4;
		}
		public static class Asociados_Relaciones
		{
			public const string CONYUGE = "RELA0001";
			public const string REPRESENTANTE_LEGAL = "RELA0002";
		}
		public static class Situacion_Adjudicado
		{
			public const string NO_ADJUDICADO = "SADJ0006";
			public const string SORTEO = "SADJ0001";
			public const string REMATE = "SADJ0002"; 
			public const string ADJUDICACION_ANULADA = "SADJ0004"; 
		}
		public static class Situacion_Entrega
		{
			public const string SOLO_ADJUDICADO = "SENT0001";
			public const string ENTREGADO = "SENT0002";
		}
		public static class Situacion_Contrato
		{
			public const string HABIL = "SCON0001";
			public const string RESUELTO = "SCON0002";
			public const string MOROSO = "SCON0003";
			public const string CANCELADO = "SCON0004";
			public const string RETIRADO = "SCON0005";
			public const string NUEVO = "SCON0006";

			public static readonly List<string> ParaAsamblea = new List<string> { "SCON0001", "SCON0003"};
		}
		public static class Situacion_Pago
		{
			public const string PENDIENTE = "SPAG0001";
			public const string PAGADO = "SPAG0002";
			public const string PARCIAL = "SPAG0003";
			public const string MOROSO = "SPAG0004";
		}
		public static class Motivos_Resolucion
		{
			public const string DECISION_PERSONAL = "MRES0001";
			public const string TRES_CUOTAS_VENCIDAS = "MRES0002";

		}
		public static class CondicionPago
		{
			public const string CONTADO = "COPA0001";
			public const string CREDITO = "COPA0002";

		}
		public static class EstadoComprobante
		{
			public const string EMITIDO = "ESCO0001";
			public const string COBRADO = "ESCO0002";
        }
        public static class TipoComprobante
        {
            public const string BOLETA = "TICO0001";
            public const string FACTURA = "TICO0002";
            public const string NOTA_CREDITO = "TICO0003";
            public const string NOTA_DEBITO = "TICO0004";
			public const string OTRO = "TICO0005";

			public static readonly List<string> ParaPagosAsamblea = new List<string> { "TICO0001", "TICO0002", "TICO0005" };
			public static readonly List<string> NotasDebitoCredito = new List<string> { "TICO0003", "TICO0004"};

		}


		public static class RequisitosVenta
		{
			public const string FICHA_RUC = "RVEN0002";
			public const string OTROS = "RVEN0007";
		}

		public static class PautasEleccion
		{
			public const string SUPERIOR = "PELE0001";
			public const string INFERIOR = "PELE0002";
		}

        public static class DestinoCuotasRematadas
        {
            public const string ULTIMAS_CUOTAS = "DREM0001";
            public const string PRORRATEO = "DREM0002";
        }
		public static class TiposComunicacion
		{
			public const string CORREO_ELECTRONICO = "TCOM0001";
		}

		public static class ConfiguracionProgramas
		{
			public const string LIMITE_VINCULADOS = "PRCF0001";
			public const string LIMITE_MAX_CONTRATOS = "PRCF0002";
		}

		public static class EstadosEntrega
		{
			public const string EN_EVALUACION = "ESEN0001";
			public const string ANULADO = "ESEN0006";
			public const string OBSERVADO = "ESEN0003";
		}

		public static class HistorialEntrega
		{
			public const string REGISTRO = "THEN0001";
			public const string MODIFICADO = "THEN0008";
			public const string PAGARE = "THEN0003";
			public const string GARANTIA_INMOBILIARIA = "THEN0002";
			public const string GARANTIA_MOBILIARIA = "THEN0009";
			public const string CONCEPTOS = "THEN0005";
		}
	}
}
