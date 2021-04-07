using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MazeItemManager : MonoBehaviour
{
    // objects to generate
    public GameObject SupplyBox;
    public GameObject Portal;
    public GameObject Keys;
    public GameObject EnemyFab;

    
    // maximum number of objects
    int Max_Supply = 10;
    int Max_Key = 3;
    int Max_Portal = 1;


    // portal
    GameObject p;


    // list of key and supply
    List<GameObject> Keylist;
    List<GameObject> SupplyList;



    void Start()
    {
        
        GameObject.FindGameObjectWithTag("MaxKeyText").GetComponent<Text>().text = Max_Key.ToString();

        
        var temp = Instantiate(EnemyFab, transform);
        SetRandomPosition(temp, 50);
        
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
