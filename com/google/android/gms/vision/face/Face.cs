using android.graphics;
using System.Collections.Generic;
using UnityEngine;

namespace com.google.android.gms.vision.face
{
    public class Face : BaseAndroidJavaObjectWrapper
    {
        public static readonly float UNCOMPUTED_PROBABILITY = new AndroidJavaClass("com.google.android.gms.vision.face.Face").GetStatic<float>("UNCOMPUTED_PROBABILITY");

        public Face(AndroidJavaObject androidJO) : base(androidJO)
        {
            // 処理なし
        }

        public float GetEulerY()
        {
            return mAndroidJO.Call<float>("getEulerY");
        }

        public float GetEulerZ()
        {
            return mAndroidJO.Call<float>("getEulerZ");
        }

        public float GetHeight()
        {
            return mAndroidJO.Call<float>("getHeight");
        }

        public int GetId()
        {
            return mAndroidJO.Call<int>("getId");
        }

        public float GetIsLeftEyeOpenProbability()
        {
            return mAndroidJO.Call<float>("getIsLeftEyeOpenProbability");
        }

        public float GetIsRightEyeOpenProbability()
        {
            return mAndroidJO.Call<float>("getIsRightEyeOpenProbability");
        }

        public float GetIsSmilingProbability()
        {
            return mAndroidJO.Call<float>("getIsSmilingProbability");
        }

        public List<Landmark> GetLandmarks()
        {
            AndroidJavaObject landmarkListJO = mAndroidJO.Call<AndroidJavaObject>("getLandmarks");
            List<Landmark> ret = new List<Landmark>();

            if (landmarkListJO != null)
            {
                int size = landmarkListJO.Call<int>("size");

                for (int i = 0; i < size; i++)
                {
                    ret.Add(new Landmark(landmarkListJO.Call<AndroidJavaObject>("get")));
                }
            }

            return ret;
        }

        public PointF GetPosition()
        {
            return new PointF(mAndroidJO.Call<AndroidJavaObject>("getPosition"));
        }

        public float GetWidth()
        {
            return mAndroidJO.Call<float>("getWidth");
        }
    }
}
