using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public EnemyController enemy;
    
    public GameObject[] gameObjects;
    private float[] coordsX = new float[5] {
        -7.66f, -21.64f, 15.12f, 3.91f, -17.86f
    };
    private float[] coordsY = new float[5] {
        -76.42f, -46.12f, -72.28f, -72.18f, -73.39f
    };


    void Start()
    {
        
        for (int i = 0; i < 5; i++)
        { 
            Instantiate(gameObjects[0], new Vector2(coordsX[i], coordsY[i]), Quaternion.identity);
            /*
            enemy.speed = Random.Range(5, 10);
            enemy.stoppingDistance = Random.Range(6, 10);
            enemy.retreatDistance = Random.Range(3, 7);
            */
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
