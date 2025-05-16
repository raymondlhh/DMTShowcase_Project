using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("✅ Connected to Photon Server");
        PhotonNetwork.JoinOrCreateRoom("MyARRoom", new RoomOptions { MaxPlayers = 4 }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("✅ You joined the room as Player " + PhotonNetwork.LocalPlayer.ActorNumber);
        PhotonNetwork.Instantiate("PlayerPrefab", Vector3.zero, Quaternion.identity);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"🟢 Player {newPlayer.ActorNumber} joined the room.");
    }
}
