using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager singleton;

    // Start is called before the first frame update
    void Start()
    {
        if (singleton && singleton != this) Destroy(this);
        else singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte) strength : (byte) 0);
        }

        if (controller == OVRInput.Controller.LTouch)
        {
            // Trigger on left controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch)
        {
            // Trigger on left controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
}
