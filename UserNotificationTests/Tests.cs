using System;
using NUnit.Framework;
using UserNotifications.alerts;

namespace UserNotificationTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void CanCreateAlertInstanceAndDefaultsAreProperlySet()
        {
            var alert = new Alert()
                {
                 AlertType =  AlertType.msgError, 
                 Message = "Error Message"
                };

            Assert.IsNotNull(alert);
            Assert.IsFalse(alert.EnabledClickToClose);
            Assert.AreEqual(4000, alert.FadeOut);
        }

        [Test]
        public void CanRenderHTML()
        {
            var alerts = new Alerts();
            alerts.AlertCollection.Add
                (
                new Alert() 
                { 
                 AlertType = AlertType.msgError, 
                 Message = "Error Message",
                 FadeOut = 5000
                }

                );

            var html = alerts.RenderHTML();
        
        }



    }
}
