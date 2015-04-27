using GamblingFramework;
using GamblingFramework.Poker;
using GamblingFramework.Generic;
using GamblingFramework.Poker.Generic;
using GamblingFramework.Properties;

using System;
using System.Collections.Generic;
namespace DllTester
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            TexasHoldemPokerGame
                myGame 
                    = new TexasHoldemPokerGame(
                        new TexasHoldemPokerTable(
                            new GambleDeck(),
                            new GambleCardHand(),
                            new GambleCardHand(),
                            1,
                            8
                        )
                    );

            GambleCardPlayer
                myPlayer = new GambleCardPlayer("Me", 100),
                myIdiot = new GambleCardPlayer("Idiot",10);

            myGame.Table.AddPlayer(myPlayer);
            myGame.Table.AddPlayer(myIdiot);

            Console.WriteLine(myGame.Table.ToString());
            */
            // / *
            GambleDeck
                myDeck = new GambleDeck();

            int players = 8;

            myDeck.AdvancedShuffle();

            List<TexasHoldemPokerHand>
                myHands = new List<TexasHoldemPokerHand>();
            List<ITexasHoldemPokerHand>
                myBestHands = new List<ITexasHoldemPokerHand>();
            for (int j = 0; j < players; j++)
            {
                myHands.Add(new TexasHoldemPokerHand());
            }
            TexasHoldemPokerHand
                myTable = new TexasHoldemPokerHand(),
                myBurn = new TexasHoldemPokerHand();

            //Draw 7 (or i, if i changed it) cards
            for (int i = 0; i < 2; i++)
            {
                for (int k = 0; k < players; k++)
                {
                    myHands[k].AddCardFromDeckToHand(myDeck);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                    case 4:
                    case 6:
                        myBurn.AddCardFromDeckToHand(myDeck);
                        break;
                    default:
                        myTable.AddCardFromDeckToHand(myDeck);
                        break;
                }
            }
            for (int j = 0; j < players; j++)
            {
                myBestHands.Add(new TexasHoldemPokerHand(myHands[j]));
                for (int i = 0; i < myTable.Count; i++)
                {
                    myBestHands[j].Add(myTable[i]);
                }
                myBestHands[j] = myBestHands[j].GetBestPokerHand();
            }

            //Display Table
            Console.Write("Table : ");
            for (int i = 0; i < myTable.Count; i++)
            {
                Console.Write(myTable[i].ToString() + ", ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Display Players Initial
            //Display Rank And Best
            for (int j = 0; j < players; j++)
            {
                Console.Write("Player [" + j + "] : ");
                for (int i = 0; i < myHands[j].Count; i++)
                {
                    Console.Write(myHands[j][i].ToString() + ", ");
                }
                Console.WriteLine();

                Console.Write(myBestHands[j].Rank.ToString());
                Console.WriteLine();
                for (int i = 0; i < myBestHands[j].Count; i++)
                {
                    Console.Write(myBestHands[j][i].ToString() + ", ");
                }
                Console.WriteLine();

                Console.WriteLine();
            }



            // */
            /*
            bool escape = false;
            for (int j = 0; j < 10 && !escape; j++ )
            {
                Console.WriteLine("[" + j + "] : " + myHand.ToString());
                Console.WriteLine();


                ITexasHoldemPokerHand<GambleCard> best = myHand.GetBestPokerHand();

                if (best.Count > 0)
                {
                    foreach (GambleCard card in best)
                    {
                        Console.Write(card.ToString() + ", ");
                    }
                    Console.WriteLine();

                    //escape = true;
                }
             * */
            /*
            IList<GambleCard> royalFlush = myHand.GetRoyalFlush();

            if (royalFlush.Count > 0)
            {
                foreach (GambleCard card in royalFlush)
                {
                    Console.Write(card.ToString() + ", ");
                }
                Console.WriteLine();
                    
                escape = true;
            }
            */
            /*
            IList<IList<GambleCard>> flushs = ((IList<GambleCard>)myHand).GetXOfSuit();

            if (flushs.Count > 0)
            {
                foreach (IList<GambleCard> flush in flushs)
                {
                    foreach (GambleCard card in flush)
                    {
                        Console.Write(card.ToString() + ", ");
                    }
                    Console.WriteLine();
                }
                escape = true;
            }*/
            /*
            IList<IList<GambleCard>> straights = myHand.GetXConsecutive();
            IList<GambleCard> winningStraight = myHand.GetStraight();
            bool displayWinning = true;

            if (straights.Count > 0)
            {
                foreach (IList<GambleCard> straight in straights)
                {
                    if(straight == winningStraight){
                        Console.Write("WINNING! >  ");
                        displayWinning = false;
                    }
                    foreach (GambleCard card in straight)
                    {
                        Console.Write(card.ToString() + ", ");
                    }
                    Console.WriteLine();
                }

                escape = true;
            }
            if (escape && displayWinning)
            {
                Console.Write("WINNING! >  ");
                foreach (GambleCard card in winningStraight)
                {
                    Console.Write(card.ToString() + ", ");
                }
            }
            // */
            Console.WriteLine();
            //Dont even compute another call!
            /*    
            if (!escape)
                {
                    myHand.ResetHand();
                    myDeck.ResetDeck();
                    myDeck.AdvancedShuffle();
                }
             * */
            //}

            /*
            GambleDeck<GambleCard>
                myDeck = new GambleDeck<GambleCard>(),
                myDeckShuffledAdvanced = new GambleDeck<GambleCard>(myDeck),
                myDeckShuffledSafe = new GambleDeck<GambleCard>(myDeck);


            Console.Out.WriteLine();
            Console.Out.WriteLine("Default Deck");
            for (int i = 0; i < 10; i++)
            {
                GambleCard card = myDeck.DrawCard();
                Console.Out.WriteLine("[" + i + "] : " + card.ToString());
            }


            Console.Out.WriteLine();
            Console.Out.WriteLine("Safe Shuffled Deck!"); 
            for (int i = 0; i < 10; i++)
            {
                myDeckShuffledSafe.SafeShuffle();
                GambleCard card = myDeckShuffledSafe.DrawCard();
                Console.Out.WriteLine("[" + i + "] : " + card.ToString());
            }

            Console.Out.WriteLine();
            Console.Out.WriteLine("Advanced Shuffled Deck!");
            for (int i = 0; i < 10; i++)
            {
                myDeckShuffledAdvanced.AdvancedShuffle();
                GambleCard card = myDeckShuffledAdvanced.DrawCard();
                Console.Out.WriteLine("[" + i + "] : " + card.ToString());
            }
            */

            /*
            TexasHoldemPokerTable<GambleCardPlayer<GambleCard>, GambleCard, GambleDeck<GambleCard>, GambleHand<GambleCard>>
                myTexasHoldemPokerTable = new TexasHoldemPokerTable<GambleCardPlayer<GambleCard>, GambleCard, GambleDeck<GambleCard>, GambleHand<GambleCard>>();

            myTexasHoldemPokerTable.Deck.Shuffle();

            Console.Out.WriteLine(myTexasHoldemPokerTable.ToString());
             */

            Console.ReadLine();
        }
    }
}
