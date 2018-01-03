using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Schoo_uGUI {

    public class Controller : MonoBehaviour {

        private const float LEAST_TIME = 15.0f;

        public static Controller Instance;

        public Counter Counter;

        public Spawner Spawner;

        public Image LeastTime;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            this.Counter.Count = 0;
            this.Counter.Total = 0;
            this.Spawner.CanSpawn = true;
            this.LeastTime.gameObject.SetActive(true);
            this.StartCoroutine(this.StartTimer());
        }

        private void StopGame() {
            this.Spawner.CanSpawn = false;
            this.Spawner.DestroyAllChildren();
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