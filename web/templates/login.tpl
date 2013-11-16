<!DOCTYPE HTML>
<html>
	<head>
		<title>Warehouse Catalog</title>
		<link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.min.css"/>
		<link rel="stylesheet" type="text/css" href="css/styles.css"/>
		<script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
		<script src="js/jquery-ui.js"></script>
		<script src="lib/bootstrap/js/bootstrap.min.js"></script>
		<script src="js/scripts.js"></script>
		<script src="js/bPopup.js"></script>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
	</head>
	<body>

		<div id="login-box">
			<div id="login-header">
				<img src="images/logo.fw.png" />
			</div>
			<form id="loginForm" role="form" method="post" action="login_action.php">
			  <div class="form-group">
			    <label for="exampleInputEmail1">Email</label>
			    <input name="email" type="email" class="form-control" id="exampleInputEmail1" placeholder="Escreva o email">
			  </div>
			  <div class="form-group">
			    <label for="exampleInputPassword1">Password</label>
			    <input name="password" type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
			  </div>
			 
			  <button type="submit" class="btn btn-primary" id="login">Login</button>
			  <button type="button" class="btn btn-danger" id="recover">Recuperar Password</button>
			</form>
		</div>
		<div id="recoveryPopup">
			<form id="recoveryForm" method="post" action="recovery_action.php">
		       	<input type="email" name="emailToRecover" placeholder="Introduzir e-mail..."/> <br />
		        <input type="submit" value="Recuperar"/>
		    </form>
		</div>

	</body>
</html>