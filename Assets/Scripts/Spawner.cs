using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private Cube _cube;
    [SerializeField] Transform _parent;
    [SerializeField]private float _refireSpawn = 0.1f;
    private Pool<Cube> pool;
    private float spawnTimer = 0f;

    public Pool<Cube> Pool => pool;
    public float RefierSpawn
    {
        get=> _refireSpawn;
        set=> _refireSpawn = value;
    }
    

    
    

    private void Start()
    {
        pool = new Pool<Cube>(_cube,_poolCount, _parent);
    }
    private void Update()
    {
       
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= RefierSpawn)
            {
                spawnTimer = 0;
                CreateCube();
            }
        
    }
    private void CreateCube()
    {
        var cube = pool.GetFreElement();
        cube.transform.position = transform.position;
    }
}
