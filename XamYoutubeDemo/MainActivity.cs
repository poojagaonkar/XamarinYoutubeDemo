using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Google.Android.Youtube.Player;



namespace XamYoutubeDemo
{
    [Activity(Label = "XamYoutubeDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : YouTubeBaseActivity, IYouTubePlayerOnInitializedListener
    {
        private int RECOVERY_DIALOG_REQUEST = 1;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            YouTubePlayerView youTubeView = FindViewById<YouTubePlayerView>(Resource.Id.youtube_view);
            youTubeView.Initialize(DevConstants.DEVELOPER_KEY, this);
            

        }

        public void OnInitializationFailure(IYouTubePlayerProvider provider, YouTubeInitializationResult errorReason)
        {
          if (errorReason.IsUserRecoverableError) {
            errorReason.GetErrorDialog(this, RECOVERY_DIALOG_REQUEST).Show();
        } else {
            String errorMessage = String.Format(
                    GetString(Resource.String.ErrorMessage), errorReason.ToString());
            Toast.MakeText(this, errorMessage, ToastLength.Long).Show();
        }
        }

        public void OnInitializationSuccess(IYouTubePlayerProvider p0, IYouTubePlayer yPlayer, bool p2)
        {
            yPlayer.LoadVideo("ofJF-cudan4");
        }
    }
}

