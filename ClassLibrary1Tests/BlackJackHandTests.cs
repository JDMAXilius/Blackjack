using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class BlackJackHandTests
    {
        [TestMethod()]
        public void BlackJackHandTest()
        {
           
            Assert.Fail();
        }

        [TestMethod()]
        public void AddCardTest()
        {
            BlackJackHand UnitTBlackJackHand = new BlackJackHand();
            ICard acecard = Factory.CreateBlackjackCard(CardFace.A, CardSuit.Hearts);
            ICard eight = Factory.CreateBlackjackCard(CardFace.eight, CardSuit.Hearts);
            ICard ten = Factory.CreateBlackjackCard(CardFace.ten, CardSuit.Diamonds);
            UnitTBlackJackHand.AddCard(acecard);
            UnitTBlackJackHand.AddCard(eight);
            UnitTBlackJackHand.AddCard(ten);
            Assert.AreEqual(19, UnitTBlackJackHand.Score);
        }
    }
}