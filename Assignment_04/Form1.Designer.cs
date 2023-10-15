namespace Calculator
{
    partial class Form1
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
            this.outputText = new System.Windows.Forms.TextBox();
            this.divide = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.nine = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Button();
            this.seven = new System.Windows.Forms.Button();
            this.four = new System.Windows.Forms.Button();
            this.undobtn = new System.Windows.Forms.Button();
            this.equal = new System.Windows.Forms.Button();
            this.dotbtn = new System.Windows.Forms.Button();
            this.historyText = new System.Windows.Forms.TextBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.openBracketbtn = new System.Windows.Forms.Button();
            this.closeBracketbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // outputText
            // 
            this.outputText.BackColor = System.Drawing.Color.DimGray;
            this.outputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputText.ForeColor = System.Drawing.SystemColors.Window;
            this.outputText.Location = new System.Drawing.Point(12, 13);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.Size = new System.Drawing.Size(315, 64);
            this.outputText.TabIndex = 1;
            this.outputText.TextChanged += new System.EventHandler(this.outputText_TextChanged);
            // 
            // divide
            // 
            this.divide.Location = new System.Drawing.Point(277, 380);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(50, 48);
            this.divide.TabIndex = 2;
            this.divide.Text = "/";
            this.divide.UseVisualStyleBackColor = true;
            this.divide.Click += new System.EventHandler(this.divide_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(277, 270);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(50, 48);
            this.minus.TabIndex = 3;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // multiply
            // 
            this.multiply.Location = new System.Drawing.Point(277, 326);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(50, 48);
            this.multiply.TabIndex = 4;
            this.multiply.Text = "x";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.Click += new System.EventHandler(this.multiply_Click);
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(277, 216);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(50, 48);
            this.plus.TabIndex = 5;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // three
            // 
            this.three.Location = new System.Drawing.Point(221, 216);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(50, 48);
            this.three.TabIndex = 9;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            this.three.Click += new System.EventHandler(this.three_Click);
            // 
            // nine
            // 
            this.nine.Location = new System.Drawing.Point(221, 326);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(50, 48);
            this.nine.TabIndex = 8;
            this.nine.Text = "9";
            this.nine.UseVisualStyleBackColor = true;
            this.nine.Click += new System.EventHandler(this.nine_Click);
            // 
            // six
            // 
            this.six.Location = new System.Drawing.Point(221, 270);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(50, 48);
            this.six.TabIndex = 7;
            this.six.Text = "6";
            this.six.UseVisualStyleBackColor = true;
            this.six.Click += new System.EventHandler(this.six_Click);
            // 
            // zero
            // 
            this.zero.Location = new System.Drawing.Point(221, 380);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(50, 48);
            this.zero.TabIndex = 6;
            this.zero.Text = "0";
            this.zero.UseVisualStyleBackColor = true;
            this.zero.Click += new System.EventHandler(this.zero_Click);
            // 
            // two
            // 
            this.two.Location = new System.Drawing.Point(165, 216);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(50, 48);
            this.two.TabIndex = 13;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            this.two.Click += new System.EventHandler(this.two_Click);
            // 
            // eight
            // 
            this.eight.Location = new System.Drawing.Point(165, 324);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(50, 48);
            this.eight.TabIndex = 12;
            this.eight.Text = "8";
            this.eight.UseVisualStyleBackColor = true;
            this.eight.Click += new System.EventHandler(this.eight_Click);
            // 
            // five
            // 
            this.five.Location = new System.Drawing.Point(165, 270);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(50, 48);
            this.five.TabIndex = 11;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = true;
            this.five.Click += new System.EventHandler(this.five_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(221, 162);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(50, 48);
            this.clearbtn.TabIndex = 10;
            this.clearbtn.Text = "C";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // one
            // 
            this.one.Location = new System.Drawing.Point(109, 216);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(50, 48);
            this.one.TabIndex = 17;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            this.one.Click += new System.EventHandler(this.one_Click);
            // 
            // seven
            // 
            this.seven.Location = new System.Drawing.Point(109, 324);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(50, 48);
            this.seven.TabIndex = 16;
            this.seven.Text = "7";
            this.seven.UseVisualStyleBackColor = true;
            this.seven.Click += new System.EventHandler(this.seven_Click);
            // 
            // four
            // 
            this.four.Location = new System.Drawing.Point(109, 270);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(50, 48);
            this.four.TabIndex = 15;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            this.four.Click += new System.EventHandler(this.four_Click);
            // 
            // undobtn
            // 
            this.undobtn.Location = new System.Drawing.Point(277, 162);
            this.undobtn.Name = "undobtn";
            this.undobtn.Size = new System.Drawing.Size(50, 48);
            this.undobtn.TabIndex = 14;
            this.undobtn.Text = "CE";
            this.undobtn.UseVisualStyleBackColor = true;
            this.undobtn.Click += new System.EventHandler(this.undobtn_Click);
            // 
            // equal
            // 
            this.equal.Location = new System.Drawing.Point(109, 162);
            this.equal.Name = "equal";
            this.equal.Size = new System.Drawing.Size(50, 48);
            this.equal.TabIndex = 18;
            this.equal.Text = "=";
            this.equal.UseVisualStyleBackColor = true;
            this.equal.Click += new System.EventHandler(this.equal_Click);
            // 
            // dotbtn
            // 
            this.dotbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotbtn.Location = new System.Drawing.Point(165, 162);
            this.dotbtn.Name = "dotbtn";
            this.dotbtn.Size = new System.Drawing.Size(50, 48);
            this.dotbtn.TabIndex = 19;
            this.dotbtn.Text = ".";
            this.dotbtn.UseVisualStyleBackColor = true;
            this.dotbtn.Click += new System.EventHandler(this.dotbtn_Click);
            // 
            // historyText
            // 
            this.historyText.Location = new System.Drawing.Point(12, 164);
            this.historyText.Multiline = true;
            this.historyText.Name = "historyText";
            this.historyText.ReadOnly = true;
            this.historyText.Size = new System.Drawing.Size(91, 264);
            this.historyText.TabIndex = 20;
            this.historyText.TextChanged += new System.EventHandler(this.historyText_TextChanged);
            // 
            // inputText
            // 
            this.inputText.BackColor = System.Drawing.Color.DimGray;
            this.inputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputText.ForeColor = System.Drawing.SystemColors.Window;
            this.inputText.Location = new System.Drawing.Point(12, 75);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(315, 63);
            this.inputText.TabIndex = 21;
            this.inputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputText_KeyDown);
            // 
            // openBracketbtn
            // 
            this.openBracketbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openBracketbtn.Location = new System.Drawing.Point(109, 378);
            this.openBracketbtn.Name = "openBracketbtn";
            this.openBracketbtn.Size = new System.Drawing.Size(50, 48);
            this.openBracketbtn.TabIndex = 22;
            this.openBracketbtn.Text = "(";
            this.openBracketbtn.UseVisualStyleBackColor = true;
            this.openBracketbtn.Click += new System.EventHandler(this.openBracketbtn_Click);
            // 
            // closeBracketbtn
            // 
            this.closeBracketbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBracketbtn.Location = new System.Drawing.Point(165, 378);
            this.closeBracketbtn.Name = "closeBracketbtn";
            this.closeBracketbtn.Size = new System.Drawing.Size(50, 48);
            this.closeBracketbtn.TabIndex = 23;
            this.closeBracketbtn.Text = ")";
            this.closeBracketbtn.UseVisualStyleBackColor = true;
            this.closeBracketbtn.Click += new System.EventHandler(this.closeBracketbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(339, 450);
            this.Controls.Add(this.closeBracketbtn);
            this.Controls.Add(this.openBracketbtn);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.historyText);
            this.Controls.Add(this.dotbtn);
            this.Controls.Add(this.equal);
            this.Controls.Add(this.one);
            this.Controls.Add(this.seven);
            this.Controls.Add(this.four);
            this.Controls.Add(this.undobtn);
            this.Controls.Add(this.two);
            this.Controls.Add(this.eight);
            this.Controls.Add(this.five);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.three);
            this.Controls.Add(this.nine);
            this.Controls.Add(this.six);
            this.Controls.Add(this.zero);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.divide);
            this.Controls.Add(this.outputText);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button divide;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button multiply;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button one;
        private System.Windows.Forms.Button seven;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button undobtn;
        private System.Windows.Forms.Button equal;
        private System.Windows.Forms.Button dotbtn;
        private System.Windows.Forms.TextBox historyText;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button openBracketbtn;
        private System.Windows.Forms.Button closeBracketbtn;
    }
}

