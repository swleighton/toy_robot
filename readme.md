# Toy Robot

## Description:
- The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units
- There are no other obstructions on the table surface
- The robot is free to roam around the surface of the table, but is prevented from falling to destruction
- Any movement that results in the robot falling from the table is prevented, however further valid movement commands are still be allowed
- The origin (0,0) is the SOUTH WEST most corner
- The application can read in commands of the following form:
    - **PLACE X,Y,D** will put the toy robot on the table in position X,Y and facing **NORTH**, **SOUTH**, **EAST** or **WEST**
    - **MOVE** moves the toy robot one unit forward in the direction it is currently facing
    - **LEFT** and **RIGHT** rotate the robot 90 degrees in the specified direction without changing the position of the robot
    - **REPORT** announces the X,Y and D of the robot
    - **EXIT** safley exists the application
- If the robot is not on the table it will ignore the MOVE, LEFT, RIGHT and REPORT commands
- The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application will discard all commands in the sequence until a valid PLACE command has been executed
- Input is from the command line only
- The toy robot will not fall off the table during movement. This includes the initial placement of the toy robot. Any move that would cause the robot to fall is ignored

 
## Setup
1. Install the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2)
2. Clone the solution to your local machine

## Running the app
1. Setup the application
2. Using a terminal, navigate to the `toy-robot` directory
3. Run the application by typing `dotnet run`

## Testing the application
1. Setup the application
2. Using a terminal, navigate to the `toy-robot.tests` directory
3. Run the unit tests by typing `dotnet test`
 
## Example Input and Output:
```
PLACE 0,0,NORTH
MOVE
REPORT
*Output: 0,1,NORTH*
EXIT
```
```
PLACE 0,0,NORTH
LEFT
REPORT
*Output: 0,0,WEST*
EXIT
```
```
PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT
*Output: 3,3,NORTH*
EXIT
```
```
PLACE 0,0,EAST
MOVE
MOVE
RIGHT
REPORT
*Output: 2,0,SOUTH*
EXIT
```