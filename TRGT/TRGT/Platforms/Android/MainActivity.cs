using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using Environment = Android.OS.Environment;

namespace TRGT;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
public class MainActivity : MauiAppCompatActivity
{
	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		Platform.Init(this, savedInstanceState);

		if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
		{
			var canRead = CheckPermissionGranted(Manifest.Permission.ReadExternalStorage);
			var canWrite = CheckPermissionGranted(Manifest.Permission.WriteExternalStorage);
			if (!canRead && !canWrite)
			{
				RequestPermission();
			}
		}
	}

	public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
	{
		Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
	}

	private void RequestPermission()
	{
		ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);

		if (Build.VERSION.SdkInt >= BuildVersionCodes.R && !Environment.IsExternalStorageManager)
		{
			StartActivityForResult(new Intent(Android.Provider.Settings.ActionManageAllFilesAccessPermission), 3);
		}
	}

	public bool CheckPermissionGranted(string Permissions)
	{
		return AndroidX.Core.Content.ContextCompat.CheckSelfPermission(this, Permissions) == Permission.Granted;
	}
}
