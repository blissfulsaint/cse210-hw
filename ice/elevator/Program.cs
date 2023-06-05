class Program
{
    static void Main(string[] args)
    {
        Apartment alpine = new Apartment();

        alpine.CallElevator1(30);


        alpine.CallElevator2(31);

        alpine.CallElevator1(5);

        alpine.CallVIPElevator(31);
    }
}