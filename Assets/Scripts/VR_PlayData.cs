using UnityEngine;

namespace MyVrSample
{
    //파일에 저장할 게임 플레이 데이터 목록
    [System.Serializable]
    public class VR_PlayData
    {
        public int sceneNumber;
        public int ammoCount;
        public bool hasGun;

        //..... health

        //생성자 - PlayerStats에 있는 데이터로 초기화
        public VR_PlayData()
        {
            sceneNumber = VR_PlayerStats.Instance.SceneNumber;
            ammoCount = VR_PlayerStats.Instance.AmmoCount;
            hasGun = VR_PlayerStats.Instance.HasGun;
        }
    }
}