using JoostenProductions;
using Tools.React;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UIElements;
using Game.Models;
using System.Collections.Generic;

namespace Game.UI
{
    internal class ObstaclesView : MonoBehaviour
    {
        [SerializeField] private List<ObstacleObjectView> _obstacleObjectViews;

        private ObstacleObjectView _currentObstacle;
        private IReadOnlySubscriptionProperty<float> _diff;

        private Vector3 _cahedPosition;
        float maxTime = 2f;
        float currentTime;
        bool isSleep;
        int currentObjectIndex;
        
        CarModel _car;

        private void Awake()
        {
            currentObjectIndex = 0;
            
            currentTime = maxTime;
            _cahedPosition = _obstacleObjectViews[0].transform.position;
        }
        private void SetNextObstacle()
        {

        }
        private void DisposeObstacles()
        {
            foreach(var obstacle in _obstacleObjectViews)
            {
                obstacle.transform.position = _cahedPosition;
                obstacle.gameObject.SetActive(false);
            }
        }
        private void SetCurrentObstacle()
        {
            currentObjectIndex = (currentObjectIndex + 1) % _obstacleObjectViews.Count;
            Debug.Log(currentObjectIndex);
            _obstacleObjectViews[currentObjectIndex].gameObject.SetActive(true);
            _currentObstacle = _obstacleObjectViews[currentObjectIndex];
        }
        public void Init(IReadOnlySubscriptionProperty<float> diff, CarModel car)
        {
            _car = car;
            _diff = diff;
            _diff.Subscribe(Move);
        }

       
        private void Move(float value)
        {
            bool isCarViewThis = _currentObstacle != null ? _currentObstacle.IsCarInView : false;

            if (value != 0  && !isCarViewThis)
                    currentTime -= Time.deltaTime * 0.5f;

            if(currentTime <= 0)
            {
                currentTime = maxTime;
                DisposeObstacles();
                SetSleep();
                if (!isSleep)
                    SetCurrentObstacle();
            }
             
            if (!isSleep && _currentObstacle != null)
            {
                
                    Vector3 position = _currentObstacle.transform.position;

                    position -= Vector3.right * value * 3 * (_car.Speed / 2);

                _currentObstacle.transform.position = position;
            }


        }

        private void SetSleep()
        {
            if (isSleep) isSleep = false;
            else isSleep = true;
        }

    }
}
