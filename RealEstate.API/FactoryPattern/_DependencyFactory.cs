using Algolia.Search.Clients;
using RealEstate.API.Authentication;
using RealEstate.Core.Guards;
using RealEstate.Microservices.Cache;
using RealEstate.Microservices.Email;
using RealEstate.Microservices.Estates;
using RealEstate.Microservices.FileUpload;
using RealEstate.Microservices.Listings;
using RealEstate.Microservices.Serializer;
using RealEstate.Microservices.Sorting;

namespace RealEstate.API.FactoryPattern
{
    internal sealed class _DependencyFactory : IDependencyFactory
    {
        private Dictionary<Type, object> dependencyMap;

        public _DependencyFactory(
            IAccountClient accountClient,
            IAuth0AuthenticationService auth0AuthenticationService,
            ICacheService cacheService,
            IEmailService emailService,
            IEstateService estateService,
            IFileUploadService fileUploadService,
            IListingService listingService,
            IJsonSerializer jsonSerializer,
            ISortingService sortingService,
            IUserService userService)
        {
            Validate.NotNull(accountClient, nameof(accountClient));
            Validate.NotNull(auth0AuthenticationService, nameof(auth0AuthenticationService));
            Validate.NotNull(cacheService, nameof(cacheService));
            Validate.NotNull(emailService, nameof(emailService));
            Validate.NotNull(estateService, nameof(estateService));
            Validate.NotNull(fileUploadService, nameof(fileUploadService));
            Validate.NotNull(listingService, nameof(listingService));
            Validate.NotNull(jsonSerializer, nameof(jsonSerializer));
            Validate.NotNull(sortingService, nameof(sortingService));
            Validate.NotNull(userService, nameof(userService));

            dependencyMap = new Dictionary<Type, object>();

            dependencyMap[typeof(IAccountClient)] = accountClient;
            dependencyMap[typeof(IAuth0AuthenticationService)] = auth0AuthenticationService;
            dependencyMap[typeof(ICacheService)] = cacheService;
            dependencyMap[typeof(IEmailService)] = emailService;
            dependencyMap[typeof(IEstateService)] = estateService;
            dependencyMap[typeof(IFileUploadService)] = fileUploadService;
            dependencyMap[typeof(IListingService)] = listingService;
            dependencyMap[typeof(IJsonSerializer)] = jsonSerializer;
            dependencyMap[typeof(ISortingService)] = sortingService;
            dependencyMap[typeof(IUserService)] = userService;
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
