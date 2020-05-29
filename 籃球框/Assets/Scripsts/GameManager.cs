
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

public class GameManager : MonoBehaviour
{
    [Header("籃球數量")]
    public Text textballcount;
    
    [Header("分數")]
    public Text textscore;

    private int ballcount = 5;
    private int score;

    private ThreePoint threePoint;

    private void    Start()
    {
        threePoint = FindObjectOfType<ThreePoint>();
    }

    public void Useball(GameObject ball) 
    {
        Destroy(ball.GetComponent<Throwable>());
        Destroy(ball.GetComponent<Interactable>());
        ballcount--;
        textballcount.text = "籃球數量:" + ballcount + "/5";
    }

    // Update is called once per frame
    private void    OnTriggerEnter(Collider other)
    {
        if(threePoint.inThreePoint)
        {
            score += 3;
        }
        else
        {
            score += 2;
        }
        
        textscore.text = "分數" + score;
    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
