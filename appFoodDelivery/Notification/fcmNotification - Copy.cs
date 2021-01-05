using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace appFoodDelivery.Notification
{
    public class fcmNotification
    {

        public void customerNotification(string deviceid, string message, string img, string title)
        {

            if (string.IsNullOrEmpty(deviceid))
            {

            }
            else
            {


                try
                {
                    string sResponseFromServer = string.Empty, finalResult = string.Empty;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    //serverKey - Key from Firebase cloud messaging server   customer
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                    //store
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));

                    //tRequest.Headers.Add(string.Format("Sender: id={0}", "844325225983"));

                    tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA4lmKnwA:APA91bHnS9ND3VSqid8vKdUTQukqJrBJytbmQKZJADNrEbxs9ZDNxoI_Cq0rhuvqkw9954fvUSuC9McpOfTAc7K3OgTvovghBkazWnIgQ0qn0TPjz1nTCZAgbrbNCYWLRei-5vzlBlYj"));

                    tRequest.Headers.Add(string.Format("Sender: id={0}", "972164865792"));
                    tRequest.ContentType = "application/json";
                    var payload = new
                    {
                        to = deviceid,
                        priority = "high",
                        content_available = true,
                        notification = new
                        {
                            body = message,
                            title = title,
                            badge = 1
                        },
                        data = new
                        {
                            key1 = "value1",
                            key2 = "value2"
                        }

                    };

                    //string postbody = JsonConvert.SerializeObject(payload).ToString();

                    var serializer = new JavaScriptSerializer();
                    var postbody = serializer.Serialize(payload);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        sResponseFromServer = tReader.ReadToEnd();
                                        //result.Response = sResponseFromServer;
                                    }
                            }
                        }
                    }

                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public void deliveryboyNotification(string deviceid, string message, string img, string title)
        {

            //if (deviceid.Trim() == "" ||deviceid==null )
            if (string.IsNullOrEmpty(deviceid))
            {

            }
            else
            {

                try
                {


                    string sResponseFromServer = string.Empty, finalResult = string.Empty;
                    WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                    tRequest.Method = "post";
                    //serverKey - Key from Firebase cloud messaging server   customer
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                    //store
                    //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAHKQA0Wk:APA91bHedRwkl8yVXSbwWC9dQY76Iw-pbxPofgap1wkZX4kAvMvGK826iFlaP6M-27qB9P3UKgwZ1we-B19YmJmbhZCnqULRVGLxfjOumkSo9R-OiQVh5eEN3qc1zo2WRxbFByvdDYO8"));

                    //tRequest.Headers.Add(string.Format("Sender: id={0}", "123010601321"));


                    tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAjemHMvA:APA91bEKvE_gDgBpfVdoSmdO8AMQfVDrMHwc6PZTOPtVvMro-HmC17KGcJQZ9D95mU9PB_8JFX3pQcOPOvV5Svrq8GCRnSYkbUj2YgXPeR-4t39hucLG709g-fvX8bNhYf2e6dBG5jH7"));

                    tRequest.Headers.Add(string.Format("Sender: id={0}", "609508340464"));


                    tRequest.ContentType = "application/json";
                    var payload = new
                    {
                        to = deviceid,
                        priority = "high",
                        content_available = true,
                        notification = new
                        {
                            body = message,
                            title = title,
                            badge = 1
                        },
                        data = new
                        {
                            key1 = "value1",
                            key2 = "value2"
                        }

                    };

                    //string postbody = JsonConvert.SerializeObject(payload).ToString();

                    var serializer = new JavaScriptSerializer();
                    var postbody = serializer.Serialize(payload);
                    Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                    tRequest.ContentLength = byteArray.Length;
                    using (Stream dataStream = tRequest.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse tResponse = tRequest.GetResponse())
                        {
                            using (Stream dataStreamResponse = tResponse.GetResponseStream())
                            {
                                if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                    {
                                        sResponseFromServer = tReader.ReadToEnd();
                                        //result.Response = sResponseFromServer;
                                    }
                            }
                        }
                    }

                }
                catch(Exception p)
                {
                    string dd = p.Message;

                }




            }

        }
        public void storeNotification(string deviceid, string message, string img, string title)
        {

            if (string.IsNullOrEmpty(deviceid))
            {

            }
            else
            {
                string sResponseFromServer = string.Empty, finalResult = string.Empty;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                //serverKey - Key from Firebase cloud messaging server   customer
                //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAxJW0hf8:APA91bG1ipIsec--9KYV5bv6kagmly4PfFHH-UCLsbsqVxuZsoBPvw-AuRy_DhBa0sT2raF5D0DJhbx8G59lKV2fg6WbUDMzvWsyqxlQLjz-Epk3p04lujWk1c-enH5o3CLq_ejPVqr4"));
                //store
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAA-grvO4U:APA91bG1TeBl5uVNLOHGyjSYSJ_-PZiOFKeSUkjhx4do27iECafs1dVdAyhE6-QvMDON6xrz-YOa10tMgFdmy_w1amPXVHsXLWrAggDh8oU0c1F8CvdBW6aGc1wrqP8OlQ86ZzxzkTuS"));

                tRequest.Headers.Add(string.Format("Sender: id={0}", "1073925274501"));

                //tRequest.Headers.Add(string.Format("Authorization: key={0}", "AAAAr0cwgUE:APA91bEs5PB48LpheJuGQOJi8jENylDdtBgGA5tcHFY2Kbz4-FwNLocAN8z7X7c4ADuP6vA7MSE3M6hx5OHp12iFt0yb7zfHO16c7mlgnppsEOFY8J4WRfpOUI-RkbXBLBwMqYwwDyYX"));

                //tRequest.Headers.Add(string.Format("Sender: id={0}", "752813637953"));
                tRequest.ContentType = "application/json";
                var payload = new
                {
                    to = deviceid,
                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = message,
                        title = title,
                        badge = 1
                    },
                    data = new
                    {
                        key1 = "value1",
                        key2 = "value2"
                    }

                };

                //string postbody = JsonConvert.SerializeObject(payload).ToString();

                var serializer = new JavaScriptSerializer();
                var postbody = serializer.Serialize(payload);
                Byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    sResponseFromServer = tReader.ReadToEnd();
                                    //result.Response = sResponseFromServer;
                                }
                        }
                    }
                }
            }

        }

    }
}
