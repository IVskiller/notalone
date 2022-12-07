using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placescript : MonoBehaviour
{
    
    public effects effects_;
    // Start is called before the first frame update
    void Start()
    {
        effects_ = FindObjectOfType<effects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick(int cardnum) {
        effects_.PlaceCliced(cardnum);
    }
}
