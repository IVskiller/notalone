using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : NetworkBehaviour
{
    public int Will;
    public bool[] Hand;
    public bool[] Gy;
    public int Setcard;
    public bool River;
    public bool Artefact;
    // Start is called before the first frame update
    void Start()
    {
        Will = 3;
        Setcard = 0;
        River = false;
        Artefact = false;
        Gy = new bool[] { true, true, true, true, true, false, false, false, false, false };
        Hand = new bool[] { true, true, true, true, true, false, false, false, false, false };
    }

    void Update()
    {
        if (!hasAuthority) { return; }
        else{ 
        if (Input.GetKeyDown(KeyCode.Q)) CmdRiver();

        if (Input.GetKeyDown(KeyCode.W)) CmdWill();
        }
    }


    [Command]
    private void CmdWill()
    {
        RpcWill();
    }

    [ClientRpc]
    private void RpcWill()
    {
    Will -= 1;
    }

    [Command]
    private void CmdRiver()
    {
        RpcRiver();
    }

    [ClientRpc]
    private void RpcRiver()
    {
        Setcard -= 1;
        
    }
}