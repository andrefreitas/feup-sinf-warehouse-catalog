<?php
function getJsonResponse($service_url, $decode = true){
	$curl = curl_init($service_url);
	curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
	$curl_response = curl_exec($curl);
	if ($curl_response === false) {
	    $info = curl_getinfo($curl);
	    curl_close($curl);
	    die('error occured during curl exec. Additioanl info: ' . var_export($info));
	}
	curl_close($curl);
	$return;
	if ($decode){
		$return = json_decode($curl_response, true);
		if (isset($return->response->status) && $return->response->status == 'ERROR') {
			die('error occured: ' . $return->response->errormessage);
		}
	}else{
		$return = $curl_response;
	}
	return $return;
}

function getJsonResponsePost($service_url, $args) {
	
	$fields_string = '';
	foreach($args as $key=>$value) { $fields_string .= $key.'='.$value.'&'; }
	rtrim($fields_string, '&');

	//open connection
	$ch = curl_init();

	//set the url, number of POST vars, POST data
	curl_setopt($ch,CURLOPT_URL, $service_url);
	curl_setopt($ch,CURLOPT_POST, count($args));
	curl_setopt($ch,CURLOPT_POSTFIELDS, $fields_string);

	//execute post
	$result = curl_exec($ch);

	//close connection
	curl_close($ch);

	$result2 = ob_get_contents();

	$resultArray = json_decode($result2, true);

	ob_end_clean();
	
	return $resultArray;
}
?>