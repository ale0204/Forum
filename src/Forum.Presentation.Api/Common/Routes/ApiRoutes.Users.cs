namespace Forum.Presentation.Api.Common.Routes;

public static partial class ApiRoutes
{
    public static class Users
    {
        public const string ADD_USER = "/users";
        public const string GET_USER = "/users/{id}";
        public const string GET_USER_BY_USERNAME = "/users/{username}";
        public const string GET_USERS = "/users";
        public const string DELETE_USER = "/users/{id}";
        public const string UPDATE_USER = "/users/{id}";
    }
}
