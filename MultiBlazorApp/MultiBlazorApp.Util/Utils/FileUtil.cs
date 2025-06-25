namespace MultiBlazorApp.Common.Utils
{
	public static class FileUtil
	{
		public static string GetTemplateWithReplace(string nombreArchivo, Dictionary<string, string> valores)
		{
			string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Templates/{nombreArchivo}");
			var htmlTexto = string.Empty;

			if (File.Exists(rutaCompleta))
			{
				htmlTexto = File.ReadAllText(rutaCompleta);
			}

			foreach (var item in valores) {
				htmlTexto = htmlTexto.Replace(item.Key, item.Value);
			}

			return htmlTexto;
		}
	}
}
