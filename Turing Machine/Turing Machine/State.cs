using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine
{
    class State
    {
        public int q;
        public bool final;
        public enum direction {L,R,S};
        public Dictionary<char, Tuple<char, direction, State>> transition;
        public State(int q, bool final)
        {
            this.q = q;
            this.final = final;
            transition = new Dictionary<char, Tuple<char, direction, State>>();
        }

        public void addTransition(char readChar, char writtenChar, direction dir, State nextState)
        {
            transition[readChar] = new Tuple<char, direction, State>(writtenChar, dir, nextState);
        }
    }
}