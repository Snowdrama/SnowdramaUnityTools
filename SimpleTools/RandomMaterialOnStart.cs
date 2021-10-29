using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterialOnStart : MonoBehaviour
{
    public List<Material> materialOptions;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = materialOptions[Random.Range(0, materialOptions.Count)];
    }
}
