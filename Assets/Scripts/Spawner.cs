﻿using System.Collections;
using UnityEngine;

namespace Schoo_uGUI {

    public class Spawner : MonoBehaviour {

        public GameObject PrefabMonry;

        public bool CanSpawn = false;

        private IEnumerator Start() {
            while (true) {
                if (this.CanSpawn) {
                    Instantiate(this.PrefabMonry, this.transform);
                    yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));
                } else {
                    yield return null;
                }
            }
        }

        public void DestroyAllChildren() {
            foreach (Monry child in this.GetComponentsInChildren<Monry>()) {
                Destroy(child.gameObject);
            }
        }

    }

}