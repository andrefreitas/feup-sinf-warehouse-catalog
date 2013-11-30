<!DOCTYPE HTML>
<html>
  <head>
    <title>Warehouse Catalog</title>
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/styles.css"/>
    <script src="http://code.jquery.com/jquery-1.10.1.min.js"></script>
    <script src="lib/bootstrap/js/bootstrap.min.js"></script>
    <script src="js/bPopup.js"></script>
    <script src="js/scripts.js"></script>
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
        <span id="logoutButton"><a href="logout.php"> <img src="images/icons/logout-menu.png" id="logo"/></span>
        <img src="images/icons/home.png" id="logo"/>
        <img src="images/icons/produtos-menu.png" id="logo"/>
        <img src="images/icons/warehouse-menu.png" id="logo"/>
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
          <div class="box article" id="{$article.CodArtigo}">
            <div class="name">{$article.DescArtigo|truncate:25}</div>
            <div class="pvp">{$article.Preco|truncate:25} €</div>
            <div class="stock"><b>Stock</b> {$article.StkAtual}</div>
            <div class="warehouse"><img src="images/icons/warehouse.svg" width="40px">{$article.DescArmazem|truncate:15}</div>
          </div>
        {/foreach}
      </div>
    </div>

    <!-- Article Popup -->
    <div id="articlePopup">
      <div class="head">
        <div class="article"><span id="articleName"></span></div>
        <div class="price"> <span id="articlePrice"></span> &euro;</div>
        <div class="stock">
          <img src="images/icons/box.svg" width="30px">
          <div class="text"><b>Stock</b><br/><span id="articleStock"></span></div>
        </div>
        <!--<div class="warehouse">
          <img src="images/icons/warehouse.svg" width="40px">
          <div class="text"><b>Armazém</b><br/>Gaia</div>
        </div>-->
      </div>
      <div class="content">
        <div class="description">
          <img id="articleImage" src="" />
          <h1>Descrição</h1>
          <span id="articleDescription"></span>
        </div>
        <div class="info">
          <span><b>Código:</b> <span id="articleCode"></span></span> 
          <!--<span><b>Unidade:</b> 2 flores</span>-->
          <span><b>IVA:</b> <span id="articleIVA"></span>%</span>
        </div>
        <div class="warehouses" id='articleWarehouses'>
        </div>
        <div class="closePopup"> <img src="images/icons/close.svg" />Fechar </div>
      </div>
    </div>

  </body>
</html>