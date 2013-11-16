<?php
	
	chdir("common");
	require_once("init.php");

	if(isset($_SESSION['s_username']))
		header('Location: articles.php');

	else {
	    $smarty->display("login.tpl");
	}
?>