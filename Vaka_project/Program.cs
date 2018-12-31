using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaka_project
{
    static class Location
    {
        public static int Max_Y { get; set; }
        public static int Max_X { get; set; }
        public const char North = 'N', West = 'W', East = 'E', South = 'S', Left = 'L', Right = 'R', Move = 'M';
    }

    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }

        public Robot()
        {
            string[] First_Location = Console.ReadLine().Split(' ');
            X = Int16.Parse(First_Location[0]);
            Y = Int16.Parse(First_Location[1]);
            Direction = char.Parse(First_Location[2]);
        }

        public void MoveOn()
        {
            switch (Direction)
            {
                case Location.North:
                    Y += 1;
                    break;

                case Location.South:
                    Y = Y - 1;
                    break;
                case Location.East:
                    X = X + 1;
                    break;

                case Location.West:
                    X = X - 1;
                    break;
            }
        }
        public void SetDirection()
        {
            Console.WriteLine("Harf Katarlarını Giriniz");
            string LetterString = Console.ReadLine();
            foreach (char letter in LetterString)
            {
                switch (letter)
                {
                    case Location.Left:
                        if (Direction == Location.North)
                            Direction = Location.West;
                        else if (Direction == Location.West)
                            Direction = Location.South;
                        else if (Direction == Location.South)
                            Direction = Location.East;
                        else
                            Direction = Location.North;
                        break;
                    case Location.Right:
                        if (Direction == Location.North)
                            Direction = Location.East;
                        else if (Direction == Location.West)
                            Direction = Location.North;
                        else if (Direction == Location.South)
                            Direction = Location.West;
                        else
                            Direction = Location.South;
                        break;
                    case Location.Move:
                        MoveOn();
                        break;
                    default:
                        Console.WriteLine("Yanlış Harf Katarı");
                        break;
                }
            }
        }
    }
   
    class Program
    {

        static void Main(string[] args)
        {
            SetMaxMarsRightTop();
            Console.WriteLine("1. Robotik Gezginin İlk konumunu giriniz...");
            Robot First_Robotic = new Robot();
            First_Robotic.SetDirection();            
            First_Robotic.X = First_Robotic.X > Location.Max_X ? Location.Max_X : First_Robotic.X;
            First_Robotic.Y = First_Robotic.Y > Location.Max_Y ? Location.Max_Y : First_Robotic.Y;
            Console.WriteLine("1.Robotik Gezginin Konumu ({0},{1}) Yönü : {2}", First_Robotic.X, First_Robotic.Y, First_Robotic.Direction);

            Console.WriteLine("2.Robotik Gezginin İlk Konumunu Giriniz");            
            Robot Second_Robotic = new Robot();
            Second_Robotic.SetDirection();
            Second_Robotic.X = Second_Robotic.X > Location.Max_X ? Location.Max_X : Second_Robotic.X;
            Second_Robotic.Y = Second_Robotic.Y > Location.Max_Y ? Location.Max_Y : Second_Robotic.Y;
            Console.WriteLine("2.Robotik Gezginin Konumu ({0},{1}) Yönü : {2}", Second_Robotic.X, Second_Robotic.Y, Second_Robotic.Direction);
            Console.ReadLine();
        }

        private static void SetMaxMarsRightTop()
        {
            Console.WriteLine("Sağ üst Köşe Koordinatlarını giriniz...");
            string[] right_top = Console.ReadLine().Split(' ');
            Location.Max_X = Int16.Parse(right_top[0]);
            Location.Max_Y = Int16.Parse(right_top[1]);
        }       

    }
}
