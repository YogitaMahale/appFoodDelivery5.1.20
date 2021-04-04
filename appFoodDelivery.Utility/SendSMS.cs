using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace appFoodDelivery.Utility
{
   public  class SendSMS
    {
        public bool smsSent(string mobileNo, string message)
        {
            #region "sms"
            try
            {
                //                1701160171010483055
                //entity id


                //1707161690831867495
                //templet id




                //http://nimbusit.co.in/api/swsendSingle.asp?username=xxxx&password=xxxx&sender=senderId&sendto=919xxxx&entityID=170134xxxxxxxxx&templateID=158777xxxxxxxxxxx&message=hello

                //                sender id
                //TOFOZF


                //  string template_id = "123";
                //string strUrl = "https://nimbusit.co.in/api/swsend.asp?username="+SD.SMS_user+"&password="+SD.SMS_Password+"&sender="+SD.SMS_OPTINS+"&sendto="+mobileNo+"&message="+message;
                string strUrl = "http://nimbusit.co.in/api/swsendSingle.asp?username=" + SD.SMS_user + "&password=" + SD.SMS_Password + "&sender=" + SD.SMS_OPTINS + "&sendto=" + mobileNo + "&entityID=" + SD.SMS_EntityId + "&templateID=" + SD.SMS_templateId + "&message=" + message + "";

                /*
                string strUrl = "http://nimbusit.co.in/api/swsendSingle.asp?username="+SD.SMS_user+"&password="+SD.SMS_Password+"&sender="+SD.SMS_OPTINS+"&sendto="+mobileNo+"&entityID="+SD.SMS_EntityId+"&templateID="+SD.SMS_templateId+"&message="+message+"";
                */

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = (Stream)response.GetResponseStream();
                StreamReader readStream = new StreamReader(s);
                string dataString = readStream.ReadToEnd();
                s.Close();
                readStream.Close();
                response.Close();
                return true;
            }

            catch
            {
                return false;
            }
            #endregion

        }
        //public bool smsSent(string mobileNo, string message)
        //{
        //    #region "sms"
        //    try
        //    {


        //        string template_id = "123";
        //        string strUrl = "https://bulksms.co/sendmessage.php?&user=" + SD.SMS_user + "&password=" + SD.SMS_Password + "&mobile=" + mobileNo + "&message=" + message  + "&sender=" + SD.SMS_OPTINS + "&type=" + 3 + "&template_id=" + template_id;

        //        ServicePointManager.Expect100Continue = true;
        //        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        //        System.Net.WebRequest request = System.Net.WebRequest.Create(strUrl);
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        Stream s = (Stream)response.GetResponseStream();
        //        StreamReader readStream = new StreamReader(s);
        //        string dataString = readStream.ReadToEnd();
        //        s.Close();
        //        readStream.Close();
        //        response.Close();
        //        return true;
        //    }

        //    catch
        //    {
        //        return false;
        //    }
        //    #endregion

        //}
    }
}
