using System.Text;

namespace MultiBlazorApp.Common.Utils
{
	public static class TextoUtil
	{
		public static string ArrayToQueryString(string[] ids, string nombreParametro)
		{
			var queryString = string.Empty;
			foreach (var id in ids)
			{
				queryString += $"&{nombreParametro}={id}";
			}
			queryString = queryString.TrimStart('&');
			return queryString;
		}

		public static bool Buscar(this string? cadenaCompleta, string? terminoDeBusqueda)
		{
			if (cadenaCompleta == null || terminoDeBusqueda == null) return false;
			var cadenaCompletaNormalizada = cadenaCompleta.Normalize(NormalizationForm.FormD);
			var terminoDeBusquedaNormalizado = terminoDeBusqueda.Normalize(NormalizationForm.FormD);

			return cadenaCompletaNormalizada.IndexOf(terminoDeBusquedaNormalizado, StringComparison.OrdinalIgnoreCase) >= 0;
		}

		public static bool EsIgualNormalizado(this string? texto, string? textoComparar)
		{
			texto ??= string.Empty;
			textoComparar ??= string.Empty;
			var texto1Normalizado = texto.Normalize(NormalizationForm.FormD);
			var texto2Normalizado = textoComparar.Normalize(NormalizationForm.FormD);
			return texto1Normalizado.Equals(texto2Normalizado, StringComparison.OrdinalIgnoreCase);
		}

		public static bool TieneLetrasYNumeros(string texto)
		{
			bool contieneLetra = false;
			bool contieneNumero = false;

			foreach (char caracter in texto)
			{
				if (char.IsLetter(caracter))
				{
					contieneLetra = true;
				}
				else if (char.IsDigit(caracter))
				{
					contieneNumero = true;
				}

				if (contieneLetra && contieneNumero)
				{
					return true; // El texto contiene al menos una letra y al menos un número
				}
			}

			return false; // El texto no cumple con los requisitos
		}

		public static string GetPrimerNombre(this string nombre)
		{
			if (string.IsNullOrEmpty(nombre)) return nombre;

			if (nombre.Contains(' '))
			{
				var split = nombre.Split(' ');
				return split[0];
			}
			return nombre;
		}
	}
}
