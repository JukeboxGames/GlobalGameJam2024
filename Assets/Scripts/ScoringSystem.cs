using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    public ReferenceFace targetFace;
    [SerializeField] private float acceptedDistance;
    float sum, score;
    float meanFace, meanFeaturePosition, meanMouth, meanFeatureIndex;
    float distance;
    public void Score () {
        sum = 0;
        // Scoring face
        for (int i = 0; i < Face.Instance.spline.GetPointCount(); i++) {
            // Assumes target spline is constructed the same way as face spline
            distance = Vector3.Distance(Face.Instance.spline.GetPosition(i), targetFace.faceSpline.GetPosition(i));
            if (distance < acceptedDistance) {
                sum += ((distance*100)/acceptedDistance);
            }
        }

        meanFace = sum / Face.Instance.spline.GetPointCount();

        sum = 0;
        // Scoring mouth
        for (int i = 0; i < Face.Instance.spline.GetPointCount(); i++) {
            // Assumes target mouth spline is constructed the same way as mouth spline
            distance = Vector3.Distance(Face.Instance.mouthSpline.GetPosition(i), targetFace.mouthSpline.GetPosition(i));
            if (distance < acceptedDistance) {
                sum += ((distance*100)/acceptedDistance);
            }
        }

        meanMouth = sum / Face.Instance.mouthSpline.GetPointCount();

        // Hardcodeado porque igual nadie hace code review

        sum = 0;
        Vector3 targetPoint;
        // Score ears
        // Right ear
        targetPoint = (targetFace.transform.position - targetFace.rightEar.transform.position);
        targetPoint.x /= (targetFace.gameObject.transform.localScale.x);
        targetPoint.y /= (targetFace.gameObject.transform.localScale.y);
        distance = Vector3.Distance(targetPoint, Face.Instance.rightEar.transform.position);

        if (distance < acceptedDistance) {
            sum += ((distance*100)/acceptedDistance);
        }

        // left ear
        targetPoint = (targetFace.transform.position - targetFace.leftEar.transform.position);
        targetPoint.x /= (targetFace.gameObject.transform.localScale.x);
        targetPoint.y /= (targetFace.gameObject.transform.localScale.y);
        distance = Vector3.Distance(targetPoint, Face.Instance.leftEar.transform.position);

        if (distance < acceptedDistance) {
            sum += ((distance*100)/acceptedDistance);
        }

        // mouth
        targetPoint = (targetFace.transform.position - targetFace.mouth.gameObject.transform.position);
        targetPoint.x /= (targetFace.gameObject.transform.localScale.x);
        targetPoint.y /= (targetFace.gameObject.transform.localScale.y);
        distance = Vector3.Distance(targetPoint, Face.Instance.mouth.transform.position);

        if (distance < acceptedDistance) {
            sum += ((distance*100)/acceptedDistance);
        }

        // left eye
        targetPoint = (targetFace.transform.position - targetFace.leftEye.gameObject.transform.position);
        targetPoint.x /= (targetFace.gameObject.transform.localScale.x);
        targetPoint.y /= (targetFace.gameObject.transform.localScale.y);
        distance = Vector3.Distance(targetPoint, Face.Instance.leftEye.transform.position);

        if (distance < acceptedDistance) {
            sum += ((distance*100)/acceptedDistance);
        }

        // right eye
        targetPoint = (targetFace.transform.position - targetFace.rightEye.gameObject.transform.position);
        targetPoint.x /= (targetFace.gameObject.transform.localScale.x);
        targetPoint.y /= (targetFace.gameObject.transform.localScale.y);
        distance = Vector3.Distance(targetPoint, Face.Instance.rightEye.transform.position);

        if (distance < acceptedDistance) {
            sum += ((distance*100)/acceptedDistance);
        }

        // nose
        targetPoint = (targetFace.transform.position - targetFace.nose.gameObject.transform.position);
        targetPoint.x /= (targetFace.gameObject.transform.localScale.x);
        targetPoint.y /= (targetFace.gameObject.transform.localScale.y);
        distance = Vector3.Distance(targetPoint, Face.Instance.nose.transform.position);

        if (distance < acceptedDistance) {
            sum += ((distance*100)/acceptedDistance);
        }

        meanFeaturePosition = sum / 6f;
        
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

        score = (meanFace + meanFeatureIndex + meanFeaturePosition + meanMouth)/4;

    }
}
