<!DOCTYPE HTML>
<html>
	<head>
		<title>Login</title>
		<link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.min.css"/>
		<link rel="stylesheet" type="text/css" href="css/styles.css"/>
		<script src="lib/bootstrap/js/bootstrap.min.js"></script>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
	</head>
	<body>

		<div id="login-box">
			<div id="login-header">
				<img src="images/logo.fw.png" />
			</div>
			<form role="form">
			  <div class="form-group">
			    <label for="exampleInputEmail1">Email</label>
			    <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Escreva o email">
			  </div>
			  <div class="form-group">
			    <label for="exampleInputPassword1">Password</label>
			    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
			  </div>
			 
			  <button type="submit" class="btn btn-primary" id="login">Login</button>
			  <button class="btn btn-danger" id="recover">Recuperar Password</button>
			</form>
		</div>

	</body>
</html>