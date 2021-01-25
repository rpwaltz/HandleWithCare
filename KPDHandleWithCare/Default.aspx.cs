using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandleWithCare
{

    public partial class _Default : Page
    {

        protected void Submit_Click(object sender, EventArgs e)
        {
            
             EmailComposer emailComposer = new EmailComposer();
            //Grab the text as entered on the default web form
            String officerEmailText = OfficerEmailTextBox.Text;
            String studentNameText = StudentNameTextBox.Text;
            String schoolNameText = SchoolNameTextBox.Text;
            HttpServerUtility httpServerUtility = Page.Server;

            string alertMessage;
            bool sendEmail = emailComposer.SendEmail(httpServerUtility, officerEmailText, studentNameText, schoolNameText);
            if (sendEmail)
            {
                alertMessage = String.Format("Email Sent by {0}", officerEmailText);
            } else
            {
                alertMessage = "Error: Email not sent. Contact Helpdesk";
            }
            Type cstype = this.Page.GetType();
            string alertUniqueIdentifier = Guid.NewGuid().ToString();

            // This javascript method is on the Default.aspx webform
            string alertMessageMethod = String.Format("AlertMessage('{0}')", alertMessage);

            // This code will execute the AlertMessage javascript on the default aspx page
            ScriptManager.RegisterStartupScript(this.Page, cstype, alertUniqueIdentifier, alertMessageMethod, true);
            //            ShowMessageBox ( this.Page, responseText);
            Response.Write("");

        }

    }
}