using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace UserNotifications.alerts
{
    //These AlertTypes correspond to the css class names. 
    public enum AlertType
    {
        msgInfo,
        msgWarn,
        msgError,
        msgOK
    }


    public class Alerts
    {

        private string _css = @"../../alerts/css/alerts.css";

        public Alerts()
        { }
        
        public Alerts(AlertMetaData data)
        {
            GetAlerts(data);
        }
        
        private IList<Alert> _alertcollection = new List<Alert>();

        public Alerts(IList<Alert> alerts) 
        {
            _alertcollection = alerts;
        }

        public IList<Alert> AlertCollection 
        { 
            get { 
                return _alertcollection; 
            } 
        }

        public string RenderHTML()
        {
            
            if (_alertcollection.Count == 0)
                return "";

            var html = new StringBuilder();

            html.AppendLine(string.Format(@"<link href=""{0}"" rel=""stylesheet"" type=""text/css""/>",_css));
            
            html.AppendLine(@"<div class=""messages"">");
            
            html.AppendLine(@"<script type=""text/javascript"">");
            html.AppendLine(@"$(document).ready(function () {");
            foreach (var alert in _alertcollection)
            {
                if (alert.FadeOut > 0)
                    html.AppendLine(string.Format(@"$("".{0}"").fadeOut({1});", alert.AlertType, alert.FadeOut));

                if (alert.EnabledClickToClose)
                {
                    html.AppendLine(string.Format(@"$("".{0}"").click(function(){1}$(this).hide();{2});", alert.AlertType, "{", "}"));
                    html.AppendLine(string.Format(@"$("".{0}"").css(""cursor"",""hand"");", alert.AlertType));

                    //Could also specify a different background graphic.

                }
            }
            html.AppendLine(@"});");
            html.AppendLine(@"</script>");

            foreach (var alert in _alertcollection)
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

        public string css { get { return _css; } set { _css = value; } }
        
        private void GetAlerts(AlertMetaData alertMetaData)
        {

            _alertcollection.Add(
                new Alert()
                {
                    AlertType = AlertType.msgError,
                    Message = alertMetaData.ErrorMessage,
                    EnabledClickToClose = alertMetaData.ErrorClickToClose,
                    FadeOut = alertMetaData.ErrorFadeOut
                }
            );

            _alertcollection.Add(
                new Alert()
                {
                    AlertType = AlertType.msgInfo,
                    Message = alertMetaData.InfoMessage,
                    EnabledClickToClose = alertMetaData.InfoClickToClose,
                    FadeOut = alertMetaData.InfoFadeOut
                }
            );

            _alertcollection.Add(
                new Alert()
                {
                    AlertType = AlertType.msgOK,
                    Message = alertMetaData.OKMessage,
                    EnabledClickToClose = alertMetaData.OKClickToClose,
                    FadeOut = alertMetaData.OKFadeOut
                }
            );

            _alertcollection.Add(
    new Alert()
    {
        AlertType = AlertType.msgWarn,
        Message = alertMetaData.WarningMessage,
        EnabledClickToClose = alertMetaData.WarningClickToClose,
        FadeOut = alertMetaData.WarningFadeOut
    }
);
            
        }
    }


    public class Alert
    {
        private  AlertType _alerttype = AlertType.msgOK;
        private bool _enableclicktoclose = false;
        private int _fadeout = 4000;

        public int FadeOut
        {
            get
            {
                return _fadeout;
            }
            set
            {
                _fadeout = value;
            }
        }

        public bool EnabledClickToClose 
        { 
            get 
            { 
                return _enableclicktoclose; 
            } 
            set 
            {
                _enableclicktoclose = value;
            } 
        }

        public AlertType AlertType
        {
            get
            {
                return _alerttype;
            }

            set 
            {
                _alerttype = value;
            }

        }

        public string Message
        {
            get;
            set;
        }
    }
}