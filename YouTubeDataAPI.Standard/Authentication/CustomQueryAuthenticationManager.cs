// <copyright file="CustomQueryAuthenticationManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace YouTubeDataAPI.Standard.Authentication
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using YouTubeDataAPI.Standard.Http.Request;
    using APIMatic.Core.Authentication;

    /// <summary>
    /// CustomQueryAuthenticationManager.
    /// </summary>
    internal class CustomQueryAuthenticationManager : AuthManager, ICustomQueryAuthenticationCredentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueryAuthenticationManager"/> class.
        /// </summary>
        /// <param name="key">key.</param>
        public CustomQueryAuthenticationManager(string key)
        {
            this.Key = key;
            Parameters(paramBuilder => paramBuilder
                .Query(query => query.Setup("key", Key))
            );
        }

        /// <summary>
        /// Gets string value for key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="key"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string key)
        {
            return key.Equals(this.Key);
        }
    }
}
