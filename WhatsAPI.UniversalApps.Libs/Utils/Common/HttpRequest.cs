﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WhatsAPI.UniversalApps.Libs.Utils.Common
{
    public class HttpRequest
    {
        /// <summary>
        /// Request to Server using GET
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<string> Get(string uri)
        {
            var httpClient = new HttpClient();
            var url = new Uri(uri);
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            httpRequestMessage.Headers.Add("User-Agent", Constants.Information.UserAgent);
            var response = await httpClient.SendAsync(httpRequestMessage);
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();
            Logger.Log.Write(res, uri);
            return res;
        }

    }
}
