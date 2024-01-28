using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehaivor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer catHead;
    [SerializeField] private float animationTime = 0.5f;
    private bool isHitting = false;
    private void Update() 
    {
      if (Face.Instance.counter <= 0 && Input.GetMouseButtonDown(0))
      {
        if (!isHitting)
        {
            StartCoroutine(HittingAnimation());
        }
      }  
    }

    IEnumerator HittingAnimation()
    {
        isHitting = true;

        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0)
        {
            animator.SetBool("Hit",true);
        } 
        else if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 0)
        {
            animator.SetBool("Hit",true);
            catHead.flipX = true;
        } 
        else 
        {
            animator.SetBool("hitLeft",true);
            catHead.flipX = true;
        }

        yield return new WaitForSeconds(animationTime);

        isHitting = false;
        catHead.flipX = false;
        animator.SetBool("Hit",false);
    }
}
