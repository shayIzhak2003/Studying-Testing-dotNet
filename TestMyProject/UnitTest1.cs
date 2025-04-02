using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyingTesting.game_area;
using StudyingTesting.poker_hands;
using StudyingTesting.user;
using StudyingTesting.users;
using System;
using System.Collections.Generic;

namespace TestMyProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCardNumberAssignment()
        {
            int expected = 7;
            Card c = new Card(expected, Suit.SPADES);
            Assert.AreEqual(expected, c.Number);
        }

        [TestMethod]
        public void TestHandSorting()
        {
            // Arrange - Create hand from string
            Hand hand = new Hand("5D 7H 2H AH 10S");

            // Act - Sort hand
            hand.Sort();

            // Assert - Check sorted order
            int previousNumber = 0;
            foreach (var card in hand.Cards)
            {
                Assert.IsTrue(previousNumber <= card.Number,
                    $"Expected {card.Number} to be greater than or equal to {previousNumber}.");
                previousNumber = card.Number;
            }
        }

        [TestMethod]
        public void TestStringToHand()
        {
            // Expected cards
            Card[] expectedCards =
            {
                new Card(8, Suit.CLUBS),
                new Card(10, Suit.SPADES),
                new Card(13, Suit.CLUBS),
                new Card(9, Suit.HEARTS),
                new Card(4, Suit.SPADES)
            };

            // Act - Create hand from string
            Hand hand = new Hand("8C TS KC 9H 4S");

            // Ensure correct number of cards
            Assert.AreEqual(expectedCards.Length, hand.Cards.Length, "Mismatch in number of cards.");

            // Check each card matches expected values
            for (int i = 0; i < expectedCards.Length; i++)
            {
                Assert.AreEqual(expectedCards[i].Number, hand.Cards[i].Number,
                    $"Card {i} number mismatch: Expected {expectedCards[i].Number}, Got {hand.Cards[i].Number}");

                Assert.AreEqual(expectedCards[i].Suit, hand.Cards[i].Suit,
                    $"Card {i} suit mismatch: Expected {expectedCards[i].Suit}, Got {hand.Cards[i].Suit}");
            }
        }

        [TestMethod]
        public void TestAdminCanOpenTable()
        {
            User admin = new User("AdminUser", new List<User_Role> { User_Role.ADMIN });
            Assert.IsTrue(GameSystem.CanAddTable(admin), "Admin should be able to open a table.");
        }

        [TestMethod]
        public void TestManagerCanOpenTable()
        {
            User manager = new User("ManagerUser", new List<User_Role> { User_Role.MANAGER });
            Assert.IsTrue(GameSystem.CanAddTable(manager), "Manager should be able to open a table.");
        }

        [TestMethod]
        public void TestPlayerCannotOpenTable()
        {
            User player = new User("PlayerUser", new List<User_Role> { User_Role.PLAYER });
            Assert.IsFalse(GameSystem.CanAddTable(player), "Player should not be able to open a table.");
        }

        // 3 testing to check if i get errors if non admin or manneger try to open a table 
        [TestMethod]
        public void TestPlayerCannotOpenTable2()
        {
            // Arrange: Create a player user
            User player = new User("PlayerUser", new List<User_Role> { User_Role.PLAYER });

            // Act & Assert: Check if the player can open a table (should be false)
            Assert.IsTrue(GameSystem.CanAddTable(player), "Player should not be able to open a table.");
        }
        [TestMethod]
        public void TestGuestCannotOpenTable()
        {
            // Arrange: Create a guest user (no roles assigned)
            User guest = new User("GuestUser", new List<User_Role> { });

            // Act & Assert: Check if the guest can open a table (should be false)
            Assert.IsTrue(GameSystem.CanAddTable(guest), "Guest should not be able to open a table.");
        }
        [TestMethod]
        public void TestModeratorCannotOpenTable()
        {
            // Arrange: Create a moderator user
            User moderator = new User("ModeratorUser", new List<User_Role> { User_Role.PLAYER });

            // Act & Assert: Check if the moderator can open a table (should be false)
            Assert.IsFalse(GameSystem.CanAddTable(moderator), "Moderator should not be able to open a table.");
        }
    }
}
