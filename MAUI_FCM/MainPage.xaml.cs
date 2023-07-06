namespace MAUI_FCM;

public partial class MainPage : ContentPage
{
	int count = 0;
    string devicetoken;
    

    public MainPage()
	{
		InitializeComponent();
        if (Preferences.ContainsKey("DeviceToken"))
        {
            devicetoken = Preferences.Get("DeviceToken", "");
        }
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		
	}
}

