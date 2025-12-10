namespace DataTier
{
    public class AllProducts
    {
        public static List<Product> GetAllProducts()
        {

            List<Product> products = new List<Product>();

            if (!File.Exists("data.txt"))
            {
                throw new FileNotFoundException("Файл data.txt не найден.");
            }

            try
            {
                String[] lines = File.ReadAllLines("data.txt");

                foreach (String line in lines)
                {
                    if (String.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    String[] parts = line.Split("%");

                    if (parts.Length < 5)
                    {
                        throw new FormatException($"Неверный формат строки: {line}");
                    }

                    Product product = new Product();
                    product.Name = parts[0].Trim();
                    product.NameGroup = parts[1].Trim();
                    product.Price = ParsePrice(parts[2].Trim());
                    product.Count = ParseCount(parts[3].Trim());
                    product.Storage = parts[4].Trim();

                    products.Add(product);

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при чтении файла data.txt: {ex.Message}", ex);
            }

            return products;
        }

        private static float ParsePrice(String priceString)
        {
            if (float.TryParse(priceString, out float price))
            {
                return price;
            }

            throw new FormatException($"Невозможно преобразовать '{priceString}' в число.");
        }

        private static int ParseCount(String countString)
        {
            if (int.TryParse(countString, out int count))
            {
                return count;
            }

            throw new FormatException($"Невозможно преобразовать '{countString}' в число.");
        }
    }
}
