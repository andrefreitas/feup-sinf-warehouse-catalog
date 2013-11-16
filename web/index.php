<?php
	if(isset($_SESSION['s_username']))
		header('Location: articles.php');

	else header('Location: login.php');
?>