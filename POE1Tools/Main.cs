using System;
using System.Drawing;
using System.Windows.Forms;
using POE1Tools.Utilities;
using System.Diagnostics;
using POE1Tools.Modules;
using System.Collections.Generic;

namespace POE1Tools
{
    public partial class Main : Form
    {
        public static Main sInstance;

        public const int UPDATE_INTERVAL = 150;
        public const int COLOR_TOLERANCE = 5;

        private WindowsUtil _windowsUtil;
        private InputHook _inputHook;
        private ColorUtil _colorUtil;

        private List<ModuleBase> _modules = new List<ModuleBase>();
        private int _moduleSelecting = 0;

        private Timer _timer = new Timer();
        private Stopwatch _stopwatch = new Stopwatch();


        public Main(WindowsUtil windowsUtil, InputHook inputHook, ColorUtil colorUtil)
        {
            sInstance = this;

            _windowsUtil = windowsUtil;
            _inputHook = inputHook;
            _colorUtil = colorUtil;

            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            _inputHook.RegisterRawInputDevices(this.Handle, OnMouseKeyEvent, OnKeyEvent);

            _timer.Interval = UPDATE_INTERVAL;
            _timer.Tick += (s, e) => MainLoop();
            _timer.Start();
            _stopwatch.Start();

            InitModules();
        }
        private void InitModules()
        {
            _modules.Add(new DivCardModule(this, _windowsUtil, _inputHook, _colorUtil));
            _modules.Add(new ScourChanceModule(this, _windowsUtil, _inputHook, _colorUtil));
        }
        private void MainLoop()
        {
            int deltaTime = (int)(_stopwatch.Elapsed.TotalMilliseconds);
            _stopwatch.Restart();

            _modules[_moduleSelecting].Update(deltaTime);
        }
        private void OnKeyEvent(Keys key, bool isDown, bool isControlDown)
        {
            _modules[_moduleSelecting].OnKeyEvent(key, isDown, isControlDown);
        }
        private void OnMouseKeyEvent(MouseButtons key, bool isDown)
        {
            _modules[_moduleSelecting].OnMouseKeyEvent(key, isDown);
        }




        // ======================= UI =========================
        private void HideAllGroupBox()
        {
            grpDivCard.Visible = false;
            grpScourChance.Visible = false;
        }
        private void optDivCard_CheckedChanged(object sender, EventArgs e)
        {
            HideAllGroupBox();
            grpDivCard.Visible = true;
            _moduleSelecting = 0;
        }
        private void optScourChance_CheckedChanged(object sender, EventArgs e)
        {
            HideAllGroupBox();
            grpScourChance.Visible = true;
            _moduleSelecting = 1;
        }
        private void trkRate_Scroll(object sender, EventArgs e)
        {
            _timer.Interval = trkRate.Value * 25;
            lblUpdateRate.Text = "Command rate: " + _timer.Interval + "ms";
        }
        // ======================= UI =========================





        // ================== DON'T TOUCH =====================
        private const int WM_INPUT = 0x00FF;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_INPUT)
            {
                _inputHook.ProcessRawInput(m.LParam);
            }

            base.WndProc(ref m);
        }
        // ======================= UI =========================
    }
}
