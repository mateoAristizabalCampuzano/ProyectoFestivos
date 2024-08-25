using calcularDiasHabiles.Entities;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace calcularDiasHabiles.Bussiness
{
    public class HolidayBussiness : IHolidayBussiness
    {
        private string URLAPI;
        private readonly string pais;
        private readonly string anio;
        private readonly string ApiKey;


        public HolidayBussiness (IConfiguration configuration)
        {
            URLAPI = configuration.GetSection("ConexionesFestivosAPI").GetSection("URL").Value;
            pais = configuration.GetSection("ConexionesFestivosAPI").GetSection("pais").Value;
            anio = configuration.GetSection("ConexionesFestivosAPI").GetSection("anio").Value;
            ApiKey = configuration.GetSection("ConexionesFestivosAPI").GetSection("ApiKey").Value;
        }


        //public Task<Holiday> CalcularApiFestivos()
        //{
        //    URLAPI += $"?api_key={ApiKey}&country={pais}&year={anio}";
        //    Holiday festivos = new Holiday();
        //    festivos = null;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(URLAPI);

        //        HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;


        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsonResponse = response.Content.ReadAsStringAsync().Result;

        //            festivos = JsonConvert.DeserializeObject<Holiday>(jsonResponse);

        //        }
        //    }

        //    return festivos;

        //}

        public async Task<HolidaysEntities> CalcularApiFestivos()
        {
            URLAPI += $"?api_key={ApiKey}&country={pais}&year={anio}";
            HolidaysEntities festivos = new HolidaysEntities();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URLAPI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        festivos = response.Content.ReadFromJsonAsync<HolidaysEntities>().Result;
                    }
                    else
                    {
                        // Manejo de error en caso de que la solicitud no sea exitosa
                        Console.WriteLine("Error en la solicitud: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones, por ejemplo, problemas de red
                    Console.WriteLine("Excepción durante la solicitud HTTP: " + ex.Message);
                }
            }

            return festivos;
        }
    }
}
