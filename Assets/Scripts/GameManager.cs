using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Andrew;
    [SerializeField] Animator AndrewAnimator;
    [SerializeField] List<PlayableDirector> TutorialTexts = new List<PlayableDirector>();
    

    public bool startedGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        startedGame = true;
        Andrew.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        AndrewAnimator.enabled = true;
        foreach(PlayableDirector text in TutorialTexts)
        {
            text.Play();
        }
    }

    /*
     Distributed stuff:
        Freshman - Collared Shirts
        Sophomores - KCIA
        Juniors - SAT
        Seniors - UW English
        TSA - Resumes
        Scioly - Tesla STEM
        NHS - 
        Robotics - 
        Nerds - Sports
        Sports - Textbooks
     */
        
}
