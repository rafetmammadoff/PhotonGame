using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;

public class RoomListing : MonoBehaviour
{
    [SerializeField] TMP_Text roomName;
    public void SetRoomInfo(RoomInfo roomInfo) {
        roomName.text = roomInfo.Name + " " + roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
    }

}
