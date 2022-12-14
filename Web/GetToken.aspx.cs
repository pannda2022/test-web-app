using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class GetToken : System.Web.UI.Page
    {
        class AzureDetails
        {
            public static string ClientID = "ec5edc22-a13c-4c97-b9f6-1166433a07f6";
            public static string ClientSecret = "Uup8Q~NTNpgQnHTXESy.Fse1py~QazTcQgP47dqo";
            public static string TenantID = "5ff58811-7dab-47de-a371-912a7558b6ad";

            public static string SubscriptionId = "c12860ff-10b5-429f-9226-d19668a0417a";
            public static string ResourceGroupName = "test-resource";
            public static string AppName = "test-web-app-cxw";
            public static string AccessToken { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetAccessToken();

            Response.Write(AzureDetails.AccessToken);
            Response.Write("<br />");

            //HttpWebRequest hwr = WebRequest.CreateHttp("https://management.azure.com/subscriptions/" + AzureDetails.SubscriptionId + "/resourceGroups/"+AzureDetails.ResourceGroupName + "/providers/Microsoft.Web/sites/"+AzureDetails.AppName + "/restart?api-version=2022-03-01");
            //hwr.Method = "POST";
            //hwr.Headers.Add("Authorization", "Bearer " + AzureDetails.AccessToken);
            //hwr.ContentType = "application/json";
            //hwr.ContentLength = 0;
            //using (WebResponse wr = hwr.GetResponse())
            //{
            //    using (StreamReader sr = new StreamReader(wr.GetResponseStream()))
            //    {
            //        Response.Write(sr.ReadToEnd());
            //    }
            //}
        }
        private void GetAccessToken()
        {
            ClientCredential cc = new ClientCredential(AzureDetails.ClientID, AzureDetails.ClientSecret);
            var context = new AuthenticationContext("https://login.microsoftonline.com/" + AzureDetails.TenantID);
            var result = context.AcquireTokenAsync("https://management.azure.com/", cc);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the Access token");
            }
            AzureDetails.AccessToken = result.Result.AccessToken;
        }
    }
}