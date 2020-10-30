using Xamarin.Forms;

namespace AprajitaRetailsNext.Mobile.Tizen
{
    class Program : Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate ();
            // Call 'LoadApplication(Application application)' here to load your application.
            LoadApplication (new Shared.App ());
        }

        static void Main(string [] args)
        {
            var app = new Program ();
            Forms.Init (app);
            app.Run (args);
        }
    }
}