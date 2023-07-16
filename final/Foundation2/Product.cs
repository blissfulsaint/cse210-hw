public class Product
{
    string _name;
    string _productId;
    int _quantity;
    double _price;

    public Product()
    {
        _name = "";
        _productId = "";
        _quantity = 0;
        _price = 0;
    }

    public Product(string name, string productId, int quantity, double price)
    {
        _name = name;
        _productId = productId;
        _quantity = quantity;
        _price = price;
    }

    public double CalcPrice()
    {
        return (double)_quantity * _price;
    }

    public string GetDetails()
    {
        return $"{_name} - {_productId}";
    }
}