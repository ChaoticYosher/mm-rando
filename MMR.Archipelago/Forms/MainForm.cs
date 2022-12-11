using MMR.Randomizer.Models.Settings;
using MMR.Archipelago.Util;
using System;
using System.Windows.Forms;

namespace MMR.Archipelago.Forms
{
    using Randomizer = Randomizer.Randomizer;
    public partial class MainForm : Form
    {
        public Configuration _configuration { get; set; }
        //private bool _isUpdating;

        public const string SETTINGS_EXTENSION = ".json";

        public MainForm()
        {
            InitializeSettings();
            InitializeTooltips();

            Text = $"Majora's Mask Randomizer v{Randomizer.AssemblyVersion} Archipelago Client";
            InitializeComponent();
        }

        private void InitializeTooltips()
        {
            // ROM Settings
            //TooltipBuilder.SetTooltip(cN64, "Output a randomized .z64 ROM that can be loaded into a N64 Emulator.");
        }

        #region Forms Code

        private void mmrMain_Load(object sender, EventArgs e)
        {
            // initialise some stuff
            //_isUpdating = true;

            //InitializeBackgroundWorker();

            var args = Environment.GetCommandLineArgs();
            //if (args.Length > 1)
            //{
            //    var openWithArg = args[1];
            //    if (Path.GetExtension(openWithArg) == ".mmr")
            //    {
            //        ttOutput.SelectedIndex = 1;
            //        TogglePatchSettings(false);
            //        _configuration.OutputSettings.InputPatchFilename = openWithArg;
            //        tPatch.Text = _configuration.OutputSettings.InputPatchFilename;
            //    }
            //}

            //_isUpdating = false;
        }

        //private void InitializeBackgroundWorker()
        //{
        //    bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
        //    bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_WorkerCompleted);
        //    bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        //}

        //private void bSkip_Click(object sender, EventArgs e)
        //{
        //    var button = (Button)sender;
        //    var cancellationTokenSource = (CancellationTokenSource)button.Tag;
        //    if (cancellationTokenSource != null)
        //    {
        //        cancellationTokenSource.Cancel();
        //    }
        //}

        //private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    pProgress.Value = e.ProgressPercentage;
        //    var state = (BackgroundWorkerProgressState)e.UserState;
        //    lStatus.Text = state.Message;
        //    bSkip.Visible = state.CTSItemImportance != null;
        //    bSkip.Tag = state.CTSItemImportance;
        //}

        //private void bgWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    pProgress.Value = 0;
        //    lStatus.Text = "Ready...";
        //    EnableAllControls(true);
        //    ToggleCheckBoxes();
        //    TogglePatchSettings(ttOutput.SelectedTab.TabIndex == 0);
        //}

        //private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    TryRandomize(sender as BackgroundWorker, e);
        //}

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            SaveAndClose();
        }

        private void SaveAndClose()
        {
            // TODO probably a good point to disconnect from the AP room
            Application.Exit();
        }

        #endregion

        #region Settings

        public void InitializeSettings()
        {
            _configuration = new Configuration
            {
                OutputSettings = new OutputSettings(),
                GameplaySettings = new GameplaySettings
                {
                    ShortenCutsceneSettings = new ShortenCutsceneSettings(),
                },
                CosmeticSettings = new CosmeticSettings(),
            };
        }
        #endregion

        private void bopen_Click(object sender, EventArgs e)
        {
            openROM.ShowDialog();

            _configuration.OutputSettings.InputROMFilename = openROM.FileName;
            tROMName.Text = _configuration.OutputSettings.InputROMFilename;
        }

        private void bLoadPatch_Click(object sender, EventArgs e)
        {

        }

        private void bApplyPatch_Click(object sender, EventArgs e)
        {

        }

        private void bConnect_Click(object sender, EventArgs e)
        {

        }

        private void bSendMessage_Click(object sender, EventArgs e)
        {

        }

        private void checkExporterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportUtil.GenerateAPData();
        }

        private void mExit_Click(object sender, EventArgs e)
        {
            SaveAndClose();
        }
    }
}
