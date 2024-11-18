using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyVrSample
{
    //플레이씬이 시작하면 자동으로 게임데이터 저장
    public class VR_AutoSave : MonoBehaviour
    {
        private void Start()
        {
            //씬번호 저장
            AutoSaveData();
        }

        private void AutoSaveData()
        {
            //현재 씬 저장
            int sceneNumber = VR_PlayerStats.Instance.SceneNumber;
            VR_PlayerStats.Instance.NowSceneNumber = SceneManager.GetActiveScene().buildIndex;

            //새로 플레이하는 씬이냐?
            if(VR_PlayerStats.Instance.NowSceneNumber > sceneNumber)
            {
                VR_PlayerStats.Instance.SceneNumber = VR_PlayerStats.Instance.NowSceneNumber;
                VR_SaveLoad.SaveData();
            }
        }
    }
}