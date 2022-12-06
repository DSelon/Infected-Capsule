using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float health; // 체력
    [SerializeField] private float moveSpeed; // 이동 속도
    [SerializeField] private float jumpPower; // 점프력
    [SerializeField] private float jumpDelayTime; // 점프 지연 시간

    private float maxHealth; // 최대 체력
    private float currentHealth; // 현재 체력
    private float maxMoveSpeed; // 최대 이동 속도
    private float currentMoveSpeed; // 현재 이동 속도
    private float maxJumpPower; // 최대 점프력
    private float currentJumpPower; // 현재 점프력
    private float maxJumpDelayTime; // 최대 점프 지연 시간
    private float currentJumpDelayTime; // 현재 점프 지연 시간

    #region

    // 체력
    public float GetHealth()
    {
        return this.health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }



    // 이동 속도
    public float GetMoveSpeed()
    {
        return this.moveSpeed;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }



    // 점프력
    public float GetJumpPower()
    {
        return this.jumpPower;
    }

    public void SetJumpPower(float jumpPower)
    {
        this.jumpPower = jumpPower;
    }



    // 점프 지연 시간
    public float GetJumpDelayTime()
    {
        return this.jumpDelayTime;
    }

    public void SetJumpDelayTime(float jumpDelayTime)
    {
        this.jumpDelayTime = jumpDelayTime;
    }

    #endregion

    #region

    // 최대 체력
    public float GetMaxHealth()
    {
        return this.maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    // 현재 체력
    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public void SetCurrentHealth(float currentHealth)
    {
        this.currentHealth = currentHealth;
    }



    // 최대 이동 속도
    public float GetMaxMoveSpeed()
    {
        return this.maxMoveSpeed;
    }

    public void SetMaxMoveSpeed(float maxMoveSpeed)
    {
        this.maxMoveSpeed = maxMoveSpeed;
    }

    // 현재 이동 속도
    public float GetCurrentMoveSpeed()
    {
        return this.currentMoveSpeed;
    }

    public void SetCurrentMoveSpeed(float currentMoveSpeed)
    {
        this.currentMoveSpeed = currentMoveSpeed;
    }



    // 최대 점프력
    public float GetMaxJumpPower()
    {
        return this.maxJumpPower;
    }

    public void SetMaxJumpPower(float maxJumpPower)
    {
        this.maxJumpPower = maxJumpPower;
    }

    // 현재 점프력
    public float GetCurrentJumpPower()
    {
        return this.currentJumpPower;
    }

    public void SetCurrentJumpPower(float currentJumpPower)
    {
        this.currentJumpPower = currentJumpPower;
    }



    // 최대 점프 지연 시간
    public float GetMaxJumpDelayTime()
    {
        return this.maxJumpDelayTime;
    }

    public void SetMaxJumpDelayTime(float maxJumpDelayTime)
    {
        this.maxJumpDelayTime = maxJumpDelayTime;
    }

    // 현재 점프 지연 시간
    public float GetCurrentJumpDelayTime()
    {
        return this.currentJumpDelayTime;
    }

    public void SetCurrentJumpDelayTime(float currentJumpDelayTime)
    {
        this.currentJumpDelayTime = currentJumpDelayTime;
    }

    #endregion



    private void Start()
    {
        maxHealth = health;
        currentHealth = health;
        maxMoveSpeed = moveSpeed;
        currentMoveSpeed = moveSpeed;
        maxJumpPower = jumpPower;
        currentJumpPower = jumpPower;
        maxJumpDelayTime = jumpDelayTime;
        currentJumpDelayTime = 0;
    }



    private void Update()
    {
        currentJumpDelayTime -= Time.deltaTime;
    }



    // 이동
    public void Move(float horizontalAxis)
    {
        Vector3 moveDistance = Vector3.right * horizontalAxis * moveSpeed * Time.deltaTime;

        if (horizontalAxis < 0) transform.eulerAngles = new Vector3(0, 0, 0);
        else if (horizontalAxis > 0) transform.eulerAngles = new Vector3(0, 180, 0);

        this.GetComponent<Rigidbody>().MovePosition(this.GetComponent<Rigidbody>().position + moveDistance);
    }



    // 점프
    public void Jump()
    {
        float detectRange = 1.3f;

        if (currentJumpDelayTime <= 0)
        {
            if (!Physics.Raycast(transform.position, Vector3.down, detectRange)) return;

            currentJumpDelayTime = maxJumpDelayTime;

            this.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpPower);
        }
    }
}
