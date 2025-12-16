using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    static public PlayerController instance;

    public bool isShieldActive = false;
    
    float horizontalInput;
    float verticalInput;
    
    [SerializeField] float speed = 5f;
    [SerializeField] float tilt = 20f;
    [SerializeField] float xLimitLeft;
    [SerializeField] float xLimitRight;
    [SerializeField] float zLimitUp;
    [SerializeField] float zLimitDown;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] GameObject LaserSpawn;
    [SerializeField] GameObject shield;
    [SerializeField] GameObject nukeZone;
    

    [SerializeField] float fireDelay = 5f;
    [SerializeField] private float specialShotDelay = 10f;
    float lastShotTime;
    float specialShotLastTime;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lastShotTime = -fireDelay;
        specialShotLastTime = -specialShotDelay;
    }

    void Update()
    {
        Move();
        Shoot();
        Shield();
    }

    void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction.Normalize();
        GetComponent<Rigidbody>().linearVelocity = direction * speed;
        
        float positionX = transform.position.x;
        float positionZ = transform.position.z;
        
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, -horizontalInput*tilt);

        positionX = Mathf.Clamp(positionX, xLimitLeft, xLimitRight);
        positionZ = Mathf.Clamp(positionZ, zLimitDown, zLimitUp);

        Vector3 newPosition = new Vector3(positionX, 0, positionZ);
        transform.position = newPosition;
    }


    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && ((Time.time - fireDelay) > lastShotTime))
        {
            Instantiate(laserPrefab, LaserSpawn.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            lastShotTime = Time.time;
        }

        if (Input.GetKey(KeyCode.Space) && ((Time.time - specialShotDelay) > specialShotLastTime))
        {
            Instantiate(nukeZone, transform.position, Quaternion.identity);
            specialShotLastTime = Time.time;
        } 
    }
    
    private void Shield()
    {
        if (isShieldActive)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
        
    }
}