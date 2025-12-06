using System;
using System.Drawing;
using System.Windows.Forms;

namespace Homepage.Logica
{
    public class PanelManager
    {
        private Panel _panelLateral;
        private bool _panelLateralVisible = false;

        public PanelManager(Panel panelLateral)
        {
            _panelLateral = panelLateral;
        }

        public void TogglePanelLateral()
        {
            _panelLateralVisible = !_panelLateralVisible;
            _panelLateral.Visible = _panelLateralVisible;

            if (_panelLateralVisible)
                _panelLateral.BringToFront();
        }

        public void CerrarPanelSiEsNecesario(Point posicionMouse)
        {
            if (_panelLateralVisible && !_panelLateral.Bounds.Contains(posicionMouse))
            {
                TogglePanelLateral();
            }
        }

        public bool PanelLateralVisible => _panelLateralVisible;
    }
}