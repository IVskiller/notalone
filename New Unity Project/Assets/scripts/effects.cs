using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class effects : MonoBehaviour
{  
    public StartButton startButton_;
    public TurnButton turnButton_;
    public BoardState BoardState_;
    public playerscript playerscript_;
    public Text text_;
    string tx;
    public GameObject willnmb1;
    public GameObject willnmb2;
    public GameObject willnmb3;
    public Image[] images_= new Image[10];


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
            int x = 0;
            if (playerscript_.playertype == false)
            {
                foreach (Image i in images_)
                {

                    if (playerscript_.Hand[x] == false)
                    {
                        i.color = new Color32(75, 75, 75, 255);
                    }
                    else
                    {
                        i.color = new Color32(255, 255, 255, 255);
                    }
                    x++;
                }
            }
            

        }
    }

    public void PlaceCliced(int x)
    {

        if (BoardState_.Phase == 1 && playerscript_.playertype == false)
        {
            if (playerscript_.Hand[x - 1])
            {
                Debug.Log("postavljena karta " + x);
                playerscript_.Setcard = x;
            }
            else Debug.Log("Karta " + x+ " nije u ruci");
        }
        if (BoardState_.Phase == 2 && playerscript_.playertype) {
            Debug.Log("postavljena karta " + x);
            BoardState_.Monstercardset = x;
        }
    }

    
    
}
