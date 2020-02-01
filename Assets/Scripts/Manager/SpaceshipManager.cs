using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{

    public GameObject spaceship;
    [SerializeField] SpaceshipData BigSpaceship;
    [SerializeField] SpaceshipData MidSpaceship;
    [SerializeField] SpaceshipData LittleSpaceship;
    public SpaceshipComponent spaceshipComp;

    float timeLeft = 5f;
    int random;

    // Start is called before the first frame update
    void Awake()
    {
        spaceshipComp = spaceship.GetComponent<SpaceshipComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0 )
        {
            RandomSpaceship();
            timeLeft = 5f;
        }        
    }

    void RandomSpaceship()
    {
        random = Random.Range(1, 3);
        if(random == 3) spaceshipComp.SetData(BigSpaceship);
        else if(random == 2) spaceshipComp.SetData(MidSpaceship);
        else spaceshipComp.SetData(LittleSpaceship);
    }
}
