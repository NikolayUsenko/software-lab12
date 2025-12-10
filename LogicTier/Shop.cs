using DataTier;

namespace LogicTier
{
    public class Shop
    {
        private List<ProductPosition> _products = new List<ProductPosition>();

        public Shop()
        {
            List<Product> tmp = AllProducts.GetAllProducts();
            foreach (var t in tmp)
            {
                _products.Add(new ProductPosition(t));
            }
        }

        public List<ProductPosition> ProductList
        {
            get { return _products; }
        }

        public String NameOfShop
        {
            get { return "Магазин теники"; }
        }
        public float MiddlePriceOfNetwork
        {
            get
            {
                var networkProducts = _products
                    .Where(p => p.NameGroupProduct == "Сетевое оборудование")
                    .ToList();

                if (networkProducts.Count == 0)
                    return 0;

                return networkProducts.Average(p => p.PriceProduct);
            }
        }

        public float MiddlePriceOfSoftware
        {
            get
            {
                var softwareProducts = _products
                    .Where(p => p.NameGroupProduct == "ПО")
                    .ToList();

                if (softwareProducts.Count == 0)
                    return 0;

                return softwareProducts.Average(p => p.PriceProduct);
            }
        }
        public String LargestStorage
        {
            get
            {
                var storageGroups = _products
                    .GroupBy(p => p.StorageProduct)
                    .Select(g => new
                    {
                        Storage = g.Key,
                        TotalCount = g.Sum(p => p.CountProduct)
                    })
                    .ToList();

                if (storageGroups.Count == 0)
                    return "Нет данных";

                var largestStorage = storageGroups
                    .OrderByDescending(g => g.TotalCount)
                    .First();

                return largestStorage.Storage;
            }
        }
    }
}
