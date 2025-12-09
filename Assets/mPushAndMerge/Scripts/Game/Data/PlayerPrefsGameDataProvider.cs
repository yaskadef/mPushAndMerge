using Assets.mPushAndMerge.Scripts.Game.Data.Root;
using Assets.mPushAndMerge.Scripts.Game.Data.Root.Maps;
using R3;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.mPushAndMerge.Scripts.Game.Data
{
    public class PlayerPrefsGameDataProvider : IGameDataProvider
    {
        private const string GAME_DATA_KEY = nameof(GAME_DATA_KEY);

        public GameDataProxy GameData { get; private set; }
        private GameData _gameDataOrigin;

        public Observable<GameDataProxy> LoadGameplayData()
        {
            if (PlayerPrefs.HasKey(GAME_DATA_KEY))
            {
                var json = PlayerPrefs.GetString(GAME_DATA_KEY);

            }
            else
            {
                GameData = GetGameDataFromSettings();
                Debug.Log("GameData created from settings: {}");

                SaveGameData();
            }

            return Observable.Return(GameData);
        }

        public void ResetData()
        {
            throw new NotImplementedException();
        }

        public void SaveGameData()
        {
            throw new NotImplementedException();
        }

        private GameDataProxy GetGameDataFromSettings()
        {
            _gameDataOrigin = new GameData
            {
                Maps = new List<MapData>()
            };

            return new GameDataProxy(_gameDataOrigin);
        }
    }
}
