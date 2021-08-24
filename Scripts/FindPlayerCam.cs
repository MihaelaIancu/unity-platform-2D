using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPlayerCam : MonoBehaviour
{
    // Start is called before the first frame update
    public CinemachineVirtualCamera myCinemachine;
    public static GameObject player;
    
    void Start()
    {
        if(player == null) {
            player = GameObject.Find("PLAYER");
        }
        myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    public Transform playerPrefab;

    // Update is called once per frame
    void Update()
    {
        var newPlayer = Instantiate(playerPrefab);
        myCinemachine.m_Follow = newPlayer;
    }
}
