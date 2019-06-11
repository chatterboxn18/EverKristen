using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coins : MonoBehaviour {
    public int value = 0;
    public Action Evt_PlayerLevelUp = delegate {  };
    public Action Evt_PlayerSpeedUp = delegate {  };

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (name.Contains("iceCream"))
        {
            if (collider.transform.tag == "player")
            {
                Evt_PlayerLevelUp();
            }
        }
        else if (name.Contains("sushi"))
        {
            if (collider.transform.tag == "player")
            {
                Evt_PlayerSpeedUp();
            }
        }
        if (collider.transform.name == "destroyLeftovers")
        {
            Destroy(this.gameObject);
        }
    }
}
