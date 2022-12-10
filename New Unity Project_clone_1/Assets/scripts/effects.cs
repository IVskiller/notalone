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
    public GameObject willnmb1;
    public GameObject willnmb2;
    public GameObject willnmb3;


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

        if (BoardState_.Phase == 1 && playerscript_.playertype == false)
        {
            Debug.Log("postavljena karta " + x);
            playerscript_.Setcard = x;
        }
        if (BoardState_.Phase == 2 && playerscript_.playertype) {
            Debug.Log("postavljena karta " + x);
            BoardState_.Monstercardset = x;
        }
    }

    
    
}
