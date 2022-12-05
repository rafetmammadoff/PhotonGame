using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // connect to the network
    // connect to the lobby
    // connect to the room

    public InputField nickNameInput;
    public InputField roomNameInput;
    string nickName;
    string roomName;
    public Text networkInfo;
    void Start()
    {
        Debug.Log("Connecting...");

        AuthenticationValues authentication = new AuthenticationValues() {
            AuthType = CustomAuthenticationType.Custom,
        };

        // authentication.AddAuthParameter("username");

        PhotonNetwork.ConnectUsingSettings();
        DontDestroyOnLoad(gameObject);
    }

    public void LoginRoom() {
        nickName = nickNameInput.text;
        roomName = roomNameInput.text;
        SceneManager.LoadScene(1);
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom() {
        nickName = nickNameInput.text;
        roomName = roomNameInput.text;
        SceneManager.LoadScene(1);
        PhotonNetwork.JoinLobby();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connect to server");
        Debug.Log("Connect to lobby");
        // PhotonNetwork.JoinLobby();
        networkInfo.text = "Connected";

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        if  (nickName!="" && roomName!="") {
            PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers = 2, IsOpen = true, IsVisible = true}, TypedLobby.Default);
        } else {
            PhotonNetwork.JoinRandomRoom();
        };
        // Debug.Log("Connect to lobby");
        // PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions { MaxPlayers=2, IsOpen=true, IsVisible=true}, TypedLobby.Default);
    }

    public override void OnJoinedRoom() {
        Debug.Log("Join to room");
        // PhotonNetwork.JoinRandomRoom();
        // PhotonNetwork.OnJoinedRoom();
        GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0, null);
        player.GetComponent<PhotonView>().Owner.NickName = nickName;
        // InvokeRepeating(nameof(CheckName), 0, 1);
        CheckName();
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("Random room error");
    }

    public void CheckName() {
        if (PhotonNetwork.PlayerList.Length == 2) {
            GameObject.FindWithTag("Oyuncu_1").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;
            GameObject.FindWithTag("Oyuncu_2").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[1].NickName;
            GameObject.FindWithTag("OyuncuBekleniyor").GetComponent<TextMeshProUGUI>().text = "";
            // CancelInvoke(nameof(CheckName));
        } else {
            GameObject.FindWithTag("Oyuncu_1").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;
            GameObject.FindWithTag("Oyuncu_2").GetComponent<TextMeshProUGUI>().text = "------";
            GameObject.FindWithTag("OyuncuBekleniyor").GetComponent<TextMeshProUGUI>().text = "Waiting Player";
        }
    }
}
