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
    public GameObject horseStage;

    public GameObject rope;

    public float playerPosition = 0;
    public int rng;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void StartGame()
    {
        //player.GetComponent<PlayerAnimation>().horseStage = true;
        fireStage.GetComponent<FireStage>().StartLevel();
        //monkeyStage.GetComponent<MonkeyStage>().StartLevel();
        //horseStage.GetComponent<HorseStage>().StartLevel();

        player.GetComponent<PlayerAnimation>().menuStage = false;
        player.GetComponent<PlayerAnimation>().fireStage = true;
        player.GetComponent<PlayerAnimation>().UpdateAnim();
    }
    
    public void LoadLevel()
    {
        rng = Random.Range(0, 3);
        if (rng == 0)
        {
            fireStage.GetComponent<FireStage>().StartLevel();
            player.GetComponent<PlayerAnimation>().fireStage = true;
        } else { player.GetComponent<PlayerAnimation>().fireStage = false; }

        if (rng == 1)
        {
            monkeyStage.GetComponent<MonkeyStage>().StartLevel();
            rope.SetActive(true);
            rope.GetComponent<Animator>().SetTrigger("RopeIn");
            player.GetComponent<PlayerAnimation>().monkeyStage = true;
        } else { StartCoroutine(RopeAnim()); player.GetComponent<PlayerAnimation>().monkeyStage = false; }
            
        if (rng == 2)
        {
            horseStage.GetComponent<HorseStage>().StartLevel();
            player.GetComponent<PlayerAnimation>().horseStage = true;
        } else { player.GetComponent<PlayerAnimation>().horseStage = false; }

        if (rng == 3)
            fireStage.GetComponent<FireStage>().StartLevel();

        if (rng == 4)
            fireStage.GetComponent<FireStage>().StartLevel();

        player.GetComponent<PlayerAnimation>().UpdateAnim();
    }

    public void Restart()
    {
        player.transform.position = new Vector3(0, 0, 0);
        ObjectPooler.Instance.ResetPool();
        mainMenu.SetActive(true);
        playerPosition = 0;

        player.GetComponent<PlayerAnimation>().menuStage = true;
        player.GetComponent<PlayerAnimation>().fireStage = false;
        player.GetComponent<PlayerAnimation>().monkeyStage = false;
        player.GetComponent<PlayerAnimation>().ballStage = false;
        player.GetComponent<PlayerAnimation>().horseStage = false;
        player.GetComponent<PlayerAnimation>().swingStage = false;
        player.GetComponent<PlayerAnimation>().UpdateAnim();
    }

    IEnumerator RopeAnim()
    {
        rope.GetComponent<Animator>().SetTrigger("RopeOut");
        yield return new WaitForSeconds(0.3f);
        rope.SetActive(false);
    }
}
