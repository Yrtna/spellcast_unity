using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;

namespace GAP_ParticleSystemController{

	public static class SaveParticleSystemScript{		

		public static void SaveVFX (GameObject prefabVFX, List<ParticleSystemOriginalSettings> psOriginalSettingsList) {
			var prefabFolderPath = GetPrefabFolder (prefabVFX);
			#if UNITY_EDITOR
			if (!Directory.Exists (prefabFolderPath + "/OriginalSettings")) {
				UnityEditor.AssetDatabase.CreateFolder (prefabFolderPath, "OriginalSettings");
				Debug.Log("Created folder:  " + prefabFolderPath + "/OriginalSettings");
			}
			#endif
			
			BinaryFormatter bf = new BinaryFormatter ();			
			FileStream stream = new FileStream (prefabFolderPath + "/OriginalSettings/" + prefabVFX.name + ".dat", FileMode.Create);

			bf.Serialize (stream, psOriginalSettingsList);		
			stream.Close ();

			Debug.Log ("Original Settings of '" + prefabVFX.name + "' saved to: " + prefabFolderPath + "/OriginalSettings");
		}

		public static List<ParticleSystemOriginalSettings> LoadVFX (GameObject prefabVFX) {
			var prefabFolderPath = GetPrefabFolder (prefabVFX);
			
			if (File.Exists (prefabFolderPath + "/OriginalSettings/" + prefabVFX.name + ".dat")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream stream = new FileStream (prefabFolderPath + "/OriginalSettings/" + prefabVFX.name + ".dat", FileMode.Open);

				List<ParticleSystemOriginalSettings> originalSettingsList = new List<ParticleSystemOriginalSettings> (); 
				originalSettingsList = bf.Deserialize (stream) as List<ParticleSystemOriginalSettings>;

				stream.Close ();
				return originalSettingsList;

			} else {
				Debug.Log ("No saved VFX data found");
				return null;
			}
		}

		public static bool CheckExistingFile (GameObject prefabVFX){
			var prefabFolderPath = GetPrefabFolder (prefabVFX);

			if (File.Exists (prefabFolderPath + "/OriginalSettings/" + prefabVFX.name + ".dat"))
				return true;
			else
				return false;
		}

		static string GetPrefabFolder (GameObject prefabVFX){
			#if UNITY_EDITOR
			string prefabPath = UnityEditor.AssetDatabase.GetAssetPath (prefabVFX);
			string prefabFolderPath = Path.GetDirectoryName (prefabPath);
			return prefabFolderPath;
			#else
			return null;
			#endif
		}
	}
}
