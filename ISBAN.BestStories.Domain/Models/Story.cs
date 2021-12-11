using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ISBAN.BestStories.Domain.Models
{
    public class Story
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("by")]
        public string PostedBy { get; set; }
        [JsonPropertyName("time")]
        public int Time { get; set; }
        [JsonPropertyName("kids")]
        public List<int> Kids { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}
