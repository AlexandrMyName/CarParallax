using JoostenProductions;
using Tools.React;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;
using Game.Models;

namespace Game.UI
{
    internal class ObstaclesView : MonoBehaviour
    {
         private GameObject _obstacle;

        private IReadOnlySubscriptionProperty<float> _diff;

        private Vector3 _cahedPosition;
        float maxTime = 2f;
        float currentTime;
        bool isSleep;
        CarModel _car;

        private void Awake()
        {
            _obstacle = GameObject.Find("Obstacle");
            
            currentTime = maxTime;
            _cahedPosition = _obstacle.transform.position;
        }
        private void OnDestroy()
        {
            
        }
        public void Init(IReadOnlySubscriptionProperty<float> diff, CarModel car)
        {
            _car = car;
            _diff = diff;
            _diff.Subscribe(Move);
        }


        private void Move(float value)
        {
            currentTime -= Time.deltaTime * 0.5f;

            if(currentTime <= 0)
            {
                currentTime = maxTime;
                _obstacle.transform.position = _cahedPosition;
                SetSleep();
                if(!isSleep)
                _obstacle.SetActive(true);
            }
             
            if (!isSleep)
            {
                
                    Vector3 position = _obstacle.transform.position;

                    position -= Vector3.right * value * 3 * (_car.Speed / 2);
                   
                    _obstacle.transform.position = position;
                 
                 

            }


        }

        private void SetSleep()
        {
            if (isSleep) isSleep = false;
            else isSleep = true;
        }

    }
}
