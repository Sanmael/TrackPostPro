using System.Text.Json.Serialization;

namespace TrackPostPro.Application.DTos
{
    public class DiscordMessageEmbedField
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("inline")]
        public bool Inline {get; set;}

        public DiscordMessageEmbedField(string name, string value, bool inline = false)
        {
            Name = name;
            Value = value;
            Inline = inline;
        }
    }
}