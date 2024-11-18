using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// ���� �Ѿ� �߻�
    /// </summary>
    public class FireBulletOnActivate : MonoBehaviour
    {
        #region Variables
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float bulletSpeed = 20f;

        private Animator animator;
        public ParticleSystem muzzle;
        public AudioSource pistolShot;

        //���ݷ�
        [SerializeField] private float attackDamage = 5f;

        //���� ������
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;

        //����Ʈ
        public GameObject hitImpactPrefab;
        #endregion

        private void Start()
        {
            XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
            grabInteractable.activated.AddListener(Fire);

            animator = GetComponent<Animator>();
        }

        void Fire(ActivateEventArgs args)
        {
            GameObject bulletGo = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bulletGo.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * bulletSpeed;
            Destroy(bulletGo, 5f);
        }

        IEnumerator Shoot()
        {
            isFire = true;

            //���տ� 100�ȿ� ���� ������ ������ �������� �ش�
            float maxDistance = 100f;
            RaycastHit hit;
            if (Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                //������ �������� �ش�
                //Debug.Log($"{hit.transform.name}���� �������� �ش�");
                //hit ����Ʈ
                GameObject eff = Instantiate(hitImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(eff, 2f);

                IDamageable_VR damageable = hit.transform.GetComponent<IDamageable_VR>();
                if (damageable != null)
                {
                    damageable.TakeDamage(attackDamage);
                }
            }

            //�� ȿ�� - VFX, SFX
            animator.SetTrigger("Fire");

            pistolShot.Play();

            muzzle.gameObject.SetActive(true);
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;
        }
    }
}