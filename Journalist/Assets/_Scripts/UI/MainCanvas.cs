using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    [SerializeField] private Transform backgroundLayerRoot, hudLayerRoot, cardsLayerRoot, popupLayerRoot;

    public Transform BackgroundLayerRoot => backgroundLayerRoot;
    public Transform HudLayerRoot => hudLayerRoot;
    public Transform CardLayerRoot => cardsLayerRoot;
    public Transform PopupLayerRoot => popupLayerRoot;

    private MainCanvas instance;
    
    public MainCanvas Instance
    {
        get => instance ??= Instantiate(Resources.Load<MainCanvas>("MainCanvas"), Vector3.zero, Quaternion.identity);
        private set => instance ??= value;
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
