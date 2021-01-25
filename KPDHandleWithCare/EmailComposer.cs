using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.IO;

namespace HandleWithCare
{
    public class EmailComposer
    {

        private string _emailToAddresses;
        private string _messageSubject;
        private string _emailFromAddress;
        private string _smtpServer;
        private int _smtpServerPort;
        private bool _enableSSL;
        private string _smtpUserName;
        private string _smtpPassword;
        private string _logFileLocation;

        public string EmailToAddresses { get => _emailToAddresses; set => _emailToAddresses = value; }
        public string EmailFromAddress { get => _emailFromAddress; set => _emailFromAddress = value; }
        public string SmtpServer { get => _smtpServer; set => _smtpServer = value; }
        public int SmtpServerPort { get => _smtpServerPort; set => _smtpServerPort = value; }
        public bool EnableSSL { get => _enableSSL; set => _enableSSL = value; }
        public string SmtpUserName { get => _smtpUserName; set => _smtpUserName = value; }
        public string SmtpPassword { get => _smtpPassword; set => _smtpPassword = value; }
        public string MessageSubject { get => _messageSubject; set => _messageSubject = value; }
        public string LogFileLocation { get => _logFileLocation; set => _logFileLocation = value; }

        /*
         * The class loads values from the appSettings.config file. To change any of the values in
         * the constructor simply edit the appSettings.config file and restart the application 
         * in the IIS server
         * 
         */
        public EmailComposer()
        {
            NameValueCollection appsetting =  ConfigurationManager.AppSettings;
            EmailToAddresses = appsetting["EmailToAddresses"];
            EmailFromAddress = appsetting["EmailFromAddress"];
            SmtpServer = appsetting["SMTPServer"];
            Boolean.TryParse(appsetting["EnableSSL"], out _enableSSL);
            int.TryParse(appsetting["SMTPServerPort"], out _smtpServerPort);
            SmtpUserName = appsetting["SmtpUserName"];
            SmtpPassword = appsetting["SMTPPassword"];
            MessageSubject = appsetting["MessageSubject"];
            LogFileLocation = appsetting["LogFileLocation"];


        }

        /*
         * Create a mail message body and send it 
         * 
         */
        public bool SendEmail(HttpServerUtility server, string officerEmail, string studentName, string schoolName)
        {
            bool returnValue = true;
            //compose the body of the message to be sent via email
            string emailMessageBody = String.Format("Email from: {0}. Please handle student {1} of {2} with care.", officerEmail, studentName, schoolName);
            StringBuilder logText = new StringBuilder();
            logText.Append(DateTime.Now.ToString());
            try
            {

 
                MailMessage emailMessage = new MailMessage();
                emailMessage.From = new MailAddress(this.EmailFromAddress);
                EmailToAddresses.Split(';');
                foreach (var address in EmailToAddresses.Split(';'))
                {
                    emailMessage.To.Add(new MailAddress(address.Trim(), ""));
                }
                emailMessage.Subject = MessageSubject;
                emailMessage.Body = emailMessageBody;

               

                SmtpClient smtpClient = new SmtpClient(SmtpServer, SmtpServerPort);
                smtpClient.EnableSsl = EnableSSL;

                if (SmtpUserName != null )
                {
                    NetworkCredential networkCredential = new NetworkCredential(SmtpUserName, SmtpPassword);
                    smtpClient.Credentials = networkCredential;
                }
                smtpClient.Send(emailMessage); 
 

                logText.AppendLine(" Email Sent Successfully"); 
            }
            catch (Exception ex)
            {
                logText.AppendLine(ex.Source + " <br\\>");
                logText.AppendLine(ex.Message + "<br\\>");
                logText.AppendLine(ex.StackTrace);
                returnValue = false;
            }

            File.AppendAllText(server.MapPath(LogFileLocation), logText.ToString());
            return returnValue;
            
        }
    }
}