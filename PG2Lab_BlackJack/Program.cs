using ClassLibrary1;
using System;
using System.Threading;

namespace PG2Lab_BlackJack
{
    class Program
    {
        //public static Deck CardDeck { get; set; }
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //ShowWindow(ThisConsole, MAXIMIZE);

            Deck CardDeck = new Deck();
            ICard newcard;
            newcard = CardDeck.Deal();

            Program BlackjackObject = new Program();
            string[] mainMenu = new string[3] { "1. Play Blackjack", "2. Shuffle & Show Deck", "3: Exit" };
            int menuChoice = 0;

            bool HUD = true;
            while (HUD)
            {
                //Console.Clear();
                BlackjackObject.ReadChoice("Choice? ", mainMenu, out menuChoice, "Welcome to the Black Jack Game");    
                Console.WriteLine();
                switch (menuChoice)
                {
                    case 1:
                        BlackjackObject.PlayBlackjack(CardDeck, newcard, BlackjackObject);
                        break;
                    case 2:
                        BlackjackObject.ShuflleShow(CardDeck);
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        //Console.exit
                        HUD = false;

                        break;
                    default: 
                        Console.WriteLine("\nYou did not make a valid selection\n");
                        break;

                }
            }
        }

        public void PlayBlackjack(Deck CardDeck, ICard newcard, Program BJObject)
        {
            Console.Clear();
            BlackJackHand Dealer = new BlackJackHand();
            BlackJackHand Player = new BlackJackHand();
            //Hand DealerH = new Hand();
            //Hand PlayerH = new Hand();
            Console.WriteLine("Play the game!");
            CardDeck.Shuffle();
            Console.WriteLine("The dealer's card is: \n");
           
            newcard = CardDeck.Deal();
            Dealer.AddCard(newcard);
            Draw(10, 3, newcard);
            //newcard.Draw(10, 3);
            DrawFlip(0, 3);
            Console.WriteLine($"Dealer Score: {Dealer.Score}");
           
            //Console.WriteLine();
            Console.WriteLine("\nYour Cards are:\n");
            for (int i = 0; i <= 10; i += 10)
            {
                newcard = CardDeck.Deal();
                Player.AddCard(newcard);
                Draw(i, 13, newcard);
                //newcard.Draw(i, 13);
            }
            Console.WriteLine($"Player Score: {Player.Score}");
            Console.WriteLine();
            if (Player.Score == 21)
            {
                Console.WriteLine("\t\t\t\t\t\tYou have won!");
                
            }
            else if (Dealer.Score == 21)
            {
                Console.WriteLine("\t\t\t\t\t\tThe dealer has won");
               
            }
            else if (Dealer.Score == 21 && Player.Score == 21)
            {
                Console.WriteLine("\t\t\t\t\t\tYou have tied with the dealer");
                
            }
            else
            {
                int select = 0;
                bool check = true;
                string[] selections = new string[2] { "1.Hit", "2.Stay" };
                int index = 20;
                int ind = 0;

                while (check)
                {
                    BJObject.ReadChoice("Choice? ", selections, out select, "Choose Wisely");
                    switch (select)
                    {
                        case 1:
                            if (Player.Score < 21)
                            {
                                newcard = CardDeck.Deal();
                                Player.AddCard(newcard);
                                Draw(index, 13, newcard);
                                //newcard.Draw(20, 13);
                                Console.WriteLine($"Player Score: {Player.Score}");
                                //Console.WriteLine("Hit");
                                if (Player.Score < 21)
                                {
                                    Console.SetCursorPosition(0, 16);
                                    break;
                                }
                                else if (Player.Score == 21)
                                {
                                    Console.WriteLine("\t\t\t\t\t\tYou have won!");
                                    check = false;

                                }
                                else
                                {
                                    Console.WriteLine("\t\t\t\t\t\tYou have loosee!");
                                    check = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\t\t\t\t\t\tSelect Stay to see the results");
                            }
                            break;
                        case 2:
                            if (Dealer.Score < 21)
                            {
                                
                                while (Dealer.Score < 17)
                                {
                                    Thread.Sleep(500);
                                    newcard = CardDeck.Deal();
                                    Dealer.AddCard(newcard);
                                    //newcard.Draw(i, 3);
                                    //Console.WriteLine($"\t{ newcard.Face}"); 
                                    Draw(ind, 3, newcard);
                                    ind += 20;
                                }
                                ind /= 2;

                                Console.WriteLine($"Dealer Score: {Dealer.Score}");

                                if (Dealer.Score > Player.Score && Dealer.Score <= 21)
                                {
                                    Console.WriteLine("\t\t\t\t\t\tThe dealer has won!");
                                }
                                else if (Player.Score > Dealer.Score && Dealer.Score <= 21 && Player.Score > 21)
                                {
                                    Console.WriteLine("\t\t\t\t\t\tThe dealer has won!");
                                }
                                else if (Player.Score > Dealer.Score && Player.Score <= 21)
                                {
                                    Console.WriteLine("\t\t\t\t\t\tYou have won!");
                                }
                                else if (Dealer.Score > Player.Score && Player.Score <= 21 && Dealer.Score > 21)
                                {
                                    Console.WriteLine("\t\t\t\t\t\tYou have won!");
                                }
                                else if (Player.Score == Dealer.Score && Player.Score <= 21 && Dealer.Score <= 21)
                                {
                                    Console.WriteLine("\t\t\t\t\t\tYou have tied with the dealer!");
                                }
                                else if (Player.Score > 21 && Dealer.Score > 21)
                                {
                                    Console.WriteLine("\t\t\t\t\t\tYou and the dealer have busted, nobody wins!");
                                }

                            }
                            //else
                            //{
                            //    newcard = CardDeck.Deal();
                            //    Dealer.AddCard(newcard);
                            //    //newcard.Draw(i, 3);
                            //    //Console.WriteLine($"\t{ newcard.Face}"); 
                            //    Draw(0, 3, newcard);
                            //    Console.WriteLine($"Dealer Score: {Dealer.Score}");
                            //}

                            Console.SetCursorPosition(0, 20);
                            check = false;
                            break;
                            //default:
                            //    Console.WriteLine("\nYou did not make a valid selection\n");
                            //    break;

                    }
                    Console.WriteLine("\n\n\n\n");
                    index += 10;
                }

            }

            Console.WriteLine();
        }

        public void Draw(int x, int y, ICard Cards)
        {
            string width = "      ";
            //BlackJackCard Cards;
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

        }

        public void DrawFlip(int x, int y)
        {
            string width = "     ";
            //BlackJackCard Cards;
            //BlackJackCard Cards = (BlackJackCard)addedCard;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = ConsoleColor.White;

            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("x x");
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

        public void ShuflleShow(Deck CardsonDeck)
        {
            Console.Clear();
            CardsonDeck.Shuffle();
            for (int i = 0; i < 130; i += 10)
            {
                for (int a = 0; a < 40; a += 10)
                {

                    CardsonDeck.Deal().Draw(i, a);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Showffle Time!");
            Console.WriteLine();
        }

        public static int ReadInterger(string prompt, int min, int max)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(prompt);
            Console.ForegroundColor = ConsoleColor.White;
            int answer = 0;
            bool check = false;

            while (!check)
            {
                try
                {
                    answer = Int32.Parse(Console.ReadLine());
                    check = true;
                    if (answer >= min && answer <= max)
                    {
                        //Console.WriteLine("Year: " + answer);
                    }
                    else
                    {
                        Console.WriteLine($"Enter a number between { min} and { max}");
                        check = false;
                    }


                }
                catch (Exception)
                {
                    Console.WriteLine("That is not a valid number! please enter a number");


                }

            }
            Console.WriteLine();
            return answer;
        }

        public void ReadChoice(string prompt, string[] options, out int selection, string head)
        {
            int maxnum=0;
            Console.WriteLine(head);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
                maxnum = i+1;
            }
            selection = ReadInterger(prompt, 1, maxnum);

        }
    }

}
