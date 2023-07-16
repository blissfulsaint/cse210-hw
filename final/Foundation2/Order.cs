public class Order
{
    Customer _customer = new Customer();
    List<Product> _products = new List<Product>();

    public Order()
    {

    }

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public double CalcCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.CalcPrice();
        }

        if (_customer.IsUSAResident())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Products List:";

        foreach (Product product in _products)
        {
            label += $"\n{product.GetDetails()}";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return _customer.GetCustomerDetails();
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine($"{GetPackingLabel()} \n{GetShippingLabel()} \nTotal: ${CalcCost()}");
    }
}