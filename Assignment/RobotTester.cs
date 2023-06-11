using Assignment.InterfaceCommand;
namespace Assignment;
static class RobotTester
{
    public static void TestRobot()
    {
        int totalCommands = 1;
        Robot robot = new Robot();
        Console.WriteLine("Choose from the following commands :\nON\nOFF\nNORTH\nSOUTH\nEAST\nWEST\nREBOOT\n");
        
        while (totalCommands <= 6){

            Console.Write($"Enter Commands | #{totalCommands}: ");
            string? choice = Console.ReadLine()?.ToUpper();

            if(choice == "ON"){
                new OnCommand();
            }
            else if(choice == "OFF"){
                new OffCommand();
            }
            else if(choice == "NORTH"){
                new NorthCommand();
            }
            else if(choice == "SOUTH"){
                new SouthCommand();
            }
            else if(choice == "EAST"){
                new EastCommand();
            }
            else if(choice == "WEST"){
                new WestCommand();
            }
            else if(choice == "REBOOT"){
                new RebootCommand();
            }

            if (command != null){
                robot.LoadCommand(command);
                totalCommands++;
            }
            else
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Not a valid Command ! ");
                Console.ResetColor();
            }

            robot.Run();

        }