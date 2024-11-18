using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVrSample
{
    //인터렉티브 액션을 구현하는 클래스
    public abstract class VR_Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        //true이면 Interactive 기능을 정지
        protected bool unInteractive = false;

        public InputActionProperty interaction;
        #endregion

        private void Update()
        {
            theDistance = VR_PlayerCasting.distanceFromTarget;

            //거리가 2이하 일때
            if (theDistance <= 2f && !unInteractive)
            {
                ShowActionUI();

                if (interaction.action.WasPressedThisFrame())
                {
                    ActiveThis();
                    unInteractive = true;
                }
            }
            else
            {
                HideActionUI();
            }
        }

        public void ActiveThis()
        {
            HideActionUI();

            //Action
            DoAction();
        }

        public void HoverHand()
        {
            //거리가 2이하 일때
            if (theDistance <= 2f && !unInteractive)
            {
                ShowActionUI();
            }
            else
            {
                HideActionUI();
            }
        }

        public void ExitHand()
        {
            HideActionUI();
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }
    }
}