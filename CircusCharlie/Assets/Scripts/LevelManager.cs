using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainMenu;

    public static LevelManager Instance;
    public GameObject fireStage;
    public GameObject monkeyStage;

    public float playerPosition = 0;
    public int rng;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    //void Update()
    //{
    //    if (0 == playerPosition % 50)
    //        LoadLevel();
    //}

    public void StartGame()
    {
        fireStage.GetComponent<FireStage>().StartLevel();
        //monkeyStage.GetComponent<MonkeyStage>().StartLevel();
    }
    
    public void LoadLevel()
    {
        rng = Random.Range(0, 5);
        if (rng == 0)
            fireStage.GetComponent<FireStage>().StartLevel();
        if (rng == 1)
            monkeyStage.GetComponent<MonkeyStage>().StartLevel();
        if (rng == 2)
            fireStage.GetComponent<FireStage>().StartLevel();
        if (rng == 3)
            fireStage.GetComponent<FireStage>().StartLevel();
        if (rng == 4)
            fireStage.GetComponent<FireStage>().StartLevel();
    }

    public void Restart()
    {
        player.transform.position = new Vector3(0, 0, 0);
        ObjectPooler.Instance.ResetPool();
        mainMenu.SetActive(true);
    }
}
