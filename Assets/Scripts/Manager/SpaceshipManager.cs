using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{

    public GameObject spaceship;
    [SerializeField] SpaceshipData BigSpaceship;
    [SerializeField] SpaceshipData MidSpaceship;
    [SerializeField] SpaceshipData LittleSpaceship;
    private SpaceshipComponent spaceshipComp;

    public float spaceshipTimer = 5f;
    float originalTimer;
    int random;

    // Start is called before the first frame update
    void Awake()
    {
        originalTimer = spaceshipTimer;
        spaceshipComp = spaceship.GetComponent<SpaceshipComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Timer for each spaceship
        spaceshipTimer -= Time.deltaTime;
        if ( spaceshipTimer < 0 )
        {
            RandomSpaceship();
            spaceshipTimer = originalTimer;
        }        
    }

    void RandomSpaceship()
    {
        random = Random.Range(0, 2);
        if(random == 1) {
            spaceshipComp.SetData(BigSpaceship);
            //Debug.Log("BigSpaceship");
        }
        //else if(random == 2) spaceshipComp.SetData(MidSpaceship);
        else {
            spaceshipComp.SetData(LittleSpaceship);
            //Debug.Log("LittleSpaceship");
        }
    }
}
