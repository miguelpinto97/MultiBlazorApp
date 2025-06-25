using System.Security.Cryptography;
using System.Text;

namespace MultiBlazorApp.Common.Utils
{
	public static class CryptoUtil
	{	

		public static string GenerarHash(string texto, string salt)
		{
			using (SHA256 sha256Hash = SHA256.Create())
			{
				// Concatenar el texto y el SALT
				string textoConSalt = texto + salt;

				// Convertir el texto con SALT en un arreglo de bytes
				byte[] bytes = Encoding.UTF8.GetBytes(textoConSalt);

				// Calcular el hash de los bytes
				byte[] hashBytes = sha256Hash.ComputeHash(bytes);

				// Convertir el hash a una cadena de texto hexadecimal
				StringBuilder builder = new StringBuilder();
				foreach (byte b in hashBytes)
				{
					builder.Append(b.ToString("x2"));
				}

				return builder.ToString();
			}
		}

		public static bool VerificarHash(string texto, string salt, string hashAlmacenado)
		{
			var nuevoHash = GenerarHash(texto, salt);
			return string.Equals(nuevoHash, hashAlmacenado);
		}

		public static string EncriptarTexto(string texto, string clave)
		{
			byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
			byte[] textoBytes = Encoding.UTF8.GetBytes(texto);

			using (Aes aes = Aes.Create())
			{
				aes.Key = claveBytes;
				aes.GenerateIV();

				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

				byte[] textoEncriptadoBytes;
				using (var ms = new MemoryStream())
				{
					using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
					{
						cs.Write(textoBytes, 0, textoBytes.Length);
					}
					textoEncriptadoBytes = ms.ToArray();
				}

				byte[] textoEncriptadoIVBytes = new byte[aes.IV.Length + textoEncriptadoBytes.Length];
				Buffer.BlockCopy(aes.IV, 0, textoEncriptadoIVBytes, 0, aes.IV.Length);
				Buffer.BlockCopy(textoEncriptadoBytes, 0, textoEncriptadoIVBytes, aes.IV.Length, textoEncriptadoBytes.Length);

				string textoEncriptado = Convert.ToBase64String(textoEncriptadoIVBytes);

				return textoEncriptado;
			}
		}

		public static string DesencriptarTexto(string textoEncriptado, string clave)
		{
			byte[] claveBytes = Encoding.UTF8.GetBytes(clave);
			byte[] textoEncriptadoIVBytes = Convert.FromBase64String(textoEncriptado);

			using (Aes aes = Aes.Create())
			{
				aes.Key = claveBytes;

				byte[] iv = new byte[aes.BlockSize / 8];
				byte[] textoEncriptadoBytes = new byte[textoEncriptadoIVBytes.Length - iv.Length];

				Buffer.BlockCopy(textoEncriptadoIVBytes, 0, iv, 0, iv.Length);
				Buffer.BlockCopy(textoEncriptadoIVBytes, iv.Length, textoEncriptadoBytes, 0, textoEncriptadoBytes.Length);

				aes.IV = iv;

				ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

				byte[] textoDesencriptadoBytes;
				using (var ms = new System.IO.MemoryStream())
				{
					using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
					{
						cs.Write(textoEncriptadoBytes, 0, textoEncriptadoBytes.Length);
					}
					textoDesencriptadoBytes = ms.ToArray();
				}

				string textoDesencriptado = Encoding.UTF8.GetString(textoDesencriptadoBytes);

				return textoDesencriptado;
			}
		}
	}
}
