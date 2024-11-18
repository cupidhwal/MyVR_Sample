using UnityEngine;
using TMPro;

namespace MyVrSample
{
    public class DrawAmmoUI : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI ammoCount;
        #endregion

        // Update is called once per frame
        void Update()
        {
            ammoCount.text = VR_PlayerStats.Instance.AmmoCount.ToString();
        }
    }
}