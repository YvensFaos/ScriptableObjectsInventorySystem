using UnityEditor;
using UnityEngine;

namespace Inventory.Editor
{
    [CustomEditor(typeof(InventoryManager))]
    public class InventoryManagerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var inventory = (InventoryManager) target;
            
            GUILayout.Label("Items: ");
            var items = inventory.GetItems();
            items.ForEach(item =>
            {
                GUILayout.Label($"   {item}");
            });
        }
    }
}