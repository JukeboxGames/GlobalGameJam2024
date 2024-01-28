using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPrefab : MonoBehaviour
{
    [SerializeField] private List<GameObject> differentFeatures = new List<GameObject>();
    public int currentIndex = 0;
    [SerializeField] private bool canChange = true;

    private void Start() {
        Transform firstChild = transform.GetChild(0);
        Instantiate(differentFeatures[currentIndex], firstChild.position, differentFeatures[currentIndex].transform.rotation, transform);
        Destroy(firstChild.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Face.Instance.IsDisabled) return;
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
            Instantiate(newFeature, transform.localPosition, newFeature.transform.rotation, transform);
            Destroy(firstChild.gameObject);
        }
        else
        {
            Debug.LogWarning("No different features available to swap.");
        }
    }
}
