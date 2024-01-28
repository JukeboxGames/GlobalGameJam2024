using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerBehavior : MonoBehaviour
{
    public int seconds = 0; 
    public TMP_Text text;
    public TMP_Text scoreText; 
    public FaceScreenUI hook;
    public GameObject camHolder; 
    public GameObject cat;
    public GameObject slider; 
    private IEnumerator MoveCamera() {
        Vector3 target = new(2.5f, 0, -10);
        while(!camHolder.transform.position.Equals(target)) {
            yield return new WaitForEndOfFrame();
            camHolder.transform.position = Vector3.Lerp(camHolder.transform.position, target, 0.1f);
        }
    }
    private IEnumerator MoveScore() {
        Vector3 target2 = new(0.50503f, 0.50503f, 0.50503f);
        yield return new WaitForSeconds(1);
        while(!scoreText.rectTransform.localScale.Equals(target2)) {
            yield return new WaitForEndOfFrame();
            scoreText.rectTransform.localScale = Vector3.Lerp(scoreText.rectTransform.localScale, target2, 0.01f);
        }
    }
    private void EndScene() {
        // TODO: Implementar esto
        hook.ForceVisible();
        cat.SetActive(false);
        Face.Instance.IsDisabled = true;
        StartCoroutine(MoveCamera());
        StartCoroutine(MoveScore());
        slider.SetActive(true);
    }
    private IEnumerator Countdown() {
        while(seconds > 0) {
            yield return new WaitForSeconds(1.0f);
            seconds--;
            text.text = seconds.ToString(); 
        }
        EndScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        text.text = seconds.ToString(); 
    }
}
