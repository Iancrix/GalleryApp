using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;

    public bool isVisualShowing = false;
    public bool enableVisual = true;

    private Pose placementPose;
    private bool placementPoseIsValid;

    public Camera ARCamera;

    UIManager _UIManager;

    void Start()
    {
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        visual.SetActive(false);
        isVisualShowing = false;

        _UIManager = UIManager.GetInstance();
    }

    public void setEnableVisual(bool enableVisual)
    {
        this.enableVisual = enableVisual;
    }

    void Update()
    {
        /*
        if (!_UIManager.showMovePhone)
        {*/
        if (enableVisual)
        {
            UpdatePlacementPose();
        }
        else
        {
            visual.SetActive(false);
            isVisualShowing = false;
        }
            
        //}
        

        // Shoot a raycast from the center of the screen
        /*
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        */

        // If we hit an AR plane, update position and rotation of the placement indicator
        /*
        if(hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }
        }
        */
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = ARCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        rayManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
            var cameraForward = ARCamera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
            visual.SetActive(true);
            isVisualShowing = true;
            transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            visual.SetActive(false);
            isVisualShowing = false;
        }
    }
}
