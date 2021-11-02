using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBasedMenu : MonoBehaviour
{
    public List<GameObject> menuItemsList = new List<GameObject>();
    Dictionary<string, GameObject> menuItemTable = new Dictionary<string, GameObject>();
    Stack<string> currentOpenMenus = new Stack<string>();

    public bool OpenFirstOnStart;
    public bool KeepRootOpen;
    void Start()
    {
        foreach (var item in menuItemsList)
        {
            menuItemTable.Add(item.name.ToLower(), item);
            item.SetActive(false);
        }
        if(OpenFirstOnStart)
        {
            OpenMenu(menuItemsList[0].name.ToLower());
        }
    }

    public void OpenMenu(string windowName)
    {
        if(menuItemTable.ContainsKey(windowName.ToLower()))
        {
            if(currentOpenMenus.Count > 0)
            {
                var current = currentOpenMenus.Peek();
                if(menuItemTable.ContainsKey(current.ToLower()))
                {
                    menuItemTable[current.ToLower()].SetActive(false);
                }
            }
            menuItemTable[windowName.ToLower()].SetActive(true);
            currentOpenMenus.Push(windowName.ToLower());
        }
        else
        {
            Debug.LogErrorFormat("Window {0} doesn't exist", windowName);
        }
    }
    public void CloseAllMenus()
    {
        foreach (var item in currentOpenMenus)
        {
            menuItemTable[item].SetActive(false);
        }
        currentOpenMenus.Clear();
    }

    public bool IsMenuOpen()
    {
        if(currentOpenMenus.Count > 0)
        {
            return true;
        }
        return false;
    }

    public void Back()
    {
        if (currentOpenMenus.Count > 0)
        {
            var current = currentOpenMenus.Pop();
            menuItemTable[current.ToLower()].SetActive(false);
            if (currentOpenMenus.Count > 0)
            {
                current = currentOpenMenus.Peek();
                menuItemTable[current.ToLower()].SetActive(true);
            }
        }
    }

    void Update()
    {
        if(KeepRootOpen && !IsMenuOpen())
        {
            OpenMenu(menuItemsList[0].name.ToLower());
        }
    }
}
