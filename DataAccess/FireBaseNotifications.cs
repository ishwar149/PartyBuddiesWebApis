using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FireBaseNotifications
    {

        //content title = message to be shown
        //content type=message type eg. new order
        // content=message to be shown
        //objid= 0 
        //tokenortopic = firebase notification token
        //isAndroid=true
        //isTopic= false
        public static void SendPushNotification(string contentTitle, string userEmail, string content, string tokenOrTopic = "", bool isAndroid = true, bool isTopic = false)
        {
            var url = new Uri("https://fcm.googleapis.com/fcm/send");


            string appKey = "AAAA070-OLc:APA91bEorl4wKQPDHYbnvU-ta0kB3OZhLRrrH5Sr-xPCZEeZvjx4xF7_Vo8VlPFm4yFf1cvpYGFCJc2-6zDm-9Od6CcMGsKYioVTr3ElCgOpduUX-Qiy58j-ngUEWYa68uPQ0f4MzNkb";

            var dataObj = new
            {
                Title = contentTitle,
                Content = content,
                UserEmail = userEmail
            };

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + appKey);

                    if (isTopic)
                    {
                        var MainTopicObj = new
                        {
                            data = dataObj,
                            to = $"/topics/{tokenOrTopic}"
                        };
                        string MainTopicObjJson = JsonConvert.SerializeObject(MainTopicObj);
                        Task.WaitAll(client.PostAsync(url,
                             new StringContent(MainTopicObjJson, Encoding.Default, "application/json")));

                    }
                    else
                    {
                        if (isAndroid)
                        {
                            var androidMainObj = new
                            {
                                data = dataObj,
                                to = tokenOrTopic
                            };
                            string androidJson = JsonConvert.SerializeObject(androidMainObj);
                            Task.WaitAll(client.PostAsync(url,
                             new StringContent(androidJson, Encoding.Default, "application/json")));
                        }
                        else
                        {
                            var notificationObj = new
                            {
                                body = content,
                                title = contentTitle,
                                sound = "default",
                                content_available = true,
                            };
                            var iosMainObj = new
                            {
                                data = dataObj,
                                notification = notificationObj,
                                to = tokenOrTopic
                            };
                            string iosJson = JsonConvert.SerializeObject(iosMainObj);
                            Task.WaitAll(client.PostAsync(url,
                                                new StringContent(iosJson, Encoding.Default, "application/json")));
                        }
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to send GCM message:");
                Console.Error.WriteLine(e.StackTrace);
            }

        }
    }
}
