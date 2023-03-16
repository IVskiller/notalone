using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phasetxts : MonoBehaviour
{
    public Text text_;
    public BoardState boardState_;
    public StartButton startButton_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startButton_.startch)
        {
            if (boardState_.Phase == 1) text_.text = "exploration phase";
            else if (boardState_.Phase == 2) text_.text = "monster phase";
            else if (boardState_.Phase == 3) text_.text = "reckoning phase";
            else if (boardState_.Phase == 4) text_.text = "end phase";
        }
    }
}
