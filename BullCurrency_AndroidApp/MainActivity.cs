using Android.App;
using Android.OS;
using Android.Util;

namespace BullCurrency_AndroidApp
{
    [Activity(Label = "BullCurrency_AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private static readonly string Tag = "ActionBarTabsSupport";

        private Fragment[] _fragments;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Main);

            _fragments = new Fragment[]
            {
                new WhatsOnFragment(),
                new SpeakersFragments(), 
                new SessionsFragment()
            };

            AddTabToActionBar(Resource.String.whatson_tab_label, Resource.Drawable.ic_action_whats_on);
            AddTabToActionBar(Resource.String.speakers_tab_label, Resource.Drawable.ic_action_speakers);
            AddTabToActionBar(Resource.String.sessions_tab_label, Resource.Drawable.ic_action_sessions);

        }

        void AddTabToActionBar(int lableResourceId, int iconResourceId)
        {
            ActionBar.Tab tab = ActionBar.NewTab()
                .SetText(lableResourceId)
                .SetIcon(iconResourceId);

            tab.TabSelected += TabOnTabSelected;
            ActionBar.AddTab(tab);
        }

        void TabOnTabSelected(object sender, ActionBar.TabEventArgs tabEventArgs)
        {
            ActionBar.Tab tab = (ActionBar.Tab) sender;

            Log.Debug(Tag, "The tab {0} has been selected.", tab.Text);
            Fragment frag = _fragments[tab.Position];
            tabEventArgs.FragmentTransaction.Replace(Resource.Id.frameLayout1, frag);
        }

    }
}

