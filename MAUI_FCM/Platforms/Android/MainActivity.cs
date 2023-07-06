using Android.App;
using Android.Content.PM;
using Android.Media;
using Android.OS;

namespace MAUI_FCM;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    internal static readonly string Channel_Id = "TestChannel";
    internal static readonly int NOTIFICATION_ID = 105;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        CreateNotificationChannel();
    }

    public void CreateNotificationChannel()
    {
        if (Build.VERSION.SdkInt < BuildVersionCodes.O)
        {
            return;
        }

        var channel = new NotificationChannel(Channel_Id, "FCM Notifications", NotificationImportance.Default)
        {
            Description = "Firebase Cloud Messages appear in this channel"
        };

        var notificationManager = (NotificationManager)GetSystemService(NotificationService);
        notificationManager.CreateNotificationChannel(channel);

        //var channel = new NotificationChannel(Channel_Id, "Test Notification Channel", NotificationImportance.Default);
        //var notificationManager = (NotificationManager)GetSystemService(Android.Content.Context.NotificationService);
        //notificationManager.CreateNotificationChannel(channel);
    }
}
