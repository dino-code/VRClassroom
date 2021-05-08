using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon;
using Photon.Pun;

public class NetworkedPlayer : MonoBehaviourPun, IPunObservable
{
    public GameObject avatar;
    public Transform playerGlobal;
    public Transform playerLocal;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            playerGlobal = GameObject.Find("LocalRemoteOVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");

            this.transform.SetParent(playerLocal);
            this.transform.localPosition = Vector3.zero;

            //avatar.SetActive(false);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.localPosition);
            stream.SendNext(playerLocal.localRotation);
        }
        else
        {
            this.transform.position = (Vector3)stream.ReceiveNext();
            this.transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
