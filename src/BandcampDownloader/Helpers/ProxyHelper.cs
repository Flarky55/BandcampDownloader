using System;
using System.Net;

namespace BandcampDownloader
{
    internal static class ProxyHelper
    {
        /// <summary>
        /// Sets the proxy of the specified WebClient according to the UserSettings.
        /// </summary>
        /// <param name="webClient">The WebClient to modify.</param>
        public static void SetProxy(WebClient webClient)
        {
            webClient.Proxy = GetProxy();
        }
        public static void SetProxy(WebRequest webRequest)
        {
            webRequest.Proxy = GetProxy();
        }

        private static IWebProxy GetProxy()
        {
            switch (App.UserSettings.Proxy)
            {
                case ProxyType.None:
                    return null;
                case ProxyType.System:
                    IWebProxy proxy = WebRequest.GetSystemWebProxy();
                    proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
                    return proxy;
                case ProxyType.Manual:
                    return new WebProxy(App.UserSettings.ProxyHttpAddress, App.UserSettings.ProxyHttpPort);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}