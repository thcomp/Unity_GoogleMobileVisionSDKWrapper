using android.graphics;
using System.Collections.Generic;
using UnityEngine;

namespace com.google.android.gms.vision.face
{
    public class Landmark : BaseAndroidJavaObjectWrapper
    {
        public static readonly int BOTTOM_MOUTH = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("BOTTOM_MOUTH");
        public static readonly int LEFT_CHEEK = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("LEFT_CHEEK");
        public static readonly int LEFT_EAR = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("LEFT_EAR");
        public static readonly int LEFT_EAR_TIP = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("LEFT_EAR_TIP");
        public static readonly int LEFT_EYE = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("LEFT_EYE");
        public static readonly int LEFT_MOUTH = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("LEFT_MOUTH");
        public static readonly int NOSE_BASE = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("NOSE_BASE");
        public static readonly int RIGHT_CHEEK = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("RIGHT_CHEEK");
        public static readonly int RIGHT_EAR = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("RIGHT_EAR");
        public static readonly int RIGHT_EAR_TIP = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("RIGHT_EAR_TIP");
        public static readonly int RIGHT_EYE = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("RIGHT_EYE");
        public static readonly int RIGHT_MOUTH = new AndroidJavaClass("com.google.android.gms.vision.face.Landmark").GetStatic<int>("RIGHT_MOUTH");

        public Landmark(AndroidJavaObject androidJO) : base(androidJO)
        {
            // 処理なし
        }

        public PointF GetPosition()
        {
            return new PointF(mAndroidJO.Call<AndroidJavaObject>("getPosition"));
        }

        public int GetTypeForJava()
        {
            return mAndroidJO.Call<int>("getType");
        }
    }
}
