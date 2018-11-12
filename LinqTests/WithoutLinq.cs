using System;
using System.Collections.Generic;
using System.Linq;
using LinqTests;

namespace LinqSample.WithoutLinq
{
    internal static class WithoutLinq
    {
        public static IEnumerable<Product> find(List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.Price > 200 && product.Price < 500)
                {
                    yield return product;
                }
            }            
        }

        public static IEnumerable<Product> Find(IEnumerable<Product> products, Func<Product, bool> func)
        {
            foreach (var product in products)
            {
                if (func(product))
                {
                    yield return product;
                }
            }
                
        }

        public static IEnumerable<T> Find<T>(this IEnumerable<T> resource, Func<T, int, bool> func)
        {
            var index = 0;

            foreach (var r in resource)
            {
                if (func(r,index))
                {
                    yield return r;
                }

                index++;
            }
        }
    }
}