using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Factory
    {
        public static ICard CreateCard(CardFace face, CardSuit suit)
        {
            Card CardClass = new Card(face, suit);
            return CardClass;
        }

        public static ICard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            BlackJackCard BlackJackCardClass = new BlackJackCard(face, suit);
            return BlackJackCardClass;
        }

    }
}
