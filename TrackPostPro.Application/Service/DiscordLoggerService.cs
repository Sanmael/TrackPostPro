using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using TrackPostPro.Application.DTos;
using TrackPostPro.Application.Interfaces;

namespace TrackPostPro.Application.Service
{
    public class DiscordLoggerService : ILoggerService
    {
        private readonly IConfiguration _configuration;
        private readonly LoggerService _loggerService;
        public DiscordLoggerService(IConfiguration configuration, LoggerService loggerService)
        {
            _configuration = configuration;
            _loggerService = loggerService;
        }

        public async Task SaveLog(Exception ex, string message, string serviceName)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var embed = MapperFields(ex, message);

                var payload = new
                {
                    embeds = new[] { embed }
                };

                string jsonPayload = JsonConvert.SerializeObject(payload);

                var content = new StringContent(jsonPayload);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await httpClient.PostAsync(_configuration.GetValue<string>("DiscordLink"), content);

                if (!response.IsSuccessStatusCode)
                {
                    await _loggerService.SaveLog(ex, message, serviceName);
                }
            }

        }
        public object MapperFields(Exception ex, string message)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var fields = new List<DiscordMessageEmbedField>
                    {
                    new DiscordMessageEmbedField("Application Name", assembly.GetName().Name!),
                    new DiscordMessageEmbedField("Message", message),
                    new DiscordMessageEmbedField("Exception type", ex.GetType().ToString()),
                    new DiscordMessageEmbedField("Source", ex.Source)
                     };

            var embed = new
            {
                title = ":skull:\r\n Error",
                description = ex.ToString(),
                type = "rich",
                color = 16711680,
                timestamp = DateTime.UtcNow.ToString("o"),
                fields = fields
            };

            return embed;
        }
    }
}
