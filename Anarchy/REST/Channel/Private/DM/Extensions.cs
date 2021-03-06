﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord
{
    public static class DMChannelExtensions
    {
        /// <summary>
        /// Gets the account's private channels
        /// </summary>
        /// <returns>A <see cref="IReadOnlyList{DMChannel}"/> containing the client's private channels</returns>
        public static IReadOnlyList<DMChannel> GetPrivateChannels(this DiscordClient client)
        {
            return client.HttpClient.Get($"/users/@me/channels")
                                .Deserialize<IReadOnlyList<DMChannel>>().SetClientsInList(client);
        }


        /// <summary>
        /// Gets a direct messaging channel
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <returns>A <see cref="DMChannel"/> representation of the channel</returns>
        public static DMChannel GetDMChannel(this DiscordClient client, ulong channelId)
        {
            return client.HttpClient.Get($"/channels/{channelId}")
                    .Deserialize<DMChannel>().SetClient(client);
        }


        /// <summary>
        /// Creates a direct messaging channel
        /// </summary>
        /// <param name="recipientId">ID of the user</param>
        /// <returns>The created <see cref="DMChannel"/></returns>
        public static DMChannel CreateDM(this DiscordClient client, ulong recipientId)
        {
            return client.HttpClient.Post($"/users/@me/channels", $"{{\"recipient_id\":\"{recipientId}\"}}")
                    .Deserialize<DMChannel>().SetClient(client);
        }


        /// <summary>
        /// Closes a direct messaging channel (does not delete the messages)
        /// </summary>
        /// <param name="channelId">ID of the channel</param>
        /// <returns>The closed <see cref="DMChannel"/></returns>
        public static DMChannel CloseDM(this DiscordClient client, ulong channelId)
        {
            return client.HttpClient.Delete($"/channels/{channelId}")
                    .Deserialize<DMChannel>().SetClient(client);
        }
    }
}
