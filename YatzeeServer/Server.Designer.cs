namespace YatzeeServer
{
    partial class Server
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
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chatBoxLbl = new System.Windows.Forms.Label();
            this.connectedPlayersLbl = new System.Windows.Forms.Label();
            this.player1Lbl = new System.Windows.Forms.Label();
            this.player2Lbl = new System.Windows.Forms.Label();
            this.player3Lbl = new System.Windows.Forms.Label();
            this.player4Lbl = new System.Windows.Forms.Label();
            this.player5Lbl = new System.Windows.Forms.Label();
            this.player1ConnLbl = new System.Windows.Forms.Label();
            this.player2ConnLbl = new System.Windows.Forms.Label();
            this.player3ConnLbl = new System.Windows.Forms.Label();
            this.player4ConnLbl = new System.Windows.Forms.Label();
            this.player5ConnLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.game5Lbl = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.game4Lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.game3Lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.game2Lbl = new System.Windows.Forms.Label();
            this.game1DesLbl = new System.Windows.Forms.Label();
            this.game1Lbl = new System.Windows.Forms.Label();
            this.gameListLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(17, 16);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(100, 28);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(17, 53);
            this.btnStopServer.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(100, 28);
            this.btnStopServer.TabIndex = 1;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(238, 16);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(363, 116);
            this.listBox1.TabIndex = 2;
            // 
            // chatBoxLbl
            // 
            this.chatBoxLbl.AutoSize = true;
            this.chatBoxLbl.Location = new System.Drawing.Point(166, 16);
            this.chatBoxLbl.Name = "chatBoxLbl";
            this.chatBoxLbl.Size = new System.Drawing.Size(55, 17);
            this.chatBoxLbl.TabIndex = 3;
            this.chatBoxLbl.Text = "Chat-->";
            // 
            // connectedPlayersLbl
            // 
            this.connectedPlayersLbl.AutoSize = true;
            this.connectedPlayersLbl.Location = new System.Drawing.Point(24, 170);
            this.connectedPlayersLbl.Name = "connectedPlayersLbl";
            this.connectedPlayersLbl.Size = new System.Drawing.Size(171, 17);
            this.connectedPlayersLbl.TabIndex = 4;
            this.connectedPlayersLbl.Text = "List of connected Players:";
            // 
            // player1Lbl
            // 
            this.player1Lbl.AutoSize = true;
            this.player1Lbl.Location = new System.Drawing.Point(24, 196);
            this.player1Lbl.Name = "player1Lbl";
            this.player1Lbl.Size = new System.Drawing.Size(78, 17);
            this.player1Lbl.TabIndex = 5;
            this.player1Lbl.Text = "Player1 -->";
            // 
            // player2Lbl
            // 
            this.player2Lbl.AutoSize = true;
            this.player2Lbl.Location = new System.Drawing.Point(24, 226);
            this.player2Lbl.Name = "player2Lbl";
            this.player2Lbl.Size = new System.Drawing.Size(78, 17);
            this.player2Lbl.TabIndex = 6;
            this.player2Lbl.Text = "Player2 -->";
            // 
            // player3Lbl
            // 
            this.player3Lbl.AutoSize = true;
            this.player3Lbl.Location = new System.Drawing.Point(24, 254);
            this.player3Lbl.Name = "player3Lbl";
            this.player3Lbl.Size = new System.Drawing.Size(78, 17);
            this.player3Lbl.TabIndex = 7;
            this.player3Lbl.Text = "Player3 -->";
            // 
            // player4Lbl
            // 
            this.player4Lbl.AutoSize = true;
            this.player4Lbl.Location = new System.Drawing.Point(24, 283);
            this.player4Lbl.Name = "player4Lbl";
            this.player4Lbl.Size = new System.Drawing.Size(78, 17);
            this.player4Lbl.TabIndex = 8;
            this.player4Lbl.Text = "Player4 -->";
            // 
            // player5Lbl
            // 
            this.player5Lbl.AutoSize = true;
            this.player5Lbl.Location = new System.Drawing.Point(24, 312);
            this.player5Lbl.Name = "player5Lbl";
            this.player5Lbl.Size = new System.Drawing.Size(78, 17);
            this.player5Lbl.TabIndex = 9;
            this.player5Lbl.Text = "Player5 -->";
            // 
            // player1ConnLbl
            // 
            this.player1ConnLbl.AutoSize = true;
            this.player1ConnLbl.Location = new System.Drawing.Point(111, 196);
            this.player1ConnLbl.Name = "player1ConnLbl";
            this.player1ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player1ConnLbl.TabIndex = 10;
            this.player1ConnLbl.Text = "disconected";
            // 
            // player2ConnLbl
            // 
            this.player2ConnLbl.AutoSize = true;
            this.player2ConnLbl.Location = new System.Drawing.Point(111, 226);
            this.player2ConnLbl.Name = "player2ConnLbl";
            this.player2ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player2ConnLbl.TabIndex = 11;
            this.player2ConnLbl.Text = "disconected";
            // 
            // player3ConnLbl
            // 
            this.player3ConnLbl.AutoSize = true;
            this.player3ConnLbl.Location = new System.Drawing.Point(111, 254);
            this.player3ConnLbl.Name = "player3ConnLbl";
            this.player3ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player3ConnLbl.TabIndex = 12;
            this.player3ConnLbl.Text = "disconected";
            // 
            // player4ConnLbl
            // 
            this.player4ConnLbl.AutoSize = true;
            this.player4ConnLbl.Location = new System.Drawing.Point(111, 283);
            this.player4ConnLbl.Name = "player4ConnLbl";
            this.player4ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player4ConnLbl.TabIndex = 13;
            this.player4ConnLbl.Text = "disconected";
            // 
            // player5ConnLbl
            // 
            this.player5ConnLbl.AutoSize = true;
            this.player5ConnLbl.Location = new System.Drawing.Point(111, 312);
            this.player5ConnLbl.Name = "player5ConnLbl";
            this.player5ConnLbl.Size = new System.Drawing.Size(84, 17);
            this.player5ConnLbl.TabIndex = 14;
            this.player5ConnLbl.Text = "disconected";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(255, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 36;
            this.label8.Text = "5";
            // 
            // game5Lbl
            // 
            this.game5Lbl.AutoSize = true;
            this.game5Lbl.Location = new System.Drawing.Point(292, 319);
            this.game5Lbl.Name = "game5Lbl";
            this.game5Lbl.Size = new System.Drawing.Size(74, 17);
            this.game5Lbl.TabIndex = 35;
            this.game5Lbl.Text = "Uncreated";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(255, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "4";
            // 
            // game4Lbl
            // 
            this.game4Lbl.AutoSize = true;
            this.game4Lbl.Location = new System.Drawing.Point(292, 289);
            this.game4Lbl.Name = "game4Lbl";
            this.game4Lbl.Size = new System.Drawing.Size(74, 17);
            this.game4Lbl.TabIndex = 33;
            this.game4Lbl.Text = "Uncreated";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "3";
            // 
            // game3Lbl
            // 
            this.game3Lbl.AutoSize = true;
            this.game3Lbl.Location = new System.Drawing.Point(292, 260);
            this.game3Lbl.Name = "game3Lbl";
            this.game3Lbl.Size = new System.Drawing.Size(74, 17);
            this.game3Lbl.TabIndex = 31;
            this.game3Lbl.Text = "Uncreated";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "2";
            // 
            // game2Lbl
            // 
            this.game2Lbl.AutoSize = true;
            this.game2Lbl.Location = new System.Drawing.Point(292, 231);
            this.game2Lbl.Name = "game2Lbl";
            this.game2Lbl.Size = new System.Drawing.Size(74, 17);
            this.game2Lbl.TabIndex = 29;
            this.game2Lbl.Text = "Uncreated";
            // 
            // game1DesLbl
            // 
            this.game1DesLbl.AutoSize = true;
            this.game1DesLbl.Location = new System.Drawing.Point(255, 200);
            this.game1DesLbl.Name = "game1DesLbl";
            this.game1DesLbl.Size = new System.Drawing.Size(16, 17);
            this.game1DesLbl.TabIndex = 28;
            this.game1DesLbl.Text = "1";
            // 
            // game1Lbl
            // 
            this.game1Lbl.AutoSize = true;
            this.game1Lbl.Location = new System.Drawing.Point(292, 200);
            this.game1Lbl.Name = "game1Lbl";
            this.game1Lbl.Size = new System.Drawing.Size(74, 17);
            this.game1Lbl.TabIndex = 27;
            this.game1Lbl.Text = "Uncreated";
            this.game1Lbl.Click += new System.EventHandler(this.game1Lbl_Click);
            // 
            // gameListLabel
            // 
            this.gameListLabel.AutoSize = true;
            this.gameListLabel.Location = new System.Drawing.Point(252, 170);
            this.gameListLabel.Name = "gameListLabel";
            this.gameListLabel.Size = new System.Drawing.Size(118, 17);
            this.gameListLabel.TabIndex = 26;
            this.gameListLabel.Text = "Available Games:";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 373);
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
            this.Controls.Add(this.gameListLabel);
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
            this.Controls.Add(this.chatBoxLbl);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnStopServer);
            this.Controls.Add(this.btnStartServer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label chatBoxLbl;
        private System.Windows.Forms.Label connectedPlayersLbl;
        private System.Windows.Forms.Label player1Lbl;
        private System.Windows.Forms.Label player2Lbl;
        private System.Windows.Forms.Label player3Lbl;
        private System.Windows.Forms.Label player4Lbl;
        private System.Windows.Forms.Label player5Lbl;
        private System.Windows.Forms.Label player1ConnLbl;
        private System.Windows.Forms.Label player2ConnLbl;
        private System.Windows.Forms.Label player3ConnLbl;
        private System.Windows.Forms.Label player4ConnLbl;
        private System.Windows.Forms.Label player5ConnLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label game5Lbl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label game4Lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label game3Lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label game2Lbl;
        private System.Windows.Forms.Label game1DesLbl;
        private System.Windows.Forms.Label game1Lbl;
        private System.Windows.Forms.Label gameListLabel;
    }
}

