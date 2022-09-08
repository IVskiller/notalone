using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerinf : NetworkBehaviour
    {
    
    [SerializeField] [SyncVar] private int Will;
    [SerializeField] private bool[] Hand;
    [SerializeField] private bool[] Gy;
    void Start()
    {
        Will = 3;
        Hand = new bool[10] { true, true, true, true, true, false, false, false, false, false };
        Gy = new bool[10] { false, false, false, false, false, false, false, false, false, false };
    }
    void Update()
    {
        Nes();
    }

    [Command(requiresAuthority = false)]
    void Nes()
    {
        if ( !isLocalPlayer ) { return;}
        if (Input.GetKey("w")) 
        {
            Will -= 1;
        }
    }
}
