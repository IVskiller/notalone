using Mirror;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerscript : NetworkBehaviour
{
    [Scene] public string gamescene = string.Empty;
    public StartButton startButton_;
    public BoardState BoardState_;
    public effects effects_;
    public TurnButton turnButton_;
    public Text text_;
    public int playerID;
    public bool playertype;
    public int Will;
    public bool[] Hand;
    public bool[] Gy;
    public int Setcard;
    public bool River;
    public bool Artefact;
    public bool clcon;
   

    
    // Start is called before the first frame update
    void Start()
    {
        
        BoardState_ = FindObjectOfType<BoardState>();
        startButton_ = FindObjectOfType<StartButton>();
        effects_ = FindObjectOfType<effects>();
        turnButton_ = FindObjectOfType<TurnButton>();
        
        playertype = false;
        Will = 3;
        Setcard = 0;
        River = false;
        Artefact = false;
        Gy = new bool[] { true, true, true, true, true, false, false, false, false, false };
        Hand = new bool[] { true, true, true, true, true, false, false, false, false, false };
        clcon = true;
        if (hasAuthority) CmdIDset();

    }

    void Update()
    {
        if (startButton_.startch)
        {
            if (isServer && hasAuthority) CmdMonsterset();
            startButton_.startb.SetActive(false);
            if (hasAuthority && isLocalPlayer) placescriptset();
            turnButton_.turnb.SetActive(true);
           


        }
    }

    #region monsterset
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
    #endregion
    #region idset
    [Command]
    public void CmdIDset()
    {
        
        RpcIDset();
    }

    [ClientRpc]
    public void RpcIDset()
    {
        playerID = BoardState_.playerIDgive;
        BoardState_.playerIDgive++;
    }
    #endregion
    #region redch
    [Command]
    public void redch1() {      
        BoardState_.readych--;    
    }

    [Command]
    public void redch2()
    {
        BoardState_.readych++;
    }
        public void placescriptset() {
        effects_.playerscript_ = this;
    }
    #endregion
    
    }