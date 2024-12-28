using System;
using TMPro;
using UnityEngine;

public class WheelFortune : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TMP_Text _rewardText;

    public float RotatePower;
    public float StopPower;

    private Rigidbody2D rbody;
    int inRotate;

    private void OnEnable()
    {
        _rewardText.gameObject.SetActive(false);
    }

    private void Start()
    {
        _rewardText.gameObject.SetActive(false);
        rbody = GetComponent<Rigidbody2D>();
    }

    float t;

    private void Update()
    {
        if (rbody.angularVelocity > 0)
        {
            rbody.angularVelocity -= StopPower * Time.deltaTime;

            rbody.angularVelocity = Mathf.Clamp(rbody.angularVelocity, 0, 1440);
        }

        if (rbody.angularVelocity == 0 && inRotate == 1)
        {
            t += 1 * Time.deltaTime;
            if (t >= 0.5f)
            {
                GetReward();

                inRotate = 0;
                t = 0;
            }
        }
    }

    public void Rotete()
    {
        if (inRotate == 0)
        {
            rbody.AddTorque(RotatePower);
            inRotate = 1;
        }
    }

    public void GetReward()
    {
        float rot = transform.eulerAngles.z;
        Debug.Log("GetReward " + rot);

        if (rot > 0 && rot <= 45)
        {
            Win(1000);
        }
        else if (rot > 45 && rot <= 90)
        {
            Win(100);
        }
        else if (rot > 90 && rot <= 135)
        {
            Win(20);
        }
        else if (rot > 135 && rot <= 180)
        {
            // GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,105);
            Win(10);
        }
        else if (rot > 180 && rot <= 225)
        {
            // GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,135);
            Win(200);
        }
        else if (rot > 225 && rot <= 270)
        {
            // GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,165);
            Win(30);
        }
        else if (rot > 270 && rot <= 315)
        {
            // GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,195);
            Win(50);
        }
        else if (rot > 315 && rot <= 360)
        {
            // GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,225);
            Win(300);
        }
    }

    private void Win(int Score)
    {
        _rewardText.text = $"+ {Score}\nBONUSES";
        _rewardText.gameObject.SetActive(true);
        _wallet.Increase(Score);
        print(Score);
    }
}