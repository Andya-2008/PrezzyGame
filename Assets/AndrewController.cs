using UnityEngine;

public class AndrewController : MonoBehaviour
{
    [SerializeField] float flapForce;
    [SerializeField] float shootSpeed;
    [SerializeField] GameObject shootObj;
    [SerializeField] float shootInterval;
    [SerializeField] Transform shootPos;
    float shootTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootTime = Time.time - shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    public void Flap()
    {
        if(!GameObject.Find("GameManager").GetComponent<GameManager>().startedGame)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
        }
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flapForce));
    }

    public void Shoot()
    {
        if (Time.time - shootTime >= shootInterval)
        {
            GameObject newShot = Instantiate(shootObj, shootPos.transform.position, Quaternion.identity);
            newShot.GetComponent<Rigidbody2D>().AddForce(transform.right * shootSpeed * 100 * Time.fixedDeltaTime);
            shootTime = Time.time;
        }
    }
}
