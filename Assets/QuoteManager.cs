using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuoteManager : MonoBehaviour
{
    [SerializeField] List<Image> Quotes = new List<Image>();
    [SerializeField] int quoteNum;
    bool displayingQuote = false;
    [SerializeField] float DisplayTime = 5f;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Image quote in Quotes)
        {
            quote.gameObject.SetActive(false);
        }
        Quotes[0].gameObject.SetActive(true);
        displayingQuote = true;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime >= DisplayTime && displayingQuote)
        {
            displayingQuote = false;
            foreach (Image quote in Quotes)
            {
                quote.gameObject.SetActive(false);
            }
        }
    }

    public void NextQuote()
    {
        quoteNum++;
        Quotes[quoteNum].gameObject.SetActive(true);
        displayingQuote = true;
        startTime = Time.time;
    }
}
