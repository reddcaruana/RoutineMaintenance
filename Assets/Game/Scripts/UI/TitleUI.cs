using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts
{
    [RequireComponent(typeof(PanelRenderer))]
    public class TitleUI : MonoBehaviour
    {
        private PanelRenderer panelRenderer;
        private VisualElement rootElement;

        private void Awake()
        {
            panelRenderer = GetComponent<PanelRenderer>();
            panelRenderer.RegisterUIReloadCallback(OnUIReload);
        }

        private void OnUIReload(PanelRenderer panel, VisualElement root, int version)
        {
            rootElement = root;
            
            var playButton = root.Q<Button>("PlayButton");
            playButton.clicked += () => GameManager.Instance.ChangeStateToNull();
        }

        public void Show()
        {
            rootElement.style.display = DisplayStyle.Flex;
        }

        public void Hide()
        {
            rootElement.style.display = DisplayStyle.None;
        }
    }
}