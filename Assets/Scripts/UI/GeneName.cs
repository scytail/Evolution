﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneName : MonoBehaviour {

    private bool isOn = false;
    private int nodeIndex;
    public Text textPrefab;

    // Adds or removes node when enabling or disabling a gene.
    /*
    public void sendGeneNum()
    {
        if(isOn == false)
        {
            GeneWebManager.AddNode(nodeIndex);
            isOn = true;
        }
        else if(isOn == true)
        {
            GeneWebManager.RemoveNode(nodeIndex);
            isOn = false;
        }
    }
    */    
    

    // Use this for initialization
    void Start() {

        nodeIndex = this.transform.parent.GetComponent<SpriteChange>().getIndex();
        StartCoroutine(Example());
    }

    IEnumerator Example() { 

        yield return new WaitForSeconds(0);

        //Debug.LogError("This message will make the console appear in Development Builds");

        /* if (GameObject.Find("Web Builder").GetComponent<buildWeb>().getWeb().getNode(nodeIndex) == null)
         {
             textPrefab.text = "Family friendly quip 1!!!!!";
         }

        */



        textPrefab.text = GameObject.Find("Web Builder")
            .GetComponent<buildWeb>()
            .getWeb()



            .getNode(nodeIndex)
            .getName();    
        
    }
}
