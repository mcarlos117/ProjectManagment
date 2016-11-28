using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HostGame : MonoBehaviour {

    [SerializeField]
    private uint roomSize = 4;

    public static int playerCount = 0;

   // private int numPlayers = Network.connections.Length;

    private string roomName;
    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if(networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetRoomName(string _name)
    {
        roomName = _name;
    }

    public void CreateRoom()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room " + roomName);
            //create room
            playerCount++;

            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
            
            //SceneManager.LoadScene("Room");

        }
    }

    public void StartMatch()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Starting Match " + roomName);
            //create room
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
            //SceneManager.LoadScene("Room");

        }
    }

}
