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
    public class ScourChanceModule
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

        public Main _main;
        public WindowsUtil _windowsUtil;
        public InputHook _inputHook;
        public ColorUtil _colorUtil;

        private List<Point> _inventoryPoints = new List<Point>();
        private Point _craftButtonPoint;
        private Point _itemCheckPoint;
        private Color _itemSampleColor;
        private int _itemSelecting = 0;
        private int _tradeStep = 0;



        public ScourChanceModule(Main main, WindowsUtil windowsUtil, InputHook inputHook, ColorUtil colorUtil)
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

        public void Start()
        {
            AddDebugPoints();
            _itemSelecting = 0;
            _tradeStep = 0;
        }

        public void Stop()
        {
            RemoveDebugPoints();
        }

        public void Update(float deltaTime)
        {
            if (_tradeStep == 0)
            {
                _inputHook.MoveMouse(_inventoryPoints[_itemSelecting].X, _inventoryPoints[_itemSelecting].Y);
                _tradeStep = 1;
            }
            else if (_tradeStep == 1)
            {
                _inputHook.SendLeftClick(true);
                _tradeStep = 2;
            }
            else if (_tradeStep == 2)
            {
                // Buffer, do nothing
                _tradeStep = 3;
            }

            else if (_tradeStep == 3)
            {
                _inputHook.MoveMouse(_craftButtonPoint.X, _craftButtonPoint.Y);
                _tradeStep = 4;
                _itemSampleColor = _colorUtil.GetColorAt(_itemCheckPoint);
            }
            else if (_tradeStep == 4)
            {
                _inputHook.SendLeftClick();
                _tradeStep = 5;
            }
            else if (_tradeStep == 5)
            {
                Color temp = _colorUtil.GetColorAt(_itemCheckPoint);
                if (!_colorUtil.IsColorSimilar(temp, _itemSampleColor, COLOR_TOLERANCE))
                {
                    _inputHook.MoveMouse(_itemCheckPoint.X, _itemCheckPoint.Y);
                    _tradeStep = 6;
                }
                else
                {
                    _tradeStep = 4;
                }
            }
            else if (_tradeStep == 6)
            {
                _inputHook.SendLeftClick(true);
                _tradeStep = 7;
            }
            else if (_tradeStep == 7)
            {
                _tradeStep = 0;
                _itemSelecting ++;
                if (_itemSelecting >= INVENTORY_W * INVENTORY_H / 2)
                {
                    _main.Stop();
                }
            }
        }

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

    }
}
