namespace AffiliateWODTracker.Core.Common
{
    public static class APIEndpoints
    {
        public static class AccountController
        {
            public const string Login = "/Account/Login";
            public const string Register = "/Account/Register";
            public const string Logout = "/Account/Logout";

        }
        public static class AffiliateController
        {
            public const string GetAffiliates = "/Affiliate/GetAffiliates";
        }

        public static class MembersController
        {
            public const string GetCurrentMemberApiEndpoint = "/Member/GetCurrentMember";
        }
        public static class WODsController
        {
            public const string PostWorkoutApiEndpoint = "/Workout/PostWorkout";
        }
    }
}
