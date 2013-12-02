<?php
	chdir("common");
    require_once("init.php");

    $url = 'http://localhost/Primavera/api/utilizadores';
	$fields = array(
		'email' => $_POST['email'],
		'password' => $_POST['password']
	);

	$response = getJsonResponsePost($url, $fields);
	if($response['status'] != 'error') {
		$_SESSION['s_username'] = $response['status'];
		header('Location: articles.php');
	}

	else {
		$_SESSION['s_error'] = "Dados incorretos!";
		header('Location: login.php');
	}
?>