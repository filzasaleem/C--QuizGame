// See https://aka.ms/new-console-template for more information
using QuizGame;

Console.WriteLine("Let's play a game and test you knowledge...!!");
var game = new Game("data");
string play = "yes";

while (!string.IsNullOrEmpty(play) && play.ToLower() == "yes")
{
    Console.Write("Enter your name: ");
    var name = Console.ReadLine() ?? "Player";

    // Pass the name to the game
    game.Start(name);

    Console.Write("Do you want to play again? Yes/no: ");
    play = Console.ReadLine() ?? "no";
}