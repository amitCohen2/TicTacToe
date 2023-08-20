using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeGameLogic;

namespace TicTacToeWinUI
{
    public partial class FormSettings : Form
    {

        private const string k_ComputerRegularLabel = "[Computer]";

        private const string k_ComputerHardLabel = "[Computer Hard]";

        public string ComputerHard { get { return k_ComputerHardLabel; } }
        public string Computer { get { return k_ComputerHardLabel; } }
        private bool m_shouldCloseApplication = true;
        public FormSettings()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2Change(object sender, EventArgs e)
        {
            CheckBox player2CheckBox = sender as CheckBox;
            if (player2CheckBox.Checked)
            {
                textBoxPlayer2.Enabled = true;
                textBoxPlayer2.Text = null;
                radioButtonComputerHard.Enabled = false;
                radioButtonComputerRegular.Enabled = false;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = (radioButtonComputerHard.Checked) ? k_ComputerHardLabel : k_ComputerRegularLabel;
                radioButtonComputerHard.Enabled = true;
                radioButtonComputerRegular.Enabled = true;
            }
        }
        private void FormSettings_Load(object sender, EventArgs e)
        {

        }


        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown rowsUpDown = sender as NumericUpDown;

            if (rowsUpDown.Value != numericUpDownCols.Value)
            {
                numericUpDownCols.Value = rowsUpDown.Value;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void radioButtonComputerHard_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton computerHardRadioButton = sender as RadioButton;

            if (computerHardRadioButton.Checked)
            {
                textBoxPlayer2.Text = k_ComputerHardLabel;
            }
            else
            {
                textBoxPlayer2.Text = k_ComputerRegularLabel;
            }
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {

            NumericUpDown colsUpDown = sender as NumericUpDown;

            if (colsUpDown.Value != numericUpDownRows.Value)
            {
                numericUpDownRows.Value = colsUpDown.Value;
            }
        }


        public ePlayerType Player2Type
        {
            get
            {
                ePlayerType playerType = ePlayerType.Computer;
                if (checkBoxPlayer2.Checked)
                {
                    playerType = ePlayerType.Human;
                }
                else
                {
                    playerType = (radioButtonComputerHard.Checked) ? ePlayerType.ComputerHard : ePlayerType.Computer;
                }

                return playerType;
            }
        }

        public int BoardCols
        {
            get
            {
                return (int)numericUpDownCols.Value;
            }
        }

        public int BoardRows
        {
            get
            {
                return (int)numericUpDownRows.Value;
            }
        }

        public string Player1Name
        {
            get
            {
                return textBoxPlayer1.Text;
            }
        }

        public string Player2Name
        {
            get
            {
                return textBoxPlayer2.Text;
            }
        }

        private bool isValidName(string i_PlayerName, ref string r_ErrorMessage)
        {
            bool validName = true;

            if (string.IsNullOrEmpty(i_PlayerName))
            {
                validName = false;
                r_ErrorMessage = "Error: Player name is empty!";
            }
            else if (textBoxPlayer2.Text == textBoxPlayer1.Text)
            {
                validName = false;
                r_ErrorMessage = "Error: both players have the same name!";
            }


            return validName;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (!isValidName(textBoxPlayer1.Text, ref errorMessage) || !isValidName(textBoxPlayer2.Text, ref errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                m_shouldCloseApplication = false;
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the user is closing the form
            if (e.CloseReason == CloseReason.UserClosing && m_shouldCloseApplication)
            {
                // Stop the code by terminating the application
                Application.Exit();
            }
        }

    }
}
