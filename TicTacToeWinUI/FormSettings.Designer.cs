namespace TicTacToeWinUI
{
    partial class FormSettings
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
            labelPlayers = new System.Windows.Forms.Label();
            labelPlayer1 = new System.Windows.Forms.Label();
            textBoxPlayer1 = new System.Windows.Forms.TextBox();
            textBoxPlayer2 = new System.Windows.Forms.TextBox();
            checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            labelBoardSize = new System.Windows.Forms.Label();
            labelRows = new System.Windows.Forms.Label();
            numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            labelCols = new System.Windows.Forms.Label();
            buttonStart = new System.Windows.Forms.Button();
            radioButtonComputerRegular = new System.Windows.Forms.RadioButton();
            radioButtonComputerHard = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCols).BeginInit();
            SuspendLayout();
            // 
            // labelPlayers
            // 
            labelPlayers.AutoSize = true;
            labelPlayers.Location = new System.Drawing.Point(12, 13);
            labelPlayers.Name = "labelPlayers";
            labelPlayers.Size = new System.Drawing.Size(58, 20);
            labelPlayers.TabIndex = 0;
            labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            labelPlayer1.AutoSize = true;
            labelPlayer1.Location = new System.Drawing.Point(30, 48);
            labelPlayer1.Name = "labelPlayer1";
            labelPlayer1.Size = new System.Drawing.Size(70, 20);
            labelPlayer1.TabIndex = 1;
            labelPlayer1.Text = "Players 1:";
            // 
            // textBoxPlayer1
            // 
            textBoxPlayer1.Location = new System.Drawing.Point(128, 48);
            textBoxPlayer1.Name = "textBoxPlayer1";
            textBoxPlayer1.Size = new System.Drawing.Size(148, 27);
            textBoxPlayer1.TabIndex = 3;
            // 
            // textBoxPlayer2
            // 
            textBoxPlayer2.Enabled = false;
            textBoxPlayer2.Location = new System.Drawing.Point(128, 83);
            textBoxPlayer2.Name = "textBoxPlayer2";
            textBoxPlayer2.Size = new System.Drawing.Size(148, 27);
            textBoxPlayer2.TabIndex = 4;
            textBoxPlayer2.Tag = "";
            textBoxPlayer2.Text = "[Computer]";
            textBoxPlayer2.TextChanged += textBoxPlayer2_TextChanged;
            // 
            // checkBoxPlayer2
            // 
            checkBoxPlayer2.AutoSize = true;
            checkBoxPlayer2.Location = new System.Drawing.Point(30, 85);
            checkBoxPlayer2.Name = "checkBoxPlayer2";
            checkBoxPlayer2.Size = new System.Drawing.Size(86, 24);
            checkBoxPlayer2.TabIndex = 5;
            checkBoxPlayer2.Text = "Player 2:";
            checkBoxPlayer2.UseVisualStyleBackColor = true;
            checkBoxPlayer2.CheckedChanged += checkBoxPlayer2Change;
            // 
            // labelBoardSize
            // 
            labelBoardSize.AutoSize = true;
            labelBoardSize.Location = new System.Drawing.Point(12, 151);
            labelBoardSize.Name = "labelBoardSize";
            labelBoardSize.Size = new System.Drawing.Size(83, 20);
            labelBoardSize.TabIndex = 6;
            labelBoardSize.Text = "Board Size:";
            // 
            // labelRows
            // 
            labelRows.AutoSize = true;
            labelRows.Location = new System.Drawing.Point(30, 186);
            labelRows.Name = "labelRows";
            labelRows.Size = new System.Drawing.Size(47, 20);
            labelRows.TabIndex = 7;
            labelRows.Text = "Rows:";
            // 
            // numericUpDownRows
            // 
            numericUpDownRows.Location = new System.Drawing.Point(92, 186);
            numericUpDownRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownRows.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownRows.Name = "numericUpDownRows";
            numericUpDownRows.Size = new System.Drawing.Size(45, 27);
            numericUpDownRows.TabIndex = 8;
            numericUpDownRows.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownRows.ValueChanged += numericUpDownRows_ValueChanged;
            // 
            // numericUpDownCols
            // 
            numericUpDownCols.Location = new System.Drawing.Point(231, 184);
            numericUpDownCols.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownCols.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownCols.Name = "numericUpDownCols";
            numericUpDownCols.Size = new System.Drawing.Size(45, 27);
            numericUpDownCols.TabIndex = 9;
            numericUpDownCols.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDownCols.ValueChanged += numericUpDownCols_ValueChanged;
            // 
            // labelCols
            // 
            labelCols.AutoSize = true;
            labelCols.Location = new System.Drawing.Point(176, 186);
            labelCols.Name = "labelCols";
            labelCols.Size = new System.Drawing.Size(40, 20);
            labelCols.TabIndex = 10;
            labelCols.Text = "Cols:";
            // 
            // buttonStart
            // 
            buttonStart.Location = new System.Drawing.Point(30, 235);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new System.Drawing.Size(246, 31);
            buttonStart.TabIndex = 11;
            buttonStart.Text = "Start!";
            buttonStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // radioButtonComputerRegular
            // 
            radioButtonComputerRegular.AutoSize = true;
            radioButtonComputerRegular.Checked = true;
            radioButtonComputerRegular.Location = new System.Drawing.Point(42, 119);
            radioButtonComputerRegular.Name = "radioButtonComputerRegular";
            radioButtonComputerRegular.Size = new System.Drawing.Size(124, 24);
            radioButtonComputerRegular.TabIndex = 12;
            radioButtonComputerRegular.TabStop = true;
            radioButtonComputerRegular.Text = "Regular Game";
            radioButtonComputerRegular.UseVisualStyleBackColor = true;
            // 
            // radioButtonComputerHard
            // 
            radioButtonComputerHard.AutoSize = true;
            radioButtonComputerHard.Location = new System.Drawing.Point(170, 119);
            radioButtonComputerHard.Name = "radioButtonComputerHard";
            radioButtonComputerHard.Size = new System.Drawing.Size(106, 24);
            radioButtonComputerHard.TabIndex = 13;
            radioButtonComputerHard.Text = "Hard Game";
            radioButtonComputerHard.UseVisualStyleBackColor = true;
            radioButtonComputerHard.CheckedChanged += radioButtonComputerHard_CheckedChanged;
            // 
            // FormSettings
            // 
            AcceptButton = buttonStart;
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            ClientSize = new System.Drawing.Size(300, 283);
            Controls.Add(radioButtonComputerHard);
            Controls.Add(radioButtonComputerRegular);
            Controls.Add(buttonStart);
            Controls.Add(labelCols);
            Controls.Add(numericUpDownCols);
            Controls.Add(numericUpDownRows);
            Controls.Add(labelRows);
            Controls.Add(labelBoardSize);
            Controls.Add(checkBoxPlayer2);
            Controls.Add(textBoxPlayer2);
            Controls.Add(textBoxPlayer1);
            Controls.Add(labelPlayer1);
            Controls.Add(labelPlayers);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormSettings";
            RightToLeft = System.Windows.Forms.RightToLeft.No;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tic Tac Toe Settings";
            FormClosing += FormSettings_FormClosing;
            Load += FormSettings_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCols).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer1;
        private System.Windows.Forms.TextBox textBoxPlayer2;
        private System.Windows.Forms.CheckBox checkBoxPlayer2;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Label labelRows;
        private System.Windows.Forms.NumericUpDown numericUpDownRows;
        private System.Windows.Forms.NumericUpDown numericUpDownCols;
        private System.Windows.Forms.Label labelCols;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.RadioButton radioButtonComputerRegular;
        private System.Windows.Forms.RadioButton radioButtonComputerHard;
    }
}