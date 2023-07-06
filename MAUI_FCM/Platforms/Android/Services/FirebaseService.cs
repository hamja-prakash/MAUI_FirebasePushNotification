using Android.App;
using Android.Content;
using AndroidX.Core.App;
using Firebase.Messaging;

namespace MAUI_FCM.Platforms.Android.Services
{
    [Service(Exported = true)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService : FirebaseMessagingService
    {
        public FirebaseService()
        {

        }

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            if (Preferences.ContainsKey("DeviceToken"))
            {
                Preferences.Remove("DeviceToken");
            }
            Preferences.Set("DeviceToken", token);
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            var notification = message.GetNotification();
            SendNotification(notification.Body, notification.Title, message.Data);
        }

        public void SendNotification(string messagebody,string title,IDictionary<string,string>data)
        {
            var intent = new Intent(this, typeof(MainActivity)); intent.AddFlags(ActivityFlags.ClearTop);
            foreach (var key in data.Keys)
            {
                intent.PutExtra(key, data[key]);
            }
            var pendingIntent = PendingIntent.GetActivity(this, MainActivity.NOTIFICATION_ID, intent, PendingIntentFlags.OneShot);
            var notificationBuilder = new NotificationCompat.Builder(this, MainActivity.Channel_Id)
                                     .SetSmallIcon(Resource.Mipmap.appicon)
                                     .SetContentTitle(title)
                                     .SetContentText(messagebody)
                                     .SetChannelId(MainActivity.Channel_Id)
                                     .SetPriority(2);
            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(MainActivity.NOTIFICATION_ID, notificationBuilder.Build());
        }
    }
}
