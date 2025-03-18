using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] List<GoodObject> objects = new List<GoodObject>();
    [SerializeField] Transform spawnPos;
    [SerializeField] float spawnTime;
    float startTime;
    public float obstacleSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().startedGame)
        {
            if (Time.time < 100)
            {
                obstacleSpeed = .3f / (10 - .1f * Time.time);
            }
            else
            {
                obstacleSpeed = .3f;
            }
            if (Time.time < 100)
            {
                spawnTime = .3f + .3f * (10 - .1f * Time.time);
            }
            else
            {
                spawnTime = .3f;
            }
            if (Time.time - startTime > spawnTime)
            {
                startTime = Time.time;
                SpawnNewObstacle();
            }
        }
    }

    private void SpawnNewObstacle()
    {
        int obstacleNum = Random.Range(0, objects.Count);
        float obstacleY = Random.Range(-2.3f, 4.4f);
        GameObject newObst = Instantiate(objects[obstacleNum].gameObject, new Vector3(spawnPos.position.x, obstacleY), Quaternion.identity);
        newObst.GetComponent<Obstacle>().obstacleSpeed = obstacleSpeed;
    }
}
