﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Discord
{
    public static class RoleExtensions
    {
        #region management
        /// <summary>
        /// Creates a role
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="properties">Options for modifying the created ole</param>
        /// <returns>The created <see cref="Role"/></returns>
        public static Role CreateGuildRole(this DiscordClient client, ulong guildId, RoleProperties properties = null)
        {
            Role role = client.HttpClient.Post($"/guilds/{guildId}/roles")
                                    .Deserialize<Role>().SetClient(client);
            role.GuildId = guildId;
            if (properties != null)
                role.Modify(properties);
            return role;
        }


        /// <summary>
        /// Modifies a role
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="roleId">ID of the role</param>
        /// <param name="properties"></param>
        /// <returns>The modified <see cref="Role"/></returns>
        public static Role ModifyGuildRole(this DiscordClient client, ulong guildId, ulong roleId, RoleProperties properties)
        {
            Role changed = client.HttpClient.Patch($"/guilds/{guildId}/roles/{roleId}", 
                                        JsonConvert.SerializeObject(properties)).Deserialize<Role>().SetClient(client);
            changed.GuildId = guildId;
            return changed;
        }


        /// <summary>
        /// Deletes a role
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="roleId">ID of the role</param>
        public static void DeleteGuildRole(this DiscordClient client, ulong guildId, ulong roleId)
        {
            client.HttpClient.Delete($"/guilds/{guildId}/roles/{roleId}");
        }
        #endregion


        /// <summary>
        /// Sets a guild member's roles
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="userId">ID of the user</param>
        public static void SetGuildMemberRoles(this DiscordClient client, ulong guildId, ulong userId, List<ulong> roles)
        {
            client.ModifyGuildMember(guildId, userId, new GuildMemberProperties() { Roles = roles });
        }


        /// <summary>
        /// Adds a role to a guild member
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="roleId">ID of the role</param>
        /// <param name="userId">ID of the guild member</param>
        public static void AddRoleToUser(this DiscordClient client, ulong guildId, ulong roleId, ulong userId)
        {
            client.HttpClient.Put($"/guilds/{guildId}/members/{userId}/roles/{roleId}");
        }


        /// <summary>
        /// Removes a role from a guild member
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        /// <param name="roleId">ID of the role</param>
        /// <param name="userId">ID of the guild member</param>
        public static void RemoveRoleFromUser(this DiscordClient client, ulong guildId, ulong roleId, ulong userId)
        {
            client.HttpClient.Delete($"/guilds/{guildId}/members/{userId}/roles/{roleId}");
        }


        /// <summary>
        /// Gets a guild's roles
        /// </summary>
        /// <param name="guildId">ID of the guild</param>
        public static IReadOnlyList<Role> GetGuildRoles(this DiscordClient client, ulong guildId)
        {
            IReadOnlyList<Role> roles = client.HttpClient.Get($"/guilds/{guildId}/roles")
                                                    .Deserialize<IReadOnlyList<Role>>().SetClientsInList(client);
            foreach (var role in roles)
                role.GuildId = guildId;
            return roles;
        }
    }
}