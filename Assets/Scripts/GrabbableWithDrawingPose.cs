using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableWithDrawingPose : OVRGrabbable
{
    public Transform leftPose;
    public Transform rightPose;
    public OvrAvatar avatar;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);

        Transform pos = grabbedBy.transform;

        if (grabbedBy.m_controller == OVRInput.Controller.RTouch)
        {
            avatar.RightHandCustomPose = rightPose; 
        }
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {

        if (grabbedBy.m_controller == OVRInput.Controller.RTouch)
        {
            avatar.RightHandCustomPose = null;
        }

        base.GrabEnd(linearVelocity, angularVelocity);
    }
}
