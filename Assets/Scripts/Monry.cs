using System.Collections;
using UnityEngine;

namespace Schoo_uGUI {

    public class Monry : MonoBehaviour {

        private void Start() {
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                Random.Range(-480.0f, 480.0f),
                Random.Range(-270.0f, 270.0f)
            );
            Controller.Instance.Counter.Total++;
            this.StartCoroutine(this.DestroyAfterFewSeconds());
        }

        private IEnumerator DestroyAfterFewSeconds() {
            yield return new WaitForSeconds(Random.Range(3.0f, 10.0f));
            this.GetComponent<Animator>().SetTrigger("Hide");
            yield return new WaitForSeconds(1.0f);
            Destroy(this.gameObject);
        }

        public void OnClick() {
            this.StartCoroutine(this.OnClickCoroutine());
        }

        private IEnumerator OnClickCoroutine() {
            Controller.Instance.Counter.Count++;
            this.GetComponent<Animator>().SetTrigger("Pump");
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<Animator>().SetTrigger("Hide");
            yield return new WaitForSeconds(1.0f);
            Destroy(this.gameObject);
        }

    }

}
