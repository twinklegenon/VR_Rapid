using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Rapid 1");
    }

    public void StartRapid2() {

        SceneManager.LoadScene("Rapid 2");
    }
}
