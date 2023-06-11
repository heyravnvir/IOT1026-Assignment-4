// Change to 'using Assignment.InterfaceCommand' when you are ready to test your interface implementation
using Assignment.InterfaceCommand;

namespace Assignment;

public class Robot
{
    public int NumCommands { get; }
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }

    private const int DefaultCommands = 6;
    // i am using Queue data type to store commands 
    private readonly Queue<RobotCommand> _commands;
    private int _commandsLoaded = 0;

    /// This function will return robot's current state 
    // its cordinates and its power status 
    public override string ToString()
    {
        return $"[{X} {Y} {IsPowered}]";
    }

    public Robot() : this(DefaultCommands) { }



    // this constructor will declare the que in robot object so that it can store commands
    public Robot(int numCommands)
    {
        _commands = new Queue<RobotCommand>(numCommands);
        NumCommands = numCommands;
    }

   // this function is responsible for executing the commands present in robot's que
   // this will return true if the command is executed correctly and false if not
    public bool Run()
    {
        if (_commands.Count <= 0){
        return false;}
        while (_commands.Count >=1){
            var c = _commands.Dequeue();
            c.Run(this);
        Console.WriteLine(this);
        }
        return true;
    }

    public bool LoadCommand(RobotCommand command)
    {
        if (_commandsLoaded  >= NumCommands){
        return false;
        }
        else{
        _commands.Enqueue(command);
        _commandsLoaded+=1;
        return true;
        }
    }
}