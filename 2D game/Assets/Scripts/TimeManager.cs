
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeSlowMultiplier = 2f;
    public float slowCooldown = 5f;

    private float timeUntilCool;

    private void Update()
    {
        if (Input.GetMouseButton(1)) //&& timeUntilCool < Time.time)
        {
            SlowTime();
            //timeUntilCool = Time.time + slowCooldown;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void SlowTime()
    {
        Time.timeScale = 1 / timeSlowMultiplier;
    }
}
