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
    private void MoveCamera() 
    {
        Vector3 target = new(2.5f, 0, -10);
        camHolder.transform.position = Vector3.Lerp(camHolder.transform.position, target, 0.07f);
    }

    private void MoveScore()
    {
        Vector3 target2 = new(0.50503f, 0.50503f, 0.50503f);
        scoreText.rectTransform.localScale = Vector3.Lerp(scoreText.rectTransform.localScale, target2, 0.01f);  
    }
    private void EndScene() {
        // TODO: Implementar esto
        hook.ForceVisible();
        cat.SetActive(false);
        Face.Instance.IsDisabled = true;
        MoveCamera();
        MoveScore();
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
