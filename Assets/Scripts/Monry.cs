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
            this.AddRandomForce();
            this.StartCoroutine(this.DestroyAfterFewSeconds());
        }

        private void AddRandomForce() {
            // ランダムな角度に力を加える
            float degree = Random.Range(0.0f, 360.0f);
            Vector2 force = new Vector2(Mathf.Cos(Mathf.Deg2Rad * degree), Mathf.Sin(Mathf.Deg2Rad * degree));
            this.GetComponent<Rigidbody2D>().AddForce(force * 100.0f);

            // ランダムなトルクを与える
            float torque = Random.Range(-1.0f, 1.0f);
            this.GetComponent<Rigidbody2D>().AddTorque(torque * 100.0f);
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

        private void OnCollisionExit2D(Collision2D other) {
            this.StartCoroutine(this.OnCollisionExit2DCoroutine());
        }

        private IEnumerator OnCollisionExit2DCoroutine() {
            this.GetComponent<Animator>().SetTrigger("Hide");
            yield return new WaitForSeconds(1.0f);
            Destroy(this.gameObject);
        }

    }

}
