using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private Capsule capsule;
    [SerializeField] private Gun gun;

    private void Update()
    {
        // ����
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) capsule.Jump();

        // �߻�
        if (Input.GetKey(KeyCode.Z)) gun.Shoot();

        // ����
        if (Input.GetKeyDown(KeyCode.X)) gun.Reload();
    }

    private void FixedUpdate()
    {
        // �̵�
        capsule.Move(Input.GetAxis("Horizontal"));
    }
}
