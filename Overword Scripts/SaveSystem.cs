using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{

    public static void SavePlayer(PlayerStats player) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        player = new PlayerStats();
        formatter.Serialize(stream, player);
        stream.Close();
    }

    public static PlayerStats LoadPlayer() {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerStats playerData = formatter.Deserialize(stream) as PlayerStats;
            stream.Close();
            return playerData;

        }

        else {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
