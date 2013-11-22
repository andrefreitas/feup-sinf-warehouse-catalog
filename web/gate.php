<?php
	chdir("common");
    require_once("init.php");

if (!isset($_REQUEST['action']))
	$_REQUEST['action'] = "";

switch ($_REQUEST['action']){
	case "getProductDescription":{
		if (isset($_REQUEST['productId'])){
			$response = getJsonResponse("localhost:49300/api/artigos/".str_replace('.', '!', $_REQUEST['productId']));
			$response = array('status'=>'ok', 'articleDescription'=>$response);
			echo json_encode($response);
		}else{
			echo json_encode(array('status'=>'error', 'reason'=>'Bad Product ID!'));
		}
		break;
	}
	default:
		echo json_encode(array('status'=>'error', 'reason'=>'No Action Set!'));
		break;
}
?>