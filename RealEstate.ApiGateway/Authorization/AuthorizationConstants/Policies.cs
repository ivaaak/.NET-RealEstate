namespace RealEstate.ApiGateway.Authorization.AuthorizationConstants
{
    public static class Policies
    {
        public const string RequireAspNetCoreRole = nameof(RequireAspNetCoreRole);

        public const string RequireRealmRole = nameof(RequireRealmRole);

        public const string RequireClientRole = nameof(RequireClientRole);

        public const string RequireToBeInKeycloakGroupAsReader = nameof(RequireToBeInKeycloakGroupAsReader);
    }
}
