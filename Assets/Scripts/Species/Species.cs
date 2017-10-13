﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Species : MonoBehaviour
{
    public GameObject species;  // The asset to use to represent the species
    public GameObject WebInstance;  // The web to use as a reference when evolving
    private string speciesName;  // name of species - for stretch goal, we will want this to be a string that appears like formal latin names, by D3, number will suffice
    private List<int> location; // in which tiles this species exists.  Assuming tiles can be simplified to their numerical value
    private List<int> genes;  // what genes this species has.  Assuming genes can be simplified to their numerical value
    private List<int> herbivoreFoodSource; // i == 0 berries, i == 1 nuts, i == 2 grass, i == 3 leaves, 0 (default) means speceis cannot eat food type at given index
    private int carnivoreFoodSource; // integer between 1 and 500 that limits what size prey you can eat, -1 (default) means species cannot eat meat
    private int amntCalories; // amount of food to survive
    private int creatureSize; // 1 is tiny, 2 - 100 is small, 101 - 200 is medium, 201 - 300 is large, 301 - 400 is humongous
    private int maxPerTile; // max number of individuals of a species in a given tile, -1 is unlimited
    private int litterSize; // population growth per reproduction
    private int matingFrequency; // reproduction speed
    private int mateAttachment; // mutation chance v offspring survivability
    private int peckingOrder; // determines when the species eats in the eating algorithm

    /*
    *   Constructor
    */
    public Species()
    {
    }

    /*
    *   Initializer
    */
    public void Init(string sN, List<int> lctn, List<int> gns, List<int> hFS, int cFS, int aC, int cS, int mPT, int lS, int mF, int mA, int pO)
    {
        speciesName = sN;
        location = lctn;
        genes = gns;
        herbivoreFoodSource = hFS;
        carnivoreFoodSource = cFS;
        amntCalories = aC;
        creatureSize = cS;
        maxPerTile = mPT;
        litterSize = lS;
        matingFrequency = mF;
        mateAttachment = mA;
        peckingOrder = pO;
    }

    /*
     *  Take boolean to determine if adding/subtracting node in evolutionary web, and takes index of that node to modify species instance accordingly
     */
    public void evolve(bool addNode, int nodeIndex)
    {
        int op;
        if (addNode)
        {
            op = 1;
        }
        else
        {
            op = -1;
        }
        Node node = WebInstance.GetComponent<Web>().getNode(nodeIndex);
        // Added a node
        for (int i = 0; i < herbivoreFoodSource.Count; i++)
        {
            herbivoreFoodSource[i] += op * node.getHerbivoreFoodSource()[i];
        }
        carnivoreFoodSource += op * node.getCarnivoreFoodSource();
        amntCalories += op * node.getAmntCalories();
        creatureSize += op * node.getCreatureSize();
        maxPerTile += op * node.getMaxPerTile();
        litterSize += op * node.getLitterSize();
        matingFrequency += op * node.getMatingFrequency();
        mateAttachment += op * node.getMateAttachment();
        peckingOrder += op * node.getPeckingOrder();
    }

    /*
     *  Deep copy of species instance of passed species.  Randomly adds/subtractes node for bot, lets player choose node, and sends other to evolve()
     */
    public void clone(Species other, bool isPlayer) // other will be evolved, clone will be parent species
    {
        Species clone = new Species();
        clone.Init(other.getSpeciesName(), other.getLocation(), other.getGenes(), other.getHFS(), other.getCFS(), other.getAmntCalories(), 
            other.getCreatureSize(), other.getMaxPerTile(), other.getLitterSize(), other.getMatingFrequency(), getMateAttachment(), other.getPeckingOrder());
    }

    /*
     *  Get methods for attributes of Species
     */
    public string getSpeciesName()
    {
        return speciesName;
    }
    public List<int> getLocation()
    {
        return location;
    }
    public List<int> getGenes()
    {
        return genes;
    }
    public List<int> getHFS()
    {
        return herbivoreFoodSource;
    }
    public int getCFS()
    {
        return carnivoreFoodSource;
    }
    public int getAmntCalories()
    {
        return amntCalories;
    }
    public int getCreatureSize()
    {
        return creatureSize;
    }
    public int getMaxPerTile()
    {
        return maxPerTile;
    }
    public int getLitterSize()
    {
        return litterSize;
    }
    public int getMatingFrequency()
    {
        return matingFrequency;
    }
    public int getMateAttachment()
    {
        return mateAttachment;
    }
    public int getPeckingOrder()
    {
        return peckingOrder;
    }
}