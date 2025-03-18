using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float obstacleSpeed;
    public float obstacleHealth = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 6);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(-obstacleSpeed * 100 * Time.deltaTime, 0, 0);
    }
}
