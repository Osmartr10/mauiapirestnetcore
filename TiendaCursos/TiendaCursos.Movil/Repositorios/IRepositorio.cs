using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaCursos.Movil.Repositorios
{
    public interface IRepositorio
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);
        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T model);
        Task<HttpResponseWrapper<object>> Put<T>(string url, T model);
        Task<HttpResponseWrapper<object>> Delete(string url);
    }
}
