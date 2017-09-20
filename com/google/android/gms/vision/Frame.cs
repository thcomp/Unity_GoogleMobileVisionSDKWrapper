using android.graphics;
using UnityEngine;

namespace com.google.android.gms.vision
{
    public class Frame : BaseAndroidJavaObjectWrapper
    {
        internal Frame(AndroidJavaObject builderJO)
        {
            mAndroidJO = builderJO.Call<AndroidJavaObject>("build");
        }

        public class Builder : BaseAndroidJavaObjectWrapper
        {
            public Builder()
            {
                mAndroidJO = new AndroidJavaObject("com.google.android.gms.vision.Frame$Builder");
            }

            public Frame Build()
            {
                return new Frame(mAndroidJO);
            }

            public Frame.Builder SetBitmap(Bitmap image)
            {
                Debug.Log("image.AndroidJO = " + image.AndroidJO);
                mAndroidJO = mAndroidJO.Call<AndroidJavaObject>("setBitmap", image.AndroidJO);
                return this;
            }
        }

        public class Metadata : BaseAndroidJavaObjectWrapper
        {
            public Metadata()
            {
                mAndroidJO = new AndroidJavaObject("com.google.android.gms.vision.Frame$Metadata");
            }

            public Metadata(AndroidJavaObject metadataJO)
            {
                mAndroidJO = metadataJO;
            }
        }
    }
}
