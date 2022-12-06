using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Reload")]
    [SerializeField] protected int magazineSize; // źâ ũ��
    [SerializeField] protected float reloadTime; // ������ �ð�

    [Header("Shooting")]
    [SerializeField] protected float damage; // ���ݷ�
    [SerializeField] protected float betweenShotsDelayTime; // ���� ���� �ð�
    [SerializeField] protected int roundsPerClick; // ���� ��
    [SerializeField] protected int bulletsPerClick; // ��ź ��
    [SerializeField] protected float bulletSpread; // ź ����
    [SerializeField] protected float knockback; // �˹�

    protected int maxMagazineSize; // �ִ� źâ ũ��
    protected int currentMagazineSize; // ���� źâ ũ��
    protected float maxReloadTime; // �ִ� ������ �ð�
    protected float currentReloadTime; // ���� ������ �ð�

    protected float maxDamage; // �ִ� ���ݷ�
    protected float currentDamage; // ���� ���ݷ�
    protected float maxBetweenShotsDelayTime; // �ִ� ���� ���� �ð�
    protected float currentBetweenShotsDelayTime; // ���� ���� ���� �ð�
    protected int maxRoundsPerClick; // �ִ� ���� ��
    protected int currentRoundsPerClick; // ���� ���� ��
    protected int maxBulletsPerClick; // �ִ� ��ź ��
    protected int currentBulletsPerClick; // ���� ��ź ��
    protected float maxBulletSpread; // �ִ� ź ����
    protected float currentBulletSpread; // ���� ź ����
    protected float maxKnockback; // �ִ� �˹�
    protected float currentKnockback; // ���� �˹�



    // �߻�
    public virtual void Shoot()
    {

    }



    // ����
    public virtual void Reload()
    {

    }
}
