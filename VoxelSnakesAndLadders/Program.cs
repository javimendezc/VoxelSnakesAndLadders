using API.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using VoxelSnakesAndLadders;
using static API.Enums;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            var services = Startup.ConfigServices();
            var serviceProvider = services.BuildServiceProvider();


            string? buffer = string.Empty;
            bool correctFormat = false;
            int numberPlayers = -1;

            while((numberPlayers <= 0) || !correctFormat)
            {
                Console.Write("Define number of players: ");
                buffer = Console.ReadLine();
                correctFormat = int.TryParse(buffer, out numberPlayers);
            }

            var listPlayers = new List<IPlayerToken>();
            for (int i = 0; i < numberPlayers; i++)
            {
                Console.WriteLine($"Write name of player {i + 1} (if blank, system will assign a name): ");
                buffer = Console.ReadLine();

                var token = serviceProvider.GetService<IPlayerToken>();
                if (buffer != String.Empty) token.Name = buffer;
                listPlayers.Add(token);
                Console.WriteLine($"<<{token.Name} added to player list>>");
            }

            var dice = serviceProvider.GetService<IDice>();   

            var game = serviceProvider.GetService<IGame>();
            game.Start(listPlayers);
            Console.WriteLine("*****************");
            Console.WriteLine("* GAME STARTS!! *");
            Console.WriteLine("*****************");

            while (game.Stage != GAME_STAGES.ENDED)
            {
                foreach (var player in listPlayers)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{player.Name} located on square {player.Position} is playing now! ");
                    int spacesToMove = dice.Roll();
                    Console.WriteLine($"Move {spacesToMove} positions");
                    player.Move(spacesToMove);
                    Console.WriteLine($"{player.Name} is now located on square {player.Position}");
                    if (player.IsWinner(game))
                    {
                        Console.WriteLine($"{player.Name} has win. Congratulations!!!!");
                        break;
                    }
                }
            }


            Console.ReadLine();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
