using System;
using System.Collections.Generic;
using System.Text;

namespace ISBAN.BestStories.Domain.Models
{
    public class Story
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string PostedBy { get; set; }
        public int Time { get; set; }
        public List<int> Kids { get; set; }
        public int Score { get; set; }
        public int CommentCount { get => Kids.Count;}
    }
}
