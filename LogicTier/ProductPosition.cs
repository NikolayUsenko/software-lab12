using DataTier;

namespace LogicTier
{
    public class ProductPosition
    {
        private Product _product;
        public ProductPosition(Product p)
        {
            _product = p;
        }
        public String NameProduct
        {
            get { return _product.Name; }
            set { _product.Name = value; }
        }
        public String NameGroupProduct
        {
            get { return _product.NameGroup; }
            set { _product.NameGroup = value; }
        }
        public float PriceProduct
        {
            get { return _product.Price; }
            set { _product.Price = value; }
        }
        public int CountProduct
        {
            get { return _product.Count; }
            set { _product.Count = value; }
        }
        public String StorageProduct
        {
            get { return _product.Storage; }
            set { _product.Storage = value; }
        }
        public string ProductPresentation
        {
            get
            {
                return $"{_product.Name} ({_product.NameGroup}) - {_product.Price}$";
            }
        }
    }
}
