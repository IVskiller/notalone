using Mirror;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class playerscript : NetworkBehaviour
{
    [Scene] public string gamescene = string.Empty;
    public BoardState BoardState_;
    public bool playertype;
    public int Will;
    public bool[] Hand;
    public bool[] Gy;
    public int Setcard;
    public bool River;
    public bool Artefact;
    public bool clcon;
    [HideInInspector]
    public StartButton startButton_;
    // Start is called before the first frame update
    void Start()
    {
        playertype = false;
        Will = 3;
        Setcard = 0;
        River = false;
        Artefact = false;
        Gy = new bool[] { true, true, true, true, true, false, false, false, false, false };
        Hand = new bool[] { true, true, true, true, true, false, false, false, false, false };
        clcon = true;
        BoardState_ = FindObjectOfType<BoardState>();
        startButton_ = FindObjectOfType<StartButton>();
    }

    void Update()
    {
        
        if (!hasAuthority) { return; }
        else {

           

            if (Input.GetKeyDown(KeyCode.Q)) CmdRiver();

            if (Input.GetKeyDown(KeyCode.W)) CmdWill();

            if(startButton_.startch) if (isServer && hasAuthority) CmdMonsterset();
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

    [Command]
    private void CmdTurn()
    {
        BoardState_.Turn++;
    }

    [Command]
    public void Plnumb()
    {
        BoardState_.Playernumb++;
    }

    [Command]
    public void CmdMonsterset()
    {
        BoardState_.MonsterID = ((int)netIdentity.netId);
        RpcMonsterset();
    }

    [ClientRpc]
    public void RpcMonsterset()
    {
        if (((int)netIdentity.netId) == BoardState_.MonsterID) playertype = true;
    }
}