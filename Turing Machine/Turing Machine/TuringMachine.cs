using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine
{
    class TuringMachine
    {
        public List<State> localStates;
        private State localCurState;
        public Tape localTape;

        public TuringMachine()
        {
            localStates = new List<State>();
            localTape = new Tape();

            for (int i = 0; i < 12; i++)
            {
                localStates.Add(new State(i, i >= 11));
            }

            localStates[0].addTransition('a', 'a', State.direction.R, localStates[1]);

            localStates[1].addTransition('a', 'a', State.direction.R, localStates[1]);
            localStates[1].addTransition('b', 'b', State.direction.R, localStates[2]);

            localStates[2].addTransition('b', 'b', State.direction.R, localStates[2]);
            localStates[2].addTransition('c', 'c', State.direction.R, localStates[3]);

            localStates[3].addTransition('c', 'c', State.direction.R, localStates[3]);
            localStates[3].addTransition(' ', ' ', State.direction.L, localStates[4]);

            localStates[4].addTransition('a', 'a', State.direction.L, localStates[4]);
            localStates[4].addTransition('b', 'b', State.direction.L, localStates[4]);
            localStates[4].addTransition('c', 'c', State.direction.L, localStates[4]);
            localStates[4].addTransition(' ', ' ', State.direction.R, localStates[5]);

            localStates[5].addTransition('a', 'x', State.direction.R, localStates[6]);
            localStates[5].addTransition('b', 'b', State.direction.R, localStates[10]);

            localStates[6].addTransition('a', 'a', State.direction.R, localStates[6]);
            localStates[6].addTransition('b', 'y', State.direction.R, localStates[7]);
            localStates[6].addTransition('z', 'z', State.direction.L, localStates[9]);

            localStates[7].addTransition('b', 'b', State.direction.R, localStates[7]);
            localStates[7].addTransition('z', 'z', State.direction.R, localStates[7]);
            localStates[7].addTransition('c', 'z', State.direction.L, localStates[8]);

            localStates[8].addTransition('b', 'b', State.direction.L, localStates[8]);
            localStates[8].addTransition('z', 'z', State.direction.L, localStates[8]);
            localStates[8].addTransition('y', 'y', State.direction.R, localStates[6]);

            localStates[9].addTransition('y', 'b', State.direction.L, localStates[9]);
            localStates[9].addTransition('a', 'a', State.direction.L, localStates[9]);
            localStates[9].addTransition('x', 'x', State.direction.R, localStates[5]);

            localStates[10].addTransition('b', 'b', State.direction.R, localStates[10]);
            localStates[10].addTransition('z', 'z', State.direction.R, localStates[10]);
            localStates[10].addTransition(' ', ' ', State.direction.R, localStates[11]);
        }

        public List<State> visualize(string text)
        {
            string newText;
            localCurState = localStates[0];
            State localNextState;
            int i = 1;
            List<State> ret;
            ret = new List<State>();
            text = text.Insert(0, " ");
            text = text + " ";
            while (!localCurState.final)
            {
                ret.Add(localCurState);
                if (localCurState.transition.ContainsKey(text[i]))
                {
                    localNextState = localCurState.transition[text[i]].Item3;
                    newText = text.Substring(0, i) + localCurState.transition[text[i]].Item1 + text.Substring(i + 1);
                    if (localCurState.transition[text[i]].Item2 == State.direction.L)
                    {
                        i--;
                    }
                    else if (localCurState.transition[text[i]].Item2 == State.direction.R)
                    {
                        i++;
                    }
                    text = newText;
                    localCurState = localNextState;
                }
                else
                {
                    break;
                }
            }
            if (localCurState.final)
            {
                ret.Add(localCurState);
            }
                
            return ret;
        }

        /*
        string input;
        bool Q0(int index)
        {
            if (input[index] == 'a')
                return Q1(index + 1);
            return false;
        }
        bool Q1(int index)
        {
            if (index >= input.Length)
                return false;
            if (input[index] == 'a')
                return Q1(index + 1);
            if (input[index] == 'b')
                return Q2(index + 1);
            return false;
        }
        bool Q2(int index)
        {
            if (index >= input.Length)
                return false;
            if (input[index] == 'b')
                return Q2(index + 1);
            if (input[index] == 'c')
                return Q3(index + 1);
            return false;
        }
        bool Q3(int index)
        {
            if (index == input.Length)
                return Q4(index - 1);
            if (input[index] == 'c')
                return Q3(index + 1);
            return false;
        }
        bool Q4(int index)
        {
            if (index == -1)
                return Q5(index + 1);
            if (input[index] == 'a' || input[index] == 'b' || input[index] == 'c')
                return Q4(index - 1);
            return false;
        }
        bool Q5(int index)
        {
            if (index >= input.Length)
                return false;
            if (input[index] == 'a')
            {
                input = input.Remove(index, 1).Insert(index, "x");
                return Q6(index + 1);
            }
            if (input[index] == 'b')
                return Q10(index + 1);

            return false;
        }
        bool Q6(int index)
        {
            if (index >= input.Length)
                return false;
            if (input[index] == 'a')
                return Q6(index + 1);

            if (input[index] == 'b')
            {
                input = input.Remove(index, 1).Insert(index, "y");
                return Q7(index + 1);
            }
            if (input[index] == 'z')
                return Q9(index - 1);

            return false;
        }


        bool Q7(int index)
        {
            if (index >= input.Length)
                return false;
            if (input[index] == 'b' || input[index] == 'z')
                return Q7(index + 1);

            if (input[index] == 'c')
            {
                input = input.Remove(index, 1).Insert(index, "z");
                return Q8(index - 1);
            }

            return false;
        }

        bool Q8(int index)
        {
            if (index <= -1)
                return false;
            if (input[index] == 'b' || input[index] == 'z')
                return Q8(index - 1);

            if (input[index] == 'y')
                return Q6(index + 1);

            return false;
        }
        bool Q9(int index)
        {
            if (index <= -1)
                return false;
            if (input[index] == 'y')
            {
                input = input.Remove(index, 1).Insert(index, "b");
                return Q9(index - 1);
            }

            if (input[index] == 'a')
                return Q9(index - 1);
            if (input[index] == 'x')
                return Q5(index + 1);

            return false;
        }
        bool Q10(int index)
        {
            if (index == input.Length)
                return H();
            if (input[index] == 'b' || input[index] == 'z')
                return Q10(index + 1);
            return false;
        }

        bool H()
        {
            return true;
        }


        public bool start(string inp)
        {
            input = inp;
            return Q0(0);
        }
        */
    }
}