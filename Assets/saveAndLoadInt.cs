using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class saveAndLoadInt : MonoBehaviour
{
	//save an integer
    public void saveInt(int data, string path) {
    	//create a file and put the integer in
    	BinaryFormatter bf = new BinaryFormatter();
   	    FileStream file = File.Create(Application.persistentDataPath + path);
        bf.Serialize(file, data);
        file.Close();
    }

    public int loadInt(int data, string path) {
    	//if the file exists, open it and read the integer
		if(File.Exists(Application.persistentDataPath + path)) {
		        BinaryFormatter bf = new BinaryFormatter();
		        FileStream file = File.Open(Application.persistentDataPath + path, FileMode.Open);
		        data = (int)bf.Deserialize(file);
		        file.Close();

		        return data;
		}

		else {
			return 0;
		}
    }
}
