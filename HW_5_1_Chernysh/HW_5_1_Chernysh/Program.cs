using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace HW_5_1_Chernysh
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SendAsync().GetAwaiter().GetResult();
            Console.WriteLine(123);

        }
        async static Task SendAsync()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync("https://reqres.in/api/users?page=2");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync("https://reqres.in/api/users/2");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync("https://reqres.in/api/users/23");

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync("https://reqres.in/api/unknown");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync("https://reqres.in/api/unknown/2");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync("https://reqres.in/api/unknown/23");

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {

                var payload = new
                {
                    name = "morpheus",
                    job = "leader"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload),
                    Encoding.UTF8, "application/json");

                var result = await httpClient.PostAsync("https://reqres.in/api/users", httpContent);

                if (result.StatusCode == HttpStatusCode.Created)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var respose = JsonConvert.DeserializeObject<Response>(content);
                }
            }

            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8,
                    "application/json");

                var result = await httpClient.PutAsync("https://reqres.in/api/users/2", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    name = "morpheus",
                    job = "zion resident"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8,
                    "application/json");

                var result = await httpClient.PatchAsync("https://reqres.in/api/users/2", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.DeleteAsync("https://reqres.in/api/users/2");

                if (result.StatusCode == HttpStatusCode.NoContent)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {

                var payload = new
                {
                    email = "eve.holt@reqres.in",
                    password = "pistol"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8,
                    "application/json");

                var result = await httpClient.PostAsync("https://reqres.in/api/register", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {

                var payload = new
                {
                    email = "sydney@fife"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8,
                    "application/json");

                var result = await httpClient.PostAsync("https://reqres.in/api/register", httpContent);

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {

                var payload = new
                {
                    email = "eve.holt@reqres.in",
                    password = "cityslicka"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8,
                    "application/json");

                var result = await httpClient.PostAsync("https://reqres.in/api/login", httpContent);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {
                var payload = new
                {
                    email = "peter@klaven"
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8,
                    "application/json");

                var result = await httpClient.PostAsync("https://reqres.in/api/login", httpContent);

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }

            using (var httpClient = new HttpClient())
            {

                var result = await httpClient.GetAsync("https://reqres.in/api/users?delay=3");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    var content = await result.Content.ReadAsStringAsync();
                }
            }
        }
    }
}