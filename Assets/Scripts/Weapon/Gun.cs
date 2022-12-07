using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum ActionState { Idle = 0, Shoot = 2, Reload = 3 }

    [Header("Shooting")]
    [SerializeField] protected float damage; // 공격력
    [SerializeField] protected float betweenShotsDelayTime; // 연사 지연 시간
    [SerializeField] protected int roundsPerClick; // 점사 수
    [SerializeField] protected int bulletsPerClick; // 산탄 수
    [SerializeField] protected float bulletSpeed; // 탄속
    [SerializeField] protected float bulletSpread; // 탄 퍼짐
    [SerializeField] protected float knockback; // 넉백

    [Header("Reload")]
    [SerializeField] protected int magazineSize; // 탄창 크기
    [SerializeField] protected float reloadTime; // 재장전 시간

    protected float maxDamage; // 최대 공격력
    protected float currentDamage; // 현재 공격력
    protected float maxBetweenShotsDelayTime; // 최대 연사 지연 시간
    protected float currentBetweenShotsDelayTime; // 현재 연사 지연 시간
    protected int maxRoundsPerClick; // 최대 점사 수
    protected int currentRoundsPerClick; // 현재 점사 수
    protected int maxBulletsPerClick; // 최대 산탄 수
    protected int currentBulletsPerClick; // 현재 산탄 수
    protected float maxBulletSpeed; // 최대 탄속
    protected float currentBulletSpeed; // 현재 탄속
    protected float maxBulletSpread; // 최대 탄 퍼짐
    protected float currentBulletSpread; // 현재 탄 퍼짐
    protected float maxKnockback; // 최대 넉백
    protected float currentKnockback; // 현재 넉백

    protected int maxMagazineSize; // 최대 탄창 크기
    protected int currentMagazineSize; // 현재 탄창 크기
    protected float maxReloadTime; // 최대 재장전 시간
    protected float currentReloadTime; // 현재 재장전 시간

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
        // 필드 초기화
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



    // 발사
    public virtual void Shoot()
    {
        if (actionState == ActionState.Reload) return; // 행동 상태가 장전일 때, 함수 반환

        StartCoroutine(Shoot_());
    }

    public virtual IEnumerator Shoot_()
    {
        if (currentBetweenShotsDelayTime <= 0) // 연사 지연 시간이 아닐 때
        {
            for (int j = 0; j < maxRoundsPerClick; j++)
            {
                GameObject[] spawnedVFX = new GameObject[bulletsPerClick];

                if (currentMagazineSize <= 0) // 탄약이 없을 경우
                {
                    Reload(); // 장전 함수 호출

                    yield break; // 함수 반환
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



    // 장전
    public virtual void Reload()
    {
        if (actionState == ActionState.Reload) return; // 행동 상태가 장전일 때, 함수 반환

        if (currentMagazineSize >= maxMagazineSize) return; // 현재 탄창 크기가 최대 탄창 크기와 같을 때, 함수 반환

        StartCoroutine(Reload_());
    }

    public virtual IEnumerator Reload_()
    {
        actionState = ActionState.Reload;

        yield return new WaitForSeconds(currentReloadTime); // 현재 장전 시간 동안 대기

        actionState = ActionState.Idle;

        currentMagazineSize = maxMagazineSize;
    }
}
