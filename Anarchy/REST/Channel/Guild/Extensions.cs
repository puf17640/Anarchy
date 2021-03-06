﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord
{
    public static class GuildChannelExtensions
    {
#pragma warning disable IDE1006
        private static T getChannel<T>(this DiscordClient client, ulong channelId) where T : GuildChannel
        {
            return client.HttpClient.Get($"/channels/{channelId}")
                                .Deserialize<T>().SetClient(client);
        }


        private static Treturn modifyChannel<Treturn, TProperties>(this DiscordClient client, ulong channelId, TProperties properties) where TProperties : GuildChannelProperties where Treturn : GuildChannel
        {
            return client.HttpClient.Patch($"/channels/{channelId}",
                                JsonConvert.SerializeObject(properties)).Deserialize<Treturn>().SetClient(client);
        }

        private static T deleteChannel<T>(this DiscordClient client, ulong channelId) where T : GuildChannel
        {
            return client.HttpClient.Delete($"/channels/{channelId}")
                .Deserialize<T>().SetClient(client);
        }


        /// <summary>
        /// Gets a guild's channels
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        public static IReadOnlyList<GuildChannel> GetGuildChannels(this DiscordClient client, ulong guildId)
        {
            return client.HttpClient.Get($"/guilds/{guildId}/channels")
                                .Deserialize<IReadOnlyList<GuildChannel>>().SetClientsInList(client);
        }


        /// <summary>
        /// Gets a guild channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        public static GuildChannel GetGuildChannel(this DiscordClient client, ulong channelId)
        {
            return client.getChannel<GuildChannel>(channelId);
        }


        /// <summary>
        /// Gets a guild text channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        public static TextChannel GetTextChannel(this DiscordClient client, ulong channelId)
        {
            return client.getChannel<TextChannel>(channelId);
        }


        /// <summary>
        /// Gets a guild voice channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        public static VoiceChannel GetVoiceChannel(this DiscordClient client, ulong channelId)
        {
            return client.getChannel<VoiceChannel>(channelId);
        }


        private static T createGuildChannel<T>(this DiscordClient client, ulong guildId, ChannelCreationProperties properties) where T : GuildChannel
        {
            return client.HttpClient.Post($"/guilds/{guildId}/channels",
                                JsonConvert.SerializeObject(properties)).Deserialize<T>().SetClient(client);
        }


        /// <summary>
        /// Creates a guild channel
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="properties">Options for creating the channel</param>
        /// <returns>The created <see cref="GuildChannel"/></returns>
        public static GuildChannel CreateGuildChannel(this DiscordClient client, ulong guildId, GuildChannelCreationProperties properties)
        {
            return client.createGuildChannel<GuildChannel>(guildId, properties);
        }


        /// <summary>
        /// Creates a guild text channel
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="properties">Options for creating the channel</param>
        /// <returns>The created <see cref="TextChannel"/></returns>
        public static TextChannel CreateTextChannel(this DiscordClient client, ulong guildId, GuildChannelCreationProperties properties)
        {
            properties.Type = ChannelType.Text;
            return client.createGuildChannel<TextChannel>(guildId, properties);
        }


        /// <summary>
        /// Creates a guild voice channel
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="properties">Options for creating the channel</param>
        /// <returns>The created <see cref="VoiceChannel"/></returns>
        public static VoiceChannel CreateVoiceChannel(this DiscordClient client, ulong guildId, GuildChannelCreationProperties properties)
        {
            properties.Type = ChannelType.Voice;
            return client.createGuildChannel<VoiceChannel>(guildId, properties);
        }


        /// <summary>
        /// Modifies a guild channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="properties">Options for modifying the guild channel</param>
        /// <returns>The modified <see cref="GuildChannel"/></returns>
        public static GuildChannel ModifyGuildChannel(this DiscordClient client, ulong channelId, GuildChannelProperties properties)
        {
            return client.modifyChannel<GuildChannel, GuildChannelProperties>(channelId, properties);
        }


        /// <summary>
        /// Modifies a guild text channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="properties">Options for modifying the channel</param>
        /// <returns>The modified <see cref="TextChannel"/></returns>
        public static TextChannel ModifyTextChannel(this DiscordClient client, ulong channelId, TextChannelProperties properties)
        {
            return client.modifyChannel<TextChannel, TextChannelProperties>(channelId, properties);
        }


        /// <summary>
        /// Modifies a guild voice channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="properties">Options for modifying the channel</param>
        /// <returns>The modified <see cref="VoiceChannel"/></returns>
        public static VoiceChannel ModifyVoiceChannel(this DiscordClient client, ulong channelId, VoiceChannelProperties properties)
        {
            return client.modifyChannel<VoiceChannel, VoiceChannelProperties>(channelId, properties);
        }


        /// <summary>
        /// Deletes a guild channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <returns>The deleted <see cref="GuildChannel"/></returns>
        public static GuildChannel DeleteGuildChannel(this DiscordClient client, ulong channelId)
        {
            return client.deleteChannel<GuildChannel>(channelId);
        }


        /// <summary>
        /// Adds/edits a permission overwrite to a channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="overwrite">The permission overwrite to add/edit</param>
        public static void AddPermissionOverwrite(this DiscordClient client, ulong channelId, PermissionOverwrite overwrite)
        {
            client.HttpClient.Put($"/channels/{channelId}/permissions/{overwrite.Id}", JsonConvert.SerializeObject(overwrite));
        }


        /// <summary>
        /// Removes a permission overwrite from a channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <param name="id">ID of the role or member affected by the overwrite</param>
        public static void RemovePermissionOverwrite(this DiscordClient client, ulong channelId, ulong id)
        {
            client.HttpClient.Delete($"/channels/{channelId}/permissions/{id}");
        }
#pragma warning restore IDE1006
    }
}
