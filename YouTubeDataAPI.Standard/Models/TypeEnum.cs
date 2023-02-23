// <copyright file="TypeEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace YouTubeDataAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using YouTubeDataAPI.Standard;
    using YouTubeDataAPI.Standard.Utilities;

    /// <summary>
    /// TypeEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TypeEnum
    {
        /// <summary>
        /// Channel.
        /// </summary>
        [EnumMember(Value = "channel")]
        Channel,

        /// <summary>
        /// Playlist.
        /// </summary>
        [EnumMember(Value = "playlist")]
        Playlist,

        /// <summary>
        /// Video.
        /// </summary>
        [EnumMember(Value = "video")]
        Video
    }
}