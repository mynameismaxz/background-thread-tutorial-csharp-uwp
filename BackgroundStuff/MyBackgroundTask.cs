﻿using Windows.Data.Xml.Dom;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;

namespace BackgroundStuff
{
    public sealed class MyBackgroundTask : IBackgroundTask
    {
        public MyBackgroundTask()
        {
        }

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // simple example with a Toast, to enable this go to manifest file
            // and mark App as TastCapable - it won't work without this
            // The Task will start but there will be no Toast.
            var toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode("My first Task - Yeah"));
            textElements[1].AppendChild(toastXml.CreateTextNode("I'm a message from your background task!"));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
        }
    }
}
