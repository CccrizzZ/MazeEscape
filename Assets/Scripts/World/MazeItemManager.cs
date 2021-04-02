using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeItemManager : MonoBehaviour
{

    public GameObject SupplyBox;
    public GameObject Portal;
    public GameObject Keys;
    
    int Max_Supply = 10;
    int Max_Key = 3;
    int Max_Portal = 1;


    GameObject p;

    List<GameObject> Keylist;
    List<GameObject> SupplyList;

    void Start()
    {

        // spawn portal
        p = Instantiate(Portal, transform);
        SetRandomPosition(p, 50);
        var PortalInGame = GameObject.FindGameObjectsWithTag("portal").Length;



        // spawn keys
        Keylist = new List<GameObject>();
        for (var i = 0; i < Max_Key; i++)
        {
            SpawnKey();
        }

        // spawn supply boxes
        SupplyList = new List<GameObject>();
        for (var i = 0; i < SupplyList.Count; i++)
        {
            SpawnSupply();
        }



    }

    void Update()
    {
        if (Time.frameCount % 240 == 0)
        {


            // foreach (var item in SupplyList)
            // {
            //     if (item == null)
            //     {
            //         Keylist.Remove(item);                    
            //     }
            //     else
            //     {
            //         SetRandomPosition(item, 50);
            //     }
            // }


            // if portal destroyed upon spawn
            var PortalInGame = GameObject.FindGameObjectsWithTag("portal").Length;
            if(PortalInGame < Max_Portal)
            {
                p = Instantiate(Portal, transform);
                SetRandomPosition(p, 50);
            }

            
            // if key destoyed upon spawn
            if (Keylist.Count < Max_Key)
            {
                SpawnKey();
            }



            // if supply destroyed upon spawn
            var SupplyBoxInGame = GameObject.FindGameObjectsWithTag("supplybox").Length;
            if (SupplyBoxInGame < Max_Supply)
            {
                SpawnSupply();
            }


        }
    }


    // set gameobject at random position
    void SetRandomPosition(GameObject go, int range)
    {
        go.transform.position = gameObject.transform.position;
        var randint = Random.Range(-range, range);
        var randint2 = Random.Range(-range, range);
        go.transform.position = gameObject.transform.position + new Vector3(randint, 0, randint2);
    }






    // spawn game object
    void SpawnKey()
    {
        var tempkey = Instantiate(Keys, transform);
        SetRandomPosition(tempkey, 45);
        Keylist.Add(tempkey);
    }


    void SpawnSupply()
    {
        var tempBox = Instantiate(SupplyBox, transform);
        SetRandomPosition(tempBox, 50);
        tempBox.transform.position += new Vector3(0,6,0);
        SupplyList.Add(tempBox);
    }
}
