using UnityEngine;

namespace MyVrSample
{
    public class AmmoUI : MonoBehaviour
    {
        #region Variables
        public GameObject ammoUI;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            ShowAmmoUI();
        }

        private void ShowAmmoUI()
        {
            ammoUI.SetActive(VR_PlayerStats.Instance.HasGun);
        }
    }
}