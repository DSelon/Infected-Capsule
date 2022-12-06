using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private Capsule capsule;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) capsule.Jump();
    }

    private void FixedUpdate()
    {
        capsule.Move(Input.GetAxis("Horizontal"));
    }
}
