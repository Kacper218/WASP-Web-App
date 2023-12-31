﻿using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WASP_Web_App.Entities;

namespace WASP_Web_App
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7155");
        }

        public async Task<string> GetLoginInfo(Auth user)
        {
            try
            {
                JsonContent content = JsonContent.Create(user);

                var response = await _httpClient.PostAsync("/Auth", content);
            

               if(response.IsSuccessStatusCode)
                { 
                   
                    var responseData = await response.Content.ReadAsStringAsync();               

                    Console.WriteLine(responseData);

                    return responseData;

                }
                return "Nie udało się zalogować";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "Blad podczas Pobierania API";
            }
        }
    }
}
