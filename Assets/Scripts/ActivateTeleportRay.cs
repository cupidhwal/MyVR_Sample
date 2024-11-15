using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVrSample
{
    /// <summary>
    /// Teleport Ray를 관리하는 클래스
    /// </summary>
    public class ActivateTeleportRay : MonoBehaviour
    {
        #region Variables
        public GameObject leftTeleportRay;          //텔레포트 왼쪽 Ray 오브젝트
        public GameObject rightTeleportRay;         //텔레포트 오른쪽 Ray 오브젝트

        public InputActionProperty leftActivate;    //왼쪽 컨트롤러의 Activate 입력
        public InputActionProperty rightActivate;   //오른쪽 컨트롤러의 Activate 입력
        #endregion

        private void Update()
        {
            float leftAivateValue = leftActivate.action.ReadValue<float>();
            float rightAivateValue = rightActivate.action.ReadValue<float>();

            leftTeleportRay.SetActive(leftAivateValue > 0.1f);
            rightTeleportRay.SetActive(rightAivateValue > 0.1f);
        }
    }
}