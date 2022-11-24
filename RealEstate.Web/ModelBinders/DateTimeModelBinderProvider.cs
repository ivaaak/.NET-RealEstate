using Microsoft.AspNetCore.Mvc.ModelBinding;
using RealEstate.API.ModelBinders;

namespace RealEstate.API.ModelBinders
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string customDateFormat;

        public DateTimeModelBinderProvider(string _customDateFormat)
        {
            customDateFormat = _customDateFormat;
        }

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(customDateFormat);
            }

            return null;
        }
    }
}
