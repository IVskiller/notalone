using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bord : MonoBehaviour
{
    public GameObject surmarker;
    public GameObject monmarker;
    public BoardState boardState_;

    public Transform[] surpos = new Transform[13];
    public Transform[] monpos = new Transform[7];
    // Start is called before the first frame update
    void Start()
    {
       boardState_.surposnum = 19;
       boardState_.monposnum = 13;
    }

    // Update is called once per frame
    void Update()
    {
        if (boardState_.surposnum <= 0)
        {
            Debug.Log("SURVIVORS WIN");
        }
        if (boardState_.monposnum <= 0)
        {
            Debug.Log("MONSTER WIN");
        }
    }
}
