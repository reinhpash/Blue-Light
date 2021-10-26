using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleRepulsors : MonoBehaviour
{
    public ParticleSystem[] repulsors;
    //0,1 Back S
    //2,3,4 Front w
    //1,3 Right side a
    //2,0
    [SerializeField] private int enginePower = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            HandleRepulsorEmit(2, enginePower);
            HandleRepulsorEmit(3, enginePower);
            HandleRepulsorEmit(4, enginePower);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            HandleRepulsorEmit(0, enginePower);
            HandleRepulsorEmit(1, enginePower);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            HandleRepulsorEmit(1, enginePower);
            HandleRepulsorEmit(3, enginePower);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            HandleRepulsorEmit(2, enginePower);
            HandleRepulsorEmit(0, enginePower);
        }
    }

    void HandleRepulsorEmit(int repulsorIndex, int emitValue)
    {
        repulsors[repulsorIndex].Emit(emitValue);
    }
}
