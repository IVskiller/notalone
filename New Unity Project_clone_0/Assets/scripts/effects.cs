using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class effects : MonoBehaviour
{  
    public StartButton startButton_;
    public BoardState BoardState_;
    public playerscript playerscript_;
    public Text text_;
    string tx;
    
    // Start is called before the first frame update
    void Start()
    {
       
        playerscript_ = FindObjectOfType<playerscript>();
       
       
    }

    void Update()
    {
        if (startButton_.startch)
        {      
            tx = BoardState_.readych + " / " + BoardState_.player_count;
            text_.text = tx;

        }
    }

    public void PlaceCliced(int x)
    {
        Debug.Log("efekt "+ x);
         playerscript_.Setcard = x;
    }

    
    
}
