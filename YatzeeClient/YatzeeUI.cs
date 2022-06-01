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
using Packet;

namespace YatzeeClient
{
    public partial class YatzeeUI : Game
    {

        Dice[] dices= new Dice[5];

        Client client;

        private bool waiting;

        private int rollNumb;

        private int turn;

        string gameName;//name of the game the ui is loged in

        Player currentPlayer;//the player whose turn is current

        public Player CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public string GameName { get => gameName; set => gameName = value; }
        public bool Waiting { get => waiting; set => waiting = value; }
        public int RollNumb { get => rollNumb; set => rollNumb = value; }

        public YatzeeUI(Client client, int playerPosition, string playerName)
        {

            this.client = client;
           
            
            InitializeComponent();
            allocate_Memory();
            //turnLabel.Text = CurrentPlayer.turn.TurnNumber.ToString();

            //players[0].Name = "victor";

            setPlayerInfo(playerPosition, playerName);
            
            
            //this.Text=currentPlayer.position.ToString();
            wait();

        }

        public void receiveChat(String message)
        {
            //MessageBox.Show("Receiving...");
            chatListBox.Items.Add(message);
        }

        private void sendChat(string message)
        {
            string sentMessage = currentPlayer.Name + ": " + message;

            client.sendChat(sentMessage);
        }
        private void setPlayerInfo(int position, string name)
        {
            CurrentPlayer.activatePlayer();
            currentPlayer.Name = name;
            currentPlayer.position =position;
            this.Text = name;
        }

        private void allocate_Memory()
        {
            Waiting = true;
           
            CurrentPlayer = new Player();
            rollNumb = 0;
            turn = 1;
            turnLabel.Text = turn.ToString();

            for (int i=0; i<5; i++)
            {
                dices[i] = new Dice();
            }

        }

        override
        public void start(string extractionDir)
        {

        }

        public void enableRoll()//enables the roll btn
        {
            rollButton.Enabled = true;
        }

        public void disableRoll()//disables the roll btn
        {
            rollButton.Enabled = false;
        }
        private void deallocate_Memory()
        {


            CurrentPlayer = null;


        }

        public void displayNextTurn()
        {
            turn++;
            turnLabel.Text = turn.ToString();
        }
        public void displayScores(Player player, int [] scoreBoard)
        {

            if (scoreBoard[0] > 0)
            {
                player1ScoreLabel.Text = scoreBoard[0].ToString();
                //player1Label.Text = "Player 1";
                
            }
            if (scoreBoard[1] > 0)
            {
                player2ScoreLabel.Text = scoreBoard[1].ToString();
                //player2Label.Text = "Player 2";

            }

            if (scoreBoard[2] > 0)
            {
                player3ScoreLabel.Text = scoreBoard[2].ToString();
                //player3Label.Text = "Player 3";

            }

            if (scoreBoard[3] > 0)
            {
                player4ScoreLabel.Text = scoreBoard[3].ToString();
                //player4Label.Text = "Player 4";

            }

            if (scoreBoard[4] > 0)
            {
                player5ScoreLabel.Text = scoreBoard[4].ToString();
                //player5Label.Text = "Player 5";

            }


            checkForFinish();
            currentPlayer = player;
            //disableButtons();
        }

        internal void setPlayerNames(string[] scoreBoardNames)
        {
            player1Label.Text = scoreBoardNames[0];
            player2Label.Text = scoreBoardNames[1];
            player3Label.Text = scoreBoardNames[2];
            player4Label.Text = scoreBoardNames[3];
            player5Label.Text = scoreBoardNames[4];
        }

        private void player1ScoreDisplay(Player currentPlayer)
        {

            this.currentPlayer = currentPlayer;
            player1ScoreLabel.Text = currentPlayer.Score.ToString();
        }

        private void dice1Display()
        {
            if (dices[0].Value == 1)
            {

                dice1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\1.jpg");
            }
            else if (dices[0].Value == 2)
            {
                dice1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\2.jpg");
            }
            else if (dices[0].Value == 3)
            {
                dice1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\3.jpg");
            }
            else if (dices[0].Value == 4)
            {
                dice1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\4.jpg");
            }
            else if (dices[0].Value == 5)
            {
                dice1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\5.jpg");
            }
            else
            {
                dice1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\6.jpg");
            }

            if (dices[0].Locked)
            {
                lock5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\locked.jpg");
            }
            else
            {
                lock5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\unlocked.jpg");
            }
        }
        private void dice2Display()
        {

            if (dices[1].Value == 1)
            {

                dice2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\1.jpg");
            }
            else if (dices[1].Value == 2)
            {
                dice2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\2.jpg");
            }
            else if (dices[1].Value == 3)
            {
                dice2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\3.jpg");
            }
            else if (dices[1].Value == 4)
            {
                dice2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\4.jpg");
            }
            else if (dices[1].Value == 5)
            {
                dice2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\5.jpg");
            }
            else
            {
                dice2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\6.jpg");
            }

            if (dices[1].Locked)
            {
                lock3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\locked.jpg");
            }
            else
            {
                lock3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\unlocked.jpg");
            }


        }
        private void dice3Display()
        {

            if (dices[2].Value == 1)
            {

                dice3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\1.jpg");
            }
            else if (dices[2].Value == 2)
            {
                dice3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\2.jpg");
            }
            else if (dices[2].Value == 3)
            {
                dice3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\3.jpg");
            }
            else if (dices[2].Value == 4)
            {
                dice3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\4.jpg");
            }
            else if (dices[2].Value == 5)
            {
                dice3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\5.jpg");
            }
            else
            {
                dice3PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\6.jpg");
            }


            if (dices[2].Locked)
            {
                lock4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\locked.jpg");
            }
            else
            {
                lock4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\unlocked.jpg");
            }
        }

        private void dice4Display()
        {

            if (dices[3].Value == 1)
            {

                dice4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\1.jpg");
            }
            else if (dices[3].Value == 2)
            {
                dice4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\2.jpg");
            }
            else if (dices[3].Value == 3)
            {
                dice4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\3.jpg");
            }
            else if (dices[3].Value == 4)
            {
                dice4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\4.jpg");
            }
            else if (dices[3].Value == 5)
            {
                dice4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\5.jpg");
            }
            else
            {
                dice4PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\6.jpg");
            }

            if (dices[3].Locked)
            {
                lock1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\locked.jpg");
            }
            else
            {
                lock1PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\unlocked.jpg");
            }
        }

        internal void updateCurrentPlayer(int who)
        {
            currentPlayerNameLbl.Text = client.playerNameLbl[who].Text;
        }

        private void dice5Display()
        {

            if (dices[4].Value == 1)
            {

                dice5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\1.jpg");
            }
            else if (dices[4].Value == 2)
            {
                dice5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\2.jpg");
            }
            else if (dices[4].Value == 3)
            {
                dice5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\3.jpg");
            }
            else if (dices[4].Value == 4)
            {
                dice5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\4.jpg");
            }
            else if (dices[4].Value == 5)
            {
                dice5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\5.jpg");
            }
            else
            {
                dice5PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\6.jpg");
            }

            if (dices[4].Locked)
            {
                lock2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\locked.jpg");
            }
            else
            {
                lock2PictureBox.ImageLocation = Path.Combine(Environment.CurrentDirectory, "diceImages\\unlocked.jpg");
            }
        }

        internal void notifyWinner(string name)
        {
            MessageBox.Show(name + " has won the game!!!!");

            this.Close();
        }

        public void displayDices(Dice [] dices)
        {
            this.dices = dices;

            dice1Display();
            dice2Display();
            dice3Display();
            dice4Display();
            dice5Display();

            //displayScores(this.currentPlayer);




        }

       

        private void rollButton_Click(object sender, EventArgs e) //roll the dice
        {
            RollNumb++;

            //MessageBox.Show(rollNumb.ToString());
            enableButtons();//activate buttons


            //dices = Server.Games[0].rollDices(CurrentPlayer);

            client.askServerToRoll(dices);


            

         
          
        }

        public void completeRoll(Player currentPlayer, Dice[] dices)
        {

            

            displayDices(dices);


            //turnLabel.Text = currentPlayer.turn.TurnNumber.ToString();

            if (RollNumb > 2)
            {//if we've rolled 3 times, we must score

                rollButton.Enabled = false;

            }

            //player1ScoreLabel.Text = CurrentPlayer.Score.ToString();
            //player1Label.Text = CurrentPlayer.Name;

            //this.currentPlayer = currentPlayer;
        }


        override
        public bool is_Won()
        {

            return false;

        }
        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void dice5PictureBox_Click(object sender, EventArgs e)
        {
            //Server.Games[0].lockDice5();
            
            dice5Display();


        }

        private void dice4PictureBox_Click(object sender, EventArgs e)
        {
            //Server.Games[0].lockDice4();
           
            dice4Display();

        }

        private void dice2PictureBox_Click(object sender, EventArgs e)
        {
            //Server.Games[0].lockDice2();
            
            dice2Display();

        }

        private void dice3PictureBox_Click(object sender, EventArgs e)
        {
            //Server.Games[0].lockDice3();
           
            dice3Display();
        }

        private void dice1PictureBox_Click(object sender, EventArgs e)
        {
            //Server.Games[0].lockDice1();
          
            dice1Display();
        }

        public void wait()//tells ui to wait for someone else's turn
        {
            waiting = true;

            disableButtons();

            rollButton.Enabled = false;
        }

        public void stopWaiting()//tells ui it's the player's turn again
        {
            waiting = false;
            enableButtons();

            rollButton.Enabled = true;
        }
        public void disableButtons()
        {
            score1button.Enabled = false;
            score2button.Enabled = false;
            score3button.Enabled = false;
            score4button.Enabled = false;
            score5button.Enabled = false;
            threeKindbutton.Enabled = false;
            fourKindButton.Enabled = false;
            yatzeeButton.Enabled = false;
            fullHouseBtn.Enabled = false;
            smStraigthBtn.Enabled = false;
            lgStraightBtn.Enabled = false;
            chanceBtn.Enabled = false;

        }


        public void enableButtons()
        {

            if (CurrentPlayer.OneScored == false)
                score1button.Enabled = true;
            if (CurrentPlayer.TwoScored == false)
                score2button.Enabled = true;
            if (CurrentPlayer.ThreeScored == false)
                score3button.Enabled = true;
            if (CurrentPlayer.FourScored == false)
                score4button.Enabled = true;
            if (CurrentPlayer.FiveScored == false)
                score5button.Enabled = true;
            if (CurrentPlayer.ThreeKindScored == false)
                threeKindbutton.Enabled = true;
            if (CurrentPlayer.FourKindScored == false) //only make these buttons usable to players who havent scored yet
                fourKindButton.Enabled = true;
            if (!CurrentPlayer.YatzeeCrossedOut && CurrentPlayer.YatzeeCount < 4)
                yatzeeButton.Enabled = true;
            if (CurrentPlayer.FullHouseScored == false)
                fullHouseBtn.Enabled = true;
            if (CurrentPlayer.SmStraightScored == false)
                smStraigthBtn.Enabled = true;
            if (CurrentPlayer.LgStraightScored == false)
                lgStraightBtn.Enabled = true;
            if (CurrentPlayer.ChanceScored == false)
                chanceBtn.Enabled = true;


        }
        private void score1button_Click(object sender, EventArgs e) //player scores the 1s
        {
            CurrentPlayer.OneScored = true;

            //Server.Games[0].score1(CurrentPlayer, dices);
            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 1;
            //MessageBox.Show(currentPlayer.position.ToString());
            client.score1Request(score1Request);
            client.endTurnNotification();
            wait();
            //rollButton.Enabled = true;
        }

        private void score2button_Click(object sender, EventArgs e) //player scores the 1s
        {
            CurrentPlayer.TwoScored = true;
            //Server.Games[0].score2(CurrentPlayer, dices);

            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 2;

            client.score1Request(score1Request);
            client.endTurnNotification();
            wait();
            //disableButtons();
            //rollButton.Enabled = true;



        }

        private void score3button_Click(object sender, EventArgs e) //player scores the 1s
        {
            CurrentPlayer.ThreeScored = true;

            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 3;

            //Server.Games[0].score3(CurrentPlayer, dices);

            client.score1Request(score1Request);
            client.endTurnNotification();
            wait();
            //disableButtons();
            // rollButton.Enabled = true;



        }

        private void score4button_Click(object sender, EventArgs e) //player scores the 1s
        {
            CurrentPlayer.FourScored = true;

            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 4;


            //Server.Games[0].score4(CurrentPlayer, dices);

            client.score1Request(score1Request);

            client.endTurnNotification();
            wait();



        }

        private void score5button_Click(object sender, EventArgs e) //player scores the 1s
        {
            CurrentPlayer.FiveScored = true;

            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 5;


            //Server.Games[0].score5(CurrentPlayer, dices);

            client.score1Request(score1Request);

            client.endTurnNotification();
            wait();


        }

        private void threeKindbutton_Click(object sender, EventArgs e)
        {
            CurrentPlayer.ThreeKindScored = true;

            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 6;

            //Server.Games[0].scoreThreeKind(CurrentPlayer, dices);
            client.score1Request(score1Request);

            client.endTurnNotification();
            wait();


        }

        private void fourKindButton_Click(object sender, EventArgs e)
        {
            CurrentPlayer.FourKindScored = true;

            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 7;

            //Server.Games[0].scoreFourKind(currentPlayer, dices);
            client.score1Request(score1Request);

            client.endTurnNotification();
            wait();


        }

        private void yatzeeButton_Click(object sender, EventArgs e)
        {



            currentPlayer.YatzeeScored = true;
            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 8;

            //Server.Games[0].scoreYatzee(currentPlayer, dices);
            client.score1Request(score1Request);

            client.endTurnNotification();
            wait();


        }

        private void fullHouseBtn_Click(object sender, EventArgs e)
        {
            CurrentPlayer.FullHouseScored = true;



            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 9;

            //Server.Games[0].scoreYatzee(currentPlayer, dices);
            client.score1Request(score1Request);

            //Server.Games[0].scoreFullHouse(currentPlayer, dices);
            client.endTurnNotification();
            wait();


        }

        private void smStraigthBtn_Click(object sender, EventArgs e)
        {
            CurrentPlayer.SmStraightScored = true;

            //Server.Games[0].scoreSmStraigth(currentPlayer, dices);


            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 10;

            //Server.Games[0].scoreYatzee(currentPlayer, dices);
            client.score1Request(score1Request);

            client.endTurnNotification();
            wait();
        }

        private void lgStraightBtn_Click(object sender, EventArgs e)
        {
            CurrentPlayer.LgStraightScored = true;

            //Server.Games[0].scoreLgStraight(currentPlayer, dices);

            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 11;

            //Server.Games[0].scoreYatzee(currentPlayer, dices);
            client.score1Request(score1Request);


            client.endTurnNotification();
            wait();

        }
        
        private void checkForFinish()
        {
            if (currentPlayer.ChanceScored == true && currentPlayer.OneScored == true && currentPlayer.TwoScored == true
                && currentPlayer.ThreeScored == true && currentPlayer.FourScored == true && currentPlayer.FiveScored == true
                && currentPlayer.ThreeKindScored == true && currentPlayer.FourKindScored == true && currentPlayer.YatzeeScored== true
                && currentPlayer.SmStraightScored == true && currentPlayer.LgStraightScored == true && currentPlayer.FullHouseScored == true)
            {
                client.hasFinished();
            }
           
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void chanceBtn_Click(object sender, EventArgs e)
        {
            CurrentPlayer.ChanceScored = true;

            //Server.Games[0].scoreChance(CurrentPlayer, dices);


            Score1Request score1Request = new Score1Request();

            score1Request.currentPlayer = this.currentPlayer;
            score1Request.dices = this.dices;
            score1Request.number = 12;

            //Server.Games[0].scoreYatzee(currentPlayer, dices);
            client.score1Request(score1Request);



            client.endTurnNotification();
            wait();


        }

        private void lock1PictureBox_Click(object sender, EventArgs e)
        {
            LockDiceRequest lockDiceRequest = new LockDiceRequest();
            lockDiceRequest.lockedDice = 3;
            lockDiceRequest.currentPlayer = this.currentPlayer;
            client.lockDiceRequest(lockDiceRequest);
        }

        private void lock5PictureBox_Click(object sender, EventArgs e)
        {
            LockDiceRequest lockDiceRequest = new LockDiceRequest();
            lockDiceRequest.lockedDice = 0;
            lockDiceRequest.currentPlayer = this.currentPlayer;
            client.lockDiceRequest(lockDiceRequest);
        }

        private void lock3PictureBox_Click(object sender, EventArgs e)
        {
            LockDiceRequest lockDiceRequest = new LockDiceRequest();
            lockDiceRequest.lockedDice = 1;
            lockDiceRequest.currentPlayer = this.currentPlayer;
            client.lockDiceRequest(lockDiceRequest);
        }

        private void lock4PictureBox_Click(object sender, EventArgs e)
        {
            LockDiceRequest lockDiceRequest = new LockDiceRequest();
            lockDiceRequest.lockedDice = 2;
            lockDiceRequest.currentPlayer = this.currentPlayer;
            client.lockDiceRequest(lockDiceRequest);
        }

        private void lock2PictureBox_Click(object sender, EventArgs e)
        {
            LockDiceRequest lockDiceRequest = new LockDiceRequest();
            lockDiceRequest.lockedDice = 4;
            lockDiceRequest.currentPlayer = this.currentPlayer;
            client.lockDiceRequest(lockDiceRequest);
        }



        private void sendMessageBtn_Click(object sender, EventArgs e)
        {
            sendChat(chatTextBox.Text);
        }

        private void player1Label_Click(object sender, EventArgs e)
        {

        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            client.Close();
        }

      
    }
}
