using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public Transform[] characters;
    private GameObject gameObjectInstantiate;
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    int temp;
    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        temp = PlayerPrefs.GetInt("Character");
      //  CurrentCharacter = Instantiate(characters[temp], new Vector3(0, 0, -7), Quaternion.identity);
      //  CurrentCharacter.rotation = Quaternion.Euler(0, 180, 0);
    //    gameObjectInstantiate = CurrentCharacter.gameObject;
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount>0)
        {
            touchPosition = Input.GetTouch(index: 0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (TryGetTouchPosition(out Vector2 touchPosition))
            return;
        if(_arRaycastManager.Raycast(touchPosition,hits,trackableTypes:TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawnedObject==null)
            {
                spawnedObject = Instantiate(characters[temp].gameObject, hitPose.position, hitPose.rotation);
                spawnedObject.transform.rotation = Quaternion.Euler(hitPose.rotation.x, 180, hitPose.rotation.z);
                spawnedObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
                spawnedObject.transform.position = new Vector3(0.2f, -2, 3);
            }
            else
            {
             //   spawnedObject.transform.position = hitPose.position;
            }
        }
    }

}
