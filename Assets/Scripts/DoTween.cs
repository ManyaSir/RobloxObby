using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTween : MonoBehaviour
{
    public float time = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f; 
        rectTransform.transform.localPosition = new Vector3 (0f,-1000f,0f);
        rectTransform.DOAnchorPos(new Vector2(0f,0f),time,false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, time);
    }

    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;  
        //rectTransform.transform.localPosition = new Vector3 (0f,0f,0f);
        rectTransform.DOAnchorPos(new Vector2(0f,-1000f),time,false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, time);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
