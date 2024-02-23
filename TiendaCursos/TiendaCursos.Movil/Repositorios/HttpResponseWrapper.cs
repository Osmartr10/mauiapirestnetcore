using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TiendaCursos.Movil.Repositorios
{
    public class HttpResponseWrapper<T>
    {

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public async Task<string> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var codigoEstatus = HttpResponseMessage.StatusCode;
            if( codigoEstatus == HttpStatusCode.NotFound )
            {
                return "Recursos no encontrado";
            }
            else if(codigoEstatus == HttpStatusCode.BadRequest )
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if(codigoEstatus== HttpStatusCode.Unauthorized ) 
            {
                return "Tienes que iniciar session para hacer esta operacion";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos en esta opéracion";
            }
            return "Ha ocurrido un eror inesperado";
        }
    }
}
