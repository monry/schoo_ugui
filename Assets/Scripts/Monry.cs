using System.Collections;
using UnityEngine;

namespace Schoo_uGUI {

    public class Monry : MonoBehaviour {

        private void Start() {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                Random.Range(-512.0f, 512.0f),
                Random.Range(-384.0f, 384.0f)
            );
            this.StartCoroutine(this.DestroyAfterFewSeconds());
        }

        private IEnumerator DestroyAfterFewSeconds() {
            yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
            Destroy(this.gameObject);
        }

    }

}