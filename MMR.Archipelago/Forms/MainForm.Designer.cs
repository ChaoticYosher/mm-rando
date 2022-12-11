using MMR.Randomizer.Models.Settings;
using System;
using System.Drawing;
using System.Linq;

namespace MMR.Archipelago.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openROM = new System.Windows.Forms.OpenFileDialog();
            this.openBROM = new System.Windows.Forms.OpenFileDialog();
            this.textArchipelagoRoom = new System.Windows.Forms.RichTextBox();
            this.gConnect = new System.Windows.Forms.GroupBox();
            this.bConnect = new System.Windows.Forms.Button();
            this.textPass = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.textSlot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.gGenerate = new System.Windows.Forms.GroupBox();
            this.tPatch = new System.Windows.Forms.TextBox();
            this.bApplyPatch = new System.Windows.Forms.Button();
            this.bLoadPatch = new System.Windows.Forms.Button();
            this.bSkip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bopen = new System.Windows.Forms.Button();
            this.tROMName = new System.Windows.Forms.TextBox();
            this.lStatus = new System.Windows.Forms.Label();
            this.cDummy = new System.Windows.Forms.CheckBox();
            this.pProgress = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bSendMessage = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkExporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gConnect.SuspendLayout();
            this.gGenerate.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openROM
            // 
            this.openROM.Filter = "ROM files|*.z64";
            // 
            // openBROM
            // 
            this.openBROM.Filter = "ROM files|*.z64;*.v64;*.n64";
            // 
            // textArchipelagoRoom
            // 
            this.textArchipelagoRoom.Location = new System.Drawing.Point(12, 229);
            this.textArchipelagoRoom.Name = "textArchipelagoRoom";
            this.textArchipelagoRoom.ReadOnly = true;
            this.textArchipelagoRoom.Size = new System.Drawing.Size(790, 411);
            this.textArchipelagoRoom.TabIndex = 19;
            this.textArchipelagoRoom.Text = "";
            // 
            // gConnect
            // 
            this.gConnect.Controls.Add(this.bConnect);
            this.gConnect.Controls.Add(this.textPass);
            this.gConnect.Controls.Add(this.labelPass);
            this.gConnect.Controls.Add(this.textSlot);
            this.gConnect.Controls.Add(this.label2);
            this.gConnect.Controls.Add(this.textIP);
            this.gConnect.Controls.Add(this.labelIPAddress);
            this.gConnect.Location = new System.Drawing.Point(537, 40);
            this.gConnect.Name = "gConnect";
            this.gConnect.Size = new System.Drawing.Size(266, 163);
            this.gConnect.TabIndex = 20;
            this.gConnect.TabStop = false;
            this.gConnect.Text = "Connect";
            // 
            // bConnect
            // 
            this.bConnect.Location = new System.Drawing.Point(77, 120);
            this.bConnect.Name = "bConnect";
            this.bConnect.Size = new System.Drawing.Size(183, 31);
            this.bConnect.TabIndex = 13;
            this.bConnect.Text = "Connect";
            this.bConnect.UseVisualStyleBackColor = true;
            this.bConnect.Click += new System.EventHandler(this.bConnect_Click);
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(77, 91);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(183, 23);
            this.textPass.TabIndex = 12;
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(11, 94);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(60, 15);
            this.labelPass.TabIndex = 11;
            this.labelPass.Text = "Password:";
            this.labelPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textSlot
            // 
            this.textSlot.Location = new System.Drawing.Point(77, 62);
            this.textSlot.Name = "textSlot";
            this.textSlot.Size = new System.Drawing.Size(183, 23);
            this.textSlot.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Slot:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(77, 33);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(183, 23);
            this.textIP.TabIndex = 8;
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(51, 36);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(20, 15);
            this.labelIPAddress.TabIndex = 7;
            this.labelIPAddress.Text = "IP:";
            this.labelIPAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gGenerate
            // 
            this.gGenerate.Controls.Add(this.tPatch);
            this.gGenerate.Controls.Add(this.bApplyPatch);
            this.gGenerate.Controls.Add(this.bLoadPatch);
            this.gGenerate.Controls.Add(this.bSkip);
            this.gGenerate.Controls.Add(this.label1);
            this.gGenerate.Controls.Add(this.bopen);
            this.gGenerate.Controls.Add(this.tROMName);
            this.gGenerate.Controls.Add(this.lStatus);
            this.gGenerate.Controls.Add(this.cDummy);
            this.gGenerate.Controls.Add(this.pProgress);
            this.gGenerate.Location = new System.Drawing.Point(13, 40);
            this.gGenerate.Name = "gGenerate";
            this.gGenerate.Size = new System.Drawing.Size(518, 163);
            this.gGenerate.TabIndex = 21;
            this.gGenerate.TabStop = false;
            this.gGenerate.Text = "Generate";
            // 
            // tPatch
            // 
            this.tPatch.Location = new System.Drawing.Point(137, 75);
            this.tPatch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tPatch.Name = "tPatch";
            this.tPatch.ReadOnly = true;
            this.tPatch.Size = new System.Drawing.Size(280, 23);
            this.tPatch.TabIndex = 38;
            // 
            // bApplyPatch
            // 
            this.bApplyPatch.Location = new System.Drawing.Point(425, 37);
            this.bApplyPatch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bApplyPatch.Name = "bApplyPatch";
            this.bApplyPatch.Size = new System.Drawing.Size(82, 61);
            this.bApplyPatch.TabIndex = 36;
            this.bApplyPatch.Text = "Create AP Game";
            this.bApplyPatch.UseVisualStyleBackColor = true;
            this.bApplyPatch.Click += new System.EventHandler(this.bApplyPatch_Click);
            // 
            // bLoadPatch
            // 
            this.bLoadPatch.Location = new System.Drawing.Point(12, 70);
            this.bLoadPatch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bLoadPatch.Name = "bLoadPatch";
            this.bLoadPatch.Size = new System.Drawing.Size(113, 31);
            this.bLoadPatch.TabIndex = 37;
            this.bLoadPatch.Text = "Load AP Patch";
            this.bLoadPatch.UseVisualStyleBackColor = true;
            this.bLoadPatch.Click += new System.EventHandler(this.bLoadPatch_Click);
            // 
            // bSkip
            // 
            this.bSkip.Location = new System.Drawing.Point(432, 126);
            this.bSkip.Name = "bSkip";
            this.bSkip.Size = new System.Drawing.Size(75, 23);
            this.bSkip.TabIndex = 35;
            this.bSkip.Text = "Skip";
            this.bSkip.UseVisualStyleBackColor = true;
            this.bSkip.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 15);
            this.label1.TabIndex = 32;
            this.label1.Text = "ROM must be Majora\'s Mask (U) ending with \".z64\"";
            // 
            // bopen
            // 
            this.bopen.Location = new System.Drawing.Point(13, 33);
            this.bopen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bopen.Name = "bopen";
            this.bopen.Size = new System.Drawing.Size(112, 31);
            this.bopen.TabIndex = 29;
            this.bopen.Text = "Open ROM";
            this.bopen.UseVisualStyleBackColor = true;
            this.bopen.Click += new System.EventHandler(this.bopen_Click);
            // 
            // tROMName
            // 
            this.tROMName.Location = new System.Drawing.Point(137, 37);
            this.tROMName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tROMName.Name = "tROMName";
            this.tROMName.ReadOnly = true;
            this.tROMName.Size = new System.Drawing.Size(280, 23);
            this.tROMName.TabIndex = 30;
            // 
            // lStatus
            // 
            this.lStatus.AutoSize = true;
            this.lStatus.BackColor = System.Drawing.Color.Transparent;
            this.lStatus.Location = new System.Drawing.Point(13, 104);
            this.lStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStatus.Name = "lStatus";
            this.lStatus.Size = new System.Drawing.Size(48, 15);
            this.lStatus.TabIndex = 33;
            this.lStatus.Text = "Ready...";
            // 
            // cDummy
            // 
            this.cDummy.AutoSize = true;
            this.cDummy.Enabled = false;
            this.cDummy.Location = new System.Drawing.Point(412, 117);
            this.cDummy.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cDummy.Name = "cDummy";
            this.cDummy.Size = new System.Drawing.Size(83, 19);
            this.cDummy.TabIndex = 31;
            this.cDummy.Text = "checkBox1";
            this.cDummy.UseVisualStyleBackColor = true;
            this.cDummy.Visible = false;
            // 
            // pProgress
            // 
            this.pProgress.Location = new System.Drawing.Point(15, 123);
            this.pProgress.Margin = new System.Windows.Forms.Padding(2);
            this.pProgress.Name = "pProgress";
            this.pProgress.Size = new System.Drawing.Size(492, 22);
            this.pProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pProgress.TabIndex = 34;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 647);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(669, 23);
            this.textBox1.TabIndex = 22;
            // 
            // bSendMessage
            // 
            this.bSendMessage.Location = new System.Drawing.Point(689, 647);
            this.bSendMessage.Name = "bSendMessage";
            this.bSendMessage.Size = new System.Drawing.Size(107, 23);
            this.bSendMessage.TabIndex = 23;
            this.bSendMessage.Text = "Send";
            this.bSendMessage.UseVisualStyleBackColor = true;
            this.bSendMessage.Click += new System.EventHandler(this.bSendMessage_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mExit
            // 
            this.mExit.Name = "mExit";
            this.mExit.ShortcutKeyDisplayString = "Alt+F4";
            this.mExit.Size = new System.Drawing.Size(180, 22);
            this.mExit.Text = "Exit";
            this.mExit.Click += new System.EventHandler(this.mExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkExporterToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // checkExporterToolStripMenuItem
            // 
            this.checkExporterToolStripMenuItem.Name = "checkExporterToolStripMenuItem";
            this.checkExporterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkExporterToolStripMenuItem.Text = "Check Exporter";
            this.checkExporterToolStripMenuItem.Click += new System.EventHandler(this.checkExporterToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(814, 715);
            this.Controls.Add(this.bSendMessage);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gGenerate);
            this.Controls.Add(this.gConnect);
            this.Controls.Add(this.textArchipelagoRoom);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.mmrMain_Load);
            this.gConnect.ResumeLayout(false);
            this.gConnect.PerformLayout();
            this.gGenerate.ResumeLayout(false);
            this.gGenerate.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openROM;
        private System.Windows.Forms.OpenFileDialog openBROM;
        private System.Windows.Forms.RichTextBox textArchipelagoRoom;
        private System.Windows.Forms.GroupBox gConnect;
        private System.Windows.Forms.Button bConnect;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.TextBox textSlot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.GroupBox gGenerate;
        private System.Windows.Forms.TextBox tPatch;
        private System.Windows.Forms.Button bApplyPatch;
        private System.Windows.Forms.Button bLoadPatch;
        private System.Windows.Forms.Button bSkip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bopen;
        private System.Windows.Forms.TextBox tROMName;
        private System.Windows.Forms.Label lStatus;
        private System.Windows.Forms.CheckBox cDummy;
        private System.Windows.Forms.ProgressBar pProgress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bSendMessage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mExit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkExporterToolStripMenuItem;
    }
}

