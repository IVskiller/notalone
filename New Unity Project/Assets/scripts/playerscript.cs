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
    public Canvas canvas_;
    public GameObject playerobject_;
    public Transform playerparent;
    public GameObject willobj1;
    public GameObject willobj2;
    public GameObject willobj3;
    public int playerID;
    public bool playertype;
    public int Will;
    public bool[] Hand;
    public bool[] Gy;
    public int Setcard;
    public bool River;
    public bool Artefact;
    public bool clcon;
    public bool ifhit;
    public bool phase3; 
    public bool phase4;



    // Start is called before the first frame update
    void Start()
    {
        
        BoardState_ = FindObjectOfType<BoardState>();
        startButton_ = FindObjectOfType<StartButton>();
        effects_ = FindObjectOfType<effects>();
        turnButton_ = FindObjectOfType<TurnButton>();
        canvas_ = FindObjectOfType<Canvas>();
        playerparent = transform.Find("players");
        playertype = false;
        Will = 3;
        Setcard = 0;
        River = false;
        Artefact = false;
        Gy = new bool[] { true, true, true, true, true, false, false, false, false, false };
        Hand = new bool[] { true, true, true, true, true, false, false, false, false, false };
        clcon = true;
        if (hasAuthority) CmdIDset();
        phase3 = true;
        phase4 = true;
        ifhit = false;
    }

    void Update()
    {
        if (startButton_.startch)
        {
            playerobject_.transform.SetParent(canvas_.transform);
            if (isServer && hasAuthority) CmdMonsterset();
            startButton_.startb.SetActive(false);
            if (hasAuthority && isLocalPlayer) placescriptset();
            turnButton_.turnb.SetActive(true);
            if (BoardState_.Phase == 1) {
                phase3 = true;
                phase4 = true;
            }
            #region phase3
            if (hasAuthority && playertype==false)
            {
                if (BoardState_.Phase == 3 && phase3)
                {
                    if (Setcard == BoardState_.Monstercardset)
                    {
                        cmdwill();
                        
                        Debug.Log("HIT");
                    }
                    else Debug.Log("MISS");
                    
                    phase3 = false;
                    
                }
            }
            #endregion
            if (BoardState_.Phase == 4 && phase4)
            {
                if(isServer && isLocalPlayer) surbordmov();
                
                phase4 = false;
            }
            #region willvisual
            if (playertype)
            {
                willobj1.SetActive(false);
                willobj2.SetActive(false);
                willobj3.SetActive(false);
            }
            else
            {
                if (Will == 3)
                {
                    willobj1.SetActive(true);
                    willobj2.SetActive(true);
                    willobj3.SetActive(true);
                }
                else if (Will == 2)
                {
                    willobj1.SetActive(true);
                    willobj2.SetActive(true);
                    willobj3.SetActive(false);
                }
                else if (Will == 1)
                {
                    willobj1.SetActive(true);
                    willobj2.SetActive(false);
                    willobj3.SetActive(false);
                }
                else if (Will == 0)
                {
                    willobj1.SetActive(false);
                    willobj2.SetActive(false);
                    willobj3.SetActive(false);
                }
            }
            #endregion 
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
    #region will & monsbordmovment
    [Command]
    public void cmdwill() {
        rpcwill();
        BoardState_.monposnum--;
    }

    [ClientRpc]
    public void rpcwill() {
        Will--;
    }
    #endregion
    #region surbordmovment
    [Command]
    public void surbordmov() {
        BoardState_.surposnum--;
    }
    #endregion
}