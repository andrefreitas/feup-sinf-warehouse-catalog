<?php
	chdir("common");
	require_once("init.php");

	if(isset($_SESSION['s_username'])) {
		unset($_SESSION['s_username']);
	}

	header('Location: login.php');
?>