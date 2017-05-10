#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;

public class IOSNativePostProcess  {

	#if UNITY_IPHONE
	[PostProcessBuild(50)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject) {


		if(IOSNativeSettings.Instance.EnableInAppsAPI) {

			string StoreKit = "StoreKit.framework";



			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(StoreKit)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = StoreKit;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}

		}

		if(IOSNativeSettings.Instance.EnableGameCenterAPI) {
			
			string GameKit = "GameKit.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(GameKit)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = GameKit;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}
			
		}



		if(IOSNativeSettings.Instance.EnableSocialSharingAPI) {
		
			string Accounts = "Accounts.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(Accounts)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = Accounts;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}

			
			
			string SocialF = "Social.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(SocialF)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = SocialF;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}
			
			string MessageUI = "MessageUI.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(MessageUI)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = MessageUI;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}


			SA.IOSDeploy.Variable LSApplicationQueriesSchemes =  new SA.IOSDeploy.Variable();
			LSApplicationQueriesSchemes.Name = "LSApplicationQueriesSchemes";
			LSApplicationQueriesSchemes.Type = SA.IOSDeploy.PlistValueTypes.Array;
			LSApplicationQueriesSchemes.ArrayType = SA.IOSDeploy.PlistValueTypes.String;

			SA.IOSDeploy.VariableListed instagram =  new SA.IOSDeploy.VariableListed();
			instagram.StringValue = "instagram";
			instagram.Type = SA.IOSDeploy.PlistValueTypes.String;
			LSApplicationQueriesSchemes.ArrayValue.Add(instagram);

			SA.IOSDeploy.VariableListed whatsapp =  new SA.IOSDeploy.VariableListed();
			whatsapp.StringValue = "whatsapp";
			whatsapp.Type = SA.IOSDeploy.PlistValueTypes.String;
			LSApplicationQueriesSchemes.ArrayValue.Add(whatsapp);


			if(!SA.IOSDeploy.Settings.Instance.ContainsPlistVarkWithName(LSApplicationQueriesSchemes.Name)) {
				SA.IOSDeploy.Settings.Instance.PlistVariables.Add(LSApplicationQueriesSchemes);
			}
		}


		if(IOSNativeSettings.Instance.EnableMediaPlayerAPI) {
			string MediaPlayer = "MediaPlayer.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(MediaPlayer)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = MediaPlayer;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}
				

			var NSAppleMusicUsageDescription =  new SA.IOSDeploy.Variable();
			NSAppleMusicUsageDescription.Name = "NSAppleMusicUsageDescription";
			NSAppleMusicUsageDescription.StringValue = IOSNativeSettings.Instance.AppleMusicUsageDescription;
			NSAppleMusicUsageDescription.Type = SA.IOSDeploy.PlistValueTypes.String;

			if(!SA.IOSDeploy.Settings.Instance.ContainsPlistVarkWithName(NSAppleMusicUsageDescription.Name)) {
				SA.IOSDeploy.Settings.Instance.PlistVariables.Add(NSAppleMusicUsageDescription);
			}
		}
	

		if(IOSNativeSettings.Instance.EnableCameraAPI) {
			string MobileCoreServices = "MobileCoreServices.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(MobileCoreServices)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = MobileCoreServices;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}



			var NSCameraUsageDescription =  new SA.IOSDeploy.Variable();
			NSCameraUsageDescription.Name = "NSCameraUsageDescription";
			NSCameraUsageDescription.StringValue = IOSNativeSettings.Instance.CameraUsageDescription;
			NSCameraUsageDescription.Type = SA.IOSDeploy.PlistValueTypes.String;



			if(!SA.IOSDeploy.Settings.Instance.ContainsPlistVarkWithName(NSCameraUsageDescription.Name)) {
				SA.IOSDeploy.Settings.Instance.PlistVariables.Add(NSCameraUsageDescription);
			}


			var NSPhotoLibraryUsageDescription =  new SA.IOSDeploy.Variable();
			NSPhotoLibraryUsageDescription.Name = "NSPhotoLibraryUsageDescription";
			NSPhotoLibraryUsageDescription.StringValue = IOSNativeSettings.Instance.PhotoLibraryUsageDescription;
			NSPhotoLibraryUsageDescription.Type = SA.IOSDeploy.PlistValueTypes.String;

			if(!SA.IOSDeploy.Settings.Instance.ContainsPlistVarkWithName(NSPhotoLibraryUsageDescription.Name)) {
				SA.IOSDeploy.Settings.Instance.PlistVariables.Add(NSPhotoLibraryUsageDescription);
			}

		}

		if(IOSNativeSettings.Instance.EnableReplayKit) {
			string ReplayKit = "ReplayKit.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(ReplayKit)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = ReplayKit;
				F.IsOptional = true;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}
		}


		if(IOSNativeSettings.Instance.EnableCloudKit) {
			string CloudKit = "CloudKit.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(CloudKit)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = CloudKit;
				F.IsOptional = true;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}


			string inheritedflag = "$(inherited)";
			if(!SA.IOSDeploy.Settings.Instance.linkFlags.Contains(inheritedflag)) {
				SA.IOSDeploy.Settings.Instance.linkFlags.Add(inheritedflag);
			}

		}

		if(IOSNativeSettings.Instance.EnablePickerAPI) {
			string AssetsLibrary = "AssetsLibrary.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(AssetsLibrary)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = AssetsLibrary;
				F.IsOptional = true;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}
		}


		if(IOSNativeSettings.Instance.EnableSoomla) {
			string AdSupport = "AdSupport.framework";
			if(!SA.IOSDeploy.Settings.Instance.ContainsFreamworkWithName(AdSupport)) {
				SA.IOSDeploy.Framework F =  new SA.IOSDeploy.Framework();
				F.Name = AdSupport;
				SA.IOSDeploy.Settings.Instance.Frameworks.Add(F);
			}

			string libsqlite3 = "libsqlite3.dylib";
			if(!SA.IOSDeploy.Settings.Instance.ContainsLibWithName(libsqlite3)) {
				SA.IOSDeploy.Lib L =  new SA.IOSDeploy.Lib();
				L.Name = libsqlite3;
				SA.IOSDeploy.Settings.Instance.Libraries.Add(L);
			}



			#if UNITY_5
				string soomlaLinkerFlag = "-force_load Libraries/Plugins/iOS/libSoomlaGrowLite.a";
			#else
				string soomlaLinkerFlag = "-force_load Libraries/libSoomlaGrowLite.a";
			#endif



			if(!SA.IOSDeploy.Settings.Instance.linkFlags.Contains(soomlaLinkerFlag)) {
				SA.IOSDeploy.Settings.Instance.linkFlags.Add(soomlaLinkerFlag);
			}
		}


		Debug.Log("ISN Postprocess Done");

	
	}
	#endif
}
#endif
