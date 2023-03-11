using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardState : NetworkBehaviour
{
    [SyncVar] [SerializeField] public int MonsterID;
    [SyncVar] [SerializeField] public int Phase;
    [SyncVar] [SerializeField] public int BoardM;
    [SyncVar] [SerializeField] public int BoardS;
    [SyncVar] [SerializeField] public int Playernumb;
    [SyncVar] [SerializeField] public bool Monsterset;
    [SyncVar] [SerializeField] public int player_count;
    [SyncVar] [SerializeField] public int playerIDgive;
    [SyncVar] [SerializeField] public int readych;
    [SyncVar] [SerializeField] public bool turnbutres;
    [SyncVar] [SerializeField] public int  Monstercardset;
    [SyncVar] [SerializeField] public int surposnum;
    [SyncVar] [SerializeField] public int monposnum;

    public playerscript playerscript_;
    public TurnButton turnButton_;
    public effects effects_;
    
    public void Start()
    {
        turnButton_ = FindObjectOfType<TurnButton>();
        readych = 0;
        playerIDgive = 0;
        Monsterset = true;
        Phase = 1;
        Playernumb = 0;
        turnbutres = false;
        Monstercardset = 11;
    }
    public void Update()
    {
        Player_countf();
        if (Phase == 5) {
            Phase = 1;
        }
        if (player_count  == readych)
        {
            Phase++;
            turnbutres=true;
            readych = 0;
        }
        

    }

    public void Player_countf() { 
            GameObject[] playercount = GameObject.FindGameObjectsWithTag("player");
            player_count = playercount.Length;
    }

    

    
}
