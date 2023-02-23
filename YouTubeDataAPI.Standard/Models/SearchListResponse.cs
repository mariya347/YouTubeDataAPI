// <copyright file="SearchListResponse.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace YouTubeDataAPI.Standard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using YouTubeDataAPI.Standard;
    using YouTubeDataAPI.Standard.Utilities;

    /// <summary>
    /// SearchListResponse.
    /// </summary>
    public class SearchListResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchListResponse"/> class.
        /// </summary>
        public SearchListResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchListResponse"/> class.
        /// </summary>
        /// <param name="kind">kind.</param>
        /// <param name="etag">etag.</param>
        /// <param name="nextPageToken">nextPageToken.</param>
        /// <param name="prevPageToken">prevPageToken.</param>
        /// <param name="regionCode">regionCode.</param>
        /// <param name="pageInfo">pageInfo.</param>
        /// <param name="items">items.</param>
        public SearchListResponse(
            string kind = null,
            string etag = null,
            string nextPageToken = null,
            string prevPageToken = null,
            string regionCode = null,
            Models.PageInfo pageInfo = null,
            object items = null)
        {
            this.Kind = kind;
            this.Etag = etag;
            this.NextPageToken = nextPageToken;
            this.PrevPageToken = prevPageToken;
            this.RegionCode = regionCode;
            this.PageInfo = pageInfo;
            this.Items = items;
        }

        /// <summary>
        /// Identifies the API resource's type
        /// </summary>
        [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
        public string Kind { get; set; }

        /// <summary>
        /// The Etag of this resource
        /// </summary>
        [JsonProperty("etag", NullValueHandling = NullValueHandling.Ignore)]
        public string Etag { get; set; }

        /// <summary>
        /// The token that can be used as the value of the pageToken parameter to retrieve the next page in the result set.
        /// </summary>
        [JsonProperty("nextPageToken", NullValueHandling = NullValueHandling.Ignore)]
        public string NextPageToken { get; set; }

        /// <summary>
        /// The token that can be used as the value of the pageToken parameter to retrieve the previous page in the result set.
        /// </summary>
        [JsonProperty("prevPageToken", NullValueHandling = NullValueHandling.Ignore)]
        public string PrevPageToken { get; set; }

        /// <summary>
        /// The region code that was used for the search query.
        /// </summary>
        [JsonProperty("regionCode", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionCode { get; set; }

        /// <summary>
        /// Gets or sets PageInfo.
        /// </summary>
        [JsonProperty("pageInfo", NullValueHandling = NullValueHandling.Ignore)]
        public Models.PageInfo PageInfo { get; set; }

        /// <summary>
        /// A list of results that match the search criteria.
        /// </summary>
        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public object Items { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            var toStringOutput = new List<string>();

            this.ToString(toStringOutput);

            return $"SearchListResponse : ({string.Join(", ", toStringOutput)})";
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            return obj is SearchListResponse other &&
                ((this.Kind == null && other.Kind == null) || (this.Kind?.Equals(other.Kind) == true)) &&
                ((this.Etag == null && other.Etag == null) || (this.Etag?.Equals(other.Etag) == true)) &&
                ((this.NextPageToken == null && other.NextPageToken == null) || (this.NextPageToken?.Equals(other.NextPageToken) == true)) &&
                ((this.PrevPageToken == null && other.PrevPageToken == null) || (this.PrevPageToken?.Equals(other.PrevPageToken) == true)) &&
                ((this.RegionCode == null && other.RegionCode == null) || (this.RegionCode?.Equals(other.RegionCode) == true)) &&
                ((this.PageInfo == null && other.PageInfo == null) || (this.PageInfo?.Equals(other.PageInfo) == true)) &&
                ((this.Items == null && other.Items == null) || (this.Items?.Equals(other.Items) == true));
        }
        
        /// <summary>
        /// ToString overload.
        /// </summary>
        /// <param name="toStringOutput">List of strings.</param>
        protected void ToString(List<string> toStringOutput)
        {
            toStringOutput.Add($"this.Kind = {(this.Kind == null ? "null" : this.Kind == string.Empty ? "" : this.Kind)}");
            toStringOutput.Add($"this.Etag = {(this.Etag == null ? "null" : this.Etag == string.Empty ? "" : this.Etag)}");
            toStringOutput.Add($"this.NextPageToken = {(this.NextPageToken == null ? "null" : this.NextPageToken == string.Empty ? "" : this.NextPageToken)}");
            toStringOutput.Add($"this.PrevPageToken = {(this.PrevPageToken == null ? "null" : this.PrevPageToken == string.Empty ? "" : this.PrevPageToken)}");
            toStringOutput.Add($"this.RegionCode = {(this.RegionCode == null ? "null" : this.RegionCode == string.Empty ? "" : this.RegionCode)}");
            toStringOutput.Add($"this.PageInfo = {(this.PageInfo == null ? "null" : this.PageInfo.ToString())}");
            toStringOutput.Add($"Items = {(this.Items == null ? "null" : this.Items.ToString())}");
        }
    }
}