﻿using Newtonsoft.Json;
using System;

namespace Discord
{
    public class PermissionOverwrite
    {
        public PermissionOverwrite()
        {
            Allow = new EditablePermissions(0);
            Deny = new EditablePermissions(0);
        }

        [JsonProperty("id")]
        public ulong Id { get; set; }


        [JsonProperty("type")]
        private string _type;
        public PermissionOverwriteType Type
        {
            get
            {
                return (PermissionOverwriteType)Enum.Parse(typeof(PermissionOverwriteType), _type, true);
            }
            set { _type = value.ToString().ToLower(); }
        }


        [JsonProperty("deny")]
        private uint _deny
        {
            get { return Deny; }
            set { Deny = new EditablePermissions(value); }
        }
        [JsonIgnore]
        public EditablePermissions Deny { get; set; }


        [JsonProperty("allow")]
        private uint _allow
        {
            get { return Allow; }
            set { Allow = new EditablePermissions(value); }
        }
        [JsonIgnore]
        public EditablePermissions Allow { get; set; }


        public override string ToString()
        {
            return Type.ToString();
        }
    }
}