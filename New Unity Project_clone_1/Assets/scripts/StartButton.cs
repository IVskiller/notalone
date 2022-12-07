using Mirror;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class StartButton : NetworkBehaviour
{
    public GameObject startb;
    [SyncVar] [SerializeField] public bool startch;
    public int buttodel;
    void Start()
    {    
        startch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        startch = true;  
    }
}
