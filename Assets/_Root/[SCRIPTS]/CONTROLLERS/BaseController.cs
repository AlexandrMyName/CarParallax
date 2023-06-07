using System;
using System.Collections.Generic;
using Tools.Generic;
using UnityEngine;


namespace Game.Controllers
{
    internal abstract class BaseController : IDisposable
    {
        private List<GameObject> _gameObjects;
        private List<BaseController> _controllers;
        private List<IRepository> _repositories;
        public void Dispose()
        {
            if (_repositories != null)
            {
                foreach (var repository in _repositories)
                    repository.Dispose();
                 
            }

            if (_controllers != null)
            {
                foreach (var _controller in _controllers)
                    _controller.Dispose();
                 
            }

            if (_gameObjects != null)
            {
                foreach (var _gameObject in _gameObjects)
                    GameObject.Destroy(_gameObject);
                
            }
            _gameObjects?.Clear();
            _repositories?.Clear();
            _controllers?.Clear();
            OnDisposable();
        }

        public void AddController(BaseController controller)
        {
            _controllers ??= new List<BaseController>();
            _controllers.Add(controller);
        }
        protected void AddGameObjects(GameObject gameObject)
        {
            _gameObjects ??=  new List<GameObject>();
            _gameObjects.Add(gameObject);
            
        }
        public void AddRepository(IRepository repository)
        {
            _repositories ??= new List<IRepository>();
            _repositories.Add(repository);
        }

        public virtual void OnDisposable() { }
    }
}
