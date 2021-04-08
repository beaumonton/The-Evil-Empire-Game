
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float timeSlowMultiplier = 2f;
    public float slowAmt = 0.1f;

    private float timeUntilCool;

    private void Update()
    {
        if (Input.GetMouseButton(1) && SlowTimeBar.instance.getCurrentSlowAmt() > 1f)
        {
            SlowTime();
            SlowTimeBar.instance.UseSlow(slowAmt);
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
