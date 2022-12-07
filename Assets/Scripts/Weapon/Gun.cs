using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum ActionState { Idle = 0, Shoot = 2, Reload = 3 }

    [Header("Shooting")]
    [SerializeField] protected float damage; // ���ݷ�
    [SerializeField] protected float betweenShotsDelayTime; // ���� ���� �ð�
    [SerializeField] protected int roundsPerClick; // ���� ��
    [SerializeField] protected int bulletsPerClick; // ��ź ��
    [SerializeField] protected float bulletSpeed; // ź��
    [SerializeField] protected float bulletSpread; // ź ����
    [SerializeField] protected float knockback; // �˹�

    [Header("Reload")]
    [SerializeField] protected int magazineSize; // źâ ũ��
    [SerializeField] protected float reloadTime; // ������ �ð�

    protected float maxDamage; // �ִ� ���ݷ�
    protected float currentDamage; // ���� ���ݷ�
    protected float maxBetweenShotsDelayTime; // �ִ� ���� ���� �ð�
    protected float currentBetweenShotsDelayTime; // ���� ���� ���� �ð�
    protected int maxRoundsPerClick; // �ִ� ���� ��
    protected int currentRoundsPerClick; // ���� ���� ��
    protected int maxBulletsPerClick; // �ִ� ��ź ��
    protected int currentBulletsPerClick; // ���� ��ź ��
    protected float maxBulletSpeed; // �ִ� ź��
    protected float currentBulletSpeed; // ���� ź��
    protected float maxBulletSpread; // �ִ� ź ����
    protected float currentBulletSpread; // ���� ź ����
    protected float maxKnockback; // �ִ� �˹�
    protected float currentKnockback; // ���� �˹�

    protected int maxMagazineSize; // �ִ� źâ ũ��
    protected int currentMagazineSize; // ���� źâ ũ��
    protected float maxReloadTime; // �ִ� ������ �ð�
    protected float currentReloadTime; // ���� ������ �ð�

    [Header("")]
    [SerializeField] protected GameObject VFX;
    [SerializeField] protected Transform barrelTransform;

    protected ActionState actionState;



    #region

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public float BetweenShostsDelayTime
    {
        get { return betweenShotsDelayTime; }
        set { betweenShotsDelayTime = value; }
    }

    public int RoundsPerClick
    {
        get { return roundsPerClick; }
        set { roundsPerClick = value; }
    }

    public int BulletsPerClick
    {
        get { return bulletsPerClick; }
        set { bulletsPerClick = value; }
    }

    public float BulletSpeed
    {
        get { return bulletSpeed; }
        set { bulletSpeed = value; }
    }

    public float BulletSpread
    {
        get { return bulletSpread; }
        set { bulletSpread = value; }
    }

    public float KnockBack
    {
        get { return knockback; }
        set { knockback = value; }
    }

    #endregion

    #region

    public int MagazineSize
    {
        get { return magazineSize; }
        set { magazineSize = value; }
    }

    public float ReloadTime
    {
        get { return reloadTime; }
        set { reloadTime = value; }
    }

    #endregion

    #region

    public float MaxDamage
    {
        get { return maxDamage; }
        set { maxDamage = value; }
    }

    public float CurrentDamage
    {
        get { return currentDamage; }
        set { currentDamage = value; }
    }

    public float MaxBetweenShotsDelayTime
    {
        get { return maxBetweenShotsDelayTime; }
        set { maxBetweenShotsDelayTime = value; }
    }

    public float CurrentBetweenShotsDelayTime
    {
        get { return currentBetweenShotsDelayTime; }
        set { currentBetweenShotsDelayTime = value; }
    }

    public int MaxRoundsPerClick
    {
        get { return maxRoundsPerClick; }
        set { maxRoundsPerClick = value; }
    }

    public int CurrentRoundsPerClick
    {
        get { return currentRoundsPerClick; }
        set { currentRoundsPerClick = value; }
    }

    public int MaxBulletsPerClick
    {
        get { return maxBulletsPerClick; }
        set { maxBulletsPerClick = value; }
    }

    public int CurrentBulletsPerClick
    {
        get { return currentBulletsPerClick; }
        set { currentBulletsPerClick = value; }
    }

    public float MaxBulletSpeed
    {
        get { return maxBulletSpeed; }
        set { maxBulletSpeed = value; }
    }

    public float CurrentBulletSpeed
    {
        get { return currentBulletSpeed; }
        set { currentBulletSpeed = value; }
    }

    public float MaxBulletSpread
    {
        get { return maxBulletSpread; }
        set { maxBulletSpread = value; }
    }

    public float CurrentBulletSpread
    {
        get { return currentBulletSpread; }
        set { currentBulletSpread = value; }
    }

    public float MaxKnockback
    {
        get { return maxKnockback; }
        set { maxKnockback = value; }
    }

    public float CurrentKnockback
    {
        get { return currentKnockback; }
        set { currentKnockback = value; }
    }

    #endregion

    #region

    public int MaxMagazineSize
    {
        get { return maxMagazineSize; }
        set { maxMagazineSize = value; }
    }

    public int CurrentMagazineSize
    {
        get { return currentMagazineSize; }
        set { currentMagazineSize = value; }
    }

    public float MaxReloadTime
    {
        get { return maxReloadTime; }
        set { maxReloadTime = value; }
    }

    public float CurrentReloadTime
    {
        get { return currentReloadTime; }
        set { currentReloadTime = value; }
    }

    #endregion



    protected virtual void Start()
    {
        // �ʵ� �ʱ�ȭ
        maxMagazineSize = magazineSize;
        currentMagazineSize = magazineSize;
        maxReloadTime = reloadTime;
        currentReloadTime = reloadTime;
        maxDamage = damage;
        currentDamage = damage;
        maxBetweenShotsDelayTime = betweenShotsDelayTime;
        currentBetweenShotsDelayTime = 0;
        maxRoundsPerClick = roundsPerClick;
        currentRoundsPerClick = roundsPerClick;
        maxBulletSpread = bulletSpread;
        currentBulletSpread = bulletSpread;
        maxKnockback = knockback;
        currentKnockback = knockback;

        actionState = ActionState.Idle;
    }



    protected virtual void Update()
    {
        currentBetweenShotsDelayTime -= Time.deltaTime;
    }



    // �߻�
    public virtual void Shoot()
    {
        if (actionState == ActionState.Reload) return; // �ൿ ���°� ������ ��, �Լ� ��ȯ

        StartCoroutine(Shoot_());
    }

    public virtual IEnumerator Shoot_()
    {
        if (currentBetweenShotsDelayTime <= 0) // ���� ���� �ð��� �ƴ� ��
        {
            for (int j = 0; j < maxRoundsPerClick; j++)
            {
                GameObject[] spawnedVFX = new GameObject[bulletsPerClick];

                if (currentMagazineSize <= 0) // ź���� ���� ���
                {
                    Reload(); // ���� �Լ� ȣ��

                    yield break; // �Լ� ��ȯ
                }

                actionState = ActionState.Shoot;

                currentBetweenShotsDelayTime = maxBetweenShotsDelayTime;
                currentMagazineSize -= 1;

                for (int i = 0; i < spawnedVFX.Length; i += 1)
                {
                    spawnedVFX[i] = Instantiate(VFX, barrelTransform.position, barrelTransform.rotation) as GameObject;

                    spawnedVFX[i].transform.Rotate(new Vector3(0, -90, 0), Space.Self);
                    spawnedVFX[i].AddComponent<Rigidbody>();
                    spawnedVFX[i].GetComponent<Rigidbody>().useGravity = false;
                    spawnedVFX[i].GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0 + Random.Range(-bulletSpread, bulletSpread), 1) * bulletSpeed, ForceMode.VelocityChange);
                    Destroy(spawnedVFX[i], 1f);
                }

                actionState = ActionState.Idle;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }



    // ����
    public virtual void Reload()
    {
        if (actionState == ActionState.Reload) return; // �ൿ ���°� ������ ��, �Լ� ��ȯ

        if (currentMagazineSize >= maxMagazineSize) return; // ���� źâ ũ�Ⱑ �ִ� źâ ũ��� ���� ��, �Լ� ��ȯ

        StartCoroutine(Reload_());
    }

    public virtual IEnumerator Reload_()
    {
        actionState = ActionState.Reload;

        yield return new WaitForSeconds(currentReloadTime); // ���� ���� �ð� ���� ���

        actionState = ActionState.Idle;

        currentMagazineSize = maxMagazineSize;
    }
}
