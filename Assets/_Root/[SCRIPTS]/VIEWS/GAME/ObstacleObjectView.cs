using UnityEngine;

namespace Game.UI
{
    public class ObstacleObjectView : MonoBehaviour
    {
        private bool _isCarInView;

        public bool IsCarInView { get => _isCarInView;  }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.CompareTag("Car"))
                _isCarInView = true;

        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Car"))
                _isCarInView = false;
        }
    }
}