using DataAccess.EF;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Test
{
    class Program
    {
        public static string BaseUrl = "http://seekparties.com/";//"http://192.168.1.106:8080/"; //"https://localhost:44341/"; //
        private static RestClient client;
        private static RestRequest restRequest;



        static void Main(string[] args)
        {
            //DataAccess.Utility.EmailUtility.SendEmail("ishwar@drdev.com","Test","Test");



            DataAccess.FireBaseNotifications.SendPushNotification("Party Buddies", "Ishwar 123", $"you have got a new Party Request", "ewDdJrA0_P4:APA91bEAOGLMNCCxoMbMlknygpTb_58LERxvd5MM8TrroLuhgej4je2t07WQ30ctSPfvMSTR-DXEDEwfQq0Bpv78rm-Z2j7_ufVOa69_xzS_yQ6vd-sPdOXK25TCGWz6YrDbTVV6Xed1", true, false);
            //DataAccess.EF.UserProfile userProfile = new DataAccess.EF.UserProfile();
            //userProfile.DateOfBirth = System.DateTime.Now;
            //userProfile.Email = "ishwar3972@gmail.com";
            //userProfile.Password = "Password@123";
            //userProfile.MobileNumber = 0469096101;
            //userProfile.Name = "Ishwar";
            //userProfile.IsOtpVerified = false;
            //userProfile.Location = "Bathinda";
            //IRestResponse result = CreateExecuteRequest("Party/GetParties", new UserProfile() { Email = "ishwar3972@gmail.com" }, Method.POST);


        }

        public static void SetHttpClient(string Url)
        {
            client = new RestClient(BaseUrl + Url);
        }

        public static IRestResponse CreateExecuteRequest<T>(string Url, T item, RestSharp.Method method)
        {
            SetHttpClient(Url);
            CreateRequest(item, method);
            IRestResponse response = client.Execute(restRequest);
            return response;
        }

        public static void CreateRequest<T>(T item, RestSharp.Method method)
        {
            restRequest = new RestRequest(method);
            restRequest.AddParameter("application/x-www-form-urlencoded", "");
            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {
                restRequest.AddParameter(propertyInfo.Name, propertyInfo.GetValue(item));
            }
        }

    }
}
