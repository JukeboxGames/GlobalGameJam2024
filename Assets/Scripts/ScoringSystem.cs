using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public ReferenceFace targetFace;
    [SerializeField] private float acceptedDistance = 2f;
    [SerializeField] private float acceptedFaceDistance = 1f;
    [SerializeField] private float onPointDistance = 0.3f;
    float sum, score;
    float meanFace, meanFeaturePosition, meanMouth, meanFeatureIndex;
    float distance;
    public TMP_Text scoreText;
    public float _score; 


    public void Score () {
        sum = 0;
        // Scoring face
        for (int i = 0; i < Face.Instance.spline.GetPointCount(); i++) {
            // Assumes target spline is constructed the same way as face spline
            distance = Vector3.Distance(Face.Instance.spline.GetPosition(i), targetFace.faceSpline.GetPosition(i)/*Face.Instance.spline.GetPosition(i)*/);
            if (distance < onPointDistance) {
                sum += 100;
            } else if (distance < acceptedFaceDistance) {
                sum += (100 - ((distance/acceptedFaceDistance)*100));
            }
        }

        meanFace = sum / Face.Instance.spline.GetPointCount();

        // Hardcodeado porque igual nadie hace code review

        sum = 0;
        Vector3 targetPoint;
        // Score ears
        // Right ear
        targetPoint = (targetFace.rightEar.transform.localPosition);
        distance = Vector3.Distance(targetPoint, Face.Instance.rightEar.transform.position);

        if (distance < onPointDistance) {
            sum += 100;
        } else if (distance < acceptedDistance) {
            sum += (100 - ((distance/acceptedDistance)*100));
        }

        // left ear
        targetPoint = (targetFace.leftEar.transform.localPosition);
        distance = Vector3.Distance(targetPoint, Face.Instance.leftEar.transform.position);

        if (distance < onPointDistance) {
            sum += 100;
        } else if (distance < acceptedDistance) {
            sum += (100 - ((distance/acceptedDistance)*100));
        }
        /*
        // mouth
        targetPoint = (targetFace.mouth.gameObject.transform.localPosition);
        distance = Vector3.Distance(targetPoint, Face.Instance.mouth.transform.position);

        if (distance < onPointDistance) {
            sum += 100;
        } else if (distance < acceptedDistance) {
            sum += (100 - ((distance/acceptedDistance)*100));
        }*/

        // left eye
        targetPoint = (targetFace.leftEye.gameObject.transform.localPosition);
        distance = Vector3.Distance(targetPoint, Face.Instance.leftEye.transform.position);

        if (distance < onPointDistance) {
            sum += 100;
        } else if (distance < acceptedDistance) {
            sum += (100 - ((distance/acceptedDistance)*100));
        }

        // right eye
        targetPoint = (targetFace.rightEye.gameObject.transform.localPosition);
        distance = Vector3.Distance(targetPoint, Face.Instance.rightEye.transform.position);

        if (distance < onPointDistance) {
            sum += 100;
        } else if (distance < acceptedDistance) {
            sum += (100 - ((distance/acceptedDistance)*100));
        }

        // nose
        targetPoint = (targetFace.nose.gameObject.transform.localPosition);
        distance = Vector3.Distance(targetPoint, Face.Instance.nose.transform.position);

        if (distance < onPointDistance) {
            sum += 100;
        } else if (distance < acceptedDistance) {
            sum += (100 - ((distance/acceptedDistance)*100));
        }

        meanFeaturePosition = sum / 5F;
        
        // Scoring Feature Indexes
        sum = 0;

        if (targetFace.rightEar.GetComponent<SwapPrefab>().currentIndex == Face.Instance.rightEar.GetComponent<SwapPrefab>().currentIndex) {
            sum += 100;
        }

        if (targetFace.leftEar.GetComponent<SwapPrefab>().currentIndex == Face.Instance.leftEar.GetComponent<SwapPrefab>().currentIndex) {
            sum += 100;
        }

        if (targetFace.nose.GetComponent<SwapPrefab>().currentIndex == Face.Instance.nose.GetComponent<SwapPrefab>().currentIndex) {
            sum += 100;
        }

        if (targetFace.leftEye.GetComponent<SwapPrefab>().currentIndex == Face.Instance.leftEye.GetComponent<SwapPrefab>().currentIndex) {
            sum += 100;
        }

        if (targetFace.rightEye.GetComponent<SwapPrefab>().currentIndex == Face.Instance.rightEye.GetComponent<SwapPrefab>().currentIndex) {
            sum += 100;
        }

        meanFeatureIndex = sum / 5;
        score = ((meanFace*4) + meanFeatureIndex + meanFeaturePosition)/6;

        scoreText.text = "Score: " + score + "%";
        _score = score;

    }

    private void Update() {
        Score();
    }
}
