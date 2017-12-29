using System.Collections;
using UnityEngine;

namespace Schoo01 {

    public class Spawner : MonoBehaviour {

        public GameObject PrefabMonry;

        private IEnumerator Start() {
            while (true) {
                Instantiate(this.PrefabMonry, this.transform);
                yield return new WaitForSeconds(Random.Range(0.5f, 2.0f));
            }
        }

    }

}