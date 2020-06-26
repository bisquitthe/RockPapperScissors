using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace ConsoleView
{
    class Program
    {
        private static readonly GestureFactory gestureFactory = new GestureFactory();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var random = new Random();
            var dictionary = new Dictionary<int, Func<Gesture>>
            {
                {
                    1, gestureFactory.GetPaper
                },
                {
                    2, gestureFactory.GetRock
                },
                {
                    3, gestureFactory.GetScissors
                }
            };
            while (true)
            {
                var computedGesture = dictionary[random.Next(1, 3)]();
                Console.WriteLine($@"
                                    1 - Paper
                                    2 - Rock
                                    3 - Scissors");
                Gesture userGesture = null;
                bool isInt = false;
                do
                {
                    isInt = int.TryParse(Console.ReadLine(), out var userGestureInt);
                    if (isInt && dictionary.ContainsKey(userGestureInt))
                        userGesture = dictionary[userGestureInt]();
                    else Console.WriteLine("Invalid number");
                } while (!isInt);

                Console.WriteLine($@"
You - {userGesture.GetEmoji()}
PC - {computedGesture.GetEmoji()}");

                if (userGesture.CanBite(computedGesture))
                    Console.WriteLine("You win");
                else if (computedGesture.CanBite(userGesture))
                    Console.WriteLine("You lose");
                else Console.WriteLine("Draw");
            }
        }
    }
}
