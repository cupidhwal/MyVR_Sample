using System.Collections;
using UnityEngine;

namespace MyVrSample
{
    public class VR_CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;      //문
        public AudioSource doorBang;    //문 열기 사운드

        public AudioSource bgm01;   //메인씬 1 배경음
        public AudioSource bgm02;   //적 등장 배경음        

        public GameObject theRobot;     //적
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        //트리거 작동시 플레이
        IEnumerator PlaySequence()
        {
            //문열기
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            //문 사운드
            bgm01.Stop();
            doorBang.Play();

            //Enemy 활성화
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1f);

            //Enemy 등장 사운드
            bgm02.Play();

            //Enemy 타겟을 향해 걷기
            VR_RobotController robot = theRobot.GetComponent<VR_RobotController>();
            if (robot != null)
            {
                robot.SetState(RobotState.R_Walk);
            }

            //트리거 킬
            Destroy(this.gameObject);
        }
    }
}