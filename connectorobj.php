<?

// This is the object to send our position data to main webservice
// Fields with /***/ are mandatory

class TypeInfo{
	var $ExtProviderName;  /***/
    var $ExtSerialCode;    /***/
    var $Code;
    var $SrcDateTime;      /***/
    var $StoryInfo;
    var $ST_Status;
    var $NS_GpsQuality;
    var $Flags;
    var $Latitude;         /***/
    var $Longitude;        /***/
    var $Altitude;
    var $Speed;
    var $Direction;
    var $InputValid;
    var $InputValue;
    var $FunValid;
    var $FunValue;
    var $OutputValid;
    var $OutputValue;
    var $NumAnalogValid;
    var $AnalogValue0;
    var $AnalogValue1;
    var $AnalogValue2;
    var $AnalogValue3;
    var $Message;
	
	function __construct(){

		$this->ExtProviderName = '';
		$this->ExtSerialCode = '';	
		$this->Code = '';	
		$this->SrcDateTime = '2000-01-01T00:00:00.000';	
		$this->StoryInfo = 0;	
		$this->ST_Status = 0;	
		$this->NS_GpsQuality = 0;	
		$this->Flags = 0;	
		$this->Latitude = 0;	
		$this->Longitude = 0;	
		$this->Altitude = 0;	
		$this->Speed = 0;	
		$this->Direction = 0;	
		$this->InputValid = 0;	
		$this->InputValue = 0;	
		$this->FunValid = 0;	
		$this->FunValue = 0;	
		$this->OutputValid = 0;	
		$this->OutputValue = 0;	
		$this->NumAnalogValid = 0;	
		$this->AnalogValue0 = 0;	
		$this->AnalogValue1 = 0;	
		$this->AnalogValue2 = 0;	
		$this->AnalogValue3 = 0;	
		$this->Message = '';
	}
}

// Prepare data to send to KFT service
$xml=array();

$newitem = new TypeInfo();
$newitem->ExtProviderName = 'KTEST';
$newitem->ExtSerialCode = 'KFT-KFT1';
$newitem->SrcDateTime = '2018-01-26T10:11:44.0';
$newitem->Latitude = 45.1234;
$newitem->Longitude = 9.4321;
$newitem->Speed = 32;
$newitem->Altitude = 240;
$newitem->Direction = 24;
array_push($xml, $newitem);


$newitem2 = new TypeInfo();
$newitem2->ExtProviderName = 'KTEST';
$newitem2->ExtSerialCode = 'KFT-KFT2';
$newitem2->SrcDateTime = '2018-01-26T10:11:44.0';
$newitem2->Latitude = 45.4321;
$newitem2->Longitude = 9.1234;
$newitem2->Speed = 32;
$newitem2->Altitude = 240;
$newitem2->Direction = 24;
array_push($xml, $newitem2);


$client = null;

try {
		 
    // Creating histance of soapclient class. No network level authentication.
    $client = new SoapClient("http://connector.getposition.com:8099/KFTDataInjector.asmx?wsdl", array('trace' => 1));
	
	// Login to the webservice
	$data = array('UserName' => 'KTEST', 'Password' => 'kv1btmkh');
    $wsResult = $client->LoginWithResponse($data);
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