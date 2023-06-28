﻿/*
The MIT License (MIT)

Copyright (c) 2023 Dai Fukunaga.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Othello
{
    internal class Beginner : Agent
    {
        public Beginner() : base("beginner") { }

        public override State ChooseMove(State current)
        {
            int min = 100;
            List<State> nextStates = new List<State>();
            foreach (State next in current.NextStates())
            {
                int size = next.board.NextMoves(current.player.Other()).Count();
                if (size < min)
                {
                    min = size;
                    nextStates.Clear();
                    nextStates.Add(next);
                }
                else if (size == min)
                {
                    nextStates.Add(next);
                }
                Console.WriteLine(size);
            }
            System.Random random = new System.Random();
            if (nextStates.Count == 0)
            {
            return null;
        }
            Thread.Sleep(1000);
            return nextStates[random.Next(nextStates.Count())];
        }
    }
}
