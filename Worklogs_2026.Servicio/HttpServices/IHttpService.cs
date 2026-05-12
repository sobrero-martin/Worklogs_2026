using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.Servicio.HttpServices
{
    public interface IHttpService
    {
        Task<HttpResponse<T>> Get<T>(string url);

        Task<HttpResponse<TResp>> Post<T, TResp>(string url, T entidad);

        Task<HttpResponse<object>> Delete(string url);
    }
}
