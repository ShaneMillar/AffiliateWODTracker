namespace AffiliateWODTracker.Mobile.Services
{
    public class AppStateService
    {
        // Singleton instance
        private static AppStateService _instance;

        // Property to check if the HomePage has been loaded
        public bool IsFirstLoad { get; set; } = false;

        // Private constructor to prevent external instantiation
        private AppStateService() { }

        // Public method to get the singleton instance
        public static AppStateService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppStateService();
                }
                return _instance;
            }
        }
    }
}

