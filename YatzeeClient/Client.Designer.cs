namespace YatzeeClient
{
    partial class Client
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.chatboxLabel = new System.Windows.Forms.Label();
            this.gameListLabel = new System.Windows.Forms.Label();
            this.createGameBtn = new System.Windows.Forms.Button();
            this.startGame1Btn = new System.Windows.Forms.Button();
            this.playerNameTxtBox = new System.Windows.Forms.TextBox();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.game1Lbl = new System.Windows.Forms.Label();
            this.game1DesLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.game2Lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.game3Lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.game4Lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.game5Lbl = new System.Windows.Forms.Label();
            this.joinGame1Btn = new System.Windows.Forms.Button();
            this.joinGame2Btn = new System.Windows.Forms.Button();
            this.startGame2Btn = new System.Windows.Forms.Button();
            this.joinGame3Btn = new System.Windows.Forms.Button();
            this.startGame3Btn = new System.Windows.Forms.Button();
            this.joinGame4Btn = new System.Windows.Forms.Button();
            this.startGame4Btn = new System.Windows.Forms.Button();
            this.joinGame5Btn = new System.Windows.Forms.Button();
            this.startGame5Btn = new System.Windows.Forms.Button();
            this.enterGameNameLbl = new System.Windows.Forms.Label();
            this.gameNameTxtBox = new System.Windows.Forms.TextBox();
            this.player5ConnLbl = new System.Windows.Forms.Label();
            this.player4ConnLbl = new System.Windows.Forms.Label();
            this.player3ConnLbl = new System.Windows.Forms.Label();
            this.player2ConnLbl = new System.Windows.Forms.Label();
            this.player1ConnLbl = new System.Windows.Forms.Label();
            this.player5Lbl = new System.Windows.Forms.Label();
            this.player4Lbl = new System.Windows.Forms.Label();
            this.player3Lbl = new System.Windows.Forms.Label();
            this.player2Lbl = new System.Windows.Forms.Label();
            this.player1Lbl = new System.Windows.Forms.Label();
            this.connectedPlayersLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(353, 28);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(279, 116);
            this.listBox1.TabIndex = 0;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(123, 9);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(132, 22);
            this.txtIPAddress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // btnConnect
            // 
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConnect.Location = new System.Drawing.Point(13, 79);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(123, 28);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSendMessage.Location = new System.Drawing.Point(353, 152);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(123, 28);
            this.btnSendMessage.TabIndex = 4;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(500, 152);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(132, 22);
            this.txtMessage.TabIndex = 6;
            // 
            // chatboxLabel
            // 
            this.chatboxLabel.AutoSize = true;
            this.chatboxLabel.Location = new System.Drawing.Point(353, 7);
            this.chatboxLabel.Name = "chatboxLabel";
            this.chatboxLabel.Size = new System.Drawing.Size(64, 17);
            this.chatboxLabel.TabIndex = 7;
            this.chatboxLabel.Text = "Chat Box";
            // 
            // gameListLabel
            // 
            this.gameListLabel.AutoSize = true;
            this.gameListLabel.Location = new System.Drawing.Point(284, 197);
            this.gameListLabel.Name = "gameListLabel";
            this.gameListLabel.Size = new System.Drawing.Size(118, 17);
            this.gameListLabel.TabIndex = 8;
            this.gameListLabel.Text = "Available Games:";
            // 
            // createGameBtn
            // 
            this.createGameBtn.Location = new System.Drawing.Point(13, 315);
            this.createGameBtn.Name = "createGameBtn";
            this.createGameBtn.Size = new System.Drawing.Size(123, 23);
            this.createGameBtn.TabIndex = 10;
            this.createGameBtn.Text = "Create Game";
            this.createGameBtn.UseVisualStyleBackColor = true;
            this.createGameBtn.Click += new System.EventHandler(this.createGameBtn_Click);
            // 
            // startGame1Btn
            // 
            this.startGame1Btn.Enabled = false;
            this.startGame1Btn.Location = new System.Drawing.Point(220, 227);
            this.startGame1Btn.Name = "startGame1Btn";
            this.startGame1Btn.Size = new System.Drawing.Size(49, 23);
            this.startGame1Btn.TabIndex = 12;
            this.startGame1Btn.Text = "Start";
            this.startGame1Btn.UseVisualStyleBackColor = true;
            this.startGame1Btn.Click += new System.EventHandler(this.startGameBtn_Click);
            // 
            // playerNameTxtBox
            // 
            this.playerNameTxtBox.Location = new System.Drawing.Point(123, 39);
            this.playerNameTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.playerNameTxtBox.Name = "playerNameTxtBox";
            this.playerNameTxtBox.Size = new System.Drawing.Size(132, 22);
            this.playerNameTxtBox.TabIndex = 13;
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Location = new System.Drawing.Point(10, 42);
            this.playerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(93, 17);
            this.playerNameLabel.TabIndex = 14;
            this.playerNameLabel.Text = "Player Name:";
            // 
            // game1Lbl
            // 
            this.game1Lbl.AutoSize = true;
            this.game1Lbl.Location = new System.Drawing.Point(324, 227);
            this.game1Lbl.Name = "game1Lbl";
            this.game1Lbl.Size = new System.Drawing.Size(74, 17);
            this.game1Lbl.TabIndex = 16;
            this.game1Lbl.Text = "Uncreated";
            // 
            // game1DesLbl
            // 
            this.game1DesLbl.AutoSize = true;
            this.game1DesLbl.Location = new System.Drawing.Point(287, 227);
            this.game1DesLbl.Name = "game1DesLbl";
            this.game1DesLbl.Size = new System.Drawing.Size(16, 17);
            this.game1DesLbl.TabIndex = 17;
            this.game1DesLbl.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(287, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "2";
            // 
            // game2Lbl
            // 
            this.game2Lbl.AutoSize = true;
            this.game2Lbl.Location = new System.Drawing.Point(324, 258);
            this.game2Lbl.Name = "game2Lbl";
            this.game2Lbl.Size = new System.Drawing.Size(74, 17);
            this.game2Lbl.TabIndex = 18;
            this.game2Lbl.Text = "Uncreated";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(287, 287);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "3";
            // 
            // game3Lbl
            // 
            this.game3Lbl.AutoSize = true;
            this.game3Lbl.Location = new System.Drawing.Point(324, 287);
            this.game3Lbl.Name = "game3Lbl";
            this.game3Lbl.Size = new System.Drawing.Size(74, 17);
            this.game3Lbl.TabIndex = 20;
            this.game3Lbl.Text = "Uncreated";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 316);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "4";
            // 
            // game4Lbl
            // 
            this.game4Lbl.AutoSize = true;
            this.game4Lbl.Location = new System.Drawing.Point(324, 316);
            this.game4Lbl.Name = "game4Lbl";
            this.game4Lbl.Size = new System.Drawing.Size(74, 17);
            this.game4Lbl.TabIndex = 22;
            this.game4Lbl.Text = "Uncreated";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 346);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "5";
            // 
            // game5Lbl
            // 
            this.game5Lbl.AutoSize = true;
            this.game5Lbl.Location = new System.Drawing.Point(324, 346);
            this.game5Lbl.Name = "game5Lbl";
            this.game5Lbl.Size = new System.Drawing.Size(74, 17);
            this.game5Lbl.TabIndex = 24;
            this.game5Lbl.Text = "Uncreated";
            // 
            // joinGame1Btn
            // 
            this.joinGame1Btn.Enabled = false;
            this.joinGame1Btn.Location = new System.Drawing.Point(159, 227);
            this.joinGame1Btn.Name = "joinGame1Btn";
            this.joinGame1Btn.Size = new System.Drawing.Size(55, 23);
            this.joinGame1Btn.TabIndex = 26;
            this.joinGame1Btn.Text = "Join";
            this.joinGame1Btn.UseVisualStyleBackColor = true;
            this.joinGame1Btn.Click += new System.EventHandler(this.joinGame1Btn_Click);
            // 
            // joinGame2Btn
            // 
            this.joinGame2Btn.Enabled = false;
            this.joinGame2Btn.Location = new System.Drawing.Point(159, 258);
            this.joinGame2Btn.Name = "joinGame2Btn";
            this.joinGame2Btn.Size = new System.Drawing.Size(55, 23);
            this.joinGame2Btn.TabIndex = 28;
            this.joinGame2Btn.Text = "Join";
            this.joinGame2Btn.UseVisualStyleBackColor = true;
            this.joinGame2Btn.Click += new System.EventHandler(this.joinGame2Btn_Click);
            // 
            // startGame2Btn
            // 
            this.startGame2Btn.Enabled = false;
            this.startGame2Btn.Location = new System.Drawing.Point(220, 258);
            this.startGame2Btn.Name = "startGame2Btn";
            this.startGame2Btn.Size = new System.Drawing.Size(49, 23);
            this.startGame2Btn.TabIndex = 27;
            this.startGame2Btn.Text = "Start";
            this.startGame2Btn.UseVisualStyleBackColor = true;
            this.startGame2Btn.Click += new System.EventHandler(this.startGame2Btn_Click);
            // 
            // joinGame3Btn
            // 
            this.joinGame3Btn.Enabled = false;
            this.joinGame3Btn.Location = new System.Drawing.Point(159, 287);
            this.joinGame3Btn.Name = "joinGame3Btn";
            this.joinGame3Btn.Size = new System.Drawing.Size(55, 23);
            this.joinGame3Btn.TabIndex = 30;
            this.joinGame3Btn.Text = "Join";
            this.joinGame3Btn.UseVisualStyleBackColor = true;
            this.joinGame3Btn.Click += new System.EventHandler(this.joinGame3Btn_Click);
            // 
            // startGame3Btn
            // 
            this.startGame3Btn.Enabled = false;
            this.startGame3Btn.Location = new System.Drawing.Point(220, 287);
            this.startGame3Btn.Name = "startGame3Btn";
            this.startGame3Btn.Size = new System.Drawing.Size(49, 23);
            this.startGame3Btn.TabIndex = 29;
            this.startGame3Btn.Text = "Start";
            this.startGame3Btn.UseVisualStyleBackColor = true;
            this.startGame3Btn.Click += new System.EventHandler(this.startGame3Btn_Click);
            // 
            // joinGame4Btn
            // 
            this.joinGame4Btn.Enabled = false;
            this.joinGame4Btn.Location = new System.Drawing.Point(159, 316);
            this.joinGame4Btn.Name = "joinGame4Btn";
            this.joinGame4Btn.Size = new System.Drawing.Size(55, 23);
            this.joinGame4Btn.TabIndex = 32;
            this.joinGame4Btn.Text = "Join";
            this.joinGame4Btn.UseVisualStyleBackColor = true;
            this.joinGame4Btn.Click += new System.EventHandler(this.joinGame4Btn_Click);
            // 
            // startGame4Btn
            // 
            this.startGame4Btn.Enabled = false;
            this.startGame4Btn.Location = new System.Drawing.Point(220, 316);
            this.startGame4Btn.Name = "startGame4Btn";
            this.startGame4Btn.Size = new System.Drawing.Size(49, 23);
            this.startGame4Btn.TabIndex = 31;
            this.startGame4Btn.Text = "Start";
            this.startGame4Btn.UseVisualStyleBackColor = true;
            this.startGame4Btn.Click += new System.EventHandler(this.startGame4Btn_Click);
            // 
            // joinGame5Btn
            // 
            this.joinGame5Btn.Enabled = false;
            this.joinGame5Btn.Location = new System.Drawing.Point(159, 346);
            this.joinGame5Btn.Name = "joinGame5Btn";
            this.joinGame5Btn.Size = new System.Drawing.Size(55, 23);
            this.joinGame5Btn.TabIndex = 34;
            this.joinGame5Btn.Text = "Join";
            this.joinGame5Btn.UseVisualStyleBackColor = true;
            this.joinGame5Btn.Click += new System.EventHandler(this.joinGame5Btn_Click);
            // 
            // startGame5Btn
            // 
            this.startGame5Btn.Enabled = false;
            this.startGame5Btn.Location = new System.Drawing.Point(220, 346);
            this.startGame5Btn.Name = "startGame5Btn";
            this.startGame5Btn.Size = new System.Drawing.Size(49, 23);
            this.startGame5Btn.TabIndex = 33;
            this.startGame5Btn.Text = "Start";
            this.startGame5Btn.UseVisualStyleBackColor = true;
            this.startGame5Btn.Click += new System.EventHandler(this.startGame5Btn_Click);
            // 
            // enterGameNameLbl
            // 
            this.enterGameNameLbl.AutoSize = true;
            this.enterGameNameLbl.Location = new System.Drawing.Point(12, 257);
            this.enterGameNameLbl.Name = "enterGameNameLbl";
            this.enterGameNameLbl.Size = new System.Drawing.Size(141, 17);
            this.enterGameNameLbl.TabIndex = 35;
            this.enterGameNameLbl.Text = "Enter a Game Name:";
            // 
            // gameNameTxtBox
            // 
            this.gameNameTxtBox.Location = new System.Drawing.Point(13, 283);
            this.gameNameTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.gameNameTxtBox.Name = "gameNameTxtBox";
            this.gameNameTxtBox.Size = new System.Drawing.Size(132, 22);
            this.gameNameTxtBox.TabIndex = 36;
            // 
            // player5ConnLbl
            // 
            this.player5ConnLbl.AutoSize = true;
            this.player5ConnLbl.Location = new System.Drawing.Point(549, 348);
            this.player5ConnLbl.Name = "player5ConnLbl";
            this.player5ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player5ConnLbl.TabIndex = 47;
            this.player5ConnLbl.Text = "disconected";
            // 
            // player4ConnLbl
            // 
            this.player4ConnLbl.AutoSize = true;
            this.player4ConnLbl.Location = new System.Drawing.Point(549, 319);
            this.player4ConnLbl.Name = "player4ConnLbl";
            this.player4ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player4ConnLbl.TabIndex = 46;
            this.player4ConnLbl.Text = "disconected";
            // 
            // player3ConnLbl
            // 
            this.player3ConnLbl.AutoSize = true;
            this.player3ConnLbl.Location = new System.Drawing.Point(549, 290);
            this.player3ConnLbl.Name = "player3ConnLbl";
            this.player3ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player3ConnLbl.TabIndex = 45;
            this.player3ConnLbl.Text = "disconected";
            // 
            // player2ConnLbl
            // 
            this.player2ConnLbl.AutoSize = true;
            this.player2ConnLbl.Location = new System.Drawing.Point(549, 262);
            this.player2ConnLbl.Name = "player2ConnLbl";
            this.player2ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player2ConnLbl.TabIndex = 44;
            this.player2ConnLbl.Text = "disconected";
            // 
            // player1ConnLbl
            // 
            this.player1ConnLbl.AutoSize = true;
            this.player1ConnLbl.Location = new System.Drawing.Point(549, 232);
            this.player1ConnLbl.Name = "player1ConnLbl";
            this.player1ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player1ConnLbl.TabIndex = 43;
            this.player1ConnLbl.Text = "disconected";
            // 
            // player5Lbl
            // 
            this.player5Lbl.AutoSize = true;
            this.player5Lbl.Location = new System.Drawing.Point(462, 348);
            this.player5Lbl.Name = "player5Lbl";
            this.player5Lbl.Size = new System.Drawing.Size(78, 17);
            this.player5Lbl.TabIndex = 42;
            this.player5Lbl.Text = "Player5 -->";
            // 
            // player4Lbl
            // 
            this.player4Lbl.AutoSize = true;
            this.player4Lbl.Location = new System.Drawing.Point(462, 319);
            this.player4Lbl.Name = "player4Lbl";
            this.player4Lbl.Size = new System.Drawing.Size(78, 17);
            this.player4Lbl.TabIndex = 41;
            this.player4Lbl.Text = "Player4 -->";
            // 
            // player3Lbl
            // 
            this.player3Lbl.AutoSize = true;
            this.player3Lbl.Location = new System.Drawing.Point(462, 290);
            this.player3Lbl.Name = "player3Lbl";
            this.player3Lbl.Size = new System.Drawing.Size(78, 17);
            this.player3Lbl.TabIndex = 40;
            this.player3Lbl.Text = "Player3 -->";
            // 
            // player2Lbl
            // 
            this.player2Lbl.AutoSize = true;
            this.player2Lbl.Location = new System.Drawing.Point(462, 262);
            this.player2Lbl.Name = "player2Lbl";
            this.player2Lbl.Size = new System.Drawing.Size(78, 17);
            this.player2Lbl.TabIndex = 39;
            this.player2Lbl.Text = "Player2 -->";
            // 
            // player1Lbl
            // 
            this.player1Lbl.AutoSize = true;
            this.player1Lbl.Location = new System.Drawing.Point(462, 232);
            this.player1Lbl.Name = "player1Lbl";
            this.player1Lbl.Size = new System.Drawing.Size(78, 17);
            this.player1Lbl.TabIndex = 38;
            this.player1Lbl.Text = "Player1 -->";
            // 
            // connectedPlayersLbl
            // 
            this.connectedPlayersLbl.AutoSize = true;
            this.connectedPlayersLbl.Location = new System.Drawing.Point(462, 206);
            this.connectedPlayersLbl.Name = "connectedPlayersLbl";
            this.connectedPlayersLbl.Size = new System.Drawing.Size(171, 17);
            this.connectedPlayersLbl.TabIndex = 37;
            this.connectedPlayersLbl.Text = "List of connected Players:";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 380);
            this.Controls.Add(this.player5ConnLbl);
            this.Controls.Add(this.player4ConnLbl);
            this.Controls.Add(this.player3ConnLbl);
            this.Controls.Add(this.player2ConnLbl);
            this.Controls.Add(this.player1ConnLbl);
            this.Controls.Add(this.player5Lbl);
            this.Controls.Add(this.player4Lbl);
            this.Controls.Add(this.player3Lbl);
            this.Controls.Add(this.player2Lbl);
            this.Controls.Add(this.player1Lbl);
            this.Controls.Add(this.connectedPlayersLbl);
            this.Controls.Add(this.gameNameTxtBox);
            this.Controls.Add(this.enterGameNameLbl);
            this.Controls.Add(this.joinGame5Btn);
            this.Controls.Add(this.startGame5Btn);
            this.Controls.Add(this.joinGame4Btn);
            this.Controls.Add(this.startGame4Btn);
            this.Controls.Add(this.joinGame3Btn);
            this.Controls.Add(this.startGame3Btn);
            this.Controls.Add(this.joinGame2Btn);
            this.Controls.Add(this.startGame2Btn);
            this.Controls.Add(this.joinGame1Btn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.game5Lbl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.game4Lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.game3Lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.game2Lbl);
            this.Controls.Add(this.game1DesLbl);
            this.Controls.Add(this.game1Lbl);
            this.Controls.Add(this.playerNameLabel);
            this.Controls.Add(this.playerNameTxtBox);
            this.Controls.Add(this.startGame1Btn);
            this.Controls.Add(this.createGameBtn);
            this.Controls.Add(this.gameListLabel);
            this.Controls.Add(this.chatboxLabel);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Client";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Client_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSendMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label chatboxLabel;
        private System.Windows.Forms.Label gameListLabel;
        private System.Windows.Forms.Button createGameBtn;
        private System.Windows.Forms.Button startGame1Btn;
        private System.Windows.Forms.TextBox playerNameTxtBox;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label game1Lbl;
        private System.Windows.Forms.Label game1DesLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label game2Lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label game3Lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label game4Lbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label game5Lbl;
        private System.Windows.Forms.Button joinGame1Btn;
        private System.Windows.Forms.Button joinGame2Btn;
        private System.Windows.Forms.Button startGame2Btn;
        private System.Windows.Forms.Button joinGame3Btn;
        private System.Windows.Forms.Button startGame3Btn;
        private System.Windows.Forms.Button joinGame4Btn;
        private System.Windows.Forms.Button startGame4Btn;
        private System.Windows.Forms.Button joinGame5Btn;
        private System.Windows.Forms.Button startGame5Btn;
        private System.Windows.Forms.Label enterGameNameLbl;
        private System.Windows.Forms.TextBox gameNameTxtBox;
        private System.Windows.Forms.Label player5ConnLbl;
        private System.Windows.Forms.Label player4ConnLbl;
        private System.Windows.Forms.Label player3ConnLbl;
        private System.Windows.Forms.Label player2ConnLbl;
        private System.Windows.Forms.Label player1ConnLbl;
        private System.Windows.Forms.Label player5Lbl;
        private System.Windows.Forms.Label player4Lbl;
        private System.Windows.Forms.Label player3Lbl;
        private System.Windows.Forms.Label player2Lbl;
        private System.Windows.Forms.Label player1Lbl;
        private System.Windows.Forms.Label connectedPlayersLbl;
    }
}

