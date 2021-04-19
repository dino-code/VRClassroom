using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

namespace VRClassroom
{
    public class MultiplayerManager : MonoBehaviourPunCallbacks
    {
        string gameVersion = "1";


        bool isConnecting;

        #region MonoBehavior CallBacks

        // MonoBehaviour method called on GameObject by Unity during early initialization phase.
        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        // Start is called before the first frame update
        // MonoBehaviour method called on GameObject by Unity during initialization phase.
        void Start()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Start the connection process.
        /// - If already connected, we attempt joining a random room
        /// - If not yet connected, Connect this application instance to Photon Cloud Network
        /// </summary>

        public void Connect()
        {
            // check if we are connected to the server. If we are, we join a random room. If we are not, we connect to the server.
            if (PhotonNetwork.IsConnected)
            {
                // # This line attempts to actually join a room. If it fails, we're notified in the OnJoinRandomFailed() callback and we'll create a room.
                //PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // # Before joining a room, we must connect to the Photon Online Server (where the room is located).
                isConnecting = PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }

        #endregion
    }

}