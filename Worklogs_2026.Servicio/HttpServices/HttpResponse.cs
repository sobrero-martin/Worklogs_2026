using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Worklogs_2026.Servicio.HttpServices
{
    public class HttpResponse<T>
    {
        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public HttpResponse(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            this.Response = response;
            this.Error = error;
            this.HttpResponseMessage = httpResponseMessage;
        }

        public string GetError()
        {
            if (!Error)
            {
                return string.Empty;
            }
            else
            {
                var statuscode = HttpResponseMessage.StatusCode;

                switch (statuscode)
                {
                    case HttpStatusCode.NotFound:
                        return "Resource not found";
                    case HttpStatusCode.Unauthorized:
                        return "Not logged in";
                    case HttpStatusCode.Forbidden:
                        return "You are not authorized to perform this action";
                    case HttpStatusCode.BadRequest:
                        return "Unable to process the information";
                    case HttpStatusCode.InternalServerError:
                        return "Internal server error";
                    default:
                        return $"Request error. Status Code: {statuscode}";
                }
            }
        }
    }
}
