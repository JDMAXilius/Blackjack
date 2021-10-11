using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public enum CardSuit { Spades = 1, Hearts, Clubs, Diamonds };
    public enum CardFace { A = 1, two = 2, three = 3, four = 4, five = 5, six = 6, seven = 7, eight = 8, nine = 9, ten = 10, J = 11, Q = 12, K = 13 };
    public class Card : ICard
    {
       
        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        string width = "      ";
        public Card(CardFace _f, CardSuit _s)
        {
            Face = _f;
            Suit = _s;
           
        }
       
        public void Draw(int x, int y)
        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;

            for (int i = 0; i < 5; i++)
            {
                if (Suit == CardSuit.Spades || Suit == CardSuit.Clubs)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
               else if (Suit == CardSuit.Hearts || Suit == CardSuit.Diamonds)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                
                switch (Face)
                {
                    case CardFace.A:
                        Console.Write("A");
                        break;
                    case CardFace.two:
                        Console.Write("2");
                        break;
                    case CardFace.three:
                        Console.Write("3");
                        break;
                    case CardFace.four:
                        Console.Write("4");
                        break;
                    case CardFace.five:
                        Console.Write("5");
                        break;
                    case CardFace.six:
                        Console.Write("6");
                        break;
                    case CardFace.seven:
                        Console.Write("7");
                        break;
                    case CardFace.eight:
                        Console.Write("8");
                        break;
                    case CardFace.nine:
                        Console.Write("9");
                        break;
                    case CardFace.ten:
                        Console.Write("10");
                        width = "     ";
                        break;
                    case CardFace.J:
                        Console.Write("J");
                        break;
                    case CardFace.Q:
                        Console.Write("Q");
                        break;
                    case CardFace.K:
                        Console.Write("K");
                        break;
                    default:
                        break;
                }
                switch (Suit)
                {
                    case CardSuit.Spades:
                        
                        Console.Write('♠');

                        break;
                    case CardSuit.Hearts:
                        //Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('♥');
                        break;
                    case CardSuit.Clubs:
                        //.ForegroundColor = ConsoleColor.Black;
                        Console.Write('♣');

                        break;
                    case CardSuit.Diamonds:
                       // Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write('♦');

                        break;
                    default:
                        break;
                }
                
                
                //Console.Write($" {this.Face} {"\u2665"} ");
                //Console.BackgroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(width);
                Console.CursorLeft = x;
                //Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

        }


    }
    public class BlackJackCard : Card
    {
        public int Value { get; set; }

        public BlackJackCard(CardFace face, CardSuit suit) : base(face, suit)
        {

            Value = TheValue(Face);
           
           
        }

        public int TheValue(CardFace Theface)
        {
            //BlackJackHand acevalue = new BlackJackHand();
            int TheValue = 0;
            switch (Theface)
            {
                case CardFace.A:
                    //if (acevalue.Score >=21)
                    //{
                    //    TheValue = 1;
                    //}
                    //else if(acevalue.Score < 21)
                    //{
                    //    TheValue = 11;
                    //}
                    TheValue = 11;

                    break;
                case CardFace.two:
                    TheValue = 2;
                    break;
                case CardFace.three:
                    TheValue = 3;
                    break;
                case CardFace.four:
                    TheValue = 4;
                    break;
                case CardFace.five:
                    TheValue = 5;
                    break;
                case CardFace.six:
                    TheValue = 6;
                    break;
                case CardFace.seven:
                    TheValue = 7;
                    break;
                case CardFace.eight:
                    TheValue = 8;
                    break;
                case CardFace.nine:
                    TheValue = 9;
                    break;
                case CardFace.ten:
                    TheValue = 10;
                    break;
                case CardFace.J:
                    TheValue = 10;
                    break;
                case CardFace.Q:
                    TheValue = 10;
                    break;
                case CardFace.K:
                    TheValue = 10;
                    break;
                default:
                    break;
            }
            return TheValue;
           

            //string[] OptFaces = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            //int[] OptValue = { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
            //for (int i = 0; i < OptFaces.Length; i++)
            //{
            //    if (Theface == OptFaces[i])
            //    {
            //        if (i == 0)
            //        {
            //            int[] ValueOfA = { 11, 1 };
            //            return ValueOfA;
            //        }
            //        int[] ValueReturn = { OptValue[i] };
            //        return ValueReturn;
            //    }

            //}
        }
    }
}
