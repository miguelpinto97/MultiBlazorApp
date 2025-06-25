using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Common.Utils
{
	public static class DictionaryUtil
	{
		public static IDictionary<TKey, TValue> NuevoConValor<TKey, TValue>(this IDictionary<TKey, TValue> diccionarioOriginal, TKey Key, TValue Value)
		{
			var diccionarioActualizado = new Dictionary<TKey, TValue>(diccionarioOriginal);


				if (!diccionarioActualizado.ContainsKey(Key))
				{
					diccionarioActualizado.Add(Key, Value);
				}
			

			return diccionarioActualizado;
		}

		public static void AgregarValor(this IDictionary<string, string[]> dictionary, string key, string value)
		{
			if (dictionary.ContainsKey(key))
			{
				var values = new List<string>(dictionary[key]);
				values.Add(value);
				dictionary[key] = values.ToArray();
			}
			else
			{
				dictionary.Add(key, new[] { value });
			}
		}
	}
}
