using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    Button level1;
    [SerializeField]
    Button level2;
    void Start()
    {
        level1.onClick.AddListener(ZapniDalsi);
        level2.onClick.AddListener(ZapniZnova);
       
    }
    
    public void ZapniDalsi()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ZapniZnova()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 0);
    }


}
