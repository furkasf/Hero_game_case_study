using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIChangePanelCommand
    {
        private readonly List<GameObject> _panels;

        public UIChangePanelCommand(ref List<GameObject> panels)
        {
            _panels = panels;
        }

        public void Execute(PanelType panelParam)
        {
            foreach(var panel in _panels)
            {
                panel.SetActive(false);

                if(panel == _panels[(int)panelParam])
                {
                    panel.SetActive(true);
                }
            }
        }
    }
}