using UnityEngine;

namespace BallPhysicsGame
{
    public class SaveData : MonoBehaviour
    {
        public void SaveIntoJson(GameSessionData gameSessionData)
        {
            string Session = JsonUtility.ToJson(gameSessionData);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/GameSessionData.json", Session);
            Debug.Log("Saved JSON file to location: " + Application.persistentDataPath);
        }
    }
    public class GameSessionData
    {
        public string timePlayed;
        public string timeJasonMade;
        public string gameName;
        public int score;
    } 
}
