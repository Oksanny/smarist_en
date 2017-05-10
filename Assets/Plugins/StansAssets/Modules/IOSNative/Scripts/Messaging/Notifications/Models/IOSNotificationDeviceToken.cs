////////////////////////////////////////////////////////////////////////////////
//  
// @module IOS Native Plugin
// @author Osipov Stanislav (Stan's Assets) 
// @support support@stansassets.com
// @website https://stansassets.com
//
////////////////////////////////////////////////////////////////////////////////



using UnityEngine;
using System.Collections;

public class IOSNotificationDeviceToken  {

	private string _tokenString;
	private byte[] _tokenBytes;


	//--------------------------------------
	// INITIALIZE
	//--------------------------------------

	public IOSNotificationDeviceToken(byte[] token)  {
		_tokenBytes = token;

		_tokenString =  System.BitConverter.ToString(token).Replace("-", "").ToLower();
	}



	//--------------------------------------
	//  GET/SET
	//--------------------------------------

	public string tokenString {
		get {
			return _tokenString;
		}
	}


	public byte[] tokenBytes {
		get {
			return _tokenBytes;
		}
	}

}
