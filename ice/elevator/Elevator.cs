public class Elevator
{
    private bool _isOpen = false;
    private int _currentFloor = 1;
    protected int _accessibleFloors = 30;

    public void OpenDoor()
    {
        _isOpen = true;
    }

    public void CloseDoor()
    {
        _isOpen = false;
    }

    public void MoveToFloor()
    {
        Console.WriteLine($"Select a floor between B and {_accessibleFloors}");
        string newFloorStr = Console.ReadLine();
        newFloorStr = newFloorStr.ToUpper();

        if (newFloorStr == "B")
        {
            _currentFloor = -1;
        }
        else if (int.Parse(newFloorStr) <= _accessibleFloors && int.Parse(newFloorStr) >= -1)
        {
            _currentFloor = int.Parse(newFloorStr);
        }
        else
        {
            Console.WriteLine("That floor is not accessible by this elevator.");
        }
    }

    public void CallToFloor(int newFloor)
    {
        if (newFloor <= _accessibleFloors)
        {
            _currentFloor = newFloor;
        }
    }

    public void DisplayFloor()
    {
        Console.WriteLine($"Current Floor: {_currentFloor}");
    }

    public int GetAccessibleFloors()
    {
        return _accessibleFloors;
    }
}