using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bord : MonoBehaviour
{
    public GameObject surmarker;
    public GameObject monmarker;
    public BoardState boardState_;
    public bool winmsg;
    public Transform[] surpos = new Transform[13];
    public Transform[] monpos = new Transform[7];
    // Start is called before the first frame update
    void Start()
    {
        winmsg = true;
       boardState_.surposnum = 19;
       boardState_.monposnum = 13;
    }

    // Update is called once per frame
    void Update()
    {
        if (winmsg)
        {
            if (boardState_.surposnum <= 0)
            {
                Debug.Log("SURVIVORS WIN");
            }
            if (boardState_.monposnum <= 0)
            {
                Debug.Log("MONSTER WIN");
            }
            winmsg = false;
        }
        if (boardState_.surposnum <= 0) boardState_.surposnum = 1;
        if (boardState_.monposnum <= 0) boardState_.monposnum = 1;

        surmarker.transform.position = surpos[boardState_.surposnum-1].position;
        monmarker.transform.position = monpos[boardState_.monposnum-1].position;

    }
}
