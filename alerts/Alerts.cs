using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace UserNotifications.alerts
{
    //These AlertTypes correspond to the css class names. 
    public enum AlertType
    {
        MsgInfo,
        MsgWarn,
        MsgError,
        MsgOK
    }

    public class Alerts
    {
        public Alerts(AlertMetaData data) 
        {
            GetAlerts(data);
        }
        
        public Alerts(IList<Alert> alerts) 
        {
            AlertCollection = alerts;
        }

        public IList<Alert> AlertCollection{get;set;}

        public string RenderHTML()
        {
            
            if (AlertCollection.Count == 0)
                return "";

            var html = new StringBuilder();



            //css = @"../../alerts/css/alerts.css";


            if (!String.IsNullOrEmpty(css))
            {
                html.AppendLine(string.Format(@"<link href=""{0}"" rel=""stylesheet"" type=""text/css""/>", @css));
            }
                
            html.AppendLine(@"<div class=""messages"">");
            
            html.AppendLine(@"<script type=""text/javascript"">");
            html.AppendLine(@"$(document).ready(function () {");
            foreach (var alert in AlertCollection)
            {
                if (alert.FadeOut > 0)
                    html.AppendLine(string.Format(@"$("".{0}"").fadeOut({1});", alert.AlertType, alert.FadeOut));

                if (alert.EnabledClickToClose)
                {
                    html.AppendLine(string.Format(@"$("".{0}"").click(function(){1}$(this).hide();{2});", alert.AlertType, "{", "}"));
                    html.AppendLine(string.Format(@"$("".{0}"").css(""cursor"",""hand"");", alert.AlertType));
                }
            }
            html.AppendLine(@"});");
            html.AppendLine(@"</script>");

            foreach (var alert in AlertCollection)
            {
                html.AppendLine(string.Format(@"<div class=""{0}""",alert.AlertType));

                if (alert.EnabledClickToClose)
                    html.Append(@" title = ""Click to close""");
                    
                
                html.Append(@">");

                html.AppendLine(alert.Message);
                html.AppendLine(@"</div>");
            }
            html.AppendLine(@"</div>");

            return html.ToString();
        }

        public string css { get; set; }
        
        private void GetAlerts(AlertMetaData alertMetaData)
        {

            if (AlertCollection == null)
                AlertCollection = new List<Alert>();

            if (alertMetaData.CssFile != null)
                css = @alertMetaData.CssFile;
            
            AlertCollection.Add(
                new Alert()
                {
                    AlertType = AlertType.MsgError,
                    Message = alertMetaData.ErrorMessage,
                    EnabledClickToClose = alertMetaData.ErrorClickToClose,
                    FadeOut = alertMetaData.ErrorFadeOut
                }
            );

            AlertCollection.Add(
                new Alert()
                {
                    AlertType = AlertType.MsgInfo,
                    Message = alertMetaData.InfoMessage,
                    EnabledClickToClose = alertMetaData.InfoClickToClose,
                    FadeOut = alertMetaData.InfoFadeOut
                }
            );

            AlertCollection.Add(
                new Alert()
                {
                    AlertType = AlertType.MsgOK,
                    Message = alertMetaData.OKMessage,
                    EnabledClickToClose = alertMetaData.OKClickToClose,
                    FadeOut = alertMetaData.OKFadeOut
                }
            );

            AlertCollection.Add(
    new Alert()
    {
        AlertType = AlertType.MsgWarn,
        Message = alertMetaData.WarningMessage,
        EnabledClickToClose = alertMetaData.WarningClickToClose,
        FadeOut = alertMetaData.WarningFadeOut
    }
);
        }
    }

    public class Alert
    {

        public Alert()
        {
            FadeOut = 4000;
            EnabledClickToClose = false;
        }
        
        public int FadeOut
        {
            get;
            set;
        }

        public bool EnabledClickToClose
        {
            get;
            set;
        }

        public AlertType AlertType
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}