using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effects : MonoBehaviour
{
    public playerscript playerscript_;
    public BoardState BoardState_;
    // Start is called before the first frame update
    void Start()
    {
        playerscript_ = FindObjectOfType<playerscript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        //if (playerscript_.Hand[0]) { playerscript_.Hand[0] = false; }
        //else { playerscript_.Hand[0] = true; }
        Debug.Log("efekt1");
    }
}
