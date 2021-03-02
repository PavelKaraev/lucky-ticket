using System;
using System.Threading;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            LuckyTicket();
        }
        static void LuckyTicket()
        {

            int[] numbers = getTicketNumber();
            int firstPiece;
            int secondPiece;

            calculateLuck(numbers, out firstPiece, out secondPiece);

            checkAndDisplayLuck(firstPiece, secondPiece);

        }

        static int[] getTicketNumber()
        {
            string ticketNumber;
            int ticketNumberLength;
            bool isTicketNumber;
            char[] ticketNumberByChar;

            do
            {
                Console.Clear();
                Console.Write("Enter your ticket number: ");

                ticketNumber = Console.ReadLine();
                ticketNumberLength = ticketNumber.Length;
                ticketNumber = zeroExtensions(ticketNumberLength, ticketNumber);

                ticketNumberByChar = ticketNumber.ToCharArray();
                isTicketNumber = Array.TrueForAll(ticketNumberByChar, itemChar => Char.IsDigit(itemChar));

            } while (!isTicketNumber || ticketNumberLength < 4 || ticketNumberLength > 8);

            int[] numbers = Array.ConvertAll(ticketNumberByChar, number => (int)Char.GetNumericValue(number));

            return numbers;
        }

        static void calculateLuck(int[] ticketNumbers, out int firstPiece, out int secondPiece)
        {
            firstPiece = 0;
            secondPiece = 0;
            int halfNumberTicket = ticketNumbers.Length / 2;

            for (int i = 0; i < ticketNumbers.Length; i++)
            {
                if (i < halfNumberTicket)
                {
                    firstPiece += ticketNumbers[i];
                }
                else
                {
                    secondPiece += ticketNumbers[i];
                }

            }
        }

        static void checkAndDisplayLuck(int firstPiece, int secondPiece)
        {
            if (firstPiece == secondPiece)
            {
                Console.WriteLine("Congratulations! Your Ticket is Lucky!");

                Thread.Sleep(2000);
                Console.Clear();
                LuckyTicket();
            }
            else
            {
                Console.WriteLine($"Oh... Better luck next time!{firstPiece}:{secondPiece}");

                Thread.Sleep(2000);
                Console.Clear();
                LuckyTicket();
            }
        }

        static string zeroExtensions(int ticketNumberLength, string ticketNumber)
        {
            return (ticketNumberLength % 2) != 0 ? 0 + ticketNumber : ticketNumber;
        }

    }
}