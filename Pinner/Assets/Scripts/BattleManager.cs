using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    private WaitForFixedUpdate wffu;
    private WaitForSeconds waitFor;
    private float rotateSpeed = 90f;
    private float playerPower = 1f;
    private bool enterRotation = false;
    private bool enterSpeed = false;
    private bool coroRunning = false;
    public float waitTime = 3f;
    public float increase = 2f;
    public Slider powerBar;
    public GameObject arrowObject;
    public GameObject playerObject;
    public Rigidbody playerRB;
    public BoolData enemyTurn;

    private void Start()
    {
        waitFor = new WaitForSeconds(waitTime);
    }

    void Update()
    {
        if (enemyTurn.value == false)
        {
            if (!enterRotation && !coroRunning)
            {
                RotatePlayer();
            }
            else if (enterRotation && !coroRunning)
            {
                if (!enterSpeed && !coroRunning)
                {
                    StartCoroutine(PowerPlayer());
                }
                else if (enterSpeed && !coroRunning)
                {
                    StartCoroutine(LaunchPlayer());
                }
            }
        }
    }

    void RotatePlayer()
    {
        coroRunning = true;
        var hInput = Input.GetAxis("Horizontal") * Time.deltaTime*rotateSpeed;
        transform.Rotate(0,-hInput,0);
        if (Input.GetButtonDown("Jump"))
        {
            enterRotation = true;
        }
        coroRunning = false;
    }

    IEnumerator PowerPlayer()
    {
        coroRunning = true;
        if (playerPower < 2000f)
        {
            while (playerPower < 2000f)
            {
                playerPower += increase;
                powerBar.value = playerPower;
                if (Input.GetButtonDown("Jump"))
                {
                    enterSpeed = true;
                    break;
                }
                yield return wffu;
            }
        }
        
        else if (playerPower >= 2000f)
        {
            while (playerPower > 1f)
            {
                playerPower -= increase;
                powerBar.value = playerPower;
                if (Input.GetButtonDown("Jump"))
                {
                    enterSpeed = true;
                    break;
                }
                yield return wffu;
            }
        }
        powerBar.value = playerPower;
        coroRunning = false;
    }

    IEnumerator LaunchPlayer()
    {
        coroRunning = true;
        playerObject.transform.parent = null;
        playerRB.constraints = RigidbodyConstraints.None;
        playerRB.useGravity = true;
        playerRB.AddRelativeForce(Vector3.forward * playerPower);
        yield return waitFor;
        playerRB.useGravity = false;
        playerRB.velocity = new Vector3(0,0,0);
        playerRB.constraints = RigidbodyConstraints.FreezeAll;
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        playerObject.transform.parent = gameObject.transform;
        playerObject.transform.position = new Vector3(0, 0.6f, -10);
        playerObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        arrowObject.transform.position = new Vector3(0, 0.5f, -8);
        arrowObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        yield return wffu;
        playerPower = 1f;
        coroRunning = false;
        enterRotation = false;
        enterSpeed = false;
        powerBar.value = playerPower;
        enemyTurn.value = true;
    }
}