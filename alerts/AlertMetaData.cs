using System;


namespace UserNotifications.alerts
{
    public class AlertMetaData
    {

        public string CssFile { get; set; }
        
        public string ErrorMessage { get; set; }
        public string WarningMessage { get; set; }
        public string InfoMessage { get; set; }
        public string OKMessage { get; set; }

        public int ErrorFadeOut { get; set; }
        public int WarningFadeOut { get; set; }
        public int InfoFadeOut { get; set; }
        public int OKFadeOut { get; set; }

        public bool ErrorClickToClose { get; set; }
        public bool WarningClickToClose { get; set; }
        public bool InfoClickToClose { get; set; }
        public bool OKClickToClose { get; set; }
    
    }
}