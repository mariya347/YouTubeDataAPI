// <copyright file="OrderEnum.cs" company="APIMatic">
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
    /// OrderEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderEnum
    {
        /// <summary>
        /// Date.
        /// </summary>
        [EnumMember(Value = "date")]
        Date,

        /// <summary>
        /// Rating.
        /// </summary>
        [EnumMember(Value = "rating")]
        Rating,

        /// <summary>
        /// Relevance.
        /// </summary>
        [EnumMember(Value = "relevance")]
        Relevance,

        /// <summary>
        /// Title.
        /// </summary>
        [EnumMember(Value = "title")]
        Title,

        /// <summary>
        /// VideoCount.
        /// </summary>
        [EnumMember(Value = "videoCount")]
        VideoCount,

        /// <summary>
        /// ViewCount.
        /// </summary>
        [EnumMember(Value = "viewCount")]
        ViewCount
    }
}