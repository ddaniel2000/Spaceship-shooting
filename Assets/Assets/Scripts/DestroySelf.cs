using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float _delaytime;

    // Start is called before the first frame update
    void Start()
    {
        DestroySelfWithdelay(_delaytime);
    }
   


    private void DestroySelfWithdelay(float delay)
    {
        Destroy(gameObject, delay);
    }
}
