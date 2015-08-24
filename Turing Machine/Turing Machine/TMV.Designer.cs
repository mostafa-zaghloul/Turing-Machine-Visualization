namespace Turing_Machine
{
    partial class TMV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.allStepsButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.oneStepButton = new System.Windows.Forms.Button();
            this.visualizeButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.TMVPanel = new System.Windows.Forms.Panel();
            this.tapeRichTextBox = new System.Windows.Forms.RichTextBox();
            this.finalResultButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.finalResultButton);
            this.panel1.Controls.Add(this.allStepsButton);
            this.panel1.Controls.Add(this.resultTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.oneStepButton);
            this.panel1.Controls.Add(this.visualizeButton);
            this.panel1.Controls.Add(this.label);
            this.panel1.Controls.Add(this.inputTextBox);
            this.panel1.Location = new System.Drawing.Point(1030, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 607);
            this.panel1.TabIndex = 3;
            // 
            // allStepsButton
            // 
            this.allStepsButton.Location = new System.Drawing.Point(61, 255);
            this.allStepsButton.Name = "allStepsButton";
            this.allStepsButton.Size = new System.Drawing.Size(86, 28);
            this.allStepsButton.TabIndex = 15;
            this.allStepsButton.Text = "All in One";
            this.allStepsButton.UseVisualStyleBackColor = true;
            this.allStepsButton.Click += new System.EventHandler(this.allStepsButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultTextBox.Location = new System.Drawing.Point(11, 376);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(179, 39);
            this.resultTextBox.TabIndex = 14;
            this.resultTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Result";
            // 
            // oneStepButton
            // 
            this.oneStepButton.Location = new System.Drawing.Point(61, 211);
            this.oneStepButton.Name = "oneStepButton";
            this.oneStepButton.Size = new System.Drawing.Size(86, 28);
            this.oneStepButton.TabIndex = 12;
            this.oneStepButton.Text = "One Step";
            this.oneStepButton.UseVisualStyleBackColor = true;
            this.oneStepButton.Click += new System.EventHandler(this.oneStepButton_Click);
            // 
            // visualizeButton
            // 
            this.visualizeButton.Location = new System.Drawing.Point(11, 83);
            this.visualizeButton.Name = "visualizeButton";
            this.visualizeButton.Size = new System.Drawing.Size(86, 28);
            this.visualizeButton.TabIndex = 11;
            this.visualizeButton.Text = "Visualize";
            this.visualizeButton.UseVisualStyleBackColor = true;
            this.visualizeButton.Click += new System.EventHandler(this.visualizeButton_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(8, 20);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(33, 13);
            this.label.TabIndex = 10;
            this.label.Text = "Input";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(11, 48);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(179, 20);
            this.inputTextBox.TabIndex = 9;
            // 
            // TMVPanel
            // 
            this.TMVPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TMVPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TMVPanel.Location = new System.Drawing.Point(12, 12);
            this.TMVPanel.Name = "TMVPanel";
            this.TMVPanel.Size = new System.Drawing.Size(1012, 563);
            this.TMVPanel.TabIndex = 4;
            this.TMVPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.TMVPanel_Paint);
            // 
            // tapeRichTextBox
            // 
            this.tapeRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tapeRichTextBox.Location = new System.Drawing.Point(12, 581);
            this.tapeRichTextBox.Multiline = false;
            this.tapeRichTextBox.Name = "tapeRichTextBox";
            this.tapeRichTextBox.ReadOnly = true;
            this.tapeRichTextBox.Size = new System.Drawing.Size(1012, 38);
            this.tapeRichTextBox.TabIndex = 6;
            this.tapeRichTextBox.Text = "";
            // 
            // finalResultButton
            // 
            this.finalResultButton.Location = new System.Drawing.Point(61, 298);
            this.finalResultButton.Name = "finalResultButton";
            this.finalResultButton.Size = new System.Drawing.Size(86, 28);
            this.finalResultButton.TabIndex = 16;
            this.finalResultButton.Text = "Final Result";
            this.finalResultButton.UseVisualStyleBackColor = true;
            this.finalResultButton.Click += new System.EventHandler(this.finalResultButton_Click);
            // 
            // TMV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 631);
            this.Controls.Add(this.tapeRichTextBox);
            this.Controls.Add(this.TMVPanel);
            this.Controls.Add(this.panel1);
            this.Name = "TMV";
            this.Text = "Turing Machine Visualization";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel TMVPanel;
        private System.Windows.Forms.Button visualizeButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button oneStepButton;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tapeRichTextBox;
        private System.Windows.Forms.Button allStepsButton;
        private System.Windows.Forms.Button finalResultButton;
    }
}

