using UnityEngine;

namespace MyVrSample
{
    //AmmoBox 아이템 획득
    public class PickupAmmoBox : VR_Interactive
    {
        #region Variables
        //AmmoBox 아이템 획득시 지급하는 ammo 갯수
        [SerializeField] private int giveAmmo = 7;
        #endregion

        protected override void DoAction()
        {
            //아이템 지급
            Debug.Log("탄환 7개를 지급 했습니다");
            VR_PlayerStats.Instance.AddAmmo(giveAmmo);

            unInteractive = true;
            //킬
            Destroy(gameObject);
        }
    }
}
