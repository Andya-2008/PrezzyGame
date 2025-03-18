using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject obstacleParticles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bullet collided with: " + collision.gameObject.name);
        if(collision.gameObject.tag == "Obstacle")
        {
            if (collision.gameObject.GetComponent<Obstacle>().obstacleHealth <= 1)
            {
                Instantiate(obstacleParticles, transform.position, Quaternion.identity);
                GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore(1);
                Destroy(collision.gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Obstacle>().obstacleHealth -= 1;
            }
            Destroy(this.gameObject);
        }
    }
}
