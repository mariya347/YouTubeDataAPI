// <copyright file="APIController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace YouTubeDataAPI.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using System.Net.Http;
    using YouTubeDataAPI.Standard;
    using YouTubeDataAPI.Standard.Authentication;
    using YouTubeDataAPI.Standard.Exceptions;
    using YouTubeDataAPI.Standard.Http.Client;
    using YouTubeDataAPI.Standard.Utilities;

    /// <summary>
    /// APIController.
    /// </summary>
    public class APIController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="APIController"/> class.
        /// </summary>
        internal APIController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Youtube Search.
        /// </summary>
        /// <param name="part">Required parameter: Comma-separated list of resource properties to include in the response..</param>
        /// <param name="q">Required parameter: Search query term(s). Cannot be used with other parameters..</param>
        /// <param name="type">Optional parameter: Comma-separated list of resource types to search for..</param>
        /// <param name="videoDefinition">Optional parameter: Specifies the definition of the video(s) to retrieve..</param>
        /// <param name="key">Optional parameter: API key. Required unless you provide an OAuth 2.0 token..</param>
        /// <param name="channelId">Optional parameter: The channelId parameter indicates that the API response should only contain resources created by the channel..</param>
        /// <param name="channelType">Optional parameter: The channelType parameter lets you restrict a search to a particular type of channel..</param>
        /// <param name="eventType">Optional parameter: The eventType parameter restricts a search to broadcast events. If you specify a value for this parameter, you must also set the type parameter's value to video..</param>
        /// <param name="location">Optional parameter: The location parameter, in conjunction with the locationRadius parameter, defines a circular geographic area and also restricts a search to videos that specify, in their metadata, a geographic location that falls within that area. The parameter value is a string that specifies latitude/longitude coordinates e.g. (37.42307,-122.08427).  If you specify a value for this parameter, you must also set the type parameter's value to video..</param>
        /// <param name="locationRadius">Optional parameter: The locationRadius parameter, in conjunction with the location parameter, defines a circular geographic area..</param>
        /// <param name="maxResults">Optional parameter: The maxResults parameter specifies the maximum number of items that should be returned in the result set. Acceptable values are 0 to 50, inclusive..</param>
        /// <param name="order">Optional parameter: The order parameter specifies the method that will be used to order resources in the API response..</param>
        /// <param name="videoCaption">Optional parameter: The videoCaption parameter indicates whether the API should filter video search results based on whether they have captions. If you specify a value for this parameter, you must also set the type parameter's value to video..</param>
        /// <returns>Returns the Models.SearchListResponse response from the API call.</returns>
        public Models.SearchListResponse YoutubeSearch(
                string part,
                string q,
                Models.TypeEnum? type = null,
                Models.VideoDefinitionEnum? videoDefinition = null,
                string key = null,
                string channelId = null,
                string channelType = null,
                Models.EventTypeEnum? eventType = null,
                string location = null,
                string locationRadius = null,
                int? maxResults = 5,
                Models.OrderEnum? order = Models.OrderEnum.Relevance,
                Models.VideoCaptionEnum? videoCaption = null)
            => CoreHelper.RunTask(YoutubeSearchAsync(part, q, type, videoDefinition, key, channelId, channelType, eventType, location, locationRadius, maxResults, order, videoCaption));

        /// <summary>
        /// Youtube Search.
        /// </summary>
        /// <param name="part">Required parameter: Comma-separated list of resource properties to include in the response..</param>
        /// <param name="q">Required parameter: Search query term(s). Cannot be used with other parameters..</param>
        /// <param name="type">Optional parameter: Comma-separated list of resource types to search for..</param>
        /// <param name="videoDefinition">Optional parameter: Specifies the definition of the video(s) to retrieve..</param>
        /// <param name="key">Optional parameter: API key. Required unless you provide an OAuth 2.0 token..</param>
        /// <param name="channelId">Optional parameter: The channelId parameter indicates that the API response should only contain resources created by the channel..</param>
        /// <param name="channelType">Optional parameter: The channelType parameter lets you restrict a search to a particular type of channel..</param>
        /// <param name="eventType">Optional parameter: The eventType parameter restricts a search to broadcast events. If you specify a value for this parameter, you must also set the type parameter's value to video..</param>
        /// <param name="location">Optional parameter: The location parameter, in conjunction with the locationRadius parameter, defines a circular geographic area and also restricts a search to videos that specify, in their metadata, a geographic location that falls within that area. The parameter value is a string that specifies latitude/longitude coordinates e.g. (37.42307,-122.08427).  If you specify a value for this parameter, you must also set the type parameter's value to video..</param>
        /// <param name="locationRadius">Optional parameter: The locationRadius parameter, in conjunction with the location parameter, defines a circular geographic area..</param>
        /// <param name="maxResults">Optional parameter: The maxResults parameter specifies the maximum number of items that should be returned in the result set. Acceptable values are 0 to 50, inclusive..</param>
        /// <param name="order">Optional parameter: The order parameter specifies the method that will be used to order resources in the API response..</param>
        /// <param name="videoCaption">Optional parameter: The videoCaption parameter indicates whether the API should filter video search results based on whether they have captions. If you specify a value for this parameter, you must also set the type parameter's value to video..</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.SearchListResponse response from the API call.</returns>
        public async Task<Models.SearchListResponse> YoutubeSearchAsync(
                string part,
                string q,
                Models.TypeEnum? type = null,
                Models.VideoDefinitionEnum? videoDefinition = null,
                string key = null,
                string channelId = null,
                string channelType = null,
                Models.EventTypeEnum? eventType = null,
                string location = null,
                string locationRadius = null,
                int? maxResults = 5,
                Models.OrderEnum? order = Models.OrderEnum.Relevance,
                Models.VideoCaptionEnum? videoCaption = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.SearchListResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/search")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("part", part))
                      .Query(_query => _query.Setup("q", q))
                      .Query(_query => _query.Setup("type", (type.HasValue) ? ApiHelper.JsonSerialize(type.Value).Trim('\"') : null))
                      .Query(_query => _query.Setup("videoDefinition", (videoDefinition.HasValue) ? ApiHelper.JsonSerialize(videoDefinition.Value).Trim('\"') : null))
                      .Query(_query => _query.Setup("key", key))
                      .Query(_query => _query.Setup("channelId", channelId))
                      .Query(_query => _query.Setup("channelType", channelType))
                      .Query(_query => _query.Setup("eventType", (eventType.HasValue) ? ApiHelper.JsonSerialize(eventType.Value).Trim('\"') : null))
                      .Query(_query => _query.Setup("location", location))
                      .Query(_query => _query.Setup("locationRadius", locationRadius))
                      .Query(_query => _query.Setup("maxResults", (maxResults != null) ? maxResults : 5))
                      .Query(_query => _query.Setup("order", (order.HasValue) ? ApiHelper.JsonSerialize(order.Value).Trim('\"') : "relevance"))
                      .Query(_query => _query.Setup("videoCaption", (videoCaption.HasValue) ? ApiHelper.JsonSerialize(videoCaption.Value).Trim('\"') : null))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Bad Request", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("403", CreateErrorCase("Forbidden.", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Not found.", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.SearchListResponse>(_response)))
              .ExecuteAsync(cancellationToken);
    }
}