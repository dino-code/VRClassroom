using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WritingUtensil : MonoBehaviour
{
    Color color;
    OVRGrabbable utensil;
    public WritingSurface surface;
    private RaycastHit touch;
    // Start is called before the first frame update
    void Start()
    {
        // later, assign surface to the value of the object being touched with trigger/collider
        this.surface = GameObject.Find("BlackBoard").GetComponent<WritingSurface>();

        utensil = gameObject.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "WhiteBoardRedMarker") color = Color.red;
        else if (gameObject.name == "WhiteBoardBlackMarker") color = Color.black;
        else if (gameObject.name == "WhiteBoardBlueMarker") color = Color.blue;
        else if (gameObject.name == "Chalk") color = Color.white;

        float tipHeight = transform.Find("Tip").transform.localScale.y * 5;
        Vector3 tip = transform.Find("Tip").transform.position;

        if (Physics.Raycast(tip, transform.up, out touch, tipHeight))
        {
            if (!(touch.collider.tag == "writing_surface")) 
                return;

            this.surface = touch.collider.GetComponent<WritingSurface>();

            VibrationManager.singleton.TriggerVibration(1, 30, 50, utensil.grabbedBy.m_controller);

            // set this based on the color of the pen.
            this.surface.SetColor(color);
            this.surface.SetTouchPosition(touch.textureCoord.x, touch.textureCoord.y);
            this.surface.ToggleTouch(true);

        } else
        {
            this.surface.ToggleTouch(false);
        }
    }
}
