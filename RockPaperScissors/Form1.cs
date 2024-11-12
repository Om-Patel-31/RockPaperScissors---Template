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

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins, losses, ties = 0;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        public Form1()
        {
            InitializeComponent();
        }

        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            playerImage.Image = Properties.Resources.rock168x280;
            ComputerTurn();
            DetermineWinner();
        }

        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.Image = Properties.Resources.paper168x280;
            ComputerTurn();
            DetermineWinner();
        }

        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            playerImage.Image = Properties.Resources.scissors168x280;
            ComputerTurn();
            DetermineWinner();
        }

        public void ComputerTurn()
        {
            jabPlayer.Play();
            int choice = randGen.Next(1, 4);

            if (choice == 1)
            {
                cpuChoice = "rock";
                cpuImage.Image = Properties.Resources.rock168x280;
            }
            else if (choice == 2)
            {
                cpuChoice = "paper";
                cpuImage.Image = Properties.Resources.paper168x280; ;
            }
            else
            {
                cpuChoice = "scissor";
                cpuImage.Image = Properties.Resources.scissors168x280;
            }
        }

        public void DetermineWinner()
        {
            if ((playerChoice == "rock" && cpuChoice == "scissor") || (playerChoice == "paper" && cpuChoice == "rock") || (playerChoice == "scissor" && cpuChoice == "paper"))
            {
                resultImage.Image = Properties.Resources.winTrans;
                wins++;
                winsLabel.Text = $"Wins: {wins}";
            }
            else if ((playerChoice == "rock" && cpuChoice == "paper") || (playerChoice == "paper" && cpuChoice == "scissor") || (playerChoice == "scissor" && cpuChoice == "rock"))
            {
                resultImage.Image = Properties.Resources.loseTrans;
                losses++;
                lossesLabel.Text = $"Losses: {losses}";
            }
            else if ((playerChoice == "rock" && cpuChoice == "rock") || (playerChoice == "paper" && cpuChoice == "paper") || (playerChoice == "scissor" && cpuChoice == "scissor"))
            {
                resultImage.Image = Properties.Resources.tieTrans;
                ties++;
                tiesLabel.Text = $"Ties: {ties}";
            }
            playerImage.Refresh();
            cpuImage.Refresh();
            resultImage.Refresh();
            Thread.Sleep(1000);
            gongPlayer.Play();
            Thread.Sleep(2000);
            playerImage.Image = null;
            cpuImage.Image = null;
            resultImage.Image = null;
        }
    }
}