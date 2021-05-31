using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stores 
{
   
    private InsideStore dewels;
    private InsideStore yiamonds;
    private InsideStore zolds;
    private InsideStore blooddiamonds;
    private InsideStore zilverexchange;

    public Stores()
    {
        dewels = new InsideStore(Random.Range(3,6));
        yiamonds = new InsideStore(Random.Range(3,6));
        zolds = new InsideStore(Random.Range(3,6));
        blooddiamonds = new InsideStore(Random.Range(3,6));
        zilverexchange = new InsideStore(Random.Range(3,6));
    }
    
}

public enum StoreName
{
    DEWELS,
    YIAMONDS,
    ZOLDS,
    BLOODDIAMONDS,
    ZILVEREXCHANGE,
    NONE
}

