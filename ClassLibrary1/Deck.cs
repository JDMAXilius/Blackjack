using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
   public class Deck 
   {
        //Random RND = new Random(52);
        public List<ICard> _Card { get; set; } = new List<ICard>();
        //List<ICard> _Card;
        //Card dCard = new Card(0, 0);

        public Deck()
        {
            CreateCardsDeck();
           
        }

        public ICard Deal()
        {
            ICard DealCard = _Card[0];
            _Card.RemoveAt(0);
            if (_Card.Count == 0) 
            {
                CreateCardsDeck();
            }
            return DealCard;
        }

        private void CreateCardsDeck()
        {
            
            for (int i = 1; i <= 13; i++)
            {
                for (int a = 1; a <= 4; a++)
                {
                    _Card.Add(Factory.CreateBlackjackCard((CardFace)i, (CardSuit)a));

                }
            }
        }
        public void Shuffle()
        {
            List<ICard> SuffleCard = new List<ICard>();
            Random rng = new Random();
            //ICard card;
            while (_Card.Count > 0)
            {
                int ran = rng.Next(0, _Card.Count);
                SuffleCard.Add(_Card[ran]);
                _Card.RemoveAt(ran);
                
            }
            //card = Shuffle[]
            _Card = SuffleCard;
        }
    }
}
