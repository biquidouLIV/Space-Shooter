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
    

    [SerializeField] float fireDelay = 5f;
    float lastShotTime;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lastShotTime = -fireDelay;
    }

    void Update()
    {
        //mouvement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        direction.Normalize();
        GetComponent<Rigidbody>().linearVelocity = direction * speed;

        //rotation
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0, 0, -horizontalInput*tilt);

        //bordures
        float positionX = transform.position.x;
        float positionZ = transform.position.z;

        positionX = Mathf.Clamp(positionX, xLimitLeft, xLimitRight);
        positionZ = Mathf.Clamp(positionZ, zLimitDown, zLimitUp);

        Vector3 newPosition = new Vector3(positionX, 0, positionZ);
        transform.position = newPosition;

        //tir
        if (Input.GetMouseButtonDown(0) && ((Time.time - fireDelay) > lastShotTime))
        {
            Instantiate(laserPrefab, LaserSpawn.transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            lastShotTime = Time.time;
        }
        
        Shield();
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