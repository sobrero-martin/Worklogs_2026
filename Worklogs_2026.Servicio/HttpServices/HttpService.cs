using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Worklogs_2026.Servicio.HttpServices
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient http;
        public HttpService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpResponse<T>> Get<T>(string url)
        {
            var response = await http.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<T>(response);
                return new HttpResponse<T>(respuesta, false, response);
            }
            else
            {
                return new HttpResponse<T>(default, true, response);
            }
        }

        public async Task<HttpResponse<TResp>> Post<T, TResp>(string url, T entidad)
        {
            var JsonAEnviar = JsonSerializer.Serialize(entidad);
            var contenido = new StringContent(JsonAEnviar, Encoding.UTF8, "application/json");

            var response = await http.PostAsync(url, contenido);
            if (response.IsSuccessStatusCode)
            {
                var respuesta = await DesSerializar<TResp>(response);
                return new HttpResponse<TResp>(respuesta, false, response);
            }
            else
            {
                return new HttpResponse<TResp>(default, true, response);
            }
        }

        public async Task<HttpResponse<object>> Delete(string url)
        {
            var respuesta = await http.DeleteAsync(url);
            return new HttpResponse<object>(null, !respuesta.IsSuccessStatusCode, respuesta);
        }

        private async Task<T?> DesSerializar<T>(HttpResponseMessage response)
        {
            /*
            if (typeof(T) == typeof(string))
            {
                var str = await response.Content.ReadAsStringAsync();
                return (T)(object)str;
            }*/

            var respStr = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respStr,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}
