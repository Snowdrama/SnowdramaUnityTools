using System;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace UIElementsExamples
{
    public class ListViewExampleWindow : EditorWindow
    {
        [SerializeField] private List<string> m_Items = new List<string>();

        [MenuItem("Window/ListViewExampleWindow")]
        public static void OpenDemoManual()
        {
            GetWindow<ListViewExampleWindow>().Show();
        }

        public void OnEnable()
        {
            // Create some list of data, here simply numbers in interval [1, 1000]
            const int itemCount = 1000;
            m_Items = new List<string>(itemCount);
            for (int i = 1; i <= itemCount; i++)
                m_Items.Add(i.ToString());

            // The "makeItem" function will be called as needed
            // when the ListView needs more items to render
            Func<VisualElement> makeItem = () => new Label();

            // As the user scrolls through the list, the ListView object
            // will recycle elements created by the "makeItem"
            // and invoke the "bindItem" callback to associate
            // the element with the matching data item (specified as an index in the list)
            Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = m_Items[i];

            // Provide the list view with an explict height for every row
            // so it can calculate how many items to actually display
            const int itemHeight = 16;

            var listView = new ListView(m_Items, itemHeight, makeItem, bindItem);

            listView.selectionType = SelectionType.Multiple;

            listView.onItemsChosen += obj => Debug.Log(obj);
            listView.onSelectionChange += objects => Debug.Log(objects);

            listView.style.flexGrow = 1.0f;

            rootVisualElement.Add(listView);
        }
    }
}