using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class CardLayout : MonoBehaviour
{
    GameObject[] sprites;
    int halfSize;
    Vector2 screenCenterPos;
    public float startAngle;
    public float deltaAngle;
    public float moveSpeed;

    public Vector3 center;
    public float xPower = 1;
    public float yPower = 1;

    int cardcount;

    // Use this for initialization
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        screenCenterPos = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        cardcount = transform.childCount;
        halfSize = (cardcount - 1) / 2;
        sprites = new GameObject[cardcount];
        for (int i = 0; i < cardcount; i++)
        {
            sprites[i] = transform.GetChild(i).gameObject;
            setPosition(i, false);
            setDeeps(i);
        }
    }

    void setPosition(int index, bool userTweener = true)
    {
        float angle = 0;
        if (index < halfSize)
        {
            //left
            angle = startAngle - (halfSize - index) * deltaAngle;
        }
        else if (index > halfSize)
        {
            //right

            angle = startAngle + (index - halfSize) * deltaAngle;
        }
        else
        {
            //medim
            angle = startAngle;
        }


        float xpos = xPower * Mathf.Cos((angle / 180) * Mathf.PI); //+center.x;
        float ypos = yPower * Mathf.Sin((angle / 180) * Mathf.PI); //+center.y;
        Debug.Log("index=" + index + ",xpos=" + xpos + ",ypos=" + ypos);

        Vector2 pos = new Vector2(xpos, ypos);
        if (!userTweener)
        {
            sprites[index].GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(pos.x, pos.y), 0f);
        }
        else
            sprites[index].GetComponent<Image>().rectTransform.DOAnchorPos(new Vector2(pos.x, pos.y), 1f);
    }

    void setDeeps(int index)
    {
        int deep = 0;
        if (index < halfSize)
        {
            deep = index;
        }
        else if (deep > halfSize)
        {
            deep = sprites.Length - (index + 1);
        }
        else
        {
            deep = halfSize;
        }

        sprites[index].GetComponent<RectTransform>().SetSiblingIndex(deep);
    }


    public void OnLeftBtnClick()
    {
        int length = sprites.Length;

        GameObject temp = sprites[0];
        for (int i = 0; i < length; i++)
        {
            if (i == length - 1)
                sprites[i] = temp;
            else
                sprites[i] = sprites[i + 1];
        }

        for (int i = 0; i < length; i++)
        {
            setPosition(i);
            setDeeps(i);
        }
    }

    public void RightBtnClick()
    {
        int length = sprites.Length;

        GameObject temp = sprites[length - 1];
        for (int i = length - 1; i >= 0; i--)
        {
            if (i == 0)
                sprites[i] = temp;
            else
                sprites[i] = sprites[i - 1];
        }

        for (int i = 0; i < length; i++)
        {
            setPosition(i);
            setDeeps(i);
        }
    }
}