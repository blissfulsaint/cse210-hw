using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Address address = new Address("42 S 1st W Apt 6", "Rexburg", "Idaho", "USA");
        Customer customer = new Customer("Brandon Lisonbee", address);

        Product brandonProduct1 = new Product("Candelabra Smart Bulbs", "G7-6", 3, 12.99);
        Product brandonProduct2 = new Product("Sakura Lego Set", "THOA773", 1, 21.99);
        Product brandonProduct3 = new Product("Japanese Tsuyu", "552-YT", 2, 20.99);

        List<Product> products = new List<Product>();
        products.Add(brandonProduct1);
        products.Add(brandonProduct2);
        products.Add(brandonProduct3);

        Order brandonOrder = new Order(customer, products);

        List<Order> orders = new List<Order>();
        orders.Add(brandonOrder);

        products.Clear();

        Console.WriteLine("\n\n");

        Address address2 = new Address("5567-009 Satou-Machi, Genji-Ward", "Tsuruoka-Shi", "Yamagata", "Japan");
        Customer customer2 = new Customer("Toshi Satou", address2);

        Product toshiProduct1 = new Product("Shrine Attachment", "AAD-333245", 2, 34.99);
        Product toshiProduct2 = new Product("Picture Frame", "HY-555", 4, 8.99);

        products.Add(toshiProduct1);
        products.Add(toshiProduct2);

        Order toshiOrder = new Order(customer2, products);

        orders.Add(toshiOrder);

        foreach (Order order in orders)
        {
            order.DisplayOrderDetails();
        }
    }
}