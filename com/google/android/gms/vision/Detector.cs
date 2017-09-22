using com.google.android.gms.vision.barcode;
using com.google.android.gms.vision.face;
using com.google.android.gms.vision.text;
using Eq.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.google.android.gms.vision
{
    public abstract class Detector<T> : BaseAndroidJavaObjectWrapper
    {
        abstract public List<T> Detect(Frame frame);

        public void SetProcessor(Processor<T> processor)
        {
            mAndroidJO.Call("setProcessor", processor.AndroidJO);
        }

        public Boolean IsOperational()
        {
            return mAndroidJO.Call<Boolean>("isOperational");
        }

        public void ReceiveFrame(Frame frame)
        {
            mAndroidJO.Call("receiveFrame", frame.AndroidJO);
        }

        public void Release()
        {
            mAndroidJO.Call("release");
        }

        public Boolean SetFocus(int id)
        {
            return mAndroidJO.Call<Boolean>("setFocus", id);
        }

        abstract public class Processor<T> : BaseAndroidJavaObjectWrapper
        {
            abstract public void ReceiveDetections(Detections<T> detections);

            abstract public void Release();
        }

        abstract public class Detections<T> : BaseAndroidJavaObjectWrapper
        {
            public Detections()
            {
                mAndroidJO = new AndroidJavaObject("com.google.android.gms.vision.Detector$Detections");
            }

            public Boolean DetectorIsOperational()
            {
                return mAndroidJO.Call<Boolean>("detectorIsOperational");
            }

            abstract public List<T> GetDetectedItems();

            public Frame.Metadata GetFrameMetadata()
            {
                AndroidJavaObject frameMetadataJO = mAndroidJO.Call<AndroidJavaObject>("getFrameMetadata");
                return new Frame.Metadata(frameMetadataJO);
            }
        }

        public class FaceDetections : Detections<Face>
        {
            public override List<Face> GetDetectedItems()
            {
                List<Face> ret = new List<Face>();
                AndroidJavaObject detectedItemSparseArray = mAndroidJO.Call<AndroidJavaObject>("getDetectedItems");
                SparseArrayUtil<Face>.ExchangeToList(
                    delegate (AndroidJavaObject detectedItem)
                    {
                        Face tempRet = new Face(detectedItem);
                        return tempRet;
                    },
                    detectedItemSparseArray);
                return ret;
            }
        }

        public class BarcodeDetections : Detections<Barcode>
        {
            public override List<Barcode> GetDetectedItems()
            {
                List<Barcode> ret = new List<Barcode>();
                AndroidJavaObject detectedItemSparseArray = mAndroidJO.Call<AndroidJavaObject>("getDetectedItems");
                SparseArrayUtil<Face>.ExchangeToList(
                    delegate (AndroidJavaObject detectedItem)
                    {
                        Face tempRet = new Face(detectedItem);
                        return tempRet;
                    },
                    detectedItemSparseArray);
                return ret;
            }
        }

        public class TextDetections : Detections<TextBlock>
        {
            public override List<TextBlock> GetDetectedItems()
            {
                List<TextBlock> ret = new List<TextBlock>();
                AndroidJavaObject detectedItemSparseArray = mAndroidJO.Call<AndroidJavaObject>("getDetectedItems");
                SparseArrayUtil<TextBlock>.ExchangeToList(
                    delegate (AndroidJavaObject detectedItem)
                    {
                        TextBlock tempRet = new TextBlock(detectedItem);
                        return tempRet;
                    },
                    detectedItemSparseArray);
                return ret;
            }
        }
    }
}
