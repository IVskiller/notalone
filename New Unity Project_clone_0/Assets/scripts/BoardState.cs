using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoardState : NetworkBehaviour
{
    public readonly SyncList<Playerinf> Boardst = new SyncList<Playerinf>();
    public struct Playerinf
 {
    public int Will;
    public bool[] Hand;
    public bool[] Gy;
    public int Setcard;
    public bool River;
    public bool Artefact;
 }

    

    [Command]
    public void Cmdplayerupdate()
    {
        Playerinf Player1 = new Playerinf
        {
            Will = 3,
            Setcard = 0,
            River = false,
            Artefact=false,
            Gy = new bool[] { true, true, true, true, true, false, false, false, false, false },
            Hand = new bool[] { true, true, true, true, true, false, false, false, false, false}
        };

        Boardst.Add(Player1);
    }
    void Start()
    {
        Cmdplayerupdate();
    }

    void Update()
    {
        
    }
    
}
