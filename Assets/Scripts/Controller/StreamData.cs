using System.IO;
using UnityEngine;

namespace Maze
{
    public class StreamData
    {
        
        private Player _player;
        private GameObject _winBonuses;

        public StreamData(Player player, GameObject winBonuses)
        {
            _player = player;
            _winBonuses = winBonuses;
        }

        private Vector3 Vector3Parse(string str)
        {
            Vector3 vector = Vector3.zero;
            int vector_index = 0;
            string number = "";

            for(int i = 0; i < str.Length; i++)
            {
                if(str[i] == ',' || str[i] == ')')
                {
                    vector[vector_index] = float.Parse(number);
                    vector_index++;

                    number = "";
                }
                else if(str[i] != '(' &&  str[i] != ' ' &&  str[i] != ',')
                {
                    number = number + str[i];
                }
            }

            return vector;
        }

        public void SaveData()
        {
            string SavePath = Path.Combine(Application.dataPath, "StreamData.txt");
            using(StreamWriter sw = new StreamWriter(SavePath))
            {
                sw.WriteLine(_player.transform.position);
                sw.WriteLine(_player.Score);

                foreach(var item in _winBonuses.GetComponentsInChildren<Transform>())
                {
                    if(item.gameObject.GetComponent<WinBonus>() != null)
                    {
                        sw.WriteLine(item.gameObject.GetComponent<WinBonus>().IsInteractable);
                    }
                }
            }

            Debug.Log("Gave saved!");
        }

        public void LoadData()
        {
            string SavePath = Path.Combine(Application.dataPath, "StreamData.txt");

            if(File.Exists(SavePath))
            {
                using(StreamReader sr = new StreamReader(SavePath))
                {
                    _player.transform.position = Vector3Parse(sr.ReadLine());
                    _player.Score = int.Parse(sr.ReadLine());

                    foreach(var item in _winBonuses.GetComponentsInChildren<Transform>())
                    {
                        if(item.gameObject.GetComponent<WinBonus>() != null)
                        {
                            item.gameObject.GetComponent<WinBonus>().IsInteractable = bool.Parse(sr.ReadLine());
                        }
                    }
                }

                Debug.Log("Save loaded!");
            }
            else
            {
                Debug.Log("The save file does not exist. Save the game at least once");
            }
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.K))
            {
                SaveData();
            }

            if (Input.GetKeyUp(KeyCode.L))
            {
                LoadData();
            }
        }
    }
}
