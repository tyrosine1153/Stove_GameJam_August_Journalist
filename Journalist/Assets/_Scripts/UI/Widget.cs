using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

public class Widget : MonoBehaviour
{
    public WidgetType type;
    
    protected virtual void Awake()
    {
        
    }

    public virtual void Show()
    {
        transform.localScale = Vector3.one;
    }

    public static T Create<T>(bool activate = false) where T : Widget
    {
        var type = typeof(T);
        var obj = Resources.Load<T>(type.ToString());

        return Instantiate(obj, MainCanvas.Instance.GetLayer(obj.type));
    }
}
