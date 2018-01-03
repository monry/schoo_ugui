using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Schoo_uGUI {

    public class Controller : MonoBehaviour {

        private const float LEAST_TIME = 30.0f;

        public static Controller Instance;

        public Counter Counter;

        public Spawner Spawner;

        public Image LeastTime;

        private void Awake() {
            Instance = this;
        }

        public void StartGame() {
            this.Counter.Count = 0;
            this.Counter.Total = 0;
            this.Spawner.CanSpawn = true;
            this.LeastTime.gameObject.SetActive(true);
            this.StartCoroutine(this.StartTimer());
        }

        public void StopGame() {
            this.Spawner.CanSpawn = false;
            this.LeastTime.gameObject.SetActive(false);
        }

        private IEnumerator StartTimer() {
            float leastTime = LEAST_TIME;
            while (leastTime > 0) {
                this.LeastTime.fillAmount = leastTime / LEAST_TIME;
                leastTime -= Time.deltaTime;
                yield return null;
            }
            this.StopGame();
        }

    }

}