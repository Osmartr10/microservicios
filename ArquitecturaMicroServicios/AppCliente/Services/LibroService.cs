using AppCliente.Models;
using Newtonsoft.Json;
using System.Text;

namespace AppCliente.Services
{
    public class LibroService
    {
        string url = "http://apigateway:8080";
        string endPoint = "";
        HttpClient client = new HttpClient();
        public async Task<List<Libro>> ListarLibros()
        {
            endPoint = "api/Libro";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Libro> result = new List<Libro>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Libro>>(respuestaCuerpo)!;
            }
            return result;
        }
       
        public async Task<Libro> InsertarLibro(Libro libro)
        {
            Libro obj = null!;
            endPoint = url + "/api/Libro";
            string jsonBody = JsonConvert.SerializeObject(libro);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeObject<Libro>(respuestaCuerpo)!;
            }
            return obj!;
        }
        public async Task<Libro> ObtenerLibro(int id)
        {
            endPoint = "/api/Libro/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Libro libro = new Libro();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                libro = JsonConvert.DeserializeObject<Libro>(respuestaCuerpo)!;
            }
            return libro;
        }

        public async Task<bool> EditarLibro(Libro libro, int id)
        {
            bool sw = false;
            endPoint = url + "/api/Libro/" + id;
            string jsonBody = JsonConvert.SerializeObject(libro);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarLibro(int id)
        {
            bool sw = false;
            endPoint = url + "/api/Libro/" + id;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }
        public async Task<bool> AgregarAutores(AutorLibro[] autores)
        {
            bool sw = false;
            endPoint = url + "/api/AutorLibro";
            string jsonBody = JsonConvert.SerializeObject(autores);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return sw = true;
            }
            return sw;
        }
        public async Task<List<AutorLibro>> ObtenerAutores(int id)
        {
           
            endPoint = "/api/AutorLibro/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            List<AutorLibro> lista = new List<AutorLibro>();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<AutorLibro>>(respuestaCuerpo)!;
            }
            return lista;
        }
        public async Task<bool> EliminarAutor(int id)
        {
            bool sw = false;
            endPoint = url + "/api/AutorLibro/" + id;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }
    }
}
