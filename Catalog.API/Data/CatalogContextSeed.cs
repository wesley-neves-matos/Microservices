using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertMany(GetMyProducts());
            }
        }

        private static IEnumerable<Product> GetMyProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "IPhone X",
                    Descriprion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi viverra magna erat, sed lobortis risus efficitur ut. Praesent tempus ex non ligula lacinia, vulputate eleifend dui gravida. Praesent ut ipsum eget ex scelerisque laoreet. Vestibulum sit amet mattis libero, nec placerat felis. Nulla porta velit sit amet lacus lacinia porttitor eget quis tortor. Suspendisse potenti. Aenean facilisis risus sem, at dapibus arcu elementum a. Curabitur blandit, magna vitae interdum scelerisque, arcu ante fermentum nulla, in tristique ipsum leo quis erat. Mauris ultricies convallis eros, ac mollis justo vehicula vitae. Nam lacus lacus, congue in accumsan eu, consequat sit amet tortor. Ut feugiat vitae ligula quis vestibulum. Duis ut lacus tempus, scelerisque nulla ac, porttitor ipsum. In pretium tincidunt nibh id hendrerit. Mauris ut lectus tincidunt, commodo nulla in, pharetra metus. Etiam bibendum vehicula maximus. Cras vel dignissim ipsum, eu tempus dui. ",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smartphone"
                },
                new Product()
                {
                    Name = "Samsug 10",
                    Descriprion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi viverra magna erat, sed lobortis risus efficitur ut. Praesent tempus ex non ligula lacinia, vulputate eleifend dui gravida. Praesent ut ipsum eget ex scelerisque laoreet. Vestibulum sit amet mattis libero, nec placerat felis. Nulla porta velit sit amet lacus lacinia porttitor eget quis tortor. Suspendisse potenti. Aenean facilisis risus sem, at dapibus arcu elementum a. Curabitur blandit, magna vitae interdum scelerisque, arcu ante fermentum nulla, in tristique ipsum leo quis erat. Mauris ultricies convallis eros, ac mollis justo vehicula vitae. Nam lacus lacus, congue in accumsan eu, consequat sit amet tortor. Ut feugiat vitae ligula quis vestibulum. Duis ut lacus tempus, scelerisque nulla ac, porttitor ipsum. In pretium tincidunt nibh id hendrerit. Mauris ut lectus tincidunt, commodo nulla in, pharetra metus. Etiam bibendum vehicula maximus. Cras vel dignissim ipsum, eu tempus dui. ",
                    Image = "product-1.png",
                    Price = 950.00M,
                    Category = "Smartphone"
                }
            };
        }
    }
}