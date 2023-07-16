public class Address
{
    string _streetAddress;
    string _city;
    string _state;
    string _country;

    public Address()
    {
        _streetAddress = "";
        _city = "";
        _state = "";
        _country = "";
    }

    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUSA()
    {
        return _country == "USA";
    }

    public string GetAddress()
    {
        return $"{_streetAddress}, \n{_city}, {_state} \n{_country}";
    }
}