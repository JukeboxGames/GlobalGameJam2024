using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerBehavior : MonoBehaviour
{
    public int time = 0; 
    public TMP_Text text;
    public TMP_Text scoreText; 
    public FaceScreenUI hook;
    public GameObject camHolder; 
    public GameObject cat;
    public GameObject slider,percentageText,button; 
    private int minutes,seconds;
    private IEnumerator MoveCamera() 
    {
        Vector3 target = new(2.5f, 0, -10);
        while(!camHolder.transform.position.Equals(target)) 
        {
            yield return new WaitForEndOfFrame();
            camHolder.transform.position = Vector3.Lerp(camHolder.transform.position, target, 0.01f);
        }
    }

    private IEnumerator MoveScore()
    {
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
        percentageText.SetActive(true);
        button.SetActive(true);
    }
    private IEnumerator Countdown() {
        hook.ForceVisible();
        yield return new WaitForSeconds(2.0f);
        hook.ForceInvisible();
        Debug.Log("I waited");
        while(time > 0) {
            yield return new WaitForSeconds(1.0f);
            time--;
            minutes = Mathf.FloorToInt(time / 60);
            seconds = Mathf.FloorToInt(time % 60);      
            text.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        }
        text.text = string.Format("{0:00}:{1:00}",minutes,seconds);
        EndScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        text.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
