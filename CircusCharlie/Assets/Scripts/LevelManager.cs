using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject mainMenu;
    public GameObject gameUI;
    public MusicPlayer mp;

    public static LevelManager Instance;
    public GameObject fireStage;
    public GameObject monkeyStage;
    public GameObject horseStage;
    public GameObject ballStage;
    public GameObject swingStage;
    public GameObject clownStage;

    public GameObject rope;

    public float playerPosition = 0;
    public int rng;

    public CameraController camera;
    public GameObject follow;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void StartGame()
    {
        //player.GetComponent<PlayerAnimation>().ballStage = true;
        fireStage.GetComponent<FireStage>().StartLevel();
        //monkeyStage.GetComponent<MonkeyStage>().StartLevel();
        //horseStage.GetComponent<HorseStage>().StartLevel();
        //ballStage.GetComponent<BallStage>().StartLevel();
        //swingStage.GetComponent<SwingStage>().StartLevel();
        //clownStage.GetComponent<ClownStage>().StartLevel();

        player.GetComponent<PlayerAnimation>().menuStage = false;
        player.GetComponent<PlayerAnimation>().fireStage = true;
        player.GetComponent<PlayerAnimation>().UpdateAnim();

        mp.GetSong(0);
    }
    
    public void LoadLevel()
    {
        rng = Random.Range(5, 6);
        if (rng == 0)
        {
            fireStage.GetComponent<FireStage>().StartLevel();
            player.GetComponent<PlayerAnimation>().fireStage = true;
            mp.GetSong(0);
        } else { player.GetComponent<PlayerAnimation>().fireStage = false; }

        if (rng == 1)
        {
            monkeyStage.GetComponent<MonkeyStage>().StartLevel();
            rope.SetActive(true);
            rope.GetComponent<Animator>().SetTrigger("RopeIn");
            player.GetComponent<PlayerAnimation>().monkeyStage = true;
            mp.GetSong(1);
        } else { StartCoroutine(RopeAnim()); player.GetComponent<PlayerAnimation>().monkeyStage = false; }
            
        if (rng == 2)
        {
            horseStage.GetComponent<HorseStage>().StartLevel();
            player.GetComponent<PlayerAnimation>().horseStage = true;
            mp.GetSong(0);
        } else { player.GetComponent<PlayerAnimation>().horseStage = false; }

        if (rng == 3)
        {
            ballStage.GetComponent<BallStage>().StartLevel();
            player.GetComponent<PlayerAnimation>().ballStage = true;
            mp.GetSong(1);
        } else { player.GetComponent<PlayerAnimation>().ballStage = false; }

        if (rng == 4)
        {
            swingStage.GetComponent<SwingStage>().StartLevel();
            player.GetComponent<PlayerAnimation>().swingStage = true;
            mp.GetSong(2);
            camera.player = follow.transform;
        } else { player.GetComponent<PlayerAnimation>().swingStage = false; camera.player = player.transform; }

        if (rng == 5)
        {
            clownStage.GetComponent<ClownStage>().StartLevel();
            player.GetComponent<PlayerAnimation>().clownStage = true;
            mp.GetSong(2);
        }
        else { player.GetComponent<PlayerAnimation>().clownStage = false;}

        player.GetComponent<PlayerAnimation>().UpdateAnim();
    }

    public void Restart()
    {
        player.transform.position = new Vector3(0, 0, 0);
        ObjectPooler.Instance.ResetPool();
        mainMenu.SetActive(true);
        gameUI.SetActive(false);
        playerPosition = 0;

        player.GetComponent<PlayerAnimation>().menuStage = true;
        player.GetComponent<PlayerAnimation>().fireStage = false;
        player.GetComponent<PlayerAnimation>().monkeyStage = false;
        player.GetComponent<PlayerAnimation>().ballStage = false;
        player.GetComponent<PlayerAnimation>().horseStage = false;
        player.GetComponent<PlayerAnimation>().swingStage = false;
        player.GetComponent<PlayerAnimation>().UpdateAnim();

        player.GetComponent<jump>().hasBall = false;
        player.GetComponent<jump>().ballTimer = 0;

        rope.SetActive(false);
    }

    IEnumerator RopeAnim()
    {
        rope.GetComponent<Animator>().SetTrigger("RopeOut");
        yield return new WaitForSeconds(0.3f);
        rope.SetActive(false);
    }
}
