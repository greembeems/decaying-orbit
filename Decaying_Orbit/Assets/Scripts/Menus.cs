using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    // Array of team members
    [SerializeField]
    Text[] names;

    // How fast the alpha changes
    [SerializeField]
    float alphaSpeed = 1;
    float alphaValue = 1f;


    public void StartClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CreditsClicked()
    {
        // All will appear at the same time

        for (int i = 0; i < names.Length; i++)
        {
            StartCoroutine(FadeIn(i));
        }
    }

    public void MainMenuClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator FadeIn(int index)
    {
        while (names[index].color.a < 255)
        {
            names[index].color = Color.Lerp(names[index].color, new Vector4(names[index].color.r, names[index].color.g, names[index].color.b, alphaValue), alphaSpeed * Time.deltaTime);

            Debug.Log("Changing Alpha " + index + " " + alphaValue);

            yield return null;
        }
    }
}
