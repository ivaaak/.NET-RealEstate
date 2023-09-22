#nullable disable
using ListingsMicroservice;
using System.Linq.Expressions;

namespace ListingsMicroservice.Services._Sorting
{
    public class GenericSortingService<T>
    {
        /// <summary>
        /// Sorts a list of elements in ascending order based on a property.
        /// </summary>
        /// <param name="values">The list of elements to sort.</param>
        /// <param name="propertySelector">A lambda expression representing the property to sort by.</param>
        /// <returns>The sorted list of elements.</returns>
        public IEnumerable<T> SortAscending(IEnumerable<T> values, Expression<Func<T, object>> propertySelector)
        {
            return values.OrderBy(propertySelector.Compile());
        }

        /// <summary>
        /// Sorts a list of elements in descending order based on a property.
        /// </summary>
        /// <param name="values">The list of elements to sort.</param>
        /// <param name="propertySelector">A lambda expression representing the property to sort by.</param>
        /// <returns>The sorted list of elements.</returns>
        public IEnumerable<T> SortDescending(IEnumerable<T> values, Expression<Func<T, object>> propertySelector)
        {
            return values.OrderByDescending(propertySelector.Compile());
        }



        /// <summary>
        /// Sorts a list of elements in ascending order based on multiple properties.
        /// </summary>
        /// <param name="values">The list of elements to sort.</param>
        /// <param name="propertySelectors">A list of lambda expressions representing the properties to sort by.</param>
        /// <returns>The sorted list of elements.</returns>
        public IEnumerable<T> SortAscendingByParams(IEnumerable<T> values, params Expression<Func<T, object>>[] propertySelectors)
        {
            IOrderedEnumerable<T> sortedValues = null;
            foreach (var propertySelector in propertySelectors)
            {
                if (sortedValues == null)
                {
                    sortedValues = values.OrderBy(propertySelector.Compile());
                }
                else
                {
                    sortedValues = sortedValues.ThenBy(propertySelector.Compile());
                }
            }
            return sortedValues;
        }

        /// <summary>
        /// Sorts a list of elements in descending order based on multiple properties.
        /// </summary>
        /// <param name="values">The list of elements to sort.</param>
        /// <param name="propertySelectors">A list of lambda expressions representing the properties to sort by.</param>
        /// <returns>The sorted list of elements.</returns>
        public IEnumerable<T> SortDescendingByParams(IEnumerable<T> values, params Expression<Func<T, object>>[] propertySelectors)
        {
            IOrderedEnumerable<T> sortedValues = null;
            foreach (var propertySelector in propertySelectors)
            {
                if (sortedValues == null)
                {
                    sortedValues = values.OrderByDescending(propertySelector.Compile());
                }
                else
                {
                    sortedValues = sortedValues.ThenByDescending(propertySelector.Compile());
                }
            }
            return sortedValues;
        }

        /*
        public List<Estate> SortByGenericProp(List<Estate> estates, string objectPropertyName)
        {
            var test = estates.FirstOrDefault();
            var property = test.GetType().GetProperty(objectPropertyName);
            if (property != null)
            // if the Estate has objectPropertyName as a property
            {
                var sortedEstates = estates
                                .OrderBy(e => e.property)
                                .ToList();

                return sortedEstates;
            }
        }*/
    }
}
