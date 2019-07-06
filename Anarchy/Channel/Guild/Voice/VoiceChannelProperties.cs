﻿using Newtonsoft.Json;

namespace Discord
{
    public class VoiceChannelProperties : GuildChannelProperties
    {
        internal Property<int> BitrateProperty = new Property<int>();
        [JsonProperty("bitrate")]
        public int Bitrate
        {
            get { return BitrateProperty; }
            set { BitrateProperty.Value = value; }
        }


        internal Property<int> UserLimitProperty = new Property<int>();
        [JsonProperty("user_limit")]
        public int UserLimit
        {
            get { return UserLimitProperty; }
            set { UserLimitProperty.Value = value; }
        }
    }
}