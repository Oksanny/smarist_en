#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;

public class AMN_PostProcess  {

	#if UNITY_ANDROID
	[PostProcessBuild(48)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {

		string file = SA.Common.Config.ANDROID_DESTANATION_PATH + "AndroidManifest.xml";
		string Manifest = SA.Common.Util.Files.Read(file);
		Manifest = Manifest.Replace("%APP_BUNDLE_ID%", PlayerSettings.bundleIdentifier);
		SA.Common.Util.Files.Write(file, Manifest);
		Debug.Log("AMN Post Process Done");

	}
	#endif

}
#endif
