using System.Collections.Generic;
using System.Drawing;
using POE1Tools.Utilities;
using System.Windows.Forms;

namespace POE1Tools.Modules
{
    public class DivCardModule
    {
        public const int INVENTORY_W = 12;
        public const int INVENTORY_H = 5;
        public const float INVENTORY_X = 0.676f;
        public const float INVENTORY_Y = 0.567f;
        public const float INVENTORY_SPACING_X = 0.02745f;
        public const float INVENTORY_SPACING_Y = 0.04965f;

        public const float TRADE_BUTTON_X = 0.33f;
        public const float TRADE_BUTTON_Y = 0.68f;

        public const float ITEM_BUTTON_X = 0.33f;
        public const float ITEM_BUTTON_Y = 0.4f;


        public Main _main;
        public WindowsUtil _windowsUtil;
        public InputHook _inputHook;
        public ColorUtil _colorUtil;

        private List<Point> _inventoryPoints = new List<Point>();
        private Point _tradeButtonPoint;
        private Point _itemButtonPoint;


        private int _itemSelecting = 0;
        private int _tradeStep = 0;

        public DivCardModule(Main main, WindowsUtil windowsUtil, InputHook inputHook, ColorUtil colorUtil)
        {
            _main = main;
            _windowsUtil = windowsUtil;
            _inputHook = inputHook;
            _colorUtil = colorUtil;

            for (int i = 0; i < INVENTORY_W; i++)
            {
                for (int j = 0; j < INVENTORY_H; j++)
                {
                    _inventoryPoints.Add(_colorUtil.GetPixelPosition(INVENTORY_X + (float)i * INVENTORY_SPACING_X, INVENTORY_Y + (float)j * INVENTORY_SPACING_Y));
                }
            }

            _tradeButtonPoint = _colorUtil.GetPixelPosition(TRADE_BUTTON_X, TRADE_BUTTON_Y);
            _itemButtonPoint = _colorUtil.GetPixelPosition(ITEM_BUTTON_X, ITEM_BUTTON_Y);
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
                _inputHook.MoveMouse(_tradeButtonPoint.X, _tradeButtonPoint.Y);
                _tradeStep = 3;
            }
            else if (_tradeStep == 3)
            {
                _inputHook.SendLeftClick();
                _tradeStep = 4;
            }
            else if (_tradeStep == 4)
            {
                _inputHook.MoveMouse(_itemButtonPoint.X, _itemButtonPoint.Y);
                _tradeStep = 5;

            }
            else if (_tradeStep == 5)
            {
                _inputHook.SendLeftClick(true);
                _tradeStep = 6;
            }
            else if (_tradeStep == 6)
            {
                _tradeStep = 0;
                _itemSelecting++;
                if (_itemSelecting >= INVENTORY_W * INVENTORY_H)
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
            _windowsUtil.AddDebugDrawPoint(_tradeButtonPoint);
            _windowsUtil.AddDebugDrawPoint(_itemButtonPoint);
        }

        private void RemoveDebugPoints()
        {
            for (int i = 0; i < _inventoryPoints.Count; i++)
            {
                _windowsUtil.RemoveDebugDrawPoint(_inventoryPoints[i]);
            }
            _windowsUtil.RemoveDebugDrawPoint(_tradeButtonPoint);
            _windowsUtil.RemoveDebugDrawPoint(_itemButtonPoint);
        }

    }
}
