using System.Net.Http.Headers;
using System.Text;

namespace Meddl
{
    public class Request
    {
        public static void Send(string endpoint, string method, string? auth, string? json = null, bool XAuditLogReason = false)
        {
            HttpClient client = new();
            string? token = Config.IsBot ? $"Bot {auth}" : auth;
            client.DefaultRequestHeaders.Add("Authorization", token);
            if (XAuditLogReason == true)
                client.DefaultRequestHeaders.Add("X-Audit-Log-Reason", "Meddl Nuker");
            HttpRequestMessage request = new(new HttpMethod(method), $"https://discord.com/api/v{Config.APIVersion}{endpoint}");
            if (json != null)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            else
                request.Content = null;
            client.Send(request);
        }

        public static string SendGet(string endpoint, string? auth, string method = "GET", string? json = null)
        {
            HttpClient client = new();
            string? token = Config.IsBot ? $"Bot {auth}" : auth;
            client.DefaultRequestHeaders.Add("Authorization", token);
            HttpRequestMessage request = new(new HttpMethod(method), $"https://discord.com/api/v{Config.APIVersion}{endpoint}");
            if (json != null)
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
            else
                request.Content = null;
            var response = client.GetAsync($"https://discord.com/api/v{Config.APIVersion}{endpoint}").GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();
            Thread.Sleep(1000);
            return new StreamReader(client.Send(request).Content.ReadAsStream()).ReadToEnd();
        }
    }
}
