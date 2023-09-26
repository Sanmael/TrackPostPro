using System.Text.Json.Serialization;

namespace TrackPostPro.Application.DTos
{
    public class DiscordMessageEmbedField
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("value")]
        public string value { get; set; }
        [JsonPropertyName("inline")]
        public bool inline { get; set;}

        public DiscordMessageEmbedField(string name, string value, bool inline = false)
        {
            this.name = name;
            this.value = value;
            this.inline = inline;
        }
    }
}