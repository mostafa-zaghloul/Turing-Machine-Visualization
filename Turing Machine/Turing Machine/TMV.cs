using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turing_Machine
{
    public partial class TMV : Form
    {
        TuringMachine TM;
        Graphics g;
        List<Point> statePosition;
        List<State> statesList;
        Pen blackPen, redPen, bluePen;
        int curStateId = -1, prevStateId = -1;
        int curStateIndex;
        enum orientation {North,South,East,West};

        public TMV()
        {
            InitializeComponent();
            TM = new TuringMachine();
            initStatePositions();
        }
        // states positions
        private void initStatePositions()
        {
            statePosition = new List<Point>(11);
            statePosition.Add(new Point(100, 100));
            statePosition.Add(new Point(300, 100));
            statePosition.Add(new Point(500, 100));
            statePosition.Add(new Point(700, 100));
            statePosition.Add(new Point(900, 100));
            statePosition.Add(new Point(85, 260));
            statePosition.Add(new Point(300, 290));
            statePosition.Add(new Point(540, 270));
            statePosition.Add(new Point(660, 420));
            statePosition.Add(new Point(400, 440));
            statePosition.Add(new Point(100, 450));
            statePosition.Add(new Point(300, 520));

        }

        public void tapeRefresh()
        {
            tapeRichTextBox.Text = TM.localTape.getTapeState();
            tapeRichTextBox.SelectionStart = TM.localTape.getCurPosition();
            tapeRichTextBox.SelectionLength = 1;
            tapeRichTextBox.SelectionColor = Color.Red;
            tapeRichTextBox.SelectionBackColor = Color.Yellow;
        }
        private void TMVPanel_Paint(object sender, PaintEventArgs e)
        {
            blackPen = new Pen(Color.FromArgb(0, 0, 0));
            redPen = new Pen(Color.Red);
            bluePen = new Pen(Color.Blue);
            g = TMVPanel.CreateGraphics();


            blackPen.Width = 3F;
            redPen.Width = 5F;
            bluePen.Width = 5F;

            //draw states
            Point drawPosition;
            for (int i = 0; i < statePosition.Count; i++)
            {
                drawPosition = statePosition[i];
                drawPosition.X -= 25;
                drawPosition.Y -= 25;
                if (i == curStateId)
                    drawState(i, redPen);
                else if (i == prevStateId)
                    drawState(i, bluePen);
                else
                    drawState(i, blackPen);
            }
            
            // write Qs
            for (int i = 0; i < statePosition.Count; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(30, 15);
                lbl.Text = "Q" + i.ToString();
                Point lblPosition = statePosition[i];
                lblPosition.X -= 12;
                lblPosition.Y -= 5;
                lbl.Location = lblPosition;
                TMVPanel.Controls.Add(lbl);
            }

            //draw the arrows
            drawTransition(0, 1, blackPen);
            drawTransition(1, 2, blackPen);
            drawTransition(2, 3, blackPen);
            drawTransition(3, 4, blackPen);
            drawTransition(4, 5, blackPen);
            drawTransition(5, 6, blackPen);
            drawTransition(5, 10, blackPen);
            drawTransition(6, 7, blackPen);
            drawTransition(6, 9, blackPen);
            drawTransition(7, 8, blackPen);
            drawTransition(8, 6, blackPen);
            drawTransition(9, 5, blackPen);
            drawTransition(10, 11, blackPen);

            drawSelfArrow(1,orientation.North, blackPen);
            drawSelfArrow(2,orientation.North, blackPen);
            drawSelfArrow(3,orientation.North, blackPen);
            drawSelfArrow(4,orientation.North, blackPen);
            drawSelfArrow(6,orientation.North, blackPen);
            drawSelfArrow(7,orientation.North, blackPen);
            drawSelfArrow(8, false ? orientation.East : orientation.South, blackPen);
            drawSelfArrow(9, false ? orientation.East : orientation.South, blackPen);
            drawSelfArrow(10, false ? orientation.East : orientation.South, blackPen);

            // write text of each arrows
            drawText(new Point(170, 75), "a,a|R");

            drawText(new Point(290, 40), "a,a|R");
            drawText(new Point(375, 75), "b,b|R");

            drawText(new Point(490, 40), "b,b|R");
            drawText(new Point(577, 75), "c,c|R");

            drawText(new Point(690, 40), "c,c|R");
            drawText(new Point(775, 75), "^,^|L");

            //q4
            drawText(new Point(950, 50), "a,a|L");
            drawText(new Point(950, 70), "b,b|L");
            drawText(new Point(950, 90), "c,c|L");
            drawText(new Point(440, 160), "^,^|R");

            //q5
            drawText(new Point(195, 250), "a,x|R");
            drawText(new Point(28, 350), "b,b|R");

            //q6
            drawText(new Point(290, 233), "a,a|R");
            drawText(new Point(400, 257), "b,y|R");
            drawText(new Point(370, 350), "z,z|L");
            
            //q7
            drawText(new Point(583, 225), "b,b|R");
            drawText(new Point(583, 245), "z,z|R");
            drawText(new Point(610, 320), "c,z|L");

            //q8
            drawText(new Point(650, 470), "b,b|L");
            drawText(new Point(650, 490), "z,z|L");
            drawText(new Point(470, 323), "y,y|R");

            //q9
            drawText(new Point(390, 490), "y,b|L");
            drawText(new Point(390, 510), "a,a|L");
            drawText(new Point(190, 365), "x,x|R");

            //q10
            drawText(new Point(90, 500), "b,b|R");
            drawText(new Point(90, 520), "z,z|R");
            drawText(new Point(170, 450), "^,^|R");
        }
        // draw states function
        private void drawState(int stateID, Pen pen)
        {
            Point drawPosition = statePosition[stateID];
            drawPosition.X -= 25;
            drawPosition.Y -= 25;
            g.DrawEllipse(pen, new Rectangle(drawPosition, new Size(50, 50)));
            //double circule for final state
            if (stateID >= 11)
            {
                drawPosition.X += 5;
                drawPosition.Y += 5;
                pen = new Pen(pen.Color, 3);
                g.DrawEllipse(pen, new Rectangle(drawPosition, new Size(40, 40)));
            }
        }
        private void drawSelfArrow(int state, orientation or, Pen pen)
        {
            pen.Width = 7F;
            pen.EndCap = LineCap.ArrowAnchor;
            Point location = statePosition[state];
            switch (or)
            {
                case orientation.North:
                    location.X -= 15;
                    location.Y -= 40;
                    g.DrawArc(pen, location.X, location.Y, 40F, 40F, 180F, 200F);
                    break;

                case orientation.South:
                    location.X -= 15;
                    g.DrawArc(pen, location.X, location.Y, 40F, 40F, 180F, -200F);
                    break;

                case orientation.East:
                    location.Y -= 20;
                    g.DrawArc(pen, location.X, location.Y, 40F, 40F, 260F, 200F);
                    break;

                case orientation.West:
                    break;
            }

        }
        void drawTransition(int fromState, int toState, Pen pen)
        {
            Pen curPen = new Pen(Color.FromArgb(0, 0, 0), 10F);
            curPen.EndCap = LineCap.ArrowAnchor;
            Point startLocation = statePosition[fromState];
            Point endLocation = statePosition[toState];
            double dx = endLocation.X - startLocation.X;
            double dy = endLocation.Y - startLocation.Y;
            double dist = Math.Sqrt(dx * dx + dy * dy);
            startLocation.X += (int)(25 * (Math.Sin(dx / dist)));
            startLocation.Y += (int)(25 * (Math.Sin(dy / dist)));
            endLocation.X += (int)(25 * (Math.Sin(-dx / dist)));
            endLocation.Y += (int)(25 * (Math.Sin(-dy / dist)));
            g.DrawLine(curPen, startLocation, endLocation);
        }

        void drawText(Point position, string text)
        {
            Label label = new Label();
            label.Size = new Size(70, 20);
            Point lblPosition = position;
            Font font = new Font("Elephant", 12);
            label.Text = text;
            lblPosition.X -= 10;
            lblPosition.Y -= 5;
            label.Location = lblPosition;
            label.Font = font;
            TMVPanel.Controls.Add(label);
        }

        private void visualizeButton_Click(object sender, EventArgs e)
        {
            bool validText = true;
            for (int i = 0; i < inputTextBox.Text.Length; i++)
            {
                if (inputTextBox.Text[i] != 'a' && inputTextBox.Text[i] != 'b' && inputTextBox.Text[i] != 'c')
                {
                    MessageBox.Show(" Invalid Input");
                    validText = false;
                    inputTextBox.Text = "";
                    resultTextBox.BackColor = Color.White;
                    resultTextBox.Text = "";
                    break;
                }
            }

            if (validText)
            {
                TM.localTape = new Tape();
                TM.localTape.setTapeState(inputTextBox.Text);
                tapeRefresh();
                statesList = TM.visualize(inputTextBox.Text);
                curStateIndex = 0;
                curStateId = prevStateId = statesList[0].q;
                TMVPanel.Refresh();
                resultTextBox.BackColor = Color.White;
                resultTextBox.Text = "";
            }
        }

        private void oneStepButton_Click(object sender, EventArgs e)
        {
            if (curStateIndex < statesList.Count - 1)
            {
                Tuple<char, State.direction, State> curTransition = statesList[curStateIndex].transition[tapeRichTextBox.Text[TM.localTape.getCurPosition()] == '$' ? ' ' : tapeRichTextBox.Text[TM.localTape.getCurPosition()]];
                TM.localTape.replace(curTransition.Item1 == ' ' ? '$' : curTransition.Item1);
                if (curTransition.Item2 == State.direction.L)
                    TM.localTape.turnLeft();
                else if (curTransition.Item2 == State.direction.R)
                    TM.localTape.turnRight();
                tapeRefresh();
                drawState(prevStateId, blackPen);
                prevStateId = curStateId;
                curStateId = statesList[curStateIndex + 1].q;
                drawState(prevStateId, bluePen);
                drawState(curStateId, redPen);
                curStateIndex++;
                if (curStateIndex == statesList.Count - 1)
                {
                    if (statesList[curStateIndex].final)
                    {
                        resultTextBox.ForeColor = Color.GreenYellow;
                        resultTextBox.BackColor = Color.Green;
                        resultTextBox.Text = "Accepted";
                    }
                    else
                    {
                        resultTextBox.ForeColor = Color.Pink;
                        resultTextBox.BackColor = Color.Red;
                        resultTextBox.Text = "Rejected";
                    }
                }
            }
        }

        private void allStepsButton_Click(object sender, EventArgs e)
        {
            while (curStateIndex < statesList.Count - 1)
            {
                oneStepButton_Click(sender, e);
                TMVPanel.Refresh();
                tapeRichTextBox.Refresh();
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void finalResultButton_Click(object sender, EventArgs e)
        {
            while (curStateIndex < statesList.Count - 1)
            {
                oneStepButton_Click(sender, e);
                //TMVPanel.Refresh();
                //tapeRichTextBox.Refresh();
                //System.Threading.Thread.Sleep(1000);
            }
        }




    }
}
