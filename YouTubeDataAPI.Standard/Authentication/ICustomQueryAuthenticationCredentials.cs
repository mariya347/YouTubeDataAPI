// <copyright file="ICustomQueryAuthenticationCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace YouTubeDataAPI.Standard.Authentication
{
    using System;

    public interface ICustomQueryAuthenticationCredentials
    {
        /// <summary>
        /// Gets string value for key.
        /// </summary>
        string Key { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="key"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string key);
    }
}