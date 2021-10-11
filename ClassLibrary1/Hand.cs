using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Hand
    {
        //has to be protected
        protected List<ICard> _cards { get; set; } = new List<ICard>();
        public virtual void AddCard(ICard addedCard)
        {
            _cards.Add(addedCard);
            //BlackJackCard Cards = (BlackJackCard)addedCard;
           
        }

        /*public void Draw(int x, int y)
        {
            string width = "      ";
            BlackJackCard Cards;
            //BlackJackCard Cards = (BlackJackCard)addedCard;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;

            for (int i = 0; i < 5; i++)
            {
                if (Cards.Suit == CardSuit.Spades || Cards.Suit == CardSuit.Clubs)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (Cards.Suit == CardSuit.Hearts || Cards.Suit == CardSuit.Diamonds)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                switch (Cards.Face)
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
                switch (Cards.Suit)
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

        }*/

    }

    public class BlackJackHand : Hand
    {
        public int Score { get;  private set; }
        public BlackJackHand() : base()
        {
            _cards = new List<ICard>();
            Score = 0;
            
        }
        public override void AddCard(ICard addedCard) 
        {
            
            base.AddCard(addedCard);
            int TotalScores = 0;
            BlackJackCard ScoreValue = (BlackJackCard)addedCard;
            //TotalScores = Score + ScoreValue.Value;
            foreach (BlackJackCard SC in _cards)
            {
                TotalScores = TotalScores + SC.Value;
                //if (SC.Face == CardFace.A)
                //{
                //    TotalScores -= 10;
                //}
            }
            if (TotalScores > 21)
            {
                foreach (BlackJackCard SC in _cards)
                {
                    
                    if (SC.Face == CardFace.A)
                    {
                        TotalScores -= 10;
                        if (TotalScores < 21)
                        {
                            break;
                        }
                    }
                }

            }
            else if(TotalScores == 21)
            {
                //Console.WriteLine("\t\t\t\tyou Win the score!");
            }
            else
            {
                //Console.WriteLine("\t\t\t\tKepp playing!");
            }

            Score = TotalScores;
        }
    }
}
