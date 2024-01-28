using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaceScreenUI : MonoBehaviour
{
    bool isVisible = false;
    RectTransform rectTrans;
    private Vector3 buttonVelocity = Vector3.zero;
    private Vector3 targetScale;
    private bool IsDisabled = false;
    Vector3 newPos;

    private void Awake() {
        rectTrans = GetComponent<RectTransform>();
        newPos = rectTrans.localPosition;
        targetScale = rectTrans.localScale;
    }
    public void ToggleFaceScreen()
    {
        if(IsDisabled) return;
        if (isVisible) {
            //rectTrans.localPosition = new Vector3(rectTrans.localPosition.x, 360, rectTrans.localPosition.z);
            newPos = new Vector3(rectTrans.localPosition.x, rectTrans.localPosition.y + 245, rectTrans.localPosition.z);
        } else {
            //rectTrans.localPosition = new Vector3(rectTrans.localPosition.x, 115, rectTrans.localPosition.z);
            newPos = new Vector3(rectTrans.localPosition.x, rectTrans.localPosition.y - 245, rectTrans.localPosition.z);
        }

        isVisible = !isVisible;
        
    }
    
    private IEnumerator ScaleSize() {
        while(!rectTrans.localScale.Equals(targetScale)) {
            rectTrans.localScale = Vector3.Lerp(rectTrans.localScale, targetScale, 0.1f);
            yield return new WaitForEndOfFrame(); 
        }
         Debug.Log("Ended");
    }

    public void ForceVisible() {
        newPos = new Vector3(rectTrans.localPosition.x-0, rectTrans.localPosition.y - 245, rectTrans.localPosition.z);
        targetScale = new(15, 15, 0);
        IsDisabled = true;
        StartCoroutine(ScaleSize());
    }

    private void Update() {
        rectTrans.localPosition = Vector3.SmoothDamp(rectTrans.localPosition, newPos, ref buttonVelocity, 0.2f);
    }
}
