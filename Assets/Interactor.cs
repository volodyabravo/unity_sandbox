using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float intaractionDistance = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, intaractionDistance);
            foreach (Collider hitCollider in hitColliders) {
                hitCollider.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
