using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turing_Machine
{
    class Tape
    {
        const int tapeSpace = 300;
        char[] tapeData = new char[tapeSpace];
        const int tapeStart = 20;
        int curPosition;
        public Tape()
        {
            for(int i=0;i<tapeSpace;i++)
            {
                tapeData[i] = '$';
            }
            curPosition = tapeStart;
        }
        public void setTapeState(string input)
        {
            for (int i = tapeStart; i < tapeStart + input.Length; i++)
            {
                tapeData[i] = input[i - tapeStart];
            }
        }

        public string getTapeState()
        {
            return new string(tapeData);
        }

        public int getCurPosition()
        {
            return curPosition;
        }

        public void replace(char newChar)
        {
            tapeData[curPosition] = newChar;
        }

        public void turnLeft()
        {
            curPosition--;
        }

        public void turnRight()
        {
            curPosition++;
        }
    }
}
