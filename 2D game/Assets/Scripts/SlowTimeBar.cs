using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlowTimeBar : MonoBehaviour
{
    public Slider slowBar;

    private float maxSlow = 100f;
    private float currentSlow;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static SlowTimeBar instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSlow = maxSlow;
        slowBar.maxValue = maxSlow;
        slowBar.value = maxSlow;
    }

    public float getCurrentSlowAmt()
    {
        return currentSlow;
    }

    public void UseSlow(float amount)
    {
        if(currentSlow - amount >= 0)
        {
            currentSlow -= amount;
            slowBar.value = currentSlow;

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenSlow());
        }
        else
        {
            Debug.Log("Not enoguh Slow Time Energy");
        }
    }

    private IEnumerator RegenSlow()
    {
        yield return new WaitForSeconds(2);

        while(currentSlow < maxSlow)
        {
            currentSlow += maxSlow / 100;
            slowBar.value = currentSlow;
            yield return regenTick;
        }
        regen = null;
    }
}
