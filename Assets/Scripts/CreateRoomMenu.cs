using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text roomName;
    public void OnClickCreateRoom() {
        if (!PhotonNetwork.IsConnected) {
            return;
        }

        RoomOptions roomOptions = new RoomOptions() {
            MaxPlayers = 10,
            IsOpen = true,
            IsVisible = true
        };

        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

  public override void OnCreatedRoom()
  {
    Debug.Log("Room is created");
    // base.OnCreatedRoom();
  }
}
