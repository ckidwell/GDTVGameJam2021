using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stores 
{
   public InsideStore[] stores = new InsideStore[5];
    
    public Stores()
    {
        stores[0] = new InsideStore(Random.Range(3,6), StoreName.DEWELS);
        stores[1] = new InsideStore(Random.Range(3,6), StoreName.YIAMONDS);
        stores[2] = new InsideStore(Random.Range(3,6), StoreName.ZOLDS);
        stores[3] = new InsideStore(Random.Range(3,6), StoreName.BLOODDIAMONDS);
        stores[4] = new InsideStore(Random.Range(3,6), StoreName.ZILVEREXCHANGE);
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

