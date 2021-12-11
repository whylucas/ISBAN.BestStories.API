using System;
using System.Text.Json.Serialization;

namespace ISBAN.BestStories.Domain.Models
{
    public class StoryResponse
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
        [JsonPropertyName("postedBy")]
        public string PostedBy { get; set; }
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("score")]
        public int Score { get; set; }
        public int CommentCount { get; set; }

        public StoryResponse(Story story)
        {
            Title = story.Title;
            Uri = story.Url;
            PostedBy = story.PostedBy;
            Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(story.Time);
            Score = story.Score;
            CommentCount = story.Kids.Count;
        }
    }
}
