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
            fire.obstacle1 = 15; fire.obstacle2 = 4;
            fire.distance1min = 9; fire.distance1max = 12;
            fire.distance2min = 19; fire.distance2max = 22;

            monkey.obstacle1 = 15; monkey.obstacle2 = 4;
            monkey.distance1min = 9; monkey.distance1max = 12;
            monkey.distance2min = 39; monkey.distance2max = 42;
        }
        if (wavesSurvived > 10)
        {
            fire.obstacle1 = 20; fire.obstacle2 = 5;
            fire.distance1min = 7; fire.distance1max = 13;
            fire.distance2min = 17; fire.distance2max = 23;

            monkey.obstacle1 = 20; monkey.obstacle2 = 5;
            monkey.distance1min = 7; monkey.distance1max = 13;
            monkey.distance2min = 37; monkey.distance2max = 43;
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
    }
}
