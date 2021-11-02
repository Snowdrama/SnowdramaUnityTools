using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameObjectListVariable", menuName = "GameData/GameObjectListVariable")]
public class GameObjectListVariable : GameData
{
    [SerializeField]
    private List<GameObject> _value;
    public List<GameObject> Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            this.OnDataChanged?.OnEvent?.Invoke();
        }
    }
    public void AddGameObject(GameObject gameObject)
    {
        if (!Value.Contains(gameObject))
        {
            Value.Add(gameObject);
        }
        else
        {
            Debug.LogError("GameObject[" + gameObject.name + "] - Already Exists in GameObjectListVariable: " + this.name);
        }
    }

    public void RemoveGameObject(GameObject gameObject)
    {
        if (Value.Contains(gameObject))
        {
            Value.Remove(gameObject);
        }
        else
        {
            Debug.LogError("GameObject[" + gameObject.name + "] - Doesn't exist in GameObjectListVariable: " + this.name);
        }
    }
}
