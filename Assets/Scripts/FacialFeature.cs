using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialFeature : MonoBehaviour
{
    private Vector3 offset; 
    [SerializeField] private List<GameObject> differentFeatures = new List<GameObject>();
    private int currentIndex = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        offset =  Face.Instance.Center - transform.position;
        Transform firstChild = transform.GetChild(0);
        Instantiate(differentFeatures[currentIndex], firstChild.position, firstChild.rotation, transform);
        Destroy(firstChild.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Face.Instance.Center - offset;
        if (Input.GetMouseButtonDown(0) && transform.GetChild(0).GetComponent<ChildFeature>().OverMe){
            Swap();
        }
    }
    void Swap() {
        if (differentFeatures.Count > 0)
        {
            Transform firstChild = transform.GetChild(0);
            int randomIndex = Random.Range(0, differentFeatures.Count);
            while(randomIndex == currentIndex){
                randomIndex = Random.Range(0, differentFeatures.Count);
            }
            currentIndex = randomIndex;
            GameObject newFeature = differentFeatures[randomIndex];
            Instantiate(newFeature, firstChild.position, firstChild.rotation, transform);
            Destroy(firstChild.gameObject);
        }
        else
        {
            Debug.LogWarning("No different features available to swap.");
        }
    }

}
