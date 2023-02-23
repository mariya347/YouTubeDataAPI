// <copyright file="YouTubeDataAPIClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace YouTubeDataAPI.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Authentication;
    using APIMatic.Core.Types;
    using YouTubeDataAPI.Standard.Authentication;
    using YouTubeDataAPI.Standard.Controllers;
    using YouTubeDataAPI.Standard.Http.Client;
    using YouTubeDataAPI.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class YouTubeDataAPIClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Default, "https://www.googleapis.com/youtube/v3" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly CustomQueryAuthenticationManager customQueryAuthenticationManager;
        private readonly Lazy<APIController> client;

        private YouTubeDataAPIClient(
            Environment environment,
            string key,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.HttpClientConfiguration = httpClientConfiguration;
            customQueryAuthenticationManager = new CustomQueryAuthenticationManager(key);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                        {"global", customQueryAuthenticationManager}
                })
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Default)
                .UserAgent(userAgent)
                .Build();


            this.client = new Lazy<APIController>(
                () => new APIController(globalConfiguration));
        }

        /// <summary>
        /// Gets APIController controller.
        /// </summary>
        public APIController APIController => this.client.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }


        /// <summary>
        /// Gets the credentials to use with CustomQueryAuthentication.
        /// </summary>
        public ICustomQueryAuthenticationCredentials CustomQueryAuthenticationCredentials => this.customQueryAuthenticationManager;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:DEFAULT.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Default)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the YouTubeDataAPIClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .CustomQueryAuthenticationCredentials(customQueryAuthenticationManager.Key)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> YouTubeDataAPIClient.</returns>
        internal static YouTubeDataAPIClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("YOU_TUBE_DATA_API_STANDARD_ENVIRONMENT");
            string key = System.Environment.GetEnvironmentVariable("YOU_TUBE_DATA_API_STANDARD_KEY");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (key != null)
            {
                builder.CustomQueryAuthenticationCredentials(key);
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = YouTubeDataAPI.Standard.Environment.Production;
            private string key = "";
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();

            /// <summary>
            /// Sets credentials for CustomQueryAuthentication.
            /// </summary>
            /// <param name="key">Key.</param>
            /// <returns>Builder.</returns>
            public Builder CustomQueryAuthenticationCredentials(string key)
            {
                this.key = key ?? throw new ArgumentNullException(nameof(key));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

           

            /// <summary>
            /// Creates an object of the YouTubeDataAPIClient using the values provided for the builder.
            /// </summary>
            /// <returns>YouTubeDataAPIClient.</returns>
            public YouTubeDataAPIClient Build()
            {

                return new YouTubeDataAPIClient(
                    environment,
                    key,
                    httpClientConfig.Build());
            }
        }
    }
}
