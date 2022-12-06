using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Reload")]
    [SerializeField] protected int magazineSize; // 탄창 크기
    [SerializeField] protected float reloadTime; // 재장전 시간

    [Header("Shooting")]
    [SerializeField] protected float damage; // 공격력
    [SerializeField] protected float betweenShotsDelayTime; // 연사 지연 시간
    [SerializeField] protected int roundsPerClick; // 점사 수
    [SerializeField] protected int bulletsPerClick; // 산탄 수
    [SerializeField] protected float bulletSpread; // 탄 퍼짐
    [SerializeField] protected float knockback; // 넉백

    protected int maxMagazineSize; // 최대 탄창 크기
    protected int currentMagazineSize; // 현재 탄창 크기
    protected float maxReloadTime; // 최대 재장전 시간
    protected float currentReloadTime; // 현재 재장전 시간

    protected float maxDamage; // 최대 공격력
    protected float currentDamage; // 현재 공격력
    protected float maxBetweenShotsDelayTime; // 최대 연사 지연 시간
    protected float currentBetweenShotsDelayTime; // 현재 연사 지연 시간
    protected int maxRoundsPerClick; // 최대 점사 수
    protected int currentRoundsPerClick; // 현재 점사 수
    protected int maxBulletsPerClick; // 최대 산탄 수
    protected int currentBulletsPerClick; // 현재 산탄 수
    protected float maxBulletSpread; // 최대 탄 퍼짐
    protected float currentBulletSpread; // 현재 탄 퍼짐
    protected float maxKnockback; // 최대 넉백
    protected float currentKnockback; // 현재 넉백



    // 발사
    public virtual void Shoot()
    {

    }



    // 장전
    public virtual void Reload()
    {

    }
}
