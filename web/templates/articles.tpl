<!DOCTYPE HTML>
<html>
  <head>
    <title>Warehouse Catalog</title>
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
        <img src="images/logo.svg" id="logo" height="100"/>
        <span id="logoutButton"><span id="textUsername">{$username_session} </span> <a href="logout.php"> <img src="images/logout.svg" height="25px" /></a></span>
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
            <option {if $selected eq 'none'}selected{/if} value="none">Qualquer um</option>
            {foreach from=$warehouses item=warehouse}
              <option {if $selected eq $warehouse.CodArmazem}selected{/if} value="{$warehouse.CodArmazem}">{$warehouse.Descricao}</option>
            {/foreach}
          </select>
        </div>
      </div>
      <!-- Articles -->
      <div id="articles">
        {foreach $articles as $article}
          <div class="box article">
            <div class="name">{$article.DescArtigo|truncate:25}</div>
            <div class="pvp">{$article.Preco|truncate:25} €</div>
            <div class="stock"><b>Stock</b> {$article.StkAtual}</div>
            <div class="warehouse"><img src="images/icons/warehouse.svg" width="40px">{$article.DescArmazem|truncate:15}</div>
          </div>
        {/foreach}
      </div>
    </div>

  </body>
</html>