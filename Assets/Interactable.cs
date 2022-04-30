using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Interactable : MonoBehaviour
{
    public bool active = false;

    public float activeRotationYchange = 0;

    public float rotationSpeed = 10.0f;
    private float defaultRotationX;
    private float defaultRotationY;
    private float defaultRotationZ;

    private int rotationCurrentStepCounter = 0;
    private int rotationTotalStepsCounter;

    AudioSource audioData;

    void Start()
    {
        audioData = GetComponent<AudioSource>();

        defaultRotationX = transform.eulerAngles.x;
        defaultRotationY = transform.eulerAngles.y;
        defaultRotationZ = transform.eulerAngles.z;
        if ((activeRotationYchange != 0) & (rotationSpeed > 0)) {
            rotationTotalStepsCounter = (int)Mathf.Abs((activeRotationYchange / rotationSpeed));
            rotationSpeed = rotationSpeed * activeRotationYchange / Mathf.Abs(activeRotationYchange);
        }
    }

    void Update()
    {
        if (active & rotationCurrentStepCounter <= rotationTotalStepsCounter) {
                Debug.Log(rotationCurrentStepCounter);

                rotationCurrentStepCounter++;

                float currentRotationY = transform.eulerAngles.y;

                float rotationX = defaultRotationX;
                float rotationY = currentRotationY + rotationSpeed;
                float rotationZ = defaultRotationZ;

                transform.localEulerAngles = new Vector3(rotationX, rotationY, rotationZ);
            
        } else if (!active & rotationCurrentStepCounter > 0) {

                rotationCurrentStepCounter--;

                float currentRotationY = transform.eulerAngles.y;

                float rotationX = defaultRotationX;
                float rotationY = currentRotationY - rotationSpeed;
                float rotationZ = defaultRotationZ;

                transform.localEulerAngles = new Vector3(rotationX, rotationY, rotationZ);

        }
    }

    void Interact()
    {
        active = !active;
        audioData.Play(0);
    }
}
