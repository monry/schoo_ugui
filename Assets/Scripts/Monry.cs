﻿using System.Collections;
using UnityEngine;

namespace Schoo_uGUI {

    public class Monry : MonoBehaviour {

        private void Start() {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                Random.Range(-480.0f, 480.0f),
                Random.Range(-270.0f, 270.0f)
            );
            this.transform.parent.GetComponent<Spawner>().Counter.Total++;
            this.StartCoroutine(this.DestroyAfterFewSeconds());
        }

        private IEnumerator DestroyAfterFewSeconds() {
            yield return new WaitForSeconds(Random.Range(3.0f, 10.0f));
            Destroy(this.gameObject);
        }

    }

}