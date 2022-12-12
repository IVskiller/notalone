using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButton : MonoBehaviour
{
    public GameObject turnb;
    public BoardState BoardState_;
    public playerscript playerscript_;
    public bool PlayerReadych;
    // Start is called before the first frame update
    void Start()
    {
        BoardState_ = FindObjectOfType<BoardState>();
        playerscript_ = FindObjectOfType<playerscript>();
        PlayerReadych = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (BoardState_.turnbutres) {
            PlayerReadych = false;
            BoardState_.turnbutres = false;
        }
    }

    public void OnClick()
    {
        if (playerscript_.isLocalPlayer && playerscript_.playertype == false)
        {
            if (playerscript_.Setcard == 11) Debug.Log("select card");
            else
            {
                if (this.PlayerReadych)
                {
                    playerscript_.redch1();
                    PlayerReadych = false;
                }
                else if (this.PlayerReadych == false)
                {
                    playerscript_.redch2();
                    PlayerReadych = true;
                }
            }
        }
        else {
            if (this.PlayerReadych)
            {
                playerscript_.redch1();
                PlayerReadych = false;
            }
            else if (this.PlayerReadych == false)
            {
                playerscript_.redch2();
                PlayerReadych = true;
            }
        }
             
    }
}
