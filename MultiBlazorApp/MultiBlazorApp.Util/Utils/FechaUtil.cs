
using System.Globalization;
using System.Linq.Expressions;

namespace MultiBlazorApp.Common.Utils
{
    public static class FechaUtil
    {
        public static DateTime FechaHoraLocal()
        {
            return DateTime.UtcNow.AddHours(-5);
		}
		public static DateOnly FechaLocal()
		{
			return DateTime.UtcNow.AddHours(-5).ToDateOnly();
		}

		public static DateTime FechaHoraUTC()
        {
            return DateTime.UtcNow;
        }

		public static DateOnly FechaUTC()
		{
            var fecha = FechaHoraUTC();
			return new DateOnly(fecha.Year,fecha.Month, fecha.Day);
		}

        public static DateOnly ToDateOnly(this DateTime fecha)
        {
            return new DateOnly(fecha.Year, fecha.Month, fecha.Day);
		}

		public static DateOnly? ToDateOnly(this DateTime? fecha)
		{
			if (!fecha.HasValue)
				return null; ;
			return new DateOnly(fecha.Value.Year, fecha.Value.Month, fecha.Value.Day);
		}

		public static DateTime ToDateTime(this DateOnly fecha)
		{
			return new DateTime(fecha.Year, fecha.Month, fecha.Day);
		}

		public static DateTime? ToDateTime(this DateOnly? fecha)
		{
			if (fecha.HasValue)
			{
				return fecha.Value.ToDateTime();
			}
			return null;
		}

		public static DateTime ToDateTime(this DateOnly fecha, string hora)
		{
			var split = hora.Split(':');
			var horaInt = split[0].ToInt();
			var minuto = split[1].ToInt();
			return new DateTime(fecha.Year, fecha.Month, fecha.Day, horaInt, minuto, 0);
		}
		public static Expression<Func<DateOnly, DateTime>> ToDateTimeExpression = fecha => new DateTime(fecha.Year, fecha.Month, fecha.Day);
		public static DateTime ToDateTime_Expression(this DateOnly fecha)
		{
			return ToDateTimeExpression.Compile()(fecha);
		}
		public static string ToHora(this DateTime fecha)
		{
			return fecha.ToString("HH:mm");
		}

		public static string ToStringFecha(this DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy");
        }

		public static string ToStringFecha(this DateTime? fecha)
		{
			if(fecha.HasValue)
				return fecha.Value.ToStringFecha();

			return "";
		}

		public static string ToStringFecha(this DateOnly? fecha)
		{
			if (fecha.HasValue)
				return fecha.Value.ToDateTime().ToStringFecha();

			return "";
		}

		public static string ToStringFecha(this DateOnly fecha)
		{
			return fecha.ToDateTime().ToStringFecha();
		}

		public static string ToStringFechaApiParameter(this DateTime fecha)
		{
			return fecha.ToString("yyyy-MM-dd");
		}

		public static string ToStringFechaHora(this DateTime fecha)
		{
			return fecha.ToString("dd/MM/yyyy HH:mm");
		}

		public static DateTime ToFechaHoraLocal(this DateTime fecha)
		{
			return fecha.AddHours(-5);
		}

		public static bool HoraValida(string hora)
		{
			return DateTime.TryParseExact(hora, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time);
		}

		public static DateOnly FechaLaborable(DateOnly fecha, List<DateOnly> listaFeriados)
		{
			while (listaFeriados.Contains(fecha) || fecha.DayOfWeek == DayOfWeek.Sunday || fecha.DayOfWeek == DayOfWeek.Saturday)
			{
				fecha = fecha.AddDays(1);
			}

			return fecha;
		}
		public static DateOnly FechaHabil(DateOnly fechaActual,int diasSumar, List<DateOnly> feriados)
		{

			while (diasSumar > 0)
			{
				// Restar un día a la fecha de asamblea
				fechaActual = fechaActual.AddDays(1);

				// Verificar si la fecha es un feriado o fin de semana
				if (feriados.Contains(fechaActual) || fechaActual.DayOfWeek == DayOfWeek.Saturday || fechaActual.DayOfWeek == DayOfWeek.Sunday)
					continue; // Ignorar la fecha y pasar al siguiente día

				diasSumar--; // Se resta un día válido
			}

			return fechaActual;
		}
		public static DateTime EstablecerTipoUtc(this DateTime fecha)
		{
			return DateTime.SpecifyKind(fecha, DateTimeKind.Utc);
		}


		public static string GetNombreDiaSemana(this DateTime fecha)
		{
			CultureInfo cultura = new CultureInfo("es-PE");
			string nombreDia = fecha.ToString("dddd", cultura);
			return nombreDia;
		}

		public static bool FechaNacimientoEsMayorDeEdad(DateTime? _fechaNacimiento, DateTime? _fechaActual)
		{

			if (_fechaActual == null) return false;

			DateTime fechaNacimiento = _fechaNacimiento ?? DateTime.MinValue;
			var edadMinima = 18; // Definir la edad mínima requerida
			var fechaActual = _fechaActual?.ToFechaHoraLocal() ?? new DateTime();
			var edad = fechaActual.Year - fechaNacimiento.Year;

			// Verificar si la persona ha cumplido la edad mínima requerida
			if (fechaNacimiento > fechaActual.AddYears(-edad))
				edad--;

			//// Verificar si ya ha llegado el cumpleaños de la persona
			//if (fechaNacimiento.Month > fechaActual.Month ||
			//	(fechaNacimiento.Month == fechaActual.Month && fechaNacimiento.Day > fechaActual.Day))
			//{
			//	// El cumpleaños de la persona aún no ha llegado
			//	edad--;
			//}

			// Verificar si la edad es mayor o igual a la edad mínima
			return edad >= edadMinima;
		}

		public static int ObtenerEdad(DateTime? _fechaNacimiento, DateTime? _fechaActual)
		{

			if (_fechaActual == null) return 0;

			DateTime fechaNacimiento = _fechaNacimiento ?? DateTime.MinValue;
			var fechaActual = _fechaActual?.ToFechaHoraLocal() ?? new DateTime();
			var edad = fechaActual.Year - fechaNacimiento.Year;

			// Verificar si la persona ha cumplido la edad mínima requerida
			if (fechaNacimiento > fechaActual.AddYears(-edad))
				edad--;

			return edad;
		}
		public static bool esFechaValida(DateTime? fecha)
        {
            // Utilizamos DateTime.TryParse para verificar si la fecha es válida
            // Si la conversión es exitosa, la fecha es válida
            return DateTime.TryParse(fecha.ToString(), out _);
        }


		public static bool esFechaValida(DateTime fecha)
		{
			// Utilizamos DateTime.TryParse para verificar si la fecha es válida
			// Si la conversión es exitosa, la fecha es válida
			return DateTime.TryParse(fecha.ToString(), out _);
		}

		public static string MesEnLetras()
		{
            // Obtiene la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Obtiene el nombre del mes en letras
            string nombreMes = fechaActual.ToString("MMMM").ToUpperInvariant();

			return nombreMes;
        }

		public static string ObtenerDiferenciaTiempo(DateTime fechaInicio, DateTime fechaFin)
		{
			TimeSpan diferencia = fechaFin - fechaInicio;

			if (diferencia.TotalMinutes < 3)
			{
				return "Hace un momento";
			}
			else if (diferencia.TotalMinutes < 60)
			{
				return $"Hace {diferencia.TotalMinutes} minutos";
			}
			else if (diferencia.TotalHours < 24)
			{
				return $"Hace {diferencia.TotalHours} horas";
			}
			else if (diferencia.TotalDays < 7)
			{
				return $"Hace {diferencia.TotalDays} días";
			}
			else if (diferencia.TotalDays < 30)
			{
				int semanas = (int)(diferencia.TotalDays / 7);
				return $"Hace {semanas} semanas";
			}
			else
			{
				int meses = (int)(diferencia.TotalDays / 30);
				return $"Hace {meses} meses";
			}
		}
	}
}
