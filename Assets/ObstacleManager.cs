using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] List<Obstacle> obstacles = new List<Obstacle>();
    [SerializeField] Transform spawnPos;
    [SerializeField] float spawnTime;
    Obstacle targetObstacle;
    float startTime;
    public float obstacleSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (PlayerPrefs.GetString("Association"))
        {
            case "Freshmen":
                targetObstacle = obstacles[0];
                return;
            case "Sophomores":
                targetObstacle = obstacles[1];
                return;
            case "Juniors":
                targetObstacle = obstacles[2];
                return;
            case "Seniors":
                targetObstacle = obstacles[3];
                return;
            case "TSA":
                targetObstacle = obstacles[4];
                return;
            case "SciOly":
                targetObstacle = obstacles[5];
                return;
            case "Robotics":
                targetObstacle = obstacles[6];
                return;
            case "Environmental":
                targetObstacle = obstacles[7];
                return;
            case "Nerds":
                targetObstacle = obstacles[8];
                return;
            case "Athletes":
                targetObstacle = obstacles[9];
                return;
            default:
                targetObstacle = obstacles[0];
                return;
        }
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
            if (Time.time - startTime > spawnTime)
            {
                startTime = Time.time;
                SpawnNewObstacle();
            }
            if (Time.time < 100)
            {
                spawnTime = .3f + .3f * (10 - .1f * Time.time);
            }
            else
            {
                spawnTime = .3f;
            }
        }
    }

    private void SpawnNewObstacle()
    {
        int obstacleNum = Random.Range(0, obstacles.Count);
        int obstacleVertical = Random.Range(0, 2);
        float obstacleY = Random.Range(-2.3f, 4.4f);
        GameObject newObst = Instantiate(targetObstacle.gameObject, new Vector3(spawnPos.position.x, obstacleY), Quaternion.identity);
        newObst.GetComponent<Obstacle>().obstacleSpeed = obstacleSpeed;
        if(obstacleVertical == 0)
        {
            newObst.GetComponent<PlayableDirector>().enabled = false;
        }
    }
}
