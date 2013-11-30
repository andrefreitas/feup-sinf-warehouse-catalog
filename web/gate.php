<?php
chdir("common");
require_once("init.php");
//if(isset($_SESSION['s_username'])) {
	if (!isset($_REQUEST['action']))
		$_REQUEST['action'] = "";

	switch ($_REQUEST['action']){
		case "getProductDescription":{
			if (isset($_REQUEST['productId'])){
				$response = getJsonResponse("localhost:49300/api/artigos/".str_replace('.', '!', $_REQUEST['productId']));
				$response2 = getJsonResponse("localhost:49300/api/QuantidadeArtigoArmazens/".str_replace('.', '!', $_REQUEST['productId']));			
				$response = array('status'=>'ok', 
					'articleDescription'=>$response,
					'articleWarehouses'=>$response2);
				echo json_encode($response);
			}else{
				echo json_encode(array('status'=>'error', 'reason'=>'Bad Product ID!'));
			}
			break;
		}
		case "getWarehouseDescription": {
			if (isset($_REQUEST['warehouseId'])){
				$response = getJsonResponse("localhost:49300/api/armazens/".str_replace('.', '!', $_REQUEST['warehouseId']));			
				$response = array('status'=>'ok', 
					'warehouseDescription'=>$response);
				echo json_encode($response);
			}else{
				echo json_encode(array('status'=>'error', 'reason'=>'Bad Warehouse ID!'));
			}
			break;
		}
		default:
		echo json_encode(array('status'=>'error', 'reason'=>'No Action Set!'));
		break;
	}
//}else{
//	echo json_encode(array('status'=>'error', 'reason'=>'Not Logged In!'));
//}
?>