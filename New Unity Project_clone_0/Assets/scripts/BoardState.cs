using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardState : NetworkBehaviour
{
    [SyncVar] [SerializeField] public int MonsterID;
    [SyncVar] [SerializeField] public int Turn;
    [SyncVar] [SerializeField] public int BoardM;
    [SyncVar] [SerializeField] public int BoardS;
    [SyncVar] [SerializeField] public int Playernumb;
    [SyncVar] [SerializeField] public bool Monsterset;

    public BoardState BoardState_;
    public playerscript playerscript_;

    public void Start()
    {
        Monsterset = true;
        Turn = 0;
        Playernumb = 0;
        
    }
    public void Update()
    {
        
    }

    
}
