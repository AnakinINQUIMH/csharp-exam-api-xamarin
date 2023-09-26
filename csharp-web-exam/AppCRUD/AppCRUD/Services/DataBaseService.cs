using AppCRUD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppCRUD.Services.DataBaseService))]

namespace AppCRUD.Services
{
    public class DataBaseService : IService
    {


        private const string _baseUrl = "https://localhost:5001/";

        #region Creates
        /// <summary>
        /// Insert a record in  bird table
        /// </summary>
        /// <param name="birds"></param>
        /// <returns></returns>
        private async Task<GeneralResponseModel> CreateBirdAsync(BirdsModel birds)
        {
            GeneralResponseModel Generalresponse ;
             try
            {
                var dataPost = new 
                {
                    Name = birds.Name,
                    Feeding = birds.Feeding,
                    TypeId = birds.TypeId
                };

                string jsonData = JsonConvert.SerializeObject(dataPost);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{_baseUrl}/api/values/");
                request.Method = HttpMethod.Post;
                request.Headers.Add("Accpet", "application/json");
                request.Content = content;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    GeneralResponseModel generalResponse = JsonConvert.DeserializeObject<GeneralResponseModel>(contentResponse);
                    return generalResponse;
                }
                else
                {
                    return Generalresponse = new GeneralResponseModel() { Message = "Error en la solicitud HTTP", Status = HttpStatusCode.NotFound.ToString() };                    
                }
            }
            catch (Exception ex)
            {
               return Generalresponse = new GeneralResponseModel() { Message = "Bad request", Status = "400" };

            }
            
        }
        #endregion

        #region Deletes
        /// <summary>
        /// Delete a record by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel> DeleteBirdAsync(int Id)
        {
            GeneralResponseModel Generalresponse;
            try
            {
                string url = $"{_baseUrl}/{Id}";

                
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{_baseUrl}/api/values/");
                request.Method = HttpMethod.Delete;
                request.Headers.Add("Accpet", "application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    GeneralResponseModel generalResponse = JsonConvert.DeserializeObject<GeneralResponseModel>(contentResponse);
                    return generalResponse;
                }
                else 
                { 
                    return Generalresponse = new GeneralResponseModel() { Message = "Error", Status = "" };
                }
            }
            catch (Exception ex)
            {
                return Generalresponse = new GeneralResponseModel() { Message = "Bad request", Status = "400" };
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// Get complete list of birds
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ListBirdsModel>> GetListBirdAsync()
        {
            ListBirdsModel listBirds = null;
            IEnumerable<ListBirdsModel> birds = null ;
            try
            {
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{_baseUrl}/api/values/");
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accpet","application/json");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    birds = JsonConvert.DeserializeObject<IEnumerable<ListBirdsModel>>(content);
                }

                return birds;

            }
            catch (Exception ex)
            {

                listBirds = new ListBirdsModel { generalResponseModel= new GeneralResponseModel { Status = "", Message ="" } };
                return (IEnumerable<ListBirdsModel>)listBirds;
            }
            
        }
        #endregion
      
        #region Updates
        /// <summary>
        /// Update bird record
        /// </summary>
        /// <param name="birds"></param>
        /// <returns></returns>
        public async Task<GeneralResponseModel> UpdateBirdAsync(BirdsModel birds)
        {
            GeneralResponseModel Generalresponse;
            try
            {
                string url = $"{_baseUrl}api/values/";
                var dataPost = new
                {
                    Id = birds.Id,
                    Name = birds.Name,
                    Feeding = birds.Feeding,
                    TypeId = birds.TypeId
                };
                string jsonData = JsonConvert.SerializeObject(dataPost);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage();
                request.RequestUri = new Uri($"{_baseUrl}/api/values/");
                request.Method = HttpMethod.Put;
                request.Headers.Add("Accpet", "application/json");
                request.Content = content;
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string contentResponse = await response.Content.ReadAsStringAsync();
                    GeneralResponseModel generalResponse = JsonConvert.DeserializeObject<GeneralResponseModel>(contentResponse);
                    return generalResponse;
                }
                else 
                { 
                     return Generalresponse = new GeneralResponseModel() { Message = "Error en la solicitud HTTP", Status = "404" };
                   
                }
            }
            catch (Exception ex)
            {
                return Generalresponse = new GeneralResponseModel() { Message = "Bad request", Status = "400" };
            }
        }


        #endregion

        #region General
        
        public Task<GeneralResponseModel> CreateOrUpdateBirdAsync(byte typeQuery, BirdsModel birds)
        {
            if (typeQuery==0)
            {
                return CreateBirdAsync(birds);
            }
            else
            {
                return UpdateBirdAsync(birds);
            }
        }
        
        #endregion
    }
}
