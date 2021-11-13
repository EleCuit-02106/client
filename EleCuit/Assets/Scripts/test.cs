using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public struct LogLayerDesc
{
    public bool isEnable;
}

public sealed class test : SerializedMonoBehaviour
{
    [SerializeField] bool m_isLogEnable = true;
    [SerializeField] Dictionary<string, LogLayerDesc> m_layerDescs;
    [SerializeField] Dictionary<string, bool> m_test;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in m_layerDescs)
        {
            print(item.Value);
        }
    }
}
