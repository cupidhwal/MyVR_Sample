using UnityEngine;

namespace MyVrSample
{
    public class SyncPosGUI : MonoBehaviour
    {
        public GameObject player;
        private Transform playerSight;

        private void Start()
        {
            playerSight = player.transform.GetChild(0).GetChild(0);
        }

        void Update()
        {
            transform.position = playerSight.transform.position;
            transform.rotation = playerSight.transform.rotation;
        }
    }
}