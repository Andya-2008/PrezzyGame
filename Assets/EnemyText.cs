using TMPro;
using UnityEngine;

public class EnemyText : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        switch (PlayerPrefs.GetString("Association"))
        {
            case "Freshmen":
                GetComponent<TextMeshProUGUI>().text = "Dress Code!";
                return;
            case "Sophomores":
                GetComponent<TextMeshProUGUI>().text = "Dress Code!";
                return;
            case "Juniors":
                GetComponent<TextMeshProUGUI>().text = "SATs!";
                return;
            case "Seniors":
                GetComponent<TextMeshProUGUI>().text = "Calculus!";
                return;
            case "TSA":
                GetComponent<TextMeshProUGUI>().text = "The forms!";
                return;
            case "SciOly":
                GetComponent<TextMeshProUGUI>().text = "Tesla STEM!";
                return;
            case "Robotics":
                GetComponent<TextMeshProUGUI>().text = "Circuit Boards!";
                return;
            case "Environmental":
                GetComponent<TextMeshProUGUI>().text = "Weeds!";
                return;
            case "Nerds":
                GetComponent<TextMeshProUGUI>().text = "No WIFIs";
                return;
            case "Athletes":
                GetComponent<TextMeshProUGUI>().text = "Textbooks!";
                return;
            default:
                GetComponent<TextMeshProUGUI>().text = "Dress Code!";
                return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
