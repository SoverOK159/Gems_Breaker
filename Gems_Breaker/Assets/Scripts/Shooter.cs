using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    StageManager _stageManager;
    PlayerManager _playerManager;

    [SerializeField] GameObject shootButton;

    [Header("Rotation")]
    [SerializeField] GameObject shooter;
    [SerializeField] float maxAngle = 0.6f;
    [SerializeField] float minAngle = -0.6f;
    [SerializeField] float smooth = 5f;

    [Header("Shooting")]
    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform shootPoint;

    private void Start()
    {

        _stageManager = FindObjectOfType<StageManager>();
        _playerManager = FindObjectOfType<PlayerManager>();
        shooter = GameObject.FindGameObjectWithTag("Shooter");
        shootPoint = GameObject.FindGameObjectWithTag("Shooter").transform;
    }

    private void Update()
    {
        Rotate();
    }

    public void Rotate()
    {
        RotateLeft();
        RotateRight();
    }
    void RotateLeft()
    {
        float inputHorizontal = SimpleInput.GetAxis("Horizontal") * smooth * Time.deltaTime;
        if (inputHorizontal < 0)
        {
            if (shooter.transform.rotation.z >= minAngle)
            {
                shooter.transform.Rotate(0, 0, inputHorizontal);
            }
            else
            {
                Debug.Log("Stop Left");
                return;
            }
        }

    }
    void RotateRight()
    {
        float inputHorizontal = SimpleInput.GetAxis("Horizontal") * smooth * Time.deltaTime; ;
        if (inputHorizontal > 0)
        {

            if (shooter.transform.rotation.z <= maxAngle)
            {
                shooter.transform.Rotate(0, 0, inputHorizontal);
            }
            else
            {
                Debug.Log("Stop Right");
                return;
            }
        }
    }
    public void ShootBall()
    {
        if(_playerManager.TriesCount > 0)
        {
            if (GameObject.FindGameObjectWithTag("Ball") == null)
            {
                _playerManager.TriesCount--;
                GameObject ball = Instantiate(ballPrefab, shootPoint.position, shootPoint.rotation);
                Rigidbody2D rigidbody2D = ball.GetComponent<Rigidbody2D>();
                rigidbody2D.AddForce(-shootPoint.up * FindObjectOfType<Ball>().Speed, ForceMode2D.Impulse);
                _stageManager.SetPlayerTries(_playerManager.TriesCount);
            }
            else
            {
                Debug.Log("Ball already exist");
                return;
            }
        }
        else
        {
            Debug.Log("No more tries");
            return;
        }
        
    }
}
