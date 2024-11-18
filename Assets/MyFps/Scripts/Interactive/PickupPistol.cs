using TMPro;
using UnityEngine;

namespace MyVrSample
{
    public class PickupPistol : VR_Interactive
    {
        #region Variables
        //Action
        public GameObject arrow;

        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public GameObject ammoUI;
        #endregion

        protected override void DoAction()
        {            
            arrow.SetActive(false);
            ammoBox.SetActive(true);
            enemyTrigger.SetActive(true);

            //무기획득
            VR_PlayerStats.Instance.SetHasGun(true);
            ammoUI.SetActive(true);

            //unInteractive = true;
            Destroy(gameObject);
        }
    }
}
