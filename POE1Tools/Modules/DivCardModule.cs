using System.Collections.Generic;
using System.Drawing;
using POE1Tools.Utilities;
using System.Windows.Forms;

namespace POE1Tools.Modules
{
    public class DivCardModule : ModuleBase
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


        private List<Point> _inventoryPoints = new List<Point>();
        private Point _tradeButtonPoint;
        private Point _itemButtonPoint;

        private int _itemID = 0;
        private int _step = 0;

        public DivCardModule(Main main, WindowsUtil windowsUtil, InputHook inputHook, ColorUtil colorUtil) : base(main, windowsUtil, inputHook, colorUtil)
        {

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

            if (_active == true)
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
                    _inputHook.MoveMouse(_tradeButtonPoint.X, _tradeButtonPoint.Y);
                    _step++;
                }
                else if (_step == 3)
                {
                    _inputHook.SendLeftClick();
                    _step++;
                }
                else if (_step == 4)
                {
                    _inputHook.MoveMouse(_itemButtonPoint.X, _itemButtonPoint.Y);
                    _step++;

                }
                else if (_step == 5)
                {
                    _inputHook.SendLeftClick(true);
                    _step++;
                }
                else if (_step == 6)
                {
                    _itemID++;
                    if (_itemID >= INVENTORY_W * INVENTORY_H)
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
        // ===================================================================
    }
}
