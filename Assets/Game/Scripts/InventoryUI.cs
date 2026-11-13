using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Game.Scripts
{
    [RequireComponent(typeof(PanelRenderer))]
    public class InventoryUI : MonoBehaviour
    {
        // This is what is rendering the UI Document
        private PanelRenderer panel;

        private VisualElement inventoryContents;

        private void Awake()
        {
            panel = GetComponent<PanelRenderer>();
            panel.RegisterUIReloadCallback(OnUIReady);
        }

        private void Start()
        {
            if (GameManager.Instance)
                GameManager.Instance.Inventory.Changed += OnInventoryChanged;
        }

        private void OnDisable()
        {
            
            if (GameManager.Instance)
                GameManager.Instance.Inventory.Changed -= OnInventoryChanged;
        }

        private void OnDestroy()
        {
            panel.UnregisterUIReloadCallback(OnUIReady);
        }

        private void OnUIReady(PanelRenderer panelRenderer, VisualElement rootElement, int version)
        {
            Debug.Log($"UI was reloaded with version {version}");

            inventoryContents = rootElement.Q<VisualElement>("InventoryContent");
        }

        private void OnInventoryChanged()
        {
            inventoryContents.Clear();

            foreach (var (item, quantity) in GameManager.Instance.Inventory.Items)
            {
                CreateItem(item, quantity);
            }
        }

        private void CreateItem(ItemType item, int quantity)
        {
            var container = new VisualElement(); // outer div
            container.AddToClassList("inventory__item");
            
            var label = new Label($"{item} ({quantity})");
            var dropBtn = new Button { text = "DROP" };
            
            // Anonymous function
            dropBtn.clicked += () => GameManager.Instance.Inventory.TryRemove(item); 
            
            // Build the structure
            container.Add(label);
            container.Add(dropBtn);
            
            inventoryContents.Add(container);
        }
    }
}