using AppCliente.Models;
using Newtonsoft.Json;
using System.Text;

namespace AppCliente.Services
{
    public class PrestamoService
    {
        string url = "http://apigateway:8080";
        string endPoint = "";
        HttpClient client = new HttpClient();
        public async Task<List<Prestamo>> ListarPrestamos()
        {
            endPoint = "api/Prestamo";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Prestamo> result = new List<Prestamo>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Prestamo>>(respuestaCuerpo)!;
            }
            return result;
        }
        public async Task<bool> InsertarPrestamo(Prestamo prestamo)
        {
            bool sw = false;
            endPoint = url + "/api/Prestamo";
            string jsonBody = JsonConvert.SerializeObject(prestamo);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return sw = true;
            }
            return sw;
        }
        public async Task<Prestamo> ObtenerPrestamo(string id)
        {
            endPoint = "/api/Prestamo/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Prestamo prestamo = new Prestamo();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                prestamo = JsonConvert.DeserializeObject<Prestamo>(respuestaCuerpo)!;
            }
            return prestamo;
        }

        public async Task<bool> EditarPrestamo(Prestamo prestamo)
        {
            bool sw = false;
            endPoint = url + "/api/Prestamo";
            string jsonBody = JsonConvert.SerializeObject(prestamo);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarPrestamo(string id)
        {
            bool sw = false;
            endPoint = url + "/api/Prestamo/" + id;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }
    }
}
