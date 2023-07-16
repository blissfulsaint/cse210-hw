public class Customer
{
    string _name;
    Address _address = new Address();

    public Customer()
    {
        _name = "";
    }

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsUSAResident()
    {
        return _address.IsUSA();
    }

    public string GetCustomerAddress()
    {
        return _address.GetAddress();
    }

    public string GetCustomerName()
    {
        return _name;
    }

    public string GetCustomerDetails()
    {
        return $"{_name}\n\n{GetCustomerAddress()}";
    }
}