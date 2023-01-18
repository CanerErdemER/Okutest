using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class wordsController : MonoBehaviour
//{
//    [Header("Location")]
//    float minX,minY, maxX, maxY;
//    Vector2 pos;
//    public GameObject[] wordsforspawn;


//    private void Start()
//    {
//        location();
//        spawnWords();
//    }

//    void location()//obje konumu belirleyen kod 
//    {

//        minX = -117.5f;
//        maxX = 117.5f;
//        minY = -340f;
//        maxY = 340f;
//    }
//    void spawnWords()
//    {

//        int numberOfObject = Random.Range(0, wordsforspawn.Length);
//        GameObject obj = Instantiate(wordsforspawn[numberOfObject]);
//        obj.transform.localPosition = new Vector2((Random.Range(minX, maxX)), (Random.Range(minY, maxY)));

//        obj.transform.parent  = transform;
//    }
//}
public class wordsController : MonoBehaviour
{
    public float waitTime = 2;
    public float cubeSpawnTotal = 10;
    public List<GameObject> cubePrefabList;

    float xPosMinLimit = -347;
    float xPosMaxLimit = 340;
    float yPosMinLimit = -458f;
    float yPosMaxLimit = 450f;

    public GameObject panel;
    void Start()
    {
        StartCoroutine(SpawnCube());
    }


    IEnumerator SpawnCube()
    {
        for (int i = 0; i < cubeSpawnTotal; i++)
        {
            GameObject prefabToSpawn = cubePrefabList[Random.Range(0, cubePrefabList.Count - 1)];
            //Vector3 spawnPosition = Camera.main.ScreenToViewportPoint(new Vector3(Random.Range(0,Screen.width),0,Random.Range(0,Screen.height)));  //Random.Range(xPosMinLimit, xPosMaxLimit);

            float xPos = Random.Range(xPosMinLimit, xPosMaxLimit);
            float yPos = Random.Range(yPosMinLimit, yPosMaxLimit);
            Vector3 spawnPosition = new Vector3(xPos, yPos, 0f);
            GameObject spwanObj = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity) as GameObject;
            spwanObj.transform.parent = panel.transform;
            spwanObj.transform.position = spawnPosition;
            yield return new WaitForSeconds(waitTime);
        }
    }
}