using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClosestParent : MonoBehaviour
{
    private Tuple<int, float> closest = new(0,0);
    [SerializeField] private List<GameObject> differentFeatures = new List<GameObject>();
    private int currentIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        closest = new(0, Vector3.Distance(transform.position, Face.Instance.spline.GetPosition(0)));
        for(int i = 0; i<Face.Instance.spline.GetPointCount(); i++) {
            float dist = Vector3.Distance(transform.position, Face.Instance.spline.GetPosition(i));
            if(closest.Item2 > dist) {
                closest = new(i, dist);
            }
        }
        
        Transform firstChild = transform.GetChild(0);
        Instantiate(differentFeatures[currentIndex], firstChild.position, firstChild.rotation, transform);
        Destroy(firstChild.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Face.Instance.spline.GetPosition(closest.Item1);
        if (Input.GetMouseButtonDown(0) && transform.GetChild(0).GetComponent<ChildFeature>().OverMe){
            Swap();
        }
    }

    void Swap() {
        if (differentFeatures.Count > 0)
        {
            Transform firstChild = transform.GetChild(0);
            int randomIndex = UnityEngine.Random.Range(0, differentFeatures.Count);
            while(randomIndex == currentIndex){
                randomIndex = UnityEngine.Random.Range(0, differentFeatures.Count);
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
