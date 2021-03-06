using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

namespace VRClassroom
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        #region Private Serializable Fields

        /// <summary>
        /// The maximum number of players per room. When a room is full, it can't be joined by new players, and so a new room will be created.
        /// </summary>

        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so a new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 30;


        #endregion

        #region Private Fields

        /// <summary>
        /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
        /// </summary>
        /// 
        string gameVersion = "1";
        #endregion


        #region MonoBehaviorPunCallbacks Callbacks

        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster was called by PUN");

            // #Critical: The first we try to do is join a potential existing room. If there is, good, else, we'll be called back with OnJoinRandomFailed()
            //PhotonNetwork.JoinRandomRoom();
            PhotonNetwork.JoinOrCreateRoom("Class", new RoomOptions(), TypedLobby.Default);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

            PhotonNetwork.LoadLevel("Room");
        }

        #endregion

        #region MonoBehaviour Callbacks
        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during early initialization phase.
        /// </summary>
        void Awake()
        {
            //#Critical
            //this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically.
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        // Start is called before the first frame update
        void Start()
        {
            Connect();
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

            if (PhotonNetwork.IsConnected)
            {
                // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
                //PhotonNetwork.JoinRandomRoom();
                PhotonNetwork.JoinOrCreateRoom("Class", new RoomOptions(), TypedLobby.Default);
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }

        #endregion
    }
}

