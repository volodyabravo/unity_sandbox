using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightIntensityController : MonoBehaviour
{
    
    public float minIntensity = 1;
    public float maxIntensity = 2;

    public float minTimechage = 10;
    public float maxTimechage = 10;

    private float defaultIntensity;

    private Light lightComponent;
    private float intensity = 0;
    private float time = 0;



    private GameObject player;

    void Start()
    {
       lightComponent = GetComponent<Light>();
       defaultIntensity = lightComponent.intensity;
       StartCoroutine(LightControl());

       player = GameObject.Find("Player");
    }

    void Update()
    {
        lightComponent.intensity = Mathf.PingPong(time, intensity);
    }

    IEnumerator LightControl()
    {
        while (true) {

            yield return new WaitForSeconds(time);

            time = Random.Range(minTimechage, maxTimechage);
            intensity = Random.Range(minIntensity, maxTimechage);
            
            Debug.Log((this.transform.position));
            if ((player.transform.position-this.transform.position).sqrMagnitude<5*5) {
                PlayerStats stats = player.GetComponent(typeof(PlayerStats)) as PlayerStats;
                stats.DealDamage();
            }
        }
    }
}
