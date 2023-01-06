using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MyButton : MonoBehaviour
{

    public Vector3 normalScale = new Vector3(1f, 1f, 1f);

    private Vector3 hoverScale = new Vector3(1.05f, 1.05f, 1.05f);

    private RectTransform rectTransform;

    public string sceneName = "GameScene";

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        
        EventTrigger trigger = GetComponent<EventTrigger>();

        EventTrigger.Entry onHoverEntry = new EventTrigger.Entry();
        onHoverEntry.eventID = EventTriggerType.PointerEnter;
        onHoverEntry.callback.AddListener((data) => { OnHover(); });
        trigger.triggers.Add(onHoverEntry);

        EventTrigger.Entry onUnhoverEntry = new EventTrigger.Entry();
        onUnhoverEntry.eventID = EventTriggerType.PointerExit;
        onUnhoverEntry.callback.AddListener((data) => { OnUnhover();  });

        trigger.triggers.Add(onUnhoverEntry);

    }

    void OnClick()
    {
        SceneManager.LoadScene(sceneName);
        FuelManager.fuel = FuelManager.initialFuel;
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
