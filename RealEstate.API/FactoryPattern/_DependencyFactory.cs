using RealEstate.API.Authentication.Contracts;
using RealEstate.Core.Guards;

namespace RealEstate.API.FactoryPattern
{
    internal sealed class _DependencyFactory : IDependencyFactory
    {
        private Dictionary<Type, object> dependencyMap;

        public _DependencyFactory(
             IUserService userService,
            IAuth0Service auth0AuthenticationService)
            //IAccountClient accountClient,
            //ICacheService cacheService,
            //IEmailService emailService,
            //IEstateService estateService,
            //IFileUploadService fileUploadService,
            //IListingService listingService,
            //IJsonSerializer jsonSerializer,
            //ISortingService sortingService)
        {
            Validate.NotNull(auth0AuthenticationService, nameof(auth0AuthenticationService));
            Validate.NotNull(userService, nameof(userService));
            //Validate.NotNull(accountClient, nameof(accountClient));
            //Validate.NotNull(cacheService, nameof(cacheService));
            //Validate.NotNull(emailService, nameof(emailService));
            //Validate.NotNull(estateService, nameof(estateService));
            //Validate.NotNull(fileUploadService, nameof(fileUploadService));
            //Validate.NotNull(listingService, nameof(listingService));
            //Validate.NotNull(jsonSerializer, nameof(jsonSerializer));
            //Validate.NotNull(sortingService, nameof(sortingService));

            dependencyMap = new Dictionary<Type, object>();

            dependencyMap[typeof(IAuth0Service)] = auth0AuthenticationService;
            dependencyMap[typeof(IUserService)] = userService;
            //dependencyMap[typeof(IAccountClient)] = accountClient;
            //dependencyMap[typeof(ICacheService)] = cacheService;
            //dependencyMap[typeof(IEmailService)] = emailService;
            //dependencyMap[typeof(IEstateService)] = estateService;
            //dependencyMap[typeof(IFileUploadService)] = fileUploadService;
            //dependencyMap[typeof(IListingService)] = listingService;
            //dependencyMap[typeof(IJsonSerializer)] = jsonSerializer;
            //dependencyMap[typeof(ISortingService)] = sortingService;
        }

        public T Get<T>()
        {
            Validate.ContainsKey(dependencyMap, typeof(T), nameof(dependencyMap), typeof(T).FullName);

            return (T)dependencyMap[typeof(T)];
        }
    }

    public interface IDependencyFactory
    {
        T Get<T>();
    }
}
