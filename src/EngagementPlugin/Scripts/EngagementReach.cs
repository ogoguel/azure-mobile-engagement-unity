/*
 * Copyright (c) Microsoft Corporation.  All rights reserved.
 * Licensed under the MIT license. See License.txt in the project root for license information.
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;

#pragma warning disable 162

namespace Microsoft.Azure.Engagement.Unity
{
	
	public class EngagementReach : MonoBehaviour
	{

		/// <summary>
		/// Event when receiving a string datapush.
		///
		/// The callback must of the form :
		/// DataPushStringReceived(<b>string category</b>, <b>string body</b>) {}
		/// </summary>
		/// 
		public  static Action<string,string> 			StringDataPushReceived ;
		/// <summary>
		/// Event when receiving a base64 datapush.
		///
		/// The callback must of the form :
		/// DataPushStringReceived(<b>string category</b>, <b>byte[] decodedBody</b>, <b>string encodedBody</b>) {}
		/// </summary>
		/// 
		public  static Action<string,byte[],string>		Base64DataPushReceived ;

		/// <summary>
		/// Event when receiving an openUrl event
		///
		/// The callback must of the form :
		/// HandleURL(<b>string url</b>) {}
		/// </summary>
		/// 
		public  static Action<string> 					HandleURL ;

		private EngagementReach()
		{

		}

		public static void Initialize( )
		{
			EngagementAgent.Logging ("Initializing Reach");

			if (EngagementConfiguration.ENABLE_REACH == false)
			{
				Debug.LogError ("Reach must be enabled in configuration first");
				return;
			}

			if (EngagementAgent.hasBeenInitialized == false) 
			{
				Debug.LogError ("Agent must be initialized before initializing Reach");
				return ;
			}
#if UNITY_WSA && !UNITY_EDITOR
#else
			EngagementWrapper.initializeReach();
#endif
        }

        // Delegates from Native

        public static void onDataPushString(string _category,string _body)
        {
            EngagementAgent.Logging("onDataPushString, category:" + _category);
            if (StringDataPushReceived != null)
                StringDataPushReceived(_category, _body);
            else
                EngagementAgent.Logging("WARNING: unitialized StringDataPushReceived");
        }

        public static void onDataPushBase64(string _category, byte [] _data, string _body)
        {
            EngagementAgent.Logging("onDataPushBase64, category:" + _category);
            if (Base64DataPushReceived != null)
                Base64DataPushReceived(_category, _data, _body);
            else
                EngagementAgent.Logging("WARNING: unitialized Base64DataPushReceived");
        }


        public static void onDataPushMessage(string _serialized)
		{
			Dictionary<string, object> dict = (Dictionary<string, object>)MiniJSON.Json.Deserialize(_serialized);
			string category = null;
			string body = null;
			bool isBase64 = (bool)dict ["isBase64"];
			if (dict["category"] != null)
				category = WWW.UnEscapeURL (dict["category"].ToString(),System.Text.Encoding.UTF8);

			EngagementAgent.Logging ("DataPushReceived, category: " + category+", isBase64:"+isBase64);

			if (isBase64 == false) {
                body = WWW.UnEscapeURL(dict["body"].ToString(), System.Text.Encoding.UTF8);
                onDataPushString(category,body);
            
			} else {
                    body = dict ["body"].ToString ();
                    byte[] data = Convert.FromBase64String(body);
                    onDataPushBase64(category, data,body);
			}	
		}

		public static  void onHandleURLMessage(string _url)
		{
			EngagementAgent.Logging ("OnHandleURL: " + _url);
			if (HandleURL != null)
				HandleURL (_url);
			else
				EngagementAgent.Logging ("WARNING: unitialized HandleURL");
		}
	}
	
}

#pragma warning restore 162
