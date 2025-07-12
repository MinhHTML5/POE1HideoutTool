using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POE1Tools.Utilities;

namespace POE1Tools.Modules
{
    public class ScourChanceModule : ModuleBase
    {
        public const int COLOR_TOLERANCE = 0;

        public const int INVENTORY_W = 12;
        public const int INVENTORY_H = 5;
        public const float INVENTORY_X = 0.676f;
        public const float INVENTORY_Y = 0.567f;
        public const float INVENTORY_SPACING_X = 0.02745f;
        public const float INVENTORY_SPACING_Y = 0.04965f;

        public const float CRAFT_BUTTON_X = 0.33f;
        public const float CRAFT_BUTTON_Y = 0.84f;

        public const float ITEM_CHECK_X = 0.33f;
        public const float ITEM_CHECK_Y = 0.68f;

        private List<Point> _inventoryPoints = new List<Point>();
        private Point _craftButtonPoint;
        private Point _itemCheckPoint;
        private Color _itemSampleColor;
        private int _itemID = 0;
        private int _step = 0;



        public ScourChanceModule(Main main, WindowsUtil windowsUtil, InputHook inputHook, ColorUtil colorUtil) : base(main, windowsUtil, inputHook, colorUtil)
        {
            _main = main;
            _windowsUtil = windowsUtil;
            _inputHook = inputHook;
            _colorUtil = colorUtil;

            
            for (int i = 0; i < INVENTORY_W; i+=2)
            {
                for (int j = 0; j < INVENTORY_H; j++)
                {
                    _inventoryPoints.Add(_colorUtil.GetPixelPosition(INVENTORY_X + (float)i * INVENTORY_SPACING_X, INVENTORY_Y + (float)j * INVENTORY_SPACING_Y));
                }
            }

            _craftButtonPoint = _colorUtil.GetPixelPosition(CRAFT_BUTTON_X, CRAFT_BUTTON_Y);
            _itemCheckPoint = _colorUtil.GetPixelPosition(ITEM_CHECK_X, ITEM_CHECK_Y);
        }

        public override void Start()
        {
            base.Start();
            
            _itemID = 0;
            _step = 0;
            AddDebugPoints();
        }

        public override void Stop()
        {
            base.Stop();
            RemoveDebugPoints();
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if (_active)
            {
                if (_step == 0)
                {
                    _inputHook.MoveMouse(_inventoryPoints[_itemID].X, _inventoryPoints[_itemID].Y);
                    _step++;
                }
                else if (_step == 1)
                {
                    _inputHook.SendLeftClick(true);
                    _step++;
                }
                else if (_step == 2)
                {
                    // Buffer, do nothing
                    _step++;
                }

                else if (_step == 3)
                {
                    _inputHook.MoveMouse(_craftButtonPoint.X, _craftButtonPoint.Y);
                    _itemSampleColor = _colorUtil.GetColorAt(_itemCheckPoint);
                    _step++;
                }
                else if (_step == 4)
                {
                    _inputHook.SendLeftClick();
                    _step++;
                }
                else if (_step == 5)
                {
                    Color temp = _colorUtil.GetColorAt(_itemCheckPoint);
                    if (!_colorUtil.IsColorSimilar(temp, _itemSampleColor, COLOR_TOLERANCE))
                    {
                        _inputHook.MoveMouse(_itemCheckPoint.X, _itemCheckPoint.Y);
                        _step++;
                    }
                    else
                    {
                        _step--;
                    }
                }
                else if (_step == 6)
                {
                    _inputHook.SendLeftClick(true);
                    _step++;
                }
                else if (_step == 7)
                {
                    _itemID++;
                    if (_itemID >= INVENTORY_W * INVENTORY_H / 2)
                    {
                        Stop();
                    }
                    _step = 0;
                }
            }
        }
        public override void OnKeyEvent(Keys key, bool isDown, bool isControlDown)
        {
            base.OnKeyEvent(key, isDown, isControlDown);
        }
        public override void OnMouseKeyEvent(MouseButtons key, bool isDown)
        {
            base.OnMouseKeyEvent(key, isDown);
        }





        // ============================ DEBUG ================================
        private void AddDebugPoints()
        {
            for (int i = 0; i < _inventoryPoints.Count; i++)
            {
                _windowsUtil.AddDebugDrawPoint(_inventoryPoints[i]);
            }
            _windowsUtil.AddDebugDrawPoint(_craftButtonPoint);
            _windowsUtil.AddDebugDrawPoint(_itemCheckPoint);
        }

        private void RemoveDebugPoints()
        {
            for (int i = 0; i < _inventoryPoints.Count; i++)
            {
                _windowsUtil.RemoveDebugDrawPoint(_inventoryPoints[i]);
            }
            _windowsUtil.RemoveDebugDrawPoint(_craftButtonPoint);
            _windowsUtil.RemoveDebugDrawPoint(_itemCheckPoint);
        }
        // ===================================================================
    }
}
