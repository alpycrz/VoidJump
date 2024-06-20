using System.Collections.Generic;
using Game.Screen;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Environment
{
    public class PlatformPool : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab = default;
        [SerializeField] private GameObject platformPrefab = default;
        [SerializeField] private GameObject platformDeadlyPrefab = default;
        [SerializeField] private float platformDistance = default;

        private List<GameObject> _platforms = new List<GameObject>();

        private Vector2 _playerPos;
        private Vector2 _platformPos;

        private void Start() { CreatePlatform(); }

        private void Update()
        {
            if (_platforms[^1].transform.position.y <
                Camera.main.transform.position.y + ScreenCalculator.instance.Height)
            {
                PlacePlatform();
            }
        }

        private void CreatePlatform()
        {
            _platformPos = new Vector2(0, 0);
            _playerPos = new Vector2(0, 0.5f);

            GameObject player = Instantiate(playerPrefab, _playerPos, Quaternion.identity);
            GameObject firstPlatform = Instantiate(platformPrefab, _platformPos, Quaternion.identity);
            player.transform.parent = firstPlatform.transform;
            _platforms.Add(firstPlatform);
            NextPlatformPos();
            firstPlatform.GetComponent<Platform>().Movement = true;
        
            for (int i = 0; i < 8; i++)
            {
                GameObject platform = Instantiate(platformPrefab, _platformPos, Quaternion.identity);
                _platforms.Add(platform);
                platform.GetComponent<Platform>().Movement = true;

                if (i % 2 == 0)
                {
                    platform.GetComponent<Gold>().GoldOff();
                }
                NextPlatformPos();
            }

            GameObject platformDeadly = Instantiate(platformDeadlyPrefab, _platformPos, Quaternion.identity);
            platformDeadly.GetComponent<PlatformDeadly>().Movement = true;
            _platforms.Add(platformDeadly);
            NextPlatformPos();
        }
        
        private void PlacePlatform()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject temp;
                temp = _platforms[i + 5];
                _platforms[i + 5] = _platforms[i];
                _platforms[i] = temp;
                _platforms[i + 5].transform.position = _platformPos;

                if (_platforms[i + 5].gameObject.CompareTag("Platform"))
                {
                    _platforms[i + 5].GetComponent<Gold>().GoldOff();
                    float randomGold = Random.Range(0.0f, 1.0f);
                    
                    if (randomGold > 0.5f)
                    {
                        _platforms[i + 5].GetComponent<Gold>().GoldOn();
                    }
                }
                NextPlatformPos();
            }
        }

        private void NextPlatformPos()
        {
            _platformPos.y += platformDistance;
            MixedPosition();
            //OrdinaryPosition();
        }

        private void MixedPosition()
        {
            float random = Random.Range(0f, 1f);

            if (random < 0.5f)
            {
                _platformPos.x = ScreenCalculator.instance.Width / 2;
            }
            else
            {
                _platformPos.x = -ScreenCalculator.instance.Width / 2;
            }
        }

        private bool _direction = true;
        private void OrdinaryPosition()
        {
            if (_direction)
            {
                _platformPos.x = ScreenCalculator.instance.Width / 2;
                _direction = false;
            }
            else
            {
                _platformPos.x = -ScreenCalculator.instance.Width / 2;
                _direction = true;
            }
        }

    }
}