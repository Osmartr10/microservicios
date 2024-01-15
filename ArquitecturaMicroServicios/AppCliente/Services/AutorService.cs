using AppCliente.Models;
using System.Text.RegularExpressions;
using System.Text;
using Newtonsoft.Json;

namespace AppCliente.Services
{
    public class AutorService
    {
        string url = "http://apigateway:8080";
        string endPoint = "";
        HttpClient client = new HttpClient();
        public async Task<List<Autor>> ListarAutores()
        {
            endPoint = "api/Autor";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Autor> result = new List<Autor>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Autor>>(respuestaCuerpo)!;
            }
            return result;
        }
        public async Task<bool> InsertarAutor(Autor autor)
        {
            bool sw = false;
            endPoint = url + "/api/Autor";
            string jsonBody = JsonConvert.SerializeObject(autor);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return sw = true;
            }
            return sw;
        }
        public async Task<Autor> ObtenerAutor(int id)
        {
            endPoint = "/api/Autor/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Autor autor = new Autor();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                autor = JsonConvert.DeserializeObject<Autor>(respuestaCuerpo)!;
            }
            return autor;
        }

        public async Task<bool> EditarAutor(Autor autor, int id)
        {
            bool sw = false;
            endPoint = url + "/api/Autor/" + id;
            string jsonBody = JsonConvert.SerializeObject(autor);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarAutor(int id)
        {
            bool sw = false;
            endPoint = url + "/api/Autor/" + id;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }
    }
}
