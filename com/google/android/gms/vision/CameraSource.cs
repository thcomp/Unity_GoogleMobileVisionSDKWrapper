using com.google.android.gms.vision.barcode;
using com.google.android.gms.vision.face;
using com.google.android.gms.vision.text;
using UnityEngine;

namespace com.google.android.gms.vision
{
    public class CameraSource : BaseAndroidJavaObjectWrapper
    {
        private CameraSource(AndroidJavaObject builderJO)
        {
            AndroidJavaObject activityJO = AndroidHelper.GetUnityActivity();
            mAndroidJO = builderJO.Call<AndroidJavaObject>("build");
        }

        public void Start()
        {
            mAndroidJO = mAndroidJO.Call<AndroidJavaObject>("start");
        }

        public void Stop()
        {
            mAndroidJO.Call("stop");
        }

        public void Release()
        {
            mAndroidJO.Call("release");
        }

        public class Builder : BaseAndroidJavaObjectWrapper
        {
            public Builder(Detector<Face> detector)
            {
                Initialize(detector.AndroidJO);
            }

            public Builder(Detector<Barcode> detector)
            {
                Initialize(detector.AndroidJO);
            }

            public Builder(Detector<TextBlock> detector)
            {
                Initialize(detector.AndroidJO);
            }

            private void Initialize(AndroidJavaObject detectorJO)
            {
                AndroidJavaObject activityJO = AndroidHelper.GetUnityActivity();
                mAndroidJO = new AndroidJavaObject("com.google.android.gms.vision.CameraSource$Builder", activityJO, detectorJO);
            }

            public CameraSource Build()
            {
                return new CameraSource(mAndroidJO);
            }
        }
    }
}
