using UnityEngine;
using System.Collections;
using Windows.Kinect;
using System;


public class BodyIndexSourceManager : MonoBehaviour {

    /// <summary>
    /// Collection of colors to be used to display the BodyIndexFrame data.
    /// </summary>
    private static readonly Color[] BodyColor =
        {
            Color.red,
            Color.green,
            Color.blue,
            Color.yellow,
            Color.white,
            Color.magenta,
        };
    /// <summary>
    /// Active Kinect sensor
    /// </summary>
    private KinectSensor kinectSensor = null;

    /// <summary>
    /// Reader for body index frames
    /// </summary>
    private BodyIndexFrameReader bodyIndexFrameReader = null;

    private int BodyFrameWidth;
    private Texture2D _Texture;
    private byte[] _Data;

    public Texture2D GetBodyIndexTexture()
    {
        return _Texture;
    }

	// Use this for initialization
	void Start () {
        initialization();
	}
	
	// Update is called once per frame
	void Update () {
        if (bodyIndexFrameReader != null)
        {
            var frame = bodyIndexFrameReader.AcquireLatestFrame();
            if (frame != null)
            {
                frame.CopyFrameDataToArray(_Data);
                setTextureByData();
                _Texture.Apply();
                /*
                _Texture.LoadRawTextureData(_Data);
                _Texture.Apply();
                */
                frame.Dispose();
                frame = null;
            }
        }
	}
    void setTextureByData()
    {
        for (int i = 0; i < _Data.Length; i++)
            {
                if (_Data[i] < BodyColor.Length)
                {
                    try
                    {
                        _Texture.SetPixel(i % BodyFrameWidth, i / BodyFrameWidth, BodyColor[_Data[i]]);
                    }
                    catch
                    {
                        break;
                    }
                }
                else
                {
                    _Texture.SetPixel(i % BodyFrameWidth, i / BodyFrameWidth, Color.clear);
                }
            }
    }

    //初始化
    void initialization()
    {
        kinectSensor = KinectSensor.GetDefault();

        if (kinectSensor != null)
        {
            bodyIndexFrameReader = kinectSensor.BodyIndexFrameSource.OpenReader();

            var frameDesc = kinectSensor.BodyIndexFrameSource.FrameDescription;
            BodyFrameWidth = frameDesc.Width;
            //Debug.Log("BodyFrameWidth = " + BodyFrameWidth + " BodyFrameHeigh = " + BodyFrameHeigh);
            //Debug.Log("frameDesc.BytesPerPixel = " + frameDesc.BytesPerPixel + " frameDesc.LengthInPixels = " + frameDesc.LengthInPixels);
            _Texture = new Texture2D(frameDesc.Width, frameDesc.Height, TextureFormat.RGBA32, false);
            _Data = new byte[frameDesc.BytesPerPixel * frameDesc.LengthInPixels];
            //Debug.Log("_Texture w = " + _Texture.width + " _Texture h = " + _Texture.height);
            if (!kinectSensor.IsOpen)
            {
                kinectSensor.Open();
            }
        }
    }
}
