using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins, losses, ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        public Form1()
        {
            InitializeComponent();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            playerImage.Image = rockImage;
            ComputerTurn();
            DetermineWinner();
            RoundOver();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.Image = paperImage;
            ComputerTurn();
            DetermineWinner();
            RoundOver();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            playerImage.Image = scissorImage;
            ComputerTurn();
            DetermineWinner();
            RoundOver();
        }

        public void ComputerTurn()
        {
            jabPlayer.Play();
            int choice = randGen.Next(1, 4);

            if (choice == 1)
            {
                cpuChoice = "rock";
                cpuImage.Image = rockImage;
            }
            else if (choice == 2)
            {
                cpuChoice = "paper";
                cpuImage.Image = paperImage;
            }
            else
            {
                cpuChoice = "scissor";
                cpuImage.Image = scissorImage;
            }
        }

        public void RoundOver()
        {
            playerImage.Refresh();
            cpuImage.Refresh();
            resultImage.Refresh();
            Thread.Sleep(choicePause);
            gongPlayer.Play();
            Thread.Sleep(outcomePause);
            playerImage.Image = null;
            cpuImage.Image = null;
            resultImage.Image = null;
        }

        public void DetermineWinner()
        {
            if ((playerChoice == "rock" && cpuChoice == "scissor") || (playerChoice == "paper" && cpuChoice == "rock") || (playerChoice == "scissor" && cpuChoice == "paper"))
            {
                resultImage.Image = winImage;
                wins++;
                winsLabel.Text = $"Wins: {wins}";
            }
            else if ((playerChoice == "rock" && cpuChoice == "paper") || (playerChoice == "paper" && cpuChoice == "scissor") || (playerChoice == "scissor" && cpuChoice == "rock"))
            {
                resultImage.Image = loseImage;
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
            }
            else if ((playerChoice == "rock" && cpuChoice == "rock") || (playerChoice == "paper" && cpuChoice == "paper") || (playerChoice == "scissor" && cpuChoice == "scissor"))
            {
                resultImage.Image = tieImage;
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
            }
        }
    }
}