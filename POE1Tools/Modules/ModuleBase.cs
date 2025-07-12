using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POE1Tools.Utilities;

namespace POE1Tools.Modules
{
    public class ModuleBase
    {
        protected Main _main;
        protected WindowsUtil _windowsUtil;
        protected InputHook _inputHook;
        protected ColorUtil _colorUtil;

        protected bool _active = false;

        public ModuleBase(Main main, WindowsUtil windowsUtil, InputHook inputHook, ColorUtil colorUtil)
        {
            _main = main;
            _windowsUtil = windowsUtil;
            _inputHook = inputHook;
            _colorUtil = colorUtil;
        }

        public virtual void Start()
        {
            _active = true;
        }

        public virtual void Stop()
        {
            _active = false;
        }

        public virtual void Update(float deltaTime)
        {
            if (_active == true)
            {
                if (_windowsUtil.GetCurrentWindowsProcessName() != "PathOfExile")
                {
                    Stop();
                }
            }
        }

        public virtual void OnKeyEvent(Keys key, bool isDown, bool isControlDown)
        {
            if (isControlDown && isDown)
            {
                if (key == Keys.Up)
                {
                    Start();
                }
                else if (key == Keys.Down)
                {
                    Stop();
                }
            }
        }
        public virtual void OnMouseKeyEvent(MouseButtons key, bool isDown)
        {

        }
    }
}
