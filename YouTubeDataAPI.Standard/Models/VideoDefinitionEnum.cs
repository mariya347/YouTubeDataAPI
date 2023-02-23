// <copyright file="VideoDefinitionEnum.cs" company="APIMatic">
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
    /// VideoDefinitionEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VideoDefinitionEnum
    {
        /// <summary>
        /// Any.
        /// </summary>
        [EnumMember(Value = "any")]
        Any,

        /// <summary>
        /// High.
        /// </summary>
        [EnumMember(Value = "high")]
        High,

        /// <summary>
        /// Standard.
        /// </summary>
        [EnumMember(Value = "standard")]
        Standard
    }
}