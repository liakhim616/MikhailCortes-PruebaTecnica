using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 rbVector;

    public float accel, maxSpd, steerStr;
    private float speedInput;
    private float turnInput;

    public bool onJump;
    public bool onHazz;
    public bool passCP1;
    public bool passCP2;
    public bool lapDone;

    private float rndX;
    private float rndY;
    private float rndZ;

    private int lapseTime;
    private int bestTime;
    public TextMeshProUGUI bestTimeTxt;
    private int timeRemaining = 30;
    public TextMeshProUGUI countdown;

    public int completedLaps;
    public TextMeshProUGUI lapsTxt;

    public GameObject defeatPanel;

    public GameObject flame1;
    public GameObject flame2;

    public int currentShip;
    public GameObject myCurrentShip;
    public GameObject rocket;
    public GameObject ship;
    public GameObject ufo;
    public GameObject shipCarrier;

    public AudioSource sndBoost;
    public AudioSource sndHazz;
    public AudioSource sndJump;
    public AudioSource sndTime;
    public AudioSource sndLamp;

    void Start()
    {
        currentShip = PlayerPrefs.GetInt("cShip", 0);

        if (currentShip == 0)
        {
            myCurrentShip = Instantiate(rocket, transform.position, Quaternion.identity);
            myCurrentShip.transform.parent = shipCarrier.transform;
            myCurrentShip.transform.localPosition = new Vector3(0, 0, 0);
            myCurrentShip.transform.localRotation = Quaternion.Euler(270, 0, 0);
        }
        else if (currentShip == 1)
        {
            myCurrentShip = Instantiate(ship, transform.position, Quaternion.identity);
            myCurrentShip.transform.parent = shipCarrier.transform;
            myCurrentShip.transform.localPosition = new Vector3(0, 0, 0);
            myCurrentShip.transform.localRotation = Quaternion.Euler(270, 0, 0);
        }
        else if (currentShip == 2)
        {
            myCurrentShip = Instantiate(ufo, transform.position, Quaternion.identity);
            myCurrentShip.transform.parent = shipCarrier.transform;
            myCurrentShip.transform.localPosition = new Vector3(0, 0, 0);
            myCurrentShip.transform.localRotation = Quaternion.Euler(270, 0, 0);
        }


        bestTime = PlayerPrefs.GetInt("BestTime", 99);
        bestTimeTxt.text = bestTime.ToString();
        completedLaps = PlayerPrefs.GetInt("Laps", 0);
        lapsTxt.text = completedLaps.ToString();
        PlayerPrefs.SetInt("fromScene", 2);
        rb.transform.parent = null;
        StartCoroutine(Countdown());
        StartCoroutine(Timer());
    }

    
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            speedInput = Input.GetAxis("Vertical");
            flame1.SetActive(true);
        }

        else
        {
            flame1.SetActive(false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            steerStr = 120;
        }

        if (Input.GetButtonUp("Jump"))
        {
            steerStr = 40;
        }

        turnInput = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * steerStr * Time.deltaTime, 0f));

        rbVector = rb.transform.position;
        transform.position = new Vector3(rbVector.x, rbVector.y - 0.5f, rbVector.z);
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * accel * speedInput);

        if (onJump)
        {
            rb.AddForce(transform.up * 160);
        }

        if (onHazz)
        {
            rb.AddForce(rndX, rndY, rndZ);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpdBoost")
        {
            sndBoost.Play();
            StopCoroutine("SpeedBoost");
            StartCoroutine("SpeedBoost");
        }

        if (other.tag == "JumpPlatform")
        {
            sndJump.Play();
            StartCoroutine(Jumping());
        }

        if (other.tag == "Hazz")
        {
            sndHazz.Play();
            StartCoroutine(Hazzard());
            rndX = Random.Range(-500.0f, 500.0f);
            rndY = Random.Range(-500.0f, 500.0f);
            rndZ = Random.Range(-500.0f, 500.0f);
        }

        if (other.tag == "CP1")
        {
            if (!passCP1)
            {
                sndTime.Play();
                timeRemaining += 15;
                passCP1 = true;
            }
        }

        if (other.tag == "CP2")
        {
            if (!passCP2)
            {
                sndTime.Play();
                timeRemaining += 15;
                passCP2 = true;
            }
        }

        if (other.tag == "FL")
        {
            if (passCP2 && passCP1)
            {
                sndLamp.Play();
                completedLaps += 1;
                PlayerPrefs.SetInt("Laps", completedLaps);
                lapsTxt.text = completedLaps.ToString();
                timeRemaining = 30;
                passCP1 = false;
                passCP2 = false;
                lapDone = true;
            }
        }

        if (other.tag == "Abyss")
        {
            Defeat();
        }
    }

    private IEnumerator SpeedBoost()
    {
        accel = 180;
        flame2.SetActive(true);
        yield return new WaitForSeconds(2f);
        accel = 120;
        flame2.SetActive(false);
    }

    private IEnumerator Jumping()
    {
        onJump = true;
        yield return new WaitForSeconds(0.3f);
        onJump = false;
    }

    private IEnumerator Hazzard()
    {
        onHazz = true;
        yield return new WaitForSeconds(0.3f);
        onHazz = false;
    }

    public IEnumerator Countdown()
    {
        while (true)
        {
            timeRemaining -= 1;
            countdown.text = timeRemaining.ToString();
            yield return new WaitForSeconds(1f);
            if (timeRemaining < 1)
            {
                Defeat();
                break;
            }
        }
    }

    public IEnumerator Timer()
    {
        while (true)
        {
            lapseTime += 1;
            yield return new WaitForSeconds(1f);
            if (lapDone)
            {
                if (lapseTime < bestTime)
                {
                    PlayerPrefs.SetInt("BestTime", lapseTime);
                    bestTime = lapseTime;
                    bestTimeTxt.text = lapseTime.ToString();
                }
                lapseTime = 0;
                lapDone = false;
            }
        }
    }

    private void Defeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LaunchMenu()
    {
        SceneManager.LoadScene(1);
    }
}
