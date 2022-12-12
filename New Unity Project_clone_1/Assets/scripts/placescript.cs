using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class placescript : MonoBehaviour
{
    
    public effects effects_;
    public BoardState boardState_;
    public playerscript playerscript_;
    public StartButton StartButton_;
    

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
