using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WidgetType
{
    Background,
    Hud,
    Card,
    Popup
}

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Transform backgroundLayerRoot, hudLayerRoot, cardsLayerRoot, popupLayerRoot;

    public Transform BackgroundLayerRoot => backgroundLayerRoot;
    public Transform HudLayerRoot => hudLayerRoot;
    public Transform CardLayerRoot => cardsLayerRoot;
    public Transform PopupLayerRoot => popupLayerRoot;

    private static MainCanvas _instance;
    
    public static MainCanvas Instance
    {
        get => _instance ??= Instantiate(Resources.Load<MainCanvas>("MainCanvas"), Vector3.zero, Quaternion.identity);
        private set => _instance ??= value;
    }

    public Transform GetLayer(WidgetType type)
    {
        return type switch
        {
            WidgetType.Background => BackgroundLayerRoot,
            WidgetType.Hud => HudLayerRoot,
            WidgetType.Card => CardLayerRoot,
            WidgetType.Popup => PopupLayerRoot,
            _ => throw new Exception("Unloaded Widget type")
        };
    }

    protected void Awake()
    {
        Instance = this;
    }

    private IEnumerator Start()
    {
        Widget.Create<Background>();
        yield return null;
        Widget.Create<Hud>();
        yield return null;
        Widget.Create<Card>();
        yield return null;
        Widget.Create<Popup>();
    }
}
