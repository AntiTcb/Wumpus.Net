﻿using System.Collections.Generic;
using Wumpus.Entities;
using Voltaic.Serialization;
using Voltaic;

namespace Wumpus.Requests
{
    /// <summary> xxx </summary>
    public class CreateMessageParams : IFormData
    {
        /// <summary> xxx </summary>
        [ModelProperty("content")]
        public Optional<Utf8String> Content { get; set; }
        /// <summary> xxx </summary>
        [ModelProperty("nonce")]
        public Optional<Utf8String> Nonce { get; set; }
        /// <summary> xxx </summary>
        [ModelProperty("tts")]
        public Optional<bool> IsTTS { get; set; }
        /// <summary> xxx </summary>
        [ModelProperty("embed")]
        public Optional<Embed> Embed { get; set; }

        public Optional<MultipartFile> File { get; set; }
        
        public IDictionary<string, object> GetFormData()
        {
            var dict = new Dictionary<string, object>();
            if (File.IsSpecified)
                dict["file"] = File.Value;
            dict["payload_json"] = this;
            return dict;
        }

        public void Validate()
        {
            Preconditions.NotNull(Nonce, nameof(Nonce));

            if (!Content.IsSpecified || Content.Value == (Utf8String)null)
                Content = (Utf8String)"";
            if (Embed.IsSpecified && Embed.Value != null)
                Preconditions.NotNullOrWhitespace(Content, nameof(Content));
            // else //TODO: Validate embed length
            Preconditions.LengthAtMost(Content, DiscordRestConstants.MaxMessageSize, nameof(Content));
        }
    }
}