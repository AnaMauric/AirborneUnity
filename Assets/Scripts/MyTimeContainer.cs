using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyTimeContainer : MonoBehaviour
{

    public Vector3 normalScale = new Vector3(1f, 1f, 1f);

    public Vector3 hoverScale = new Vector3(1.25f, 1.25f, 1.25f);

    private RectTransform rectTransform;

    public string sceneName = "GameScene";

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        EventTrigger trigger = GetComponent<EventTrigger>();

        EventTrigger.Entry onHoverEntry = new EventTrigger.Entry();
        onHoverEntry.eventID = EventTriggerType.PointerEnter;
        onHoverEntry.callback.AddListener((data) => { OnHover(); });
        trigger.triggers.Add(onHoverEntry);

        EventTrigger.Entry onUnhoverEntry = new EventTrigger.Entry();
        onUnhoverEntry.eventID = EventTriggerType.PointerExit;
        onUnhoverEntry.callback.AddListener((data) => { OnUnhover(); });

        trigger.triggers.Add(onUnhoverEntry);
        rectTransform.localScale = normalScale;

    }

    public void OnHover()
    {
        // set the button's scale to the hover scale
        rectTransform.localScale = hoverScale;
    }

    public void OnUnhover()
    {
        // set the button
        rectTransform.localScale = normalScale;
    }
}
