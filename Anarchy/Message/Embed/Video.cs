﻿using Newtonsoft.Json;

namespace Discord
{
    //as far as i know videos cannot be put into an embed
    public class EmbedVideo
    {
        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonProperty("width")]
        public int Width { get; private set; }

        [JsonProperty("height")]
        public int Height { get; private set; }


        public override string ToString()
        {
            return $"W: {Width} H: {Height}";
        }
    }
}