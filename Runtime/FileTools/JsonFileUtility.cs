using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

public class JsonFileUtility {

	/*
	██╗      ██████╗  █████╗ ██████╗      █████╗ ███████╗    ██████╗ ███████╗███████╗ ██████╗ ██╗   ██╗██████╗  ██████╗███████╗
	██║     ██╔═══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔════╝    ██╔══██╗██╔════╝██╔════╝██╔═══██╗██║   ██║██╔══██╗██╔════╝██╔════╝
	██║     ██║   ██║███████║██║  ██║    ███████║███████╗    ██████╔╝█████╗  ███████╗██║   ██║██║   ██║██████╔╝██║     █████╗
	██║     ██║   ██║██╔══██║██║  ██║    ██╔══██║╚════██║    ██╔══██╗██╔══╝  ╚════██║██║   ██║██║   ██║██╔══██╗██║     ██╔══╝
	███████╗╚██████╔╝██║  ██║██████╔╝    ██║  ██║███████║    ██║  ██║███████╗███████║╚██████╔╝╚██████╔╝██║  ██║╚██████╗███████╗
	╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝     ╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚══════╝

	*/


	/// <summary>
	/// Load from a file in the Resources folder. 
	/// </summary>
	/// <param name="path">Path relative to Resources folder</param>
	/// <param name="filename">The file name</param>
	/// <param name="res">the variable to put the string</param>
	/// <returns>A bool representing successful loading of the file</returns>
	public static bool LoadStringFromResources(string path, string filename, ref string res){
		string jsonFilePath = path + "/" + filename.Replace(".json", "");
		TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
		if(loadedJsonfile == null){
			return false;
		}
		res = loadedJsonfile.text;
		return true;
	}

/*
██╗      ██████╗  █████╗ ██████╗      █████╗ ███████╗    ███████╗██╗  ██╗████████╗███████╗██████╗ ███╗   ██╗ █████╗ ██╗
██║     ██╔═══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔════╝    ██╔════╝╚██╗██╔╝╚══██╔══╝██╔════╝██╔══██╗████╗  ██║██╔══██╗██║
██║     ██║   ██║███████║██║  ██║    ███████║███████╗    █████╗   ╚███╔╝    ██║   █████╗  ██████╔╝██╔██╗ ██║███████║██║
██║     ██║   ██║██╔══██║██║  ██║    ██╔══██║╚════██║    ██╔══╝   ██╔██╗    ██║   ██╔══╝  ██╔══██╗██║╚██╗██║██╔══██║██║
███████╗╚██████╔╝██║  ██║██████╔╝    ██║  ██║███████║    ███████╗██╔╝ ██╗   ██║   ███████╗██║  ██║██║ ╚████║██║  ██║███████╗
╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝     ╚═╝  ╚═╝╚══════╝    ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝

*/

	/// <summary>
	/// Load a string from a file in the Application.persistentDataPath
	/// </summary>
	/// <param name="path">Path relative to Application.persistentDataPath</param>
	/// <param name="filename">The file name</param>
	/// <param name="res">the variable to put the string</param>
	/// <returns>A bool representing successful loading of the file</returns>
	public static bool LoadStringFromFile(string path, string filename, ref string res){
		string filePath = Application.persistentDataPath + "/" + path + "/" + filename;
		//Debug.LogWarning("Read Data from" + filePath);
		if(!System.IO.File.Exists(filePath)){
			return false;
		}
		StreamReader reader = new StreamReader(filePath);
		string response = "";
		while(!reader.EndOfStream){
			response += reader.ReadLine();
		}
		res = response;
		reader.Close();

		if(res == null)
		{
			return false;
		}
		return true;
	}

	/*
	██╗    ██╗██████╗ ██╗████████╗███████╗     █████╗ ███████╗    ███████╗██╗  ██╗████████╗███████╗██████╗ ███╗   ██╗ █████╗ ██╗
	██║    ██║██╔══██╗██║╚══██╔══╝██╔════╝    ██╔══██╗██╔════╝    ██╔════╝╚██╗██╔╝╚══██╔══╝██╔════╝██╔══██╗████╗  ██║██╔══██╗██║
	██║ █╗ ██║██████╔╝██║   ██║   █████╗      ███████║███████╗    █████╗   ╚███╔╝    ██║   █████╗  ██████╔╝██╔██╗ ██║███████║██║
	██║███╗██║██╔══██╗██║   ██║   ██╔══╝      ██╔══██║╚════██║    ██╔══╝   ██╔██╗    ██║   ██╔══╝  ██╔══██╗██║╚██╗██║██╔══██║██║
	╚███╔███╔╝██║  ██║██║   ██║   ███████╗    ██║  ██║███████║    ███████╗██╔╝ ██╗   ██║   ███████╗██║  ██║██║ ╚████║██║  ██║███████╗
	 ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝   ╚═╝   ╚══════╝    ╚═╝  ╚═╝╚══════╝    ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝

	*/

	/// <summary>
	/// Write json to a file relative to Application.persistentDataPath
	/// </summary>
	/// <param name="path">Path relative to Application.persistentDataPath</param>
	/// <param name="filename">The file name</param>
	/// <param name="content">The string to write to the file</param>
	/// <returns></returns>
	public static void WriteJsonToFile(string path, string filename, string content){
		string directoryPath = Application.persistentDataPath + "/" + path;
		string filePath = directoryPath + "/" + filename;
		//Debug.LogFormat("Writing to path {0}", filePath);
		if (!System.IO.Directory.Exists(directoryPath)){
			Directory.CreateDirectory(directoryPath);
		}
		//Debug.LogWarning("Write Data To" + filePath);
		FileStream stream = File.Create(filePath);
		byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);
		stream.Write(contentBytes, 0, contentBytes.Length);
        stream.Dispose();
	}

/*
██╗      ██████╗  █████╗ ██████╗     ███████╗██████╗  ██████╗ ███╗   ███╗    ██╗   ██╗██████╗ ██╗
██║     ██╔═══██╗██╔══██╗██╔══██╗    ██╔════╝██╔══██╗██╔═══██╗████╗ ████║    ██║   ██║██╔══██╗██║
██║     ██║   ██║███████║██║  ██║    █████╗  ██████╔╝██║   ██║██╔████╔██║    ██║   ██║██████╔╝██║
██║     ██║   ██║██╔══██║██║  ██║    ██╔══╝  ██╔══██╗██║   ██║██║╚██╔╝██║    ██║   ██║██╔══██╗██║
███████╗╚██████╔╝██║  ██║██████╔╝    ██║     ██║  ██║╚██████╔╝██║ ╚═╝ ██║    ╚██████╔╝██║  ██║███████╗
╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝     ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═╝     ╚═╝     ╚═════╝ ╚═╝  ╚═╝╚══════╝

*/
	//public delegate void OnWebLoaded(string responseText);

	////this creates a 
	//public static IEnumerator LoadJsonFromURL(string url, OnWebLoaded callback){
	//	WWW request = new WWW(url);
	//	yield return request;
	//	callback(request.text);
	//}

	////this creates a new file
	//public static IEnumerator PostJsonToURL(string url, string body, OnWebLoaded callback){
	//	Dictionary<string, string> headers = new Dictionary<string, string>();
	//	//put headers here as the api requires
	//	headers["content-type"] = "application/json; charset=utf-8";

	//	WWW request = new WWW(url, Encoding.ASCII.GetBytes(body), headers);
	//	yield return request;
	//	callback(request.text);
	//}

}
