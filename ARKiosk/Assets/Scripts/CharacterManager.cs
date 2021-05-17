using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Transform[] characters;
    Transform CurrentCharacter;
    private float initialDistance;
    private Vector3 initialScale;
    void Start()
    {
        //Getting the AR Object at selected Index 
        var temp = PlayerPrefs.GetInt("Character");
        CurrentCharacter=Instantiate(characters[temp], new Vector3(0, 0, -7), Quaternion.identity);
        CurrentCharacter.rotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //For Scaling 3D Model
        if(Input.touchCount==2)
        {
            var touchZero = Input.GetTouch(0);
            var touchOne = Input.GetTouch(1);

            //If by mistake two finger touches

            if(touchZero.phase==TouchPhase.Ended || touchZero.phase==TouchPhase.Canceled || touchOne.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Canceled)
            {
                return;
            }

            if(touchZero.phase==TouchPhase.Began || touchOne.phase==TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = CurrentCharacter.localScale;

            }
            else
            {
                var currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                if(Mathf.Approximately(initialDistance,0)) // if distance is two small
                {
                    return;
                }
                var factor = currentDistance / initialDistance;
                CurrentCharacter.localScale = initialScale * factor;
            }
        }
    }
}
