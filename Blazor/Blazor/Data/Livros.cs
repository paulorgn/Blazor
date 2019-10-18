using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Blazor.Data
{
    public class Livros
    {
        public HttpClient IniciarCliente()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                cliente.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HttpResponseMessage ClienteChamarAAPI()
        {
            try
            {
                HttpClient cliente = IniciarCliente();
                HttpResponseMessage resposta = cliente.GetAsync("/posts").Result;

                return resposta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<DtoObjetoExemplo> PegarRetornoDaAPI()
        {
            try
            {
                HttpResponseMessage resposta = ClienteChamarAAPI();

                if (resposta.IsSuccessStatusCode)
                {
                    string stringRetornoDaApi = resposta.Content.ReadAsStringAsync().Result.ToString();
                    List<DtoObjetoExemplo> retornoDaAPI =  JsonConvert.DeserializeObject<List<DtoObjetoExemplo>>(stringRetornoDaApi);

                    return retornoDaAPI;
                }
                else
                {
                    throw new Exception("A requisição não obteve uma resposta do servidor");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
