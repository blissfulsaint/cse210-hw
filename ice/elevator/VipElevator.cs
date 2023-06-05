public class VipElevator : Elevator

{

    private int _accessCode = 1234;


    public VipElevator()
    {
        _accessibleFloors = 31;
    }


    public bool VerifyCode()

    {
        Console.WriteLine("Please enter the access code: ");
        string accessCode = Console.ReadLine();
        int code = int.Parse(accessCode);

        if (code == _accessCode)

        {

            return true;

        }
        else 
        {
            return false;
        }

    }

}