using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connector_sample_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prepare data to send to KFT service
            String xml =
             "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + 
	         @" <moviles>
		        <movil>
			        <pgps>KTEST</pgps>
			        <trns>NO</trns>
			        <pat>KFT-KFT1</pat>
			        <codm>KFT-KFT1</codm>
			        <fh>12/01/2018 22:11:33</fh>
			        <lat>45.1234</lat>
			        <lon>9.4321</lon>
			        <dirm>23</dirm>
			        <vel>43</vel>
			        <motor>1</motor>
			        <log>0</log>
			        <sensor1>0</sensor1>
			        <opc1>0</opc1>
			        <opc2></opc2>
			        <temp>999</temp>
                </movil>
                <movil>
			        <pgps>KTEST</pgps>
			        <trns>NO</trns>
			        <pat>KFT-KFT2</pat>
			        <codm>KFT-KFT2</codm>
			        <fh>12/01/2018 22:11:44</fh>
			        <lat>45.4321</lat>
			        <lon>9.1234</lon>
			        <dirm>23</dirm>
			        <vel>43</vel>
			        <motor>1</motor>
			        <log>0</log>
			        <sensor1>0</sensor1>
			        <opc1>0</opc1>
			        <opc2></opc2>
			        <temp>999</temp>
                </movil>
              </moviles>";

            // Creating histance of soapclient class. No network level authentication.
            KFTMovilPosicion.WSMovilPosicionServiceClient soapClient = 
                new KFTMovilPosicion.WSMovilPosicionServiceClient("BasicHttpBinding_IWSMovilPosicionService", "http://connector.getposition.com:8099/WSMovilPosicionService.svc");
            

            // Login to the webservice
            if (soapClient.Login("KTEST", "kv1btmkh"))
            {
                // Setting cookies for the next request is done in the app.config file
                soapClient.InsertDataXML(xml);
                Console.WriteLine("Data inserted");
            }
            else
                Console.WriteLine("Login failed");

            Console.ReadLine();


        }
    }
}
