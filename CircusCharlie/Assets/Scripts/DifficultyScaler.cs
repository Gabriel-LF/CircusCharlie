using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour
{
    public static DifficultyScaler Instance;
    public int wavesSurvived;

    public FireStage fire;
    public MonkeyStage monkey;
    public HorseStage horse;
    public BallStage ball;
    public SwingStage swing;

    public AudioSource audios;
    public AudioClip wave;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Reset();
    }

    public void LevelUp()
    {
        wavesSurvived++;

        if(wavesSurvived > 5 && wavesSurvived < 11)
        {
            if(wavesSurvived == 6)
            {
                audios.clip = wave;
                audios.Play();
            }          

            fire.obstacle1 = 15; fire.obstacle2 = 4;
            fire.distance1min = 9; fire.distance1max = 12;
            fire.distance2min = 19; fire.distance2max = 22;

            monkey.obstacle1 = 15; monkey.obstacle2 = 4;
            monkey.distance1min = 9; monkey.distance1max = 12;
            monkey.distance2min = 39; monkey.distance2max = 42;

            horse.obstacle = 15;
            horse.distancemin = 9; horse.distancemax = 12;

            ball.obstacle = 4;
            ball.distancemin = 29; ball.distancemax = 32;

            swing.obstacle = 4;
            swing.distancemin = swing.begin; swing.distancemax = swing.begin + 1;
        }
        if (wavesSurvived > 10)
        {
            if (wavesSurvived == 11)
            {
                audios.clip = wave;
                audios.Play();
            }

            fire.obstacle1 = 20; fire.obstacle2 = 5;
            fire.distance1min = 7; fire.distance1max = 13;
            fire.distance2min = 17; fire.distance2max = 23;

            monkey.obstacle1 = 20; monkey.obstacle2 = 5;
            monkey.distance1min = 7; monkey.distance1max = 13;
            monkey.distance2min = 37; monkey.distance2max = 43;

            horse.obstacle = 20;
            horse.distancemin = 7; horse.distancemax = 13;

            ball.obstacle = 5;
            ball.distancemin = 27; ball.distancemax = 33;

            swing.obstacle = 5;
            swing.distancemin = swing.begin; swing.distancemax = swing.begin + 1;
        }
    }

    public void Reset()
    {
        wavesSurvived = 0;
        fire.obstacle1 = fire.circlesToSpawn; fire.obstacle2 = fire.jarsToSpawn;
        fire.distance1min = fire.begin1; fire.distance1max = fire.begin1 + 1;
        fire.distance2min = fire.begin2; fire.distance2max = fire.begin2 + 1;

        monkey.obstacle1 = monkey.monkeysToSpawn; monkey.obstacle2 = monkey.bluesToSpawn;
        monkey.distance1min = monkey.begin1; monkey.distance1max = monkey.begin1 + 1;
        monkey.distance2min = monkey.begin2; monkey.distance2max = monkey.begin2 + 1;

        horse.obstacle = horse.jumpsToSpawn;
        horse.distancemin = horse.begin; horse.distancemax = horse.begin + 1;

        ball.obstacle = ball.ballsToSpawn;
        ball.distancemin = ball.begin; ball.distancemax = ball.begin + 1;

        swing.obstacle = swing.swingsToSpawn;
        swing.distancemin = swing.begin; swing.distancemax = swing.begin + 1;
    }
}
