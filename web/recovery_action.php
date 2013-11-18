<?php
	chdir("common");
    require_once("init.php");

    $temp = str_replace(".", "!", $_POST['emailToRecover']);
    $toSend = 'localhost:49300/api/utilizadores/' . $temp;

    $password = getJsonResponse($toSend);

	if($password['status'] == 'error') {
		$_SESSION['s_error'] = "Email incorreto!";
	}

	else {
		$argMail = $password['status'];

		$to = $_POST['emailToRecover'];
		$subject = "Warehouse Catalog: Recuperacao de palavra-passe";
		$message = "Ola!\n\nEnviamos este email na sequencia do seu pedido para recuperacao da palavra-passe.\n\nA sua password e $argMail.\n\n Cumprimentos,\n A Equipa Warehouse Catalog.";
		$from = "noreply@warehouse-catalog.com";
		$headers = "From:" . $from;
		mail($to,$subject,$message,$headers);
		$_SESSION['s_ok'] = "Email enviado com sucesso!";
	}

	header('Location: login.php');
?>