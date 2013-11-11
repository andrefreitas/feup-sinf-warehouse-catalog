<?php /* Smarty version Smarty-3.1.15, created on 2013-11-11 11:31:10
         compiled from "..\templates\articles.tpl" */ ?>
<?php /*%%SmartyHeaderCode:158945264f48bac7b69-33844750%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '1e8fabe4c372af95d757ea8f4ade2a7d0c3ae980' => 
    array (
      0 => '..\\templates\\articles.tpl',
      1 => 1384165858,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '158945264f48bac7b69-33844750',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5264f48bb4ca58_30010217',
  'variables' => 
  array (
    'selected' => 0,
    'warehouses' => 0,
    'warehouse' => 0,
    'articles' => 0,
    'article' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5264f48bb4ca58_30010217')) {function content_5264f48bb4ca58_30010217($_smarty_tpl) {?><?php if (!is_callable('smarty_modifier_truncate')) include 'C:\\git\\sinf-warehouse-catalog\\web\\lib\\smarty\\plugins\\modifier.truncate.php';
?><!DOCTYPE HTML>
<html>
  <head>
    <title>Warehouse Catalogs</title>
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/styles.css"/>
    <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <link rel="shortcut icon" type="image/x-icon" href="images/favicon.ico" />
    <link rel="apple-touch-icon" href="images/icons/ipad-icon.png"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta charset="utf-8">
  </head>
  <body>
    <!-- Top bar -->
    <div id="top-bar">
      <div class="container">
        <img src="images/logo.svg" id="logo" height="100">
      </div>
    </div>
    <!-- Content -->
    <div class="container">
      <!-- Filter -->
      <div class="box" id="filter">
        <div class="icon">
          <img src="images/icons/settings.svg" width="33" height="33">
        </div>
        <div id="parameters">
          Armazém:
          <select onchange="location = 'articles.php?warehouse='+this.options[this.selectedIndex].value;">
            <option <?php if ($_smarty_tpl->tpl_vars['selected']->value=='none') {?>selected<?php }?> value="none">Qualquer um</option>
            <?php  $_smarty_tpl->tpl_vars['warehouse'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['warehouse']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['warehouses']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['warehouse']->key => $_smarty_tpl->tpl_vars['warehouse']->value) {
$_smarty_tpl->tpl_vars['warehouse']->_loop = true;
?>
              <option <?php if ($_smarty_tpl->tpl_vars['selected']->value==$_smarty_tpl->tpl_vars['warehouse']->value['CodArmazem']) {?>selected<?php }?> value="<?php echo $_smarty_tpl->tpl_vars['warehouse']->value['CodArmazem'];?>
"><?php echo $_smarty_tpl->tpl_vars['warehouse']->value['Descricao'];?>
</option>
            <?php } ?>
          </select>
        </div>
      </div>
      <!-- Articles -->
      <div id="articles">
        <?php  $_smarty_tpl->tpl_vars['article'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['article']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['articles']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['article']->key => $_smarty_tpl->tpl_vars['article']->value) {
$_smarty_tpl->tpl_vars['article']->_loop = true;
?>
          <div class="box article">
            <div class="name"><?php echo smarty_modifier_truncate($_smarty_tpl->tpl_vars['article']->value['DescArtigo'],25);?>
</div>
            <div class="pvp"><?php echo smarty_modifier_truncate($_smarty_tpl->tpl_vars['article']->value['Preco'],25);?>
 €</div>
            <div class="stock"><b>Stock</b> <?php echo $_smarty_tpl->tpl_vars['article']->value['StkAtual'];?>
</div>
            <div class="warehouse"><img src="images/icons/warehouse.svg" width="40px"><?php echo smarty_modifier_truncate($_smarty_tpl->tpl_vars['article']->value['DescArmazem'],15);?>
</div>
          </div>
        <?php } ?>
      </div>
    </div>

  </body>
</html><?php }} ?>
