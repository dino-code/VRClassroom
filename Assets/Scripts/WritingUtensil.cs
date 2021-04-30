using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritingUtensil : MonoBehaviour
{
    public WritingSurface surface;
    private RaycastHit touch;
    // Start is called before the first frame update
    void Start()
    {
        // later, assign surface to the value of the object being touched with trigger/collider
        this.surface = GameObject.Find("BlackBoard").GetComponent<WritingSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        float tipHeight = transform.Find("Tip").transform.localScale.y;
        Vector3 tip = transform.Find("Tip").transform.position;

        if (Physics.Raycast(tip, transform.up, out touch, tipHeight))
        {
            if (!(touch.collider.CompareTag("writing_surface")))
            {
                OVRInput.SetControllerVibration(0.0f, 0.0f, OVRInput.Controller.RTouch);
                return;
            }

            this.surface = touch.collider.GetComponent<WritingSurface>();
            OVRInput.SetControllerVibration(0.5f, 0.5f, OVRInput.Controller.RTouch);
            
            Debug.Log("touching-new");
        }
    }
}
