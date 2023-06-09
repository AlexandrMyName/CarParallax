using System;
using System.Collections.Generic;
using Tools.Generic;
using UnityEngine;


namespace Game.Controllers
{
    internal abstract class BaseController : IDisposable
    {
        private List<GameObject> _gameObjects;
        private List<IDisposable> _disposables;
        
        public void Dispose()
        {
            if (_disposables != null)
                foreach (var disposable in _disposables)
                    disposable.Dispose();
             
            if (_gameObjects != null)
            {
                foreach (var _gameObject in _gameObjects)
                    GameObject.Destroy(_gameObject);
                
            }
            _gameObjects?.Clear();
           
            _disposables?.Clear();
            OnDisposable();
        }

       
        protected void AddGameObjects(GameObject gameObject)
        {
            _gameObjects ??=  new List<GameObject>();
            _gameObjects.Add(gameObject);
            
        }
        public void AddDisposableObject(IDisposable disposable)
        {
            _disposables ??= new List<IDisposable>();
            _disposables.Add(disposable);
        }

        public virtual void OnDisposable() { }
    }
}
