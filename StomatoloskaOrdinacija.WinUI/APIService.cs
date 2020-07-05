﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using StomatoloskaOrdinacija.Model;
using StomatoloskaOrdinacija.WinUI.Properties;


namespace StomatoloskaOrdinacija.WinUI
{
    public class APIService
    {
        private string _resource;
        public string endpoint = $"{Settings.Default.APIUrl}";

        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int Permisije { get; set; }
        public static int KorisnikId { get; set; }
        public static int UlazUSkladisteId { get; set; }

        public APIService(string resource)
        {
            _resource = resource;
        }
        public async Task<T> GetAll<T>(object searchRequest = null)
        {
            var query = "";
            if (searchRequest != null)
            {
                query = await searchRequest?.ToQueryString();
            }

            var list = await $"{endpoint}/{_resource}?{query}"
               .WithBasicAuth(Username, Password).GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var url = $"{endpoint}/{_resource}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }

        public async Task<T> Login<T>(object request)
        {
            var url = $"{endpoint}/{_resource}";

            return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();


        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}/{_resource}";

            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }

        public async Task<T> Update<T>(object id, object request)
        {
            try
            {
                var url = $"{endpoint}/{_resource}/{id}";

                return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }

        }


    }
}
