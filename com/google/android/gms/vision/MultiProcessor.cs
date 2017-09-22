using UnityEngine;

namespace com.google.android.gms.vision
{
    public class MultiProcessor<T> : Detector<T>.Processor<T>
    {
        private MultiProcessor(AndroidJavaObject builderJO)
        {
            mAndroidJO = builderJO.Call<AndroidJavaObject>("build");
        }

        public override void ReceiveDetections(Detector<T>.Detections<T> detections)
        {
            mAndroidJO.Call("ReceiveDetections", detections.AndroidJO);
        }

        public override void Release()
        {
            mAndroidJO.Call("release");
        }

        public class Builder<T> : BaseAndroidJavaObjectWrapper
        {
            public Builder(Factory factory)
            {
                mAndroidJO = new AndroidJavaObject("com.google.android.gms.vision.MultiProcessor$Builder", factory);
            }

            public MultiProcessor<T> Build()
            {
                return new MultiProcessor<T>(mAndroidJO);
            }

            public Builder<T> SetMaxGapFrames(int maxGapFrames)
            {
                mAndroidJO.Call("setMaxGapFrames", maxGapFrames);
                return this;
            }
        }

        abstract public class Factory : AndroidJavaProxy
        {
            public Factory() : base("com.google.android.gms.vision.MultiProcessor$Factory")
            {
                // 処理なし
            }

            abstract public Tracker create(AndroidJavaObject itemJO);
        }
    }
}
