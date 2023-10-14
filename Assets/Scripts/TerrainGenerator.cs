using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    private Transform player;
    private List<List<GameObject>> nearby = new List<List<GameObject>>();
    public List<Sprite> grass;
    public GameObject defaultGrass;
    private int currentIndexX = 0;
    private int currentIndexY = 0;
    public float size = 100f;
    private int pickLen;

    void Start()
    {
        pickLen = grass.Count;
        player = GameObject.Find("Player").transform;
        
        List<GameObject> floors;
        for (int i=0; i<3; i++)
        {
            floors = new List<GameObject>();
            int pick = Random.Range(0, pickLen);
            GameObject newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX - 1) * size, (currentIndexY + 1 - i) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            floors.Add(newobject);

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX) * size, (currentIndexY + 1 - i) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            floors.Add(newobject);

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY + 1 - i) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            floors.Add(newobject);

            nearby.Add(floors);
        }
    }

    
    void Update()
    {
        if (player.position.x >= size / 2 + size * currentIndexX)
        {
            GameObject.Destroy(nearby[0][0]);
            GameObject.Destroy(nearby[1][0]);
            GameObject.Destroy(nearby[2][0]);

            nearby[0][0] = nearby[0][1];
            nearby[1][0] = nearby[1][1];
            nearby[2][0] = nearby[2][1];
            nearby[0][1] = nearby[0][2];
            nearby[1][1] = nearby[1][2];
            nearby[2][1] = nearby[2][2];

            currentIndexX++;

            int pick = Random.Range(0, pickLen);
            GameObject newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY + 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[0][2] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[1][2] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY - 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[2][2] = newobject;
        }
        if (player.position.y >= size / 2 + size * currentIndexY)
        {
            GameObject.Destroy(nearby[2][0]);
            GameObject.Destroy(nearby[2][1]);
            GameObject.Destroy(nearby[2][2]);

            nearby[2][0] = nearby[1][0];
            nearby[2][1] = nearby[1][1];
            nearby[2][2] = nearby[1][2];
            nearby[1][0] = nearby[0][0];
            nearby[1][1] = nearby[0][1];
            nearby[1][2] = nearby[0][2];

            currentIndexY++;

            int pick = Random.Range(0, pickLen);
            GameObject newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX - 1) * size, (currentIndexY + 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[0][0] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX) * size, (currentIndexY + 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[0][1] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY + 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[0][2] = newobject;
        }
        if (player.position.x <= -1 * size / 2 + size * currentIndexX)
        {
            GameObject.Destroy(nearby[0][2]);
            GameObject.Destroy(nearby[1][2]);
            GameObject.Destroy(nearby[2][2]);

            nearby[0][2] = nearby[0][1];
            nearby[1][2] = nearby[1][1];
            nearby[2][2] = nearby[2][1];
            nearby[0][1] = nearby[0][0];
            nearby[1][1] = nearby[1][0];
            nearby[2][1] = nearby[2][0];

            currentIndexX--;

            int pick = Random.Range(0, pickLen);
            GameObject newgrass = new GameObject();
            GameObject newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY + 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[0][0] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[1][0] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY - 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[2][0] = newobject;
        }
        if (player.position.y <= -1 * size / 2 + size * currentIndexY)
        {
            GameObject.Destroy(nearby[0][0]);
            GameObject.Destroy(nearby[0][1]);
            GameObject.Destroy(nearby[0][2]);

            nearby[0][0] = nearby[1][0];
            nearby[0][1] = nearby[1][1];
            nearby[0][2] = nearby[1][2];
            nearby[1][0] = nearby[2][0];
            nearby[1][1] = nearby[2][1];
            nearby[1][2] = nearby[2][2];

            currentIndexY--;

            int pick = Random.Range(0, pickLen);
            GameObject newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX - 1) * size, (currentIndexY - 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[2][0] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX) * size, (currentIndexY - 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[2][1] = newobject;

            pick = Random.Range(0, pickLen);
            newobject = GameObject.Instantiate(defaultGrass, new Vector3((currentIndexX + 1) * size, (currentIndexY - 1) * size, 0), Quaternion.identity, gameObject.transform);
            newobject.GetComponent<SpriteRenderer>().sprite = grass[pick];
            nearby[2][2] = newobject;
        }
    }
}
