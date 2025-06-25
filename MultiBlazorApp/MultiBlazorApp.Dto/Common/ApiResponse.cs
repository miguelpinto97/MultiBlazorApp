using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBlazorApp.Dto.Common
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Data = new Dictionary<string, string>();
            Errors = new Dictionary<string, string[]>();
        }

        public ApiResponse Exito(int id)
        {
            Data.Add("Id", id.ToString());
            return Exito();
        }

        public ApiResponse Exito(string id)
        {
            Data.Add("Id", id);
            return Exito();
        }

        public ApiResponse Exito()
        {
            Success = true;
            StatusCode = 200;
            Title = "La operación se ha realizado con éxito";
            return this;
        }

        public void AddData(string key, string value)
        {
            Data.Add(key, value);
        }

        public string ObtenerId()
        { 
            return Data["Id"];
        }
		public int ObtenerId_Integer()
		{
			return int.Parse(Data["Id"]);
		}
		public bool Success { get; set; }
        public string? Title { get; set; }
        public IDictionary<string, string> Data { get; set; }
        public string? TraceId { get; set; }
        public int StatusCode { get; set; }
        public IDictionary<string, string[]>? Errors { get; set; }
    }
}
