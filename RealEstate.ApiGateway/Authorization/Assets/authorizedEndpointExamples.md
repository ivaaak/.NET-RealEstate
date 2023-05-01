// login with required aspnet core identity role
app.MapGet("/endpoint1", (ClaimsPrincipal user) => user)
    .RequireAuthorization(RequireAspNetCoreRole);

// login with requireed realm role evaluated from corresponding claim
app.MapGet("/endpoint2", (ClaimsPrincipal user) => user)
    .RequireAuthorization(RequireRealmRole);

// login with requireed client role evaluated from corresponding claim
app.MapGet("/endpoint3", (ClaimsPrincipal user) => user)
    .RequireAuthorization(RequireClientRole);

// login based on remotely executed policy
// authorization is performed by Keycloak (Authorization Server)
app.MapGet("/endpoint4", (ClaimsPrincipal user) => user)
    .RequireAuthorization(RequireToBeInKeycloakGroupAsReader);