using UnityEngine;
using UnityEngine.UI;

namespace Schoo_uGUI {

    public class Counter : MonoBehaviour {

        public int Count;

        public int Total;

        private void Update() {
            this.GetComponent<Text>().text = string.Format("{0}/{1}", this.Count, this.Total);
        }

    }

}