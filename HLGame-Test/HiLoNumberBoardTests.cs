﻿using HLGame.Interface;
using HLGame.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HLGame_Test
{
    public class HiLoNumberBoardTests
    {
        INumberGenerator generator;
        private const int NumberOfRounds = 10;

        public HiLoNumberBoardTests()
        {
            generator = new NumberGenerator_RandomNumbers_DifferFromPrevious();
        }



        [Fact]
        public void HiLoNumberBoard_Has_Numbers_Generated()
        {
            var board = new HiLoNumbersBoard(generator);

            Assert.True(board.Numbers.Length > 0);
        }

        [Fact]
        public void HiLoNumberBoard_Should_Have_One_Number_Revealead()
        {
            var board = new HiLoNumbersBoard(generator);

            Assert.Single(board.RevealedNumbers);
        }

        [Fact]
        public void HiLoNumberBoard_Should_Change_Number_NextNumber()
        {
            var board = new HiLoNumbersBoard(generator);

            Assert.NotEqual(board.NextNumber(), board.CurrentNumber());
        }

        [Fact]
        public void HiLoNumberBoard_Should_Change_Number_NextNumber_MoveToNextNumber()
        {
            var board = new HiLoNumbersBoard(generator);

            while (board.NextNumber() > -1)
            {
                board.MoveToNextNumber();

                Assert.NotEqual(board.NextNumber(), board.CurrentNumber());
            }
        }

        [Fact]
        public void HiLoNumberBoard_Should_Have_Ten_Answers_Revelead()
        {
            var board = new HiLoNumbersBoard(generator);

            bool HasNumber = false;
            do
            {
                HasNumber = board.MoveToNextNumber();
            } while (HasNumber);


            Assert.Equal(NumberOfRounds, board.RevealedNumbers.Count);
        }




    }
}
