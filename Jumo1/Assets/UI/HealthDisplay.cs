﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Bow bowInst = new Bow();
   //private int health = Bow.getHealth();
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
     //   healthText.text = "HEALTH : " + health;
    }
}
