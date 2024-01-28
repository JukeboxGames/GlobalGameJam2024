using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaceScreenUI : MonoBehaviour
{
    bool isVisible = false;
    RectTransform rectTrans;
    private Vector3 buttonVelocity = Vector3.zero;
    Vector3 newPos;

    private void Awake() {
        rectTrans = GetComponent<RectTransform>();
        newPos = rectTrans.localPosition;
    }
    public void ToggleFaceScreen()
    {
        if (isVisible) {
            //rectTrans.localPosition = new Vector3(rectTrans.localPosition.x, 360, rectTrans.localPosition.z);
            newPos = new Vector3(rectTrans.localPosition.x, rectTrans.localPosition.y + 245, rectTrans.localPosition.z);
        } else {
            //rectTrans.localPosition = new Vector3(rectTrans.localPosition.x, 115, rectTrans.localPosition.z);
            newPos = new Vector3(rectTrans.localPosition.x, rectTrans.localPosition.y - 245, rectTrans.localPosition.z);
        }

        isVisible = !isVisible;
        
    }

    private void Update() {
        rectTrans.localPosition = Vector3.SmoothDamp(rectTrans.localPosition, newPos, ref buttonVelocity, 0.2f);
    }
}
