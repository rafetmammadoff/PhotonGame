using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform content;
    [SerializeField] RoomListing roomListingPref;
  public override void OnRoomListUpdate(List<RoomInfo> roomList)
  {
    // base.OnRoomListUpdate(roomList);
    foreach (RoomInfo info in roomList)
    {
        RoomListing listing = Instantiate(roomListingPref, content);
        listing.SetRoomInfo(info);
    }
  }
}
