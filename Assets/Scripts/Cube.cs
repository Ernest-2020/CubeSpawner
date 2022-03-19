using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]  private float _distance;
    private Vector3 startPosition;

    public float Speed
    {
        get => _speed;
        set => _speed = value;  
    }
    public float Distance
    {
        get => _distance;
        set => _distance = value;
    }



    private void OnEnable()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        Move();
        CheckDistance();
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
    private void CheckDistance()
    {
        if (Vector3.Distance(startPosition, transform.position) >= Distance)
        {
            gameObject.SetActive(false);
            transform.position = startPosition;
        }
    }
}
