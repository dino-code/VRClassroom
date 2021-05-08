using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

namespace VRClassroom
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        [SerializeField]
        public GameObject playerPrefab;

        private GameObject localPlayer;

        

        public static GameManager Instance;

        public void Start()
        {
            Instance = this;

            if (!PhotonNetwork.IsConnected)
            {
                SceneManager.LoadScene("Login");

                return;
            }

            if (playerPrefab == null)
            { // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.

                Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
            }
            else
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);

                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                //PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(4.27f, 1.48f, -2.27f), Quaternion.identity, 0);
                
                if (photonView.IsMine)
                {
                    Debug.Log("SPAWN WORKS");
                    localPlayer = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(4.27f, 1.48f, -2.27f), Quaternion.identity, 0);

                    
                    //Transform camera = localPlayer.transform.Find("Camera");
                    //camera.gameObject.SetActive(true);
                } else
                {
                    //playerPrefab.gameObject.GetComponentInChildren<OVRManager>().gameObject.SetActive(false);
                    //playerPrefab.GetComponent<OVRCameraRig>().enabled = false;
                }
                    
            }
        }

        #region Photon Callbacks

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.LogFormat("OnPlayerEnteredRoom() {0}", newPlayer.NickName); // not seen if you're the player

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient); // called before OnPlayerLeftRoom

                LoadArena();
            }
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.LogFormat("OnPlayerLeftRoom() {0}", otherPlayer.NickName); // seen when other disconnects


            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

                LoadArena();
            }
        }

        /// <summary>
        /// Called when the local player leaves the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        #endregion

        #region Public Methods

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        #endregion

        #region Private Methods

        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }

            
            Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
            PhotonNetwork.LoadLevel("Room");
        }

        #endregion
    }
}

