using NUnit.Framework;
using UnityEngine.Networking;

namespace Tests
{
    public class TurnShould
    {
        private Turn turn;

        [SetUp]
        public void Before()
        {
            turn = new Turn();
        }

        [Test]
        public void Return_is_strike_true_if_first_shoot_equals_10()
        {
            //When
            turn.Shoot(10);
            //Then
            Assert.IsTrue(turn.IsStrike);
        }

        [Test]
        public void Return_is_strike_false_if_first_shoot_is_less_than_10()
        {
            //When
            turn.Shoot(9);
            //Then
            Assert.IsFalse(turn.IsStrike);
        }

        [Test]
        public void Return_is_spare_true_if_is_not_strike_and_the_sum_of_first_and_second_shot_is_equal_to_10()
        {
            //When
            turn.Shoot(9);
            turn.Shoot(1);

            //Assert
            Assert.IsTrue(turn.IsSpare);
        }

        [Test]
        public void Return_is_spare_false_if_is_strike_is_true()
        {
            //When
            turn.Shoot(10);

            //Assert
            Assert.IsFalse(turn.IsSpare);
        }

        [Test]
        public void Return_is_spare_false_if_is_strike_is_false_and_the_sum_of_first_and_second_shoot_is_less_than_10()
        {
            //When
            turn.Shoot(7);
            turn.Shoot(1);

            //Then
            Assert.IsFalse(turn.IsSpare);
        }

        [TestCase(5, 5, 0, 4, 3, 2)]
        [TestCase(6, 3, 3, 1, 0)]
        public void Ignore_shoots_after_the_second_shoot(int expected, params int[] shoots)
        {
            //When
            foreach (var shoot in shoots)
            {
                turn.Shoot(shoot);
            }

            var result = turn.Score;
            //Then
            Assert.AreEqual(expected, result);
        }

        [TestCase(10, 10)]
        [TestCase(5, 6)]
        [TestCase(20)]
        public void Not_return_more_than_10_as_result(params int[] shoots)
        {
            //When
            foreach (var shoot in shoots)
            {
                turn.Shoot(shoot);
            }

            //Then
            Assert.IsTrue(turn.Score <= 10);
        }

        [TestCase(-10)]
        [TestCase(10, -20)]
        [TestCase(-5, -5)]
        public void Not_return_less_than_0_as_result(params int[] shoots)
        {
            //When
            foreach (var shoot in shoots)
            {
                turn.Shoot(shoot);
            }
            //Then
            Assert.IsTrue(turn.Score >= 0);
        }
    }
}