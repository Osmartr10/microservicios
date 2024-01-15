using AppCliente.Models;
using Newtonsoft.Json;
using System.Text;

namespace AppCliente.Services
{
    public class EstudianteService
    {
        string url = "http://apigateway:8080";
        string endPoint = "";
        HttpClient client = new HttpClient();
        public async Task<List<Estudiante>> ListarEstudiantes()
        {
            endPoint = "api/Estudiante";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Estudiante> result = new List<Estudiante>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Estudiante>>(respuestaCuerpo)!;
            }
            return result;
        }
        public async Task<bool> InsertarEstudiante(Estudiante estudiante)
        {
            bool sw = false;
            endPoint = url + "/api/Estudiante";
            string jsonBody = JsonConvert.SerializeObject(estudiante);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                return sw = true;
            }
            return sw;
        }
        public async Task<Estudiante> ObtenerEstudiante(int id)
        {
            endPoint = "/api/Estudiante/" + id;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Estudiante estudiante = new Estudiante();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                estudiante = JsonConvert.DeserializeObject<Estudiante>(respuestaCuerpo)!;
            }
            return estudiante;
        }

        public async Task<bool> EditarEstudiante(Estudiante estudiante, int id)
        {
            bool sw = false;
            endPoint = url + "/api/Estudiante/" + id;
            string jsonBody = JsonConvert.SerializeObject(estudiante);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarEstudiante(int id)
        {
            bool sw = false;
            endPoint = url + "/api/Estudiante/" + id;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }
    }
}
