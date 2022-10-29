using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Time before game just ends
    [SerializeField]
    float gameTime = 600;

    // Requirements for the game to end otherwise
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
