using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[EditorWindowTitle(title = "Quick Create Prefabs - Snow")]
public class SnowQuickCreatePrefabs : EditorWindow
{
    // using the window itself as an example container
    [SerializeField] private List<GameObject> m_Items = new List<GameObject>();

    private ListView m_ListView;
    private SerializedProperty m_ListProperty;
    [MenuItem("Snow/Quick Create Prefabs")]
    public static void ShowExample()
    {
        GetWindow<SnowQuickCreatePrefabs>().Show();
    }
    public void OnEnable()
    {
        var root = rootVisualElement;
        // instantiate the window UI
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Packages/SnowUtils/Editor/ItemLibrary/ItemLibrary.uxml");
        visualTree.CloneTree(root);

        var listView = root.Q<ListView>("items");

        var dataContext = new SerializedObject(this);
        var listProperty = dataContext.FindProperty(nameof(m_Items));

        // bind this ListView to the m_Items list
        listView.BindProperty(listProperty);

        // important, otherwise the item at index 0 is expected to bind to the Array.size property
        listView.showBoundCollectionSize = false;

        // customize the list items look and feel
        // note: if you don't set these callbacks, PropertyField will be used to bind each list item
        listView.makeItem = MakeItem;
        listView.bindItem = BindItem;

        m_ListView = listView;
        m_ListProperty = listProperty;

        var addButton = root.Q<Button>("items-add");
        addButton.clicked += AddItem;

        //var deleteButton = root.Q<Button>("items-delete");
        //deleteButton.clicked += DeleteSelectedItems;

        var clearButton = root.Q<Button>("items-clear");
        clearButton.clicked += ClearItems;

        var createButton = root.Q<Button>("create-prefabs");
        createButton.clicked += CreatePrefabs;
    }

    private void ClearItems()
    {
        Undo.RecordObject(this, "Clear items");
        m_Items.Clear();
    }

    //private void DeleteSelectedItems()
    //{
    //    if (!m_ListView.selectedIndices.Any())
    //        return;

    //    Undo.RecordObject(this, "Remove selected items");
    //    foreach (var selectedIndex in m_ListView.selectedIndices.OrderByDescending(i => i))
    //    {
    //        m_Items.RemoveAt(selectedIndex);
    //    }
    //}

    private void AddItem()
    {
        Undo.RecordObject(this, "Add new item");

        var objects = Selection.objects;
        //Debug.Log(objects.Length);
        foreach (var o in objects)
        {
            if(o is GameObject)
            {
                m_Items.Add((GameObject)o);
            }
        }
    }

    private VisualElement MakeItem()
    {
        // TODO: instantiate some UXML template here
        return new Label();
    }

    private void BindItem(VisualElement target, int index)
    {
        var bindable = (BindableElement)target;
        bindable.BindProperty(m_ListProperty.GetArrayElementAtIndex(index));
    }

    private void CreatePrefabs()
    {
        if (!m_ListView.selectedIndices.Any())
            return;

        string path = EditorUtility.SaveFolderPanel("Save Prefabs", "", "Save Folder");
        if (path != null && path != "")
        {
            string moddedPath = SnowEditorUtils.ConvertPathToAssetPath(path);

            foreach (var item in m_Items)
            {
                //var objectToPrefab = m_Items[selectedIndex];
                PrefabUtility.SaveAsPrefabAssetAndConnect(item, string.Format("{0}/{1}{2}", moddedPath, item.name, ".prefab"), InteractionMode.AutomatedAction);
            }
            AssetDatabase.Refresh(ImportAssetOptions.ForceSynchronousImport);
        }
    }
}