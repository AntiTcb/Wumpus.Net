﻿using Wumpus.Entities;
using Voltaic.Serialization;
using Voltaic;

namespace Wumpus.Requests
{
    /// <summary> xxx </summary>
    public class CreateGuildParams
    {
        /// <summary> xxx </summary>
        [ModelProperty("name")]
        public Utf8String Name { get; }
        /// <summary> xxx </summary>
        [ModelProperty("region")]
        public Utf8String RegionId { get; }
        /// <summary> xxx </summary>
        [ModelProperty("icon")]
        public Optional<Image?> Icon { get; set; }
        /// <summary> xxx </summary>
        [ModelProperty("verification_level")]
        public Optional<VerificationLevel> VerificationLevel { get; set; }
        /// <summary> xxx </summary>
        [ModelProperty("default_message_notifications")]
        public Optional<DefaultMessageNotifications> DefaultMessageNotifications { get; set; }
        /// <summary> xxx </summary>
        [ModelProperty("roles")]
        public Optional<Role[]> Roles { get; set; }
        /// <summary> xxx </summary>
        [ModelProperty("channels")]
        public Optional<Channel[]> Channels { get; set; }

        public CreateGuildParams(Utf8String name, Utf8String regionId)
        {
            Name = name;
            RegionId = regionId;
        }

        public void Validate()
        {
            Preconditions.NotNullOrWhitespace(Name, nameof(Name));
            Preconditions.NotNullOrWhitespace(RegionId, nameof(RegionId));
        }
    }
}