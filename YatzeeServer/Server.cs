using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Packet;

namespace YatzeeServer
{
    public partial class Server : Form
    {
        private delegate void srvDelegate(object temp, int loc); //delegates are used for callbacks between threads

        private TcpListener listener;//listens for incoming connections
        private Socket connection; //socket used by server
        NetworkStream connectionStream = null; //stream used to communicate

        //Wait For Connection thread
        //Manages incoming connections
        private Thread WFCThread = null; //WFC==wait for connection
        private static BinaryFormatter formatter = new BinaryFormatter();// binary formatter used to serialize stuff before sending through net
        Thread[] AllThreads;//all threads
        CData[] AllSockets;//connection data abt all our sockets
        int NextLocation = 0;//keeps track of which socket we are at


        YatzeeGame[] games = new YatzeeGame[5]; //the five games the server can run
        Dice[] dices = new Dice[5];

        Label[] playerNameLbl = new Label[5];//player names on the form
        Label[] playerConnectionLbl = new Label[5];//player connection status on form
        Label[] gameNames = new Label[5];//name of games on form

        public Server()
        {
            allocateMem();
            InitializeComponent();
            AllThreads = new Thread[5]; //creates array
            AllSockets = new CData[5]; //creates array
        }


        public YatzeeGame[] Games { get => games; set => games = value; }

        private void goOnCmd(int who, int game)//tells ui to go on
        {
           
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    GoOnCommand goOnCmd = new GoOnCommand();
                    goOnCmd.gameID = game;
                    goOnCmd.who = who;
                    
                    if (AllSockets[x] != null)
                    {
                        
                            formatter.Serialize(AllSockets[x].ConnStream, goOnCmd); //send new message to clients (temp)
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }

        }
        private void displayDices(int gameID, Dice[] dices, Player currentPlayer, int who) //tell client to display dice
        {
            int[] ScoreBoard = games[gameID].ScoreBoard;
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    DisplayDiceCommand displayCommand = new DisplayDiceCommand();
                    displayCommand.dices = dices;
                    displayCommand.gameID = gameID;
                    displayCommand.currentPlayer = currentPlayer;
                    displayCommand.scoreBoard = ScoreBoard;

                    if (AllSockets[x] != null)
                    {
                        //if (AllSockets[x].which == who)
                        formatter.Serialize(AllSockets[x].ConnStream, displayCommand); //send new message to clients (temp)

                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }
        }
        private void allocateMem()
        {
            for (int i = 0; i < 5; i++)
            {
                
                dices[i] = new Dice();
            }

        }




        public bool startNewGame(int gameID, int who, string name)//returns true if a new game is started
        {

            games[gameID].IsBeingPlayed = true;
            games[gameID].ScoreBoardNames[who] = name;
            tellUiToStart(who, gameID, name);
            goOnCmd(who, gameID);
            return true;
            /*
            foreach (YatzeeGame game in Games)
            {
                if (game.IsBeingPlayed == false)
                {
                    game.IsBeingPlayed = true;
                    game.Name = name;

                    tellUiToStart(who, name);
                    return true;
                }
            }
           

            return false;

            */
        }

        private void tellUiToStart(int who, int gameID, string name)
        {

            //MessageBox.Show(who.ToString());
            listBox1.Items.Add("Starting game " + gameID);
            try
            {
                for (int x = 0; x < 5; x++)
                {
                    Packet.StartGameCommand startCommand = new Packet.StartGameCommand();
                    startCommand.gameID = gameID;
                    startCommand.name = name;
                    startCommand.scoreBoardNames = games[gameID].ScoreBoardNames;
                    

                    if (AllSockets[x] != null)
                    {

                        startCommand.who = x;

                        if (AllSockets[x].which == who)//set which game the connection is on
                            AllSockets[x].gameID = gameID;

                        formatter.Serialize(AllSockets[x].ConnStream, startCommand); //send new message to clients (temp)
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            //WFCThread == null
            //If the thread has never been created
            //OR
            //If the thread is dead
            //IsAlive is a proprty that tells us if
            if (WFCThread == null || !WFCThread.IsAlive)
            {
                //Is this a parameterized thread? No
                WFCThread = new Thread(new ThreadStart(WFCProcedure));
                WFCThread.IsBackground = true;
                WFCThread.Start();
                listBox1.Items.Add("Server Started");
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)//stops the connection gracefully
        {

            sendDisconectMessage();
            if (WFCThread != null && WFCThread.IsAlive)
            {
                listener.Stop(); //stops the blocking call listener.AcceptSocket()
                NextLocation = 0;
            }

            for (int x = 0; x < 5; x++)
            {
                if (AllSockets[x] != null && AllThreads[x] != null && AllThreads[x].IsAlive)
                {
                    AllSockets[x].TheSocket.Close();//close socket
                    AllThreads[x].Join();//join all threads then set to null
                    AllThreads[x] = null;
                    AllSockets[x] = null;
                }
            }
        }

        private void sendDisconectMessage()
        {
            ServerDisconected serverDisconect = new ServerDisconected();


            


            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {
                        
                            formatter.Serialize(AllSockets[x].ConnStream, serverDisconect); //send new message to clients (temp)
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }
        }

        private void WFCProcedure()
        {
            int port = 3005;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            listener = new TcpListener(localAddr, port);
            listener.Start();

            try
            {
               
                while (NextLocation < 5)//we can only run 5 connections at most
                {
                    //MessageBox.Show(NextLocation.ToString());
                    if (AllSockets[NextLocation] == null)
                    {
                        connection = listener.AcceptSocket(); //blocking call, connection==socket
                                                              //MessageBox.Show("Connection Made");

                        AllSockets[NextLocation] = new CData();//we  cretest a Conection data objec-> contains=> stream, socket, isconected?, whichConection?

                        AllSockets[NextLocation].gameID = -1;//we do not know which game this will be

                        //If we want to shut this down, we need the socket
                        AllSockets[NextLocation].TheSocket = connection; //we're trying to save information about the given conncetion

                        //This is the stream (Think of it like a pointer to the client)
                        AllSockets[NextLocation].ConnStream = new NetworkStream(connection);
                        AllSockets[NextLocation].Connected = true;

                        //Can be used to track which client connection this is. 
                        //Might not need this, but we have it for debugging
                        AllSockets[NextLocation].which = NextLocation;

                        AllThreads[NextLocation] = new Thread(new ParameterizedThreadStart(AreYouTalkingToME));
                        AllThreads[NextLocation].IsBackground = true;
                        AllThreads[NextLocation].Start(AllSockets[NextLocation]);

                        if (NextLocation == 4)
                            NextLocation = 0;
                        else
                            NextLocation++;
                    }
                    else
                    {
                        NextLocation++;
                    }
                }
               
            }
            catch (SocketException)
            {
                MessageBox.Show("Server Shutting down!");
            }
            //listener.Server.Close();
        }

        private void AreYouTalkingToME(object obj)//looks like callback function
        {

            CData who = null;//which connection of the 5 possible connected are we talking to
            object temp;
            if (obj is CData) //if the thread has received conection data, we cast it so
            {
                who = (CData)obj;
            }

            try
            {
                while (true)
                {
                    if (who != null)//if the connection stands, we apparently deserialize the conection stream
                    {
                        temp = formatter.Deserialize(who.ConnStream);  //Blocking Call

                        if (listBox1.InvokeRequired)//if the thread cannot access listbox (it belongs to another)
                        {
                            BeginInvoke(new srvDelegate(SendToListbox), temp, who.which);
                        }


                    }
                }
            }
            catch (System.Runtime.Serialization.SerializationException e)
            {
                if (listBox1.InvokeRequired == false)
                    listBox1.Items.Add("Client Died!");
            }
            catch (System.IO.IOException)
            {
                if (listBox1.InvokeRequired==false)
                    listBox1.Items.Add("Client Died!");
            }
        
          
        }
        private void SendToListbox(object obj, int location)
        {
            if (obj is Packet.Message)// if the server has received a message, cast it as such and send to listboxl
            {
                Packet.Message m = (Packet.Message)obj;
                listBox1.Items.Add(location.ToString() + " " + m.message);

                sendChatMessage(m.message, location,m.gameID);

            }
            else if (obj is Packet.Question)//if it is a question do the smae
            {
                Packet.Question q = (Packet.Question)obj;
                listBox1.Items.Add(location.ToString() + " " + q.Operand1.ToString() + q.Operator + q.Operand2.ToString());
            }
            else if (obj is string)//if it's just a string same ting
            {
                listBox1.Items.Add(location.ToString() + " " + (string)obj);
            }
            else if (obj is StartGameRequest)
            {
                StartGameRequest request = (StartGameRequest)obj;

                startNewGame(request.gameID, location, request.name);
            }
            else if (obj is RollDiceRequest)
            {


                RollDiceRequest rollDiceRequest = (RollDiceRequest)obj;

                int gameID = rollDiceRequest.gameID;

                Player currentPlayer = rollDiceRequest.currentPlayer;

                dices = games[gameID].rollDices(currentPlayer);


                displayDices(gameID, dices, currentPlayer, location);

            }
            else if (obj is LockDiceRequest)
            {
                LockDiceRequest lockDiceRequest = (LockDiceRequest)obj;

                lockDice(lockDiceRequest, location);
            }
            else if (obj is Score1Request)
            {
                Score1Request score1Request = (Score1Request)obj;

                

                Player currentPlayer = score1Request.currentPlayer;
                Dice[] dices = score1Request.dices;
                int gameID = score1Request.gameID;
                if (score1Request.number == 1)
                    games[gameID].score1(currentPlayer, dices);
                else if (score1Request.number == 2)
                    games[gameID].score2(currentPlayer, dices);
                else if (score1Request.number == 3)
                    games[gameID].score3(currentPlayer, dices);
                else if (score1Request.number == 4)
                    games[gameID].score4(currentPlayer, dices);
                else if (score1Request.number == 5)
                    games[gameID].score5(currentPlayer, dices);
                else if (score1Request.number == 6) // three of a kind
                    games[gameID].scoreThreeKind(currentPlayer, dices);
                else if (score1Request.number == 7) // 4 of a kind
                    games[gameID].scoreFourKind(currentPlayer, dices);
                else if (score1Request.number == 8) // yatzee
                    games[gameID].scoreYatzee(currentPlayer, dices);
                else if (score1Request.number == 9) // fullHouse
                    games[gameID].scoreFullHouse(currentPlayer, dices);
                else if (score1Request.number == 10) // smstraight
                    games[gameID].scoreSmStraigth(currentPlayer, dices);
                else if (score1Request.number == 11) // lgstraight
                    games[gameID].scoreLgStraight(currentPlayer, dices);
                else if (score1Request.number == 12) // lgstraight
                    games[gameID].scoreChance(currentPlayer, dices);



                //
                //displayDices(0, score1Request.dices, score1Request.currentPlayer);
                games[gameID].ScoreBoard[location] = currentPlayer.Score;

                CompleteScoreCommand completeScoreCommand = new CompleteScoreCommand();

                completeScoreCommand.currentPlayer = currentPlayer;
                completeScoreCommand.gameID = gameID;

                sendCompleteScoreCommand(completeScoreCommand, location);



            }

            else if (obj is EndTurnNotification)
            {
                EndTurnNotification endTurnNotification = (EndTurnNotification)obj;
                int turnEnder = endTurnNotification.who;

                int gameID = endTurnNotification.gameID;
                int nextGuy=findNextGuy(turnEnder,gameID);
               
                goOnCmd(nextGuy,gameID);
            }

            else if (obj is IdRequest)
            {
                IdAssign idAssign = new IdAssign();

                idAssign.who = location;

                assignId(idAssign,location);

                //we need to update the list of connected players
                IdRequest idRequest = (IdRequest)obj;

                string playerName = idRequest.name;
                int who = location;

                playerNameLbl[location].Text = playerName+" --> ";
                playerConnectionLbl[location].Text = "Connected";

                updatePlayerList();
                //everytime someone requests an id, the game list is updated
                if (games[0] != null)
                {
                    CreateGameCommand createGameCommand = new CreateGameCommand();

                    createGameCommand.creatorID = games[0].GameCreatorID;

                    createGameCommand.gameNum = 0;
                    createGameCommand.name = games[0].GameName;

                    displayGameList(createGameCommand);
                }
                if (games[1] != null)
                {
                    CreateGameCommand createGameCommand = new CreateGameCommand();

                    createGameCommand.creatorID = games[1].GameCreatorID;

                    createGameCommand.gameNum = 1;
                    createGameCommand.name = games[1].GameName;

                    displayGameList(createGameCommand);
                }
                if (games[2] != null)
                {
                    CreateGameCommand createGameCommand = new CreateGameCommand();

                    createGameCommand.creatorID = games[2].GameCreatorID;

                    createGameCommand.gameNum = 2;
                    createGameCommand.name = games[2].GameName;

                    displayGameList(createGameCommand);
                }
                if (games[3] != null)
                {
                    CreateGameCommand createGameCommand = new CreateGameCommand();

                    createGameCommand.creatorID = games[3].GameCreatorID;

                    createGameCommand.gameNum = 3;
                    createGameCommand.name = games[3].GameName;

                    displayGameList(createGameCommand);
                }
                if (games[4] != null)
                {
                    CreateGameCommand createGameCommand = new CreateGameCommand();

                    createGameCommand.creatorID = games[4].GameCreatorID;

                    createGameCommand.gameNum = 4;
                    createGameCommand.name = games[4].GameName;

                    displayGameList(createGameCommand);
                }
            }
            else if (obj is CreateGameRequest)
            {
                CreateGameRequest createGameRequest = (CreateGameRequest) obj;

               
                createGame(createGameRequest);

            }
            else if (obj is JoinGameRequest)
            {
                JoinGameRequest joinGameRequest = (JoinGameRequest)obj;

                int who = joinGameRequest.who;
                int gameID = joinGameRequest.gameID;
                string name = joinGameRequest.name;
                
                games[gameID].ScoreBoardNames[who] = name;
                games[gameID].increaseNumberOfPlayers();

                AllSockets[who].gameID = gameID;

                gameNames[gameID].Text = games[gameID].GameName;

                updateGameList();
            }
            else if (obj is UserFinished)
            {
                UserFinished notif = (UserFinished)obj;
                int who = notif.who;
                int gameID = notif.gameID;

                games[gameID].decreaseNumberOfPlayers();

                if (games[gameID].NumberOfPlayers < 1)
                    annouceWinner(gameID);
            }
            else if (obj is DisconnectRequest)
            {
                DisconnectRequest disconnectRequest = (DisconnectRequest)obj;

                int who = disconnectRequest.who;
                int gameID = disconnectRequest.gameID;
                //string name = joinGameRequest.name;
                if(gameID>=0&&gameID<5 && games[gameID]!=null)
                    games[gameID].decreaseNumberOfPlayers();
                if(gameID >= 0 && gameID < 5 && games[gameID] != null && who ==games[gameID].GameCreatorID){

                    playerNameLbl[who].Text = "Player" + (who + 1).ToString() + " -->";
                    playerConnectionLbl[who].Text = "Disconected";

                    gameNames[gameID].Text = "Uncreated";
                    games[gameID] = null;

                    updatePlayerList();
                    updateGameList();

                }
                else if (gameID >= 0 && gameID < 5 && games[gameID].NumberOfPlayers > 0)
                {
                    playerNameLbl[who].Text = "Player" + (who + 1).ToString() + " -->";
                    playerConnectionLbl[who].Text = "Disconected";

                    gameNames[gameID].Text = games[gameID].GameName;

                    updatePlayerList();
                    updateGameList();
                    int nextGuy = findNextGuy(who, gameID);
                    goOnCmd(nextGuy, gameID);
                }
                else if (gameID >= 0 && gameID < 5 && games[gameID].NumberOfPlayers < 1)
                {
                    playerNameLbl[who].Text = "Player" + (who + 1).ToString() + " -->";
                    playerConnectionLbl[who].Text = "Disconected";

                    gameNames[gameID].Text = "Uncreated";
                    games[gameID] = null;


                    updatePlayerList();
                    updateGameList();
                }
                else
                {
                    playerNameLbl[who].Text = "Player" + (who + 1).ToString() + " -->";
                    playerConnectionLbl[who].Text = "Disconected";
                    updatePlayerList();
                    updateGameList();

                }

                AllSockets[who] = null;

               
              
                //this.NextLocation = who;

                //WFCProcedure();
               // WFCThread = new Thread(new ThreadStart(WFCProcedure));
               // WFCThread.Start();






            }



        }

        private void annouceWinner(int gameID)
        {
            AnnounceWinner winner = new AnnounceWinner();


            winner.gameID = gameID;
            int winnerID = 0;

            int highest = -1;

            int[] scoreBoard = games[gameID].ScoreBoard;

            for (int i=0; i<5; i++)
            {
                if (scoreBoard[i] > highest)
                {
                    winnerID = i;
                    highest = scoreBoard[i];
                }
            }


            winner.who = winnerID;
            winner.gameID = gameID;

            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {


                        formatter.Serialize(AllSockets[x].ConnStream, winner); //send new message to clients (temp)

                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }




        }

        private void createGame(CreateGameRequest createGameRequest)
        {

            if (games[0] == null)
            {
                games[0] = new YatzeeGame();
                games[0].GameName = createGameRequest.name;
                
                
                games[0].GameCreatorID = createGameRequest.who;

                //MessageBox.Show(createGameRequest.who.ToString());

                games[0].GameId = 0;

                CreateGameCommand createGameCommand = new CreateGameCommand();
                createGameCommand.name = createGameRequest.name;
                createGameCommand.creatorID = createGameRequest.who;
                createGameCommand.gameNum = 0;
                listBox1.Items.Add("Game " + games[0].GameName + " Created");

                games[0].increaseNumberOfPlayers();
                displayGameList(createGameCommand);

                gameNames[0].Text = games[0].GameName;//update game list

            }
            else if (games[1] == null)
            {
                games[1] = new YatzeeGame();
                games[1].GameName = createGameRequest.name;
                games[1].increaseNumberOfPlayers();
                games[1].GameCreatorID = createGameRequest.who;

                games[1].GameId = 1;

                CreateGameCommand createGameCommand = new CreateGameCommand();
                createGameCommand.name = createGameRequest.name;
                createGameCommand.creatorID = createGameRequest.who;
                createGameCommand.gameNum = 1;
                listBox1.Items.Add("Game " + games[1].GameName + " Created");
                displayGameList(createGameCommand);

                gameNames[1].Text = games[1].GameName;
            }
            else if (games[2] == null)
            {
                games[2] = new YatzeeGame();
                games[2].GameName = createGameRequest.name;
                games[2].increaseNumberOfPlayers();
                games[2].GameCreatorID = createGameRequest.who;

                games[2].GameId = 2;

                CreateGameCommand createGameCommand = new CreateGameCommand();
                createGameCommand.name = createGameRequest.name;
                createGameCommand.creatorID = createGameRequest.who;
                createGameCommand.gameNum = 2;
                listBox1.Items.Add("Game " + games[2].GameName + " Created");
                displayGameList(createGameCommand);

                gameNames[2].Text = games[2].GameName;
            }
            else if (games[3] == null)
            {
                games[3] = new YatzeeGame();
                games[3].GameName = createGameRequest.name;
                games[3].increaseNumberOfPlayers();
                games[3].GameCreatorID = createGameRequest.who;

                games[3].GameId = 3;

                CreateGameCommand createGameCommand = new CreateGameCommand();
                createGameCommand.name = createGameRequest.name;
                createGameCommand.creatorID = createGameRequest.who;
                createGameCommand.gameNum = 3;
                listBox1.Items.Add("Game " + games[3].GameName + " Created");
                displayGameList(createGameCommand);
                gameNames[3].Text = games[3].GameName;
            }
            else if (games[4] == null)
            {
                games[4] = new YatzeeGame();
                games[4].GameName = createGameRequest.name;
                games[4].increaseNumberOfPlayers();
                games[4].GameCreatorID = createGameRequest.who;

                games[4].GameId = 4;

                CreateGameCommand createGameCommand = new CreateGameCommand();
                createGameCommand.name = createGameRequest.name;
                createGameCommand.creatorID = createGameRequest.who;
                createGameCommand.gameNum = 4;
                listBox1.Items.Add("Game " + games[4].GameName + " Created");
                displayGameList(createGameCommand);

                gameNames[4].Text = games[4].GameName;
            }
        }

        private void updateGameList()
        {
            UpdateGameList updateGameList = new UpdateGameList();

            string[] labels = new string[5];

            if (gameNames[0] != null)
                labels[0] = gameNames[0].Text;
            else
                labels[0] = "Uncreated";

            if (gameNames[1] != null)
                labels[1] = gameNames[1].Text;
            else
               labels[1] = "Uncreated";

            if (gameNames[2] != null)
                labels[2] = gameNames[2].Text;
            else
               labels[2] = "Uncreated";

            if (gameNames[3] != null)
               labels[3] = gameNames[3].Text;
            else
               labels[3] = "Uncreated";

            if (gameNames[4] != null)
                labels[4] = gameNames[4].Text;
            else
               labels[4] = "Uncreated";

            updateGameList.labels = labels;
            /*
            updateGameList.labels[1] = gameNames[1].Text;
            updateGameList.labels[2] = gameNames[2].Text;
            updateGameList.labels[3] = gameNames[3].Text;
            updateGameList.labels[4] = gameNames[4].Text;
           
            */
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {


                        formatter.Serialize(AllSockets[x].ConnStream, updateGameList); //send new message to clients (temp)

                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }

        }

        private void updatePlayerList()
        {
            UpdatePlayerListCommand updatePlayerCmd = new UpdatePlayerListCommand();
            updatePlayerCmd.labels[0] = playerNameLbl[0].Text;
            updatePlayerCmd.labels[1] = playerNameLbl[1].Text;
            updatePlayerCmd.labels[2] = playerNameLbl[2].Text;
            updatePlayerCmd.labels[3] = playerNameLbl[3].Text;
            updatePlayerCmd.labels[4] = playerNameLbl[4].Text;

            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {


                        formatter.Serialize(AllSockets[x].ConnStream, updatePlayerCmd); //send new message to clients (temp)

                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }

        }
        private void displayGameList(CreateGameCommand createGameCommand)
        {
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {

                       
                            formatter.Serialize(AllSockets[x].ConnStream, createGameCommand); //send new message to clients (temp)

                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }
        }

        private void assignId(IdAssign idAssign, int who)
        {
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {

                        if (AllSockets[x].which == who)
                            formatter.Serialize(AllSockets[x].ConnStream, idAssign); //send new message to clients (temp)

                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }
        }

        private int findNextGuy(int turnEnder, int gameID)
        {

            int who = turnEnder + 1;
            bool nextFound = false;
            int nextGuy = 0;

            while (!nextFound)
            {


                for (int i = who; i < 5; i++)
                {
                    if (AllSockets[i] != null && !nextFound && AllSockets[i].gameID==gameID)
                    {
                        //MessageBox.Show(i.ToString());
                        nextFound = true;
                        nextGuy = i;

                    }
                }
                who = 0;
            }

            return nextGuy;
        }

        private void sendChatMessage(string message, int who, int gameID)
        {
            Packet.Message chatMessage = new Packet.Message();
            chatMessage.message = message;
            chatMessage.gameID = gameID;
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {  

                        if (AllSockets[x].which != who)
                            formatter.Serialize(AllSockets[x].ConnStream, chatMessage); //send new message to clients (temp)
                        
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }

        }



        private void sendCompleteScoreCommand(CompleteScoreCommand completeScoreCommand, int who)//send command to complete scoring
        {
            int gameID = completeScoreCommand.gameID;
            int[] scoreBoard = games[gameID].ScoreBoard;
            completeScoreCommand.scoreBoard = scoreBoard;
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {
                        if (AllSockets[x].which == who)
                            formatter.Serialize(AllSockets[x].ConnStream, completeScoreCommand); //send new message to clients (temp)
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }



            unlockDiceCMD(0, who);

        }

        private void unlockDiceCMD(int game, int who)//command to unlock all dices
        {
            games[game].unlockDices();

            dices = games[game].Dices;

            UnlockDicesCommand unlockDiceCMD = new UnlockDicesCommand();
            unlockDiceCMD.dices = dices;


          
            try
            {
                //MessageBox.Show(dices[0].Value.ToString());
                for (int x = 0; x < 5; x++)
                {
                    if (AllSockets[x] != null)
                    {
                        if (AllSockets[x].which == who)
                            formatter.Serialize(AllSockets[x].ConnStream, unlockDiceCMD); //send new message to clients (temp)
                    }
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Client Died!");
            }

            
        }

        private void lockDice(LockDiceRequest lockDiceRequest, int who)
        {
            int gameID = lockDiceRequest.gameID;
            int dice = lockDiceRequest.lockedDice;
            games[gameID].lockDice(dice);
            displayDices(gameID, games[gameID].Dices, lockDiceRequest.currentPlayer, who);

        }

        private void Server_Load(object sender, EventArgs e)
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

        private void game1Lbl_Click(object sender, EventArgs e)
        {

        }
    }
}
