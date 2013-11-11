<?php /* Smarty version Smarty-3.1.15, created on 2013-10-21 23:47:09
         compiled from "..\templates\login.tpl" */ ?>
<?php /*%%SmartyHeaderCode:31905265a0dd135266-55136887%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '3a3ad0481f8ec021d13686506707f433d8151a12' => 
    array (
      0 => '..\\templates\\login.tpl',
      1 => 1382205664,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '31905265a0dd135266-55136887',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5265a0dd1b7709_89717431',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5265a0dd1b7709_89717431')) {function content_5265a0dd1b7709_89717431($_smarty_tpl) {?><!DOCTYPE HTML>
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
</html><?php }} ?>
