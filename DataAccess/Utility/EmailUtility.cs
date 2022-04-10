using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Utility
{
    public class EmailUtility
    {
        public static bool SendEmail(string Email, string Body, string Subject)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtpclient = new SmtpClient();
                message.From = new MailAddress("partybuddies.in@gmail.com");
                message.To.Add(new MailAddress(Email));
                message.Subject = Subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = Body;
                smtpclient.Port = 587;
                smtpclient.Host = "smtp.gmail.com"; //for gmail host  
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new NetworkCredential("partybuddies.in@gmail.com", "Ishwar@123");
                smtpclient.EnableSsl = true;
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return false;
            }
        }
        public static bool SendOtpEmail(string Otp, string Email)
        {
            string Subject = "Verify your email to complete account creation on Party buddies.";
            string Body = $"Hi New User Please Enter {Otp} as otp to verify your email.";
            return SendEmail(Email, Body, Subject);
        }

    }
}
