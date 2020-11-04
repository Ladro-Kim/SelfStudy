using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();

    Image itemIcon;

    enum Buttons
    {
        PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText
    }

    void Start()
    {
        // Bind<Button>(typeof(Buttons));
        // Bind<Text>(typeof(Texts));
        itemIcon = transform.Find("ItemIcon").GetComponent<Image>();
        GameObject go = itemIcon.gameObject;
        AddUIEvent(go, (PointerEventData data) => { itemIcon.transform.position = data.position; }, Define.UIEvent.Drag);
        // evt.OnDragHandler += ((PointerEventData data) => { evt.gameObject.transform.position = data.position; });
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);                                  // Enum 목록 가져오기.
        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];   // Enum 목록 만큼 UnityEngine.Object(최상위 객체타입) 배열 생성
        _objects.Add(typeof(T), objects);                                      // 딕셔너리에 키값을 타입으로, 밸류값을 배열로 추가

        for (int i = 0; i < names.Length; i++)
        {
            objects[i] = Utils.FindChild<T>(gameObject, names[i], true);       // 
        }

    }

    public void OnButtonClicked()
    {
        // text.text = inputText.text;
    }

    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click) // Click 을 기본값으로 설정.
    {
        UI_EventHandler evt = Utils.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                evt.OnDragHandler -= action;
                evt.OnDragHandler += action;

                break;


        }


    }


}
