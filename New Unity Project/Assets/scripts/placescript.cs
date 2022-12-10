using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placescript : MonoBehaviour
{
    
    public effects effects_;
    public BoardState boardState_;
    public playerscript playerscript_;
    // Start is called before the first frame update
    void Start()
    {
        effects_ = FindObjectOfType<effects>();
        playerscript_ = FindObjectOfType<playerscript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(int cardnum) {
    effects_.PlaceCliced(cardnum);
    }
}
