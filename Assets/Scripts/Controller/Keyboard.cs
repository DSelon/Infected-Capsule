using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    [SerializeField] private Capsule capsule;
    [SerializeField] private Gun gun;

    private void Update()
    {
        // 점프
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) capsule.Jump();

        // 발사
        if (Input.GetKey(KeyCode.Z)) gun.Shoot();

        // 장전
        if (Input.GetKeyDown(KeyCode.X)) gun.Reload();
    }

    private void FixedUpdate()
    {
        // 이동
        capsule.Move(Input.GetAxis("Horizontal"));
    }
}
