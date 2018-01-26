using Connector_sample_OBJ.KFTDataInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connector_sample_OBJ
{
    class Program
    {
        static void Main(string[] args)
        {

            // Prepare data to send to KFT service
            TypeInfo[] data = new TypeInfo[] {
                new TypeInfo(){
                    ExtProviderName = "KTEST",
                    ExtSerialCode =  "KFT-KFT1",
                    Code =  "",
                    SrcDateTime = new DateTime(),
                    StoryInfo = 0,
                    ST_Status = 0,
                    NS_GpsQuality = 0,
                    Flags = 0,
                    Latitude = 45.21312,
                    Longitude = 9.31412,
                    Altitude = 42,
                    Speed = 57,
                    Direction = 124,
                    InputValid = 0,
                    InputValue = 0,
                    FunValid = 0,
                    FunValue = 0,
                    OutputValid = 0,
                    OutputValue = 0,
                    NumAnalogValid = 0,
                    AnalogValue0 = 0,
                    AnalogValue1 = 0,
                    AnalogValue2 = 0,
                    AnalogValue3 = 0,
                    Message = ""
                },
                new TypeInfo(){
                    ExtProviderName = "KTEST",
                    ExtSerialCode =  "KFT-KFT2",
                    Code =  "",
                    SrcDateTime = new DateTime(),
                    StoryInfo = 0,
                    ST_Status = 0,
                    NS_GpsQuality = 0,
                    Flags = 0,
                    Latitude = 44.6764,
                    Longitude = 9.15121,
                    Altitude = 42,
                    Speed = 57,
                    Direction = 124,
                    InputValid = 0,
                    InputValue = 0,
                    FunValid = 0,
                    FunValue = 0,
                    OutputValid = 0,
                    OutputValue = 0,
                    NumAnalogValid = 0,
                    AnalogValue0 = 0,
                    AnalogValue1 = 0,
                    AnalogValue2 = 0,
                    AnalogValue3 = 0,
                    Message = ""
                },
            };

            // Creating histance of soapclient class. No network level authentication.
            KFTDataInjector.KFTDataInjectorSoapClient soapClient = new KFTDataInjector.KFTDataInjectorSoapClient();

            // Login to the webservice
            if (soapClient.LoginWithResponse("KTEST", "kv1btmkh").isSuccesful)
            {
                // Setting cookies for the next request is done in the app.config file
                soapClient.InsertKFTStoryData(data);
                Console.WriteLine("Data inserted");
            }
            else
                Console.WriteLine("Login failed");

            Console.ReadLine();
        }
    }
}
