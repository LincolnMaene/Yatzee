using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using Packet;
using System.Runtime.Serialization;

namespace YatzeeClient
{
    public partial class Client : Form
    {
        private delegate void clDelegate(object temp);//u know what a delegate is by now
        private Thread TalkThread = null;//thread used by client to talk to server?
        NetworkStream clientStream = null;
        private static BinaryFormatter formatter = new BinaryFormatter();
        private int who;//who the player is, streamWise
        private string playerName;
        YatzeeUI userInterface;
        private int gameID;
        private bool finished;

        public Label[] playerNameLbl = new Label[5];//player names on the form
        Label[] playerConnectionLbl = new Label[5];//player connection status on form
        Label[] gameNames = new Label[5];//name of games on form

        bool serverOn = true;
        public int GameID { get => gameID; set => gameID = value; }

        public Client()
        {
            finished = false;
            InitializeComponent();
            allocateMem();

        }

        public void hasFinished()
        {
            finished = true;
            UserFinished notification = new UserFinished();
            notification.who = this.who;
            notification.gameID = this.gameID;
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                   
                    formatter.Serialize(clientStream, notification); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }
        private void allocateMem()
        {

            playerName = "Incognito";

            gameID = 99;
        }

        public void lockDiceRequest(LockDiceRequest lockDiceRequest)
        {
            lockDiceRequest.gameID = this.gameID;

            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                   
                   formatter.Serialize(clientStream, lockDiceRequest); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        public void completeRoll(DisplayDiceCommand displayCmd)//tell user interface to display dices properly
        {
            int[] scoreBoard = displayCmd.scoreBoard;
            userInterface.displayScores(userInterface.CurrentPlayer, scoreBoard);
            userInterface.completeRoll(displayCmd.currentPlayer,displayCmd.dices);
            

        }
        public void askServerToRoll(Dice [] dices)//asks server to toll the dice
        {
            int gameID = this.gameID;
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                    RollDiceRequest rollDiceRequest = new RollDiceRequest();

                    rollDiceRequest.dices = dices; //which dice we are rolling
                    rollDiceRequest.currentPlayer = userInterface.CurrentPlayer;//which player is rolling 

                    rollDiceRequest.gameID = gameID;
                    
                   
                    formatter.Serialize(clientStream, rollDiceRequest); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }

        }

        private void setPlayerLabel(StartGameCommand startGameCommand)
        {
            userInterface.setPlayerNames(startGameCommand.scoreBoardNames);
        }
        private void startUi(StartGameCommand startGameCommand)
        {
            //this.who = startGameCommand.who;
            userInterface = new YatzeeUI(this, this.who, playerName);
            setPlayerLabel(startGameCommand);
            
        
            
            userInterface.Show();
            this.Hide();

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {

            if (playerNameTxtBox.Text.Equals("") == false)
                playerName = playerNameTxtBox.Text;

            

            if (TalkThread == null || !TalkThread.IsAlive)// if thread has not been created or is dead
            {
                //MessageBox.Show("We are here");
                TcpClient client = new TcpClient(); //create a new tcp client
                try
                {
                    client.Connect(txtIPAddress.Text, 3005);//connect to watever address in the textbox, port 3005
                    clientStream = client.GetStream();//give a stream to the client

                    TalkThread = new Thread(new ThreadStart(TalkProcedure));//start thread, pass in the talkprocedure function
                    TalkThread.IsBackground = true;
                    TalkThread.Start();
                }
                catch (SocketException)
                {
                    MessageBox.Show("Cannot connect to server");
                }

            }

            sendChat(playerName + " Connected");
            
            getIdFromServer();
        }

        public void TalkProcedure()
        {
            object temp;

           
            try
            {
                while (true)
                {
                   // MessageBox.Show("Waiting");
                    temp = formatter.Deserialize(clientStream); //blocking call, waits it then deserializes what it gets from server

                    
                    if (listBox1.InvokeRequired)
                    {
                        BeginInvoke(new clDelegate(SendToListbox), temp);
                    }
                   

                }
            }
            catch (Exception e)
            {

                TalkThread.Join();
                TalkThread = null;
                return;
                
            }
        }

        private void SendToListbox(object obj)
        {


            if (obj is Packet.Message) //if we get a message from delegate, cas then add to listbox
            {

                //MessageBox.Show("Receivin...");
                Packet.Message m = (Packet.Message)obj;
                int gameID = m.gameID;
                //MessageBox.Show(gameID.ToString());
                //listBox1.Items.Add((string)obj);
                if (userInterface != null && (this.gameID == gameID))
                    userInterface.receiveChat(m.message);
                else if (gameID > 5 || gameID < 0)
                    listBox1.Items.Add(m.message);
                
                
            }
            else if (obj is Packet.Question)
            {
                Packet.Question q = (Packet.Question)obj;
                listBox1.Items.Add(q.Operand1.ToString() + q.Operator + q.Operand2.ToString());
            }
            else if (obj is string)
            {
                listBox1.Items.Add((string)obj);
                if (userInterface != null)
                    userInterface.receiveChat((string)obj);
            }
            else if (obj is StartGameCommand)
            {
                StartGameCommand startCommand = (StartGameCommand)obj;

                int gameID = startCommand.gameID;
               
                if(this.gameID==gameID)
                    startUi(startCommand);
            }
            else if (obj is DisplayDiceCommand)
            {
                
                DisplayDiceCommand displayCommand = (DisplayDiceCommand)obj;

                //MessageBox.Show(displayCommand.dices[0].Value.ToString());
                if(displayCommand.gameID==this.gameID)
                    completeRoll(displayCommand);
            }

            else if (obj is CompleteScoreCommand)
            {

                CompleteScoreCommand completeScoreCommand = (CompleteScoreCommand)obj;

                //MessageBox.Show(displayCommand.dices[0].Value.ToString());
                if(completeScoreCommand.gameID==this.gameID)
                    completeScore(completeScoreCommand);
            }


            else if (obj is UnlockDicesCommand)
            {

                UnlockDicesCommand unlockDicesCommand = (UnlockDicesCommand)obj;

                Dice[] dices = unlockDicesCommand.dices;
                //MessageBox.Show(displayCommand.dices[0].Value.ToString());

                userInterface.displayDices(dices);

            }


            else if (obj is GoOnCommand)
            {

                GoOnCommand goOnCmd = (GoOnCommand)obj;
                if (goOnCmd.who == this.who)
                {
                    if (userInterface != null && finished == false)
                    {
                        userInterface.CurrentPlayer.turn.resetTurns();
                        userInterface.stopWaiting();
                        userInterface.disableButtons();
                    }
                    else if (finished == true)
                    {
                        endTurnNotification();
                    }
                }
                if (userInterface!=null && goOnCmd.gameID==this.gameID)
                    userInterface.updateCurrentPlayer(goOnCmd.who);
            }

            else if (obj is IdAssign)//find out which connection i am
            {

                IdAssign idAssign = (IdAssign)obj;

                this.who = idAssign.who;

                //MessageBox.Show("my id is: " + who.ToString());
                listBox1.Items.Add("You have connected successfully");


            }

            else if (obj is CreateGameCommand)//find out which connection i am
            {
                CreateGameCommand createGameCommand = (CreateGameCommand)obj;

                if (createGameCommand.creatorID == this.who && this.gameID>5)//if i created the game i join by default
                    this.gameID = createGameCommand.gameNum;

                displayGameList(createGameCommand);



            }
            else if (obj is UpdatePlayerListCommand)//find out which connection i am
            {
                UpdatePlayerListCommand updatePlayerListCommand = (UpdatePlayerListCommand)obj;

                string [] playerListNames = updatePlayerListCommand.labels;

                updatePlayerList(playerListNames);



            }

            else if (obj is UpdateGameList)
            {
                UpdateGameList updateGameListCMD = (UpdateGameList)obj;



                string[] gameList = updateGameListCMD.labels;

           

                updateGameList(gameList);
            }

            else if (obj is ServerDisconected)
            {
                serverOn = false;
            }
            else if (obj is AnnounceWinner)
            {
                AnnounceWinner notif = (AnnounceWinner)obj;

                string winner = playerNameLbl[notif.who].Text;

                if (this.gameID == notif.gameID)
                    userInterface.notifyWinner(winner);
            }


        }

        private void updateGameList(string[] gameList)
        {
            gameNames[0].Text = gameList[0];
            gameNames[1].Text = gameList[1];
            gameNames[1].Text = gameList[1];
            gameNames[1].Text = gameList[1];
            gameNames[1].Text = gameList[1];

            if (gameNames[0].Text.Equals("Uncreated"))
                joinGame1Btn.Enabled = false;
            if (gameNames[1].Text.Equals("Uncreated"))
                joinGame2Btn.Enabled = false;
            if (gameNames[2].Text.Equals("Uncreated"))
                joinGame3Btn.Enabled = false;
            if (gameNames[3].Text.Equals("Uncreated"))
                joinGame4Btn.Enabled = false;
            if (gameNames[4].Text.Equals("Uncreated"))
                joinGame5Btn.Enabled = false;
        }

        private void updatePlayerList(string[] playerListNames)
        {
            if(playerListNames[0].Equals("Player1 -->") == false)
            {
                playerNameLbl[0].Text = playerListNames[0]+" --> ";
                playerConnectionLbl[0].Text = "Connected";
            }

            if (playerListNames[1].Equals("Player2 -->") == false)
            {
                playerNameLbl[1].Text = playerListNames[1]+ " --> ";
                playerConnectionLbl[1].Text = "Connected";
            }

            if (playerListNames[2].Equals("Player3 -->") == false)
            {
                playerNameLbl[2].Text = playerListNames[2] + " --> ";
                playerConnectionLbl[2].Text = "Connected";
            }

            if (playerListNames[3].Equals("Player4 -->") == false)
            {
                playerNameLbl[3].Text = playerListNames[3] + " --> ";
                playerConnectionLbl[3].Text = "Connected";
            }

            if (playerListNames[4].Equals("Player5 -->") == false)
            {
                playerNameLbl[4].Text = playerListNames[4] + " --> ";
                playerConnectionLbl[4].Text = "Connected";
            }
        }

        private void displayGameList(CreateGameCommand createGameCommand)
        {
            int creator = createGameCommand.creatorID;
            int gameNum = createGameCommand.gameNum;
            string name = createGameCommand.name;

            if (gameNum == 0)
            {
                if(creator!=this.who)
                    joinGame1Btn.Enabled = true;
                if (creator==this.who)
                    startGame1Btn.Enabled = true;
                if(name.Equals("")==false)
                    game1Lbl.Text = name+"(1)";
                else
                    game1Lbl.Text = "Incognito(1)";

                this.listBox1.Items.Add("Game " + name + " Created");
            }
            else if (gameNum == 1)
            {
                if (creator != this.who)
                    joinGame2Btn.Enabled = true;
                if (creator == this.who)
                    startGame2Btn.Enabled = true;
                if (name.Equals("") == false)
                    game2Lbl.Text = name + "(1)";
                else
                    game2Lbl.Text = "Incognito(1)";

                this.listBox1.Items.Add("Game " + name + " Created");
            }
            else if (gameNum == 2)
            {
                if (creator != this.who)
                    joinGame3Btn.Enabled = true;
                if (creator == this.who)
                    startGame3Btn.Enabled = true;
                if (name.Equals("") == false)
                    game3Lbl.Text = name + "(1)";
                else
                    game3Lbl.Text = "Incognito(1)";

                this.listBox1.Items.Add("Game " + name + " Created");
            }
            else if (gameNum == 3)
            {
                if (creator != this.who)
                    joinGame4Btn.Enabled = true;
                if (creator == this.who)
                    startGame4Btn.Enabled = true;
                if (name.Equals("") == false)
                    game4Lbl.Text = name + "(1)";
                else
                    game4Lbl.Text = "Incognito(1)";

                this.listBox1.Items.Add("Game " + name + " Created");
            }
            else if (gameNum == 4)
            {
                if (creator != this.who)
                    joinGame5Btn.Enabled = true;
                if (creator == this.who)
                    startGame5Btn.Enabled = true;
                if (name.Equals("") == false)
                    game5Lbl.Text = name + "(1)";
                else
                    game5Lbl.Text = "Incognito(1)";

                this.listBox1.Items.Add("Game " + name + " Created");
            }

        }

        private void completeScore(CompleteScoreCommand completeScoreCommand)
        {
            Player currentPlayer = completeScoreCommand.currentPlayer;
            int[] scoreBoard = completeScoreCommand.scoreBoard;

            userInterface.displayScores(currentPlayer, scoreBoard);

            //userInterface.enableRoll();
          

        }
        
        public void sendChat(string message)
        {
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                    Packet.Message m = new Packet.Message();
                    m.message = message;
                    m.gameID = this.gameID;
                    formatter.Serialize(clientStream, m); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                    Packet.Message m = new Packet.Message();
                    m.message = txtMessage.Text;
                    m.gameID = this.gameID;
                    formatter.Serialize(clientStream, m); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        private void btnSendQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                    Packet.Question q = new Packet.Question();
                    q.Operator = "+";
                    q.Operand1 = 12;
                    q.Operand2 = 21;

                    formatter.Serialize(clientStream, q); //send data
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        private void startGameBtn_Click(object sender, EventArgs e)//start game button clicked
        {
            int gameID = this.gameID;
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                    
                    Packet.StartGameRequest request = new Packet.StartGameRequest();
                    request.gameID = gameID;
                    request.name = this.playerName;

                    formatter.Serialize(clientStream, request); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        public void score1Request(Score1Request score1Request)
        {

            userInterface.RollNumb = 0;
            int who = score1Request.currentPlayer.position;
            score1Request.gameID = this.gameID;
            
            //MessageBox.Show(who.ToString());
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {
                    formatter.Serialize(clientStream, score1Request); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        public void endTurnNotification()
        {
            
            userInterface.displayNextTurn();

            try
            {
                EndTurnNotification endTurnNotification = new EndTurnNotification();
                endTurnNotification.who = this.who;
                endTurnNotification.gameID = this.gameID;
                if (clientStream != null && clientStream.CanWrite)
                {
                    formatter.Serialize(clientStream, endTurnNotification); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        private void getIdFromServer()
        {
            IdRequest idRequest = new IdRequest();
            idRequest.name = this.playerName;
            try
            {
                
                if (clientStream != null && clientStream.CanWrite)
                {
                    formatter.Serialize(clientStream, idRequest); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }
        private void createGameBtn_Click(object sender, EventArgs e)
        {
            string gameName = gameNameTxtBox.Text;
            CreateGameRequest createGameRequest = new CreateGameRequest();
            createGameRequest.name = gameName;
            createGameRequest.who = this.who;
            sendCreateGameRequest(createGameRequest);
          
        }

        private void sendCreateGameRequest(CreateGameRequest createGameRequest)
        {
            try
            {

                if (clientStream != null && clientStream.CanWrite)
                {
                    formatter.Serialize(clientStream, createGameRequest); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }
        private void sendJoinGameRequest(JoinGameRequest request)
        {
            request.name = this.playerName;
            try
            {

                if (clientStream != null && clientStream.CanWrite)
                {
                    formatter.Serialize(clientStream, request); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }
        private void joinGame1Btn_Click(object sender, EventArgs e)//join game 1
        {
            this.gameID = 0;
            JoinGameRequest joinGameRequest = new JoinGameRequest();

            joinGameRequest.who = this.who;
            joinGameRequest.gameID = gameID;
            sendJoinGameRequest(joinGameRequest);

            joinGame1Btn.Enabled = false;
            listBox1.Items.Add("You have joined " + gameNames[0] + " Please wait for it to start");

        }

        private void joinGame2Btn_Click(object sender, EventArgs e)
        {
            this.gameID = 1;

            JoinGameRequest joinGameRequest = new JoinGameRequest();
            joinGameRequest.who = this.who;
            joinGameRequest.gameID = gameID;
            sendJoinGameRequest(joinGameRequest);
            joinGame2Btn.Enabled = false;
            listBox1.Items.Add("You have joined " + gameNames[1] + " Please wait for it to start");
        }

        private void joinGame3Btn_Click(object sender, EventArgs e)
        {
            this.gameID = 2;

            JoinGameRequest joinGameRequest = new JoinGameRequest();
            joinGameRequest.who = this.who;
            joinGameRequest.gameID = gameID;
            sendJoinGameRequest(joinGameRequest);
            joinGame3Btn.Enabled = false;
            listBox1.Items.Add("You have joined " + gameNames[2] + " Please wait for it to start");
        }

        private void joinGame4Btn_Click(object sender, EventArgs e)
        {
            this.gameID = 3;

            JoinGameRequest joinGameRequest = new JoinGameRequest();
            joinGameRequest.who = this.who;
            joinGameRequest.gameID = gameID;
            sendJoinGameRequest(joinGameRequest);
            joinGame4Btn.Enabled = false;
            listBox1.Items.Add("You have joined " + gameNames[3] + " Please wait for it to start");
        }

        private void joinGame5Btn_Click(object sender, EventArgs e)
        {
            this.gameID = 4;

            JoinGameRequest joinGameRequest = new JoinGameRequest();
            joinGameRequest.who = this.who;
            joinGameRequest.gameID = gameID;
            sendJoinGameRequest(joinGameRequest);
            joinGame5Btn.Enabled = false;
            listBox1.Items.Add("You have joined " + gameNames[4] + " Please wait for it to start");
        }

        private void startGame2Btn_Click(object sender, EventArgs e)
        {
            int gameID = this.gameID;
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {

                    Packet.StartGameRequest request = new Packet.StartGameRequest();
                    request.gameID = gameID;
                    request.name = this.playerName;

                    formatter.Serialize(clientStream, request); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        private void startGame3Btn_Click(object sender, EventArgs e)
        {
            int gameID = this.gameID;
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {

                    Packet.StartGameRequest request = new Packet.StartGameRequest();
                    request.gameID = gameID;
                    request.name = this.playerName;

                    formatter.Serialize(clientStream, request); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        private void startGame4Btn_Click(object sender, EventArgs e)
        {
            int gameID = this.gameID;
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {

                    Packet.StartGameRequest request = new Packet.StartGameRequest();
                    request.gameID = gameID;
                    request.name = this.playerName;

                    formatter.Serialize(clientStream, request); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        private void startGame5Btn_Click(object sender, EventArgs e)
        {
            int gameID = this.gameID;
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {

                    Packet.StartGameRequest request = new Packet.StartGameRequest();
                    request.gameID = gameID;
                    request.name = this.playerName;

                    formatter.Serialize(clientStream, request); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            playerNameLbl[0] = player1Lbl;
            playerNameLbl[1] = player2Lbl;
            playerNameLbl[2] = player3Lbl;
            playerNameLbl[3] = player4Lbl;
            playerNameLbl[4] = player5Lbl;


            playerConnectionLbl[0] = player1ConnLbl;
            playerConnectionLbl[1] = player2ConnLbl;
            playerConnectionLbl[2] = player3ConnLbl;
            playerConnectionLbl[3] = player4ConnLbl;
            playerConnectionLbl[4] = player5ConnLbl;


            gameNames[0] = game1Lbl;
            gameNames[1] = game2Lbl;
            gameNames[2] = game3Lbl;
            gameNames[3] = game4Lbl;
            gameNames[4] = game5Lbl;

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            closeForm();
        }

        public void closeForm()
        {
            DisconnectRequest disconnectRequest = new DisconnectRequest();

            disconnectRequest.gameID = this.gameID;
            disconnectRequest.who = this.who;

            sendDisconnectRequest(disconnectRequest);
            //MessageBox.Show("Closing...");


            
        }

        private void sendDisconnectRequest(DisconnectRequest disconnectRequest)
        {
            try
            {
                if (clientStream != null && clientStream.CanWrite)
                {

                   

                    formatter.Serialize(clientStream, disconnectRequest); //send data, serializes than sends across stream
                }
            }
            catch (System.IO.IOException)
            {

            }
        }
    }
}
