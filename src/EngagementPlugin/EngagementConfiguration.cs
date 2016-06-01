
/*
 * Copyright (c) Microsoft Corporation.  All rights reserved.
 * Licensed under the MIT license. See License.txt in the project root for license information.
 */

namespace Microsoft.Azure.Engagement.Unity 
{

  /// <summary>
  /// Engagement configuration.
  /// </summary>
  /// <remarks>
  /// Every time this class is being modified, the File/Engagement/Generate Android Manifest must be executed.
  /// </remarks>
  public static class EngagementConfiguration
	{
    /// <summary>
    /// (Required) Your iOS Engagement application connection string.
    /// </summary>
    public const string IOS_CONNECTION_STRING = null;

    /// <summary>
    /// (Required) Your Android Engagement application connection string.
    /// </summary>
    public const string ANDROID_CONNECTION_STRING = null;

    /// <summary>
    /// (Required) Your Windows Engagement application connection string.
    /// </summary>
    public const string WINDOWS_CONNECTION_STRING = null; 

    /// <summary>
    /// Enable\Disable console logs on native SDKs.
    /// </summary>
    public const bool 	ENABLE_NATIVE_LOG = true;

    /// <summary>
    /// Enable\Disable console logs on the Unity plugin.
    /// </summary>
    public const bool 	ENABLE_PLUGIN_LOG = true;

    /// <summary>
    /// Enable\Disable the use of the IDFA to compute the device id. 
    /// </summary>
    /// <remarks>
    /// If you are enabling the IDFA in the SDK but you are not using advertising elsewhere in the application, 
    /// you might be rejected by the App Store review process. In this case you should keep this configuration to false.
    /// </remarks>
    public const bool 	IOS_DISABLE_IDFA = false;

    /// <summary>
    /// If you customized the Unity3D Android activity then provide your customized activity here.
    /// </summary>
    public const string ANDROID_UNITY3D_ACTIVITY = null;

    /// <summary>
    /// Define the location reporting type thanks to <see cref="LocationReportingType"/> enumeration.
    /// </summary>
    public const LocationReportingType LOCATION_REPORTING_TYPE = LocationReportingType.NONE;

    /// <summary>
    /// Define the location reporting mode thanks to <see cref="LocationReportingMode"/> enumeration.
    /// </summary>
    public const LocationReportingMode LOCATION_REPORTING_MODE = LocationReportingMode.NONE;

    /// <summary>
    /// (Required if location enabled for iOS) Starting with iOS 8, you must provide a description for how your application uses location services.
    /// </summary>
    public const string LOCATION_REPORTING_DESCRIPTION = null ;

    /// <summary>
    /// Enable\Disable the Reach feature of the SDK.
    /// </summary>
    public const bool ENABLE_REACH = true;

    /// <summary>
    /// Define a URL scheme used by action urls from Reach campaigns.
    /// </summary>
    public const string ACTION_URL_SCHEME = null;

    /// <summary>
    /// An icon file's path relative to the Assets/ directory if you want to use another one than the default iOS application icon.
    /// </summary>
    public const string IOS_REACH_ICON = null;

    /// <summary>
    /// An icon file's path relative to the Assets/ directory if you want to use another one than the default Android application icon.
    /// </summary>
    public const string ANDROID_REACH_ICON = null;

    /// <summary>
    /// (Required if Reach feature is enabled) Your Android Google project number to enable native push in the application.
    /// </summary>
    public const string ANDROID_GOOGLE_PROJECT_NUMBER = null;	
	}
}


