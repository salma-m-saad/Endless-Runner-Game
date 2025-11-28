using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenueFunction : MonoBehaviour
{
    void Start()
    {
        CoinCount.coinCount = 0;
    }

    void Update()
    {
        
    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
}
