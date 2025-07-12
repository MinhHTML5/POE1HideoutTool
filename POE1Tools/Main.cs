using System;
using System.Drawing;
using System.Windows.Forms;
using POE1Tools.Utilities;
using System.Diagnostics;
using POE1Tools.Modules;

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

        private DivCardModule _divCardModule;
        private ScourChanceModule _scouChanceModule;

        public bool active = false;

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

        private const int WM_INPUT = 0x00FF;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_INPUT)
            {
                _inputHook.ProcessRawInput(m.LParam);
            }

            base.WndProc(ref m);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _divCardModule = new DivCardModule(this, _windowsUtil, _inputHook, _colorUtil);
            _scouChanceModule = new ScourChanceModule(this, _windowsUtil, _inputHook, _colorUtil);

            _inputHook.RegisterRawInputDevices(this.Handle, OnMouseKeyEvent, OnKeyEvent);

            _timer.Interval = UPDATE_INTERVAL;
            _timer.Tick += (s, e) => MainLoop();
            _timer.Start();
            _stopwatch.Start();
        }

        private void MainLoop()
        {
            // This variable turn off all submodule from doing logic, but still let them to count cooldown
            bool shouldDoLogic = true;
            int deltaTime = (int)(_stopwatch.Elapsed.TotalMilliseconds);
            _stopwatch.Restart();

            if (active == true)
            {
                if (optDivCard.Checked == true)
                {
                    _divCardModule.Update(deltaTime);
                }
                else if (optScourChance.Checked == true)
                {
                    _scouChanceModule.Update(deltaTime);
                }
            }
        }

        public void Start()
        {
            active = true;
            _divCardModule.Start();
            _scouChanceModule.Start();
        }

        public void Stop()
        {
            active = false;
            _divCardModule.Stop();
            _scouChanceModule.Stop();
        }



        private void OnKeyEvent(Keys key, bool isDown, bool isControlDown)
        {
            if (key == Keys.Up && isControlDown == true)
            {
                Start();
            }
            else if (key == Keys.Down && isControlDown == true)
            {
                Stop();
            }
        }

        private void OnMouseKeyEvent(MouseButtons key, bool isDown)
        {

        }

        private void trkRate_Scroll(object sender, EventArgs e)
        {
            _timer.Interval = trkRate.Value * 25;
            lblUpdateRate.Text = "Command rate: " + _timer.Interval + "ms";
        }

        private void HideAllGroupBox()
        {
            grpDivCard.Visible = false;
            grpScourChance.Visible = false;
        }

        private void optDivCard_CheckedChanged(object sender, EventArgs e)
        {
            HideAllGroupBox();
            grpDivCard.Visible = true;
        }
        private void optScourChance_CheckedChanged(object sender, EventArgs e)
        {
            HideAllGroupBox();
            grpScourChance.Visible = true;
        }
    }
}
