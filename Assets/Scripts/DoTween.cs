using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTween : MonoBehaviour
{
    public float time = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;
    public List<GameObject> items = new List<GameObject>();

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

    public void MenuFadeIn()
    {
        canvasGroup.alpha = 0f; 
        rectTransform.transform.localPosition = new Vector3 (-1000f,0f,0f);
        rectTransform.DOAnchorPos(new Vector2(0f,0f),time,false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, time);
    }
    public void ItemsFadeIn()
    {
        StartCoroutine("ItemsFade");
    }
    IEnumerator ItemsFade()
    {
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }
        foreach (var item in items)
        {
            item.transform.DOScale(1f, time).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
    }

    public void PauseFadeIn()
    {
        canvasGroup.alpha = 0f; 
        rectTransform.transform.localPosition = new Vector3 (0f,1000f,0f);
        rectTransform.DOAnchorPos(new Vector2(0f,0f),time,false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, time);
    }
    public void PauseFadeOut()
    {
        canvasGroup.alpha = 1f;  
        //rectTransform.transform.localPosition = new Vector3 (0f,0f,0f);
        rectTransform.DOAnchorPos(new Vector2(0f,1000f),time,false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, time);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseFadeIn();
        }
    }
}
