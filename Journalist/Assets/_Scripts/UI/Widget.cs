using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

public class Widget : MonoBehaviour
{
    protected virtual void Awake()
    {
        
    }

    public virtual void Show()
    {
        
    }

    private void OnEnable()
    {
        Show();
    }

    public static T Create<T>(bool activate = false) where T : Widget
    {
        var type = typeof(T);
        var obj = Resources.Load<T>(type.ToString());
        return Instantiate(obj,
            typeof(MainCanvas).GetProperty($"{type}LayerRoot")?.GetValue(obj, null) as Transform);
    }
}
