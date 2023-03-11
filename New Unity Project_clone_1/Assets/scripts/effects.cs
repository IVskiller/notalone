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
    public bool effect5;


    // Start is called before the first frame update
    void Start()
    {
        effect5 = false;
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

                    if (playerscript_.Gy[x] && playerscript_.Hand[x]==false)
                    {
                        i.color = new Color32(75, 75, 75, 255);
                    }
                    
                    else if (playerscript_.Gy[x]==false && playerscript_.Hand[x] == false)
                    {
                        i.color = new Color32(255, 255, 255, 100);
                    }
                    else if (playerscript_.Gy[x]==false && playerscript_.Hand[x])
                    {
                        i.color = new Color32(255, 255, 255, 255);
                    }
                    x++;
                }
            }
            #region effect
            if (BoardState_.Phase == 3 && playerscript_.isLocalPlayer && playerscript_.playertype == false) {
                switch (playerscript_.effectnum) {
                    case 1:
                        
                        break;
                    case 2:
                        playerscript_.effectcardselect=true;
                        break;
                    case 3:
                        playerscript_.effectcardselect=true;

                        break;
                    case 4:
                        
                        break;
                    case 5:
                        playerscript_.effectcardselect = true;

                        break;
                    case 6:
                        playerscript_.effectcardselect = true;

                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        playerscript_.effectcardselect = true;

                        break;
                    case 11:
                        break;

                }

            }
            #endregion
        }
    }

    public void PlaceCliced(int x)
    {
        if (playerscript_.effectcardselect == false)
        {
            if (BoardState_.Phase == 1 && playerscript_.playertype == false)
            {
                if (playerscript_.Hand[x - 1])
                {
                    Debug.Log("postavljena karta " + x);
                    playerscript_.Setcard = x;
                }
                else Debug.Log("Karta " + x + " nije u ruci");
            }
            if (BoardState_.Phase == 2 && playerscript_.playertype)
            {
                Debug.Log("postavljena karta " + x);
                BoardState_.Monstercardset = x;
            }
            
        }
        else {
            
            if (BoardState_.Phase == 3 && playerscript_.playertype == false) {
                Debug.Log("odabrana je karta " + x);
                playerscript_.effectcard = 1;
            }
        }

    }

    
    
}
