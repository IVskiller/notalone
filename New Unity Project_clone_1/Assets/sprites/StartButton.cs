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
    public bool startch;
    public int buttodel;
    void Start()
    {
        
        startch = false;
        buttodel = ((int)netIdentity.netId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        startch = true;
        if(!hasAuthority)Cmdbuttodell();
    }

    [Command]
    public void Cmdbuttodell() {
        Rpcbuttodell();
    }
    [ClientRpc]
    public void Rpcbuttodell()
    {
        startb.SetActive(false);
    }

}
