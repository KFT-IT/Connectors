<?
// Prepare data to send to KFT service
$xml='<?xml version="1.0" encoding="UTF-8"?>
	  <moviles>
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
      </moviles>';

$client = null;

try {
		 
    // Creating histance of soapclient class. No network level authentication.
    $client = new SoapClient("http://connector.getposition.com:8099/WSMovilPosicionService.svc?wsdl", array('trace' => 1));
	
	// Login to the webservice
	$data = array('UserName' => 'KTEST', 'Password' => 'kv1btmkh');
    $wsResult = $client->Login($data);
	if (is_soap_fault($wsResult)) {
		 echo '<h2>Fault</h2><pre>';
		 print_r($wsResult);
		 echo '</pre>';
	} else {
		 echo '<h2>Login Result</h2><pre>';
		 print_r($wsResult);
		 echo '</pre>';
	}
	
	// get the actual answer from webservice
	$actualRes = $wsResult->LoginWithResponseResult; //->isSuccessful;
	$res = $actualRes->isSuccesful;
	echo '<h2>Actual result</h2><pre>';
	echo $res ;
	echo '</pre>';
  
	// Get cookie to keep session open
	echo '<h2>Cookies</h2><pre>';
	$bisc = $client->_cookies['ASP.NET_SessionId'];
	echo print_r($bisc);
	echo '</pre>';
	
	if($res == 1){
		// Incapsulate XML data in an object with the correct parameters
		$data = array('AllStories' => $xml);
		
		// Set cookie for the next request. This is very important to keep session open.
		$client->__setCookie('ASP.NET_SessionId', $bisc[0]);
		
		// Call insert data on server
		$wsResult = $client->InsertKFTStoryData($data);
		if (is_soap_fault($wsResult)) {
			 echo '<h2>Fault</h2><pre>';
			 print_r($wsResult);
			 echo '</pre>';
		} else {
			 echo '<h2>Insert data</h2><pre>';
			 print_r($wsResult);
			 echo '</pre>';
		}
	}
	else
		echo '<h2>Login Failed</h2>';
	
} catch (SoapFault $fault) {
	echo '<h2>ERROR</h2>';
	echo "REQUEST:\n" . print_r($client->__getLastRequest()) . "\n";
    echo '<pre> ' . date("Y-m-d H:i:s",time()).'|'.$fault->faultstring . '</pre>';
} catch (Exception $fault) {
   echo '<h2>ERROR</h2><pre> ' . date("Y-m-d H:i:s",time()).'|'.$fault->faultstring . '</pre>';
}

?>