using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    [SerializeField] private float health; // ü��
    [SerializeField] private float moveSpeed; // �̵� �ӵ�
    [SerializeField] private float jumpPower; // ������
    [SerializeField] private float jumpDelayTime; // ���� ���� �ð�

    private float maxHealth; // �ִ� ü��
    private float currentHealth; // ���� ü��
    private float maxMoveSpeed; // �ִ� �̵� �ӵ�
    private float currentMoveSpeed; // ���� �̵� �ӵ�
    private float maxJumpPower; // �ִ� ������
    private float currentJumpPower; // ���� ������
    private float maxJumpDelayTime; // �ִ� ���� ���� �ð�
    private float currentJumpDelayTime; // ���� ���� ���� �ð�

    #region

    // ü��
    public float GetHealth()
    {
        return this.health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }



    // �̵� �ӵ�
    public float GetMoveSpeed()
    {
        return this.moveSpeed;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }



    // ������
    public float GetJumpPower()
    {
        return this.jumpPower;
    }

    public void SetJumpPower(float jumpPower)
    {
        this.jumpPower = jumpPower;
    }



    // ���� ���� �ð�
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

    // �ִ� ü��
    public float GetMaxHealth()
    {
        return this.maxHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    // ���� ü��
    public float GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public void SetCurrentHealth(float currentHealth)
    {
        this.currentHealth = currentHealth;
    }



    // �ִ� �̵� �ӵ�
    public float GetMaxMoveSpeed()
    {
        return this.maxMoveSpeed;
    }

    public void SetMaxMoveSpeed(float maxMoveSpeed)
    {
        this.maxMoveSpeed = maxMoveSpeed;
    }

    // ���� �̵� �ӵ�
    public float GetCurrentMoveSpeed()
    {
        return this.currentMoveSpeed;
    }

    public void SetCurrentMoveSpeed(float currentMoveSpeed)
    {
        this.currentMoveSpeed = currentMoveSpeed;
    }



    // �ִ� ������
    public float GetMaxJumpPower()
    {
        return this.maxJumpPower;
    }

    public void SetMaxJumpPower(float maxJumpPower)
    {
        this.maxJumpPower = maxJumpPower;
    }

    // ���� ������
    public float GetCurrentJumpPower()
    {
        return this.currentJumpPower;
    }

    public void SetCurrentJumpPower(float currentJumpPower)
    {
        this.currentJumpPower = currentJumpPower;
    }



    // �ִ� ���� ���� �ð�
    public float GetMaxJumpDelayTime()
    {
        return this.maxJumpDelayTime;
    }

    public void SetMaxJumpDelayTime(float maxJumpDelayTime)
    {
        this.maxJumpDelayTime = maxJumpDelayTime;
    }

    // ���� ���� ���� �ð�
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



    // �̵�
    public void Move(float horizontalAxis)
    {
        Vector3 moveDistance = Vector3.right * horizontalAxis * moveSpeed * Time.deltaTime;

        if (horizontalAxis < 0) transform.eulerAngles = new Vector3(0, 0, 0);
        else if (horizontalAxis > 0) transform.eulerAngles = new Vector3(0, 180, 0);

        this.GetComponent<Rigidbody>().MovePosition(this.GetComponent<Rigidbody>().position + moveDistance);
    }



    // ����
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
