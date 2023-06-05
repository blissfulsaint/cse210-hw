public class Apartment

{

    List<Elevator> _elevators =  new List<Elevator>();
    Elevator elevator1 = new Elevator();
    Elevator elevator2 = new Elevator();
    VipElevator vipElevator = new VipElevator();
    private int _floors = 31;




    public void CallElevator1(int currentFloor)

    {

        elevator1.CallToFloor(currentFloor);
        elevator1.MoveToFloor();

    }




    public void CallElevator2(int currentFloor)

    {

        elevator2.CallToFloor(currentFloor);
        elevator2.MoveToFloor();

    }




    public void CallVIPElevator(int currentFloor)

    {
        vipElevator.CallToFloor(currentFloor);
        vipElevator.VerifyCode();
        vipElevator.MoveToFloor();

    }

}